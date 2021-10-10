using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalProject
{
    public partial class Form1 : Form
    {
        int size, r, g,b;
        Vector2 pos, speed, racketPos, racketSize, brickPos;

        Random random = new Random();
        static Brick racket;

        static List<Ball> ballList = new List<Ball>();

        static List<Brick> brickList = new List<Brick>();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonRule_Click(object sender, EventArgs e)
        {
            FormRule formRule = new FormRule();
            Hide();
            formRule.FormClosing += formClosing;
            formRule.Show();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            FormGame game = new FormGame();
            this.Hide();
            game.FormClosing += formClosing;
            game.Show();
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void pictureBoxGame_Paint(object sender, PaintEventArgs e)
        {

            foreach (Brick brick in brickList)
            {
                SolidBrush brickBrush = new SolidBrush(brick.color);
                e.Graphics.FillRectangle(brickBrush, (float)brick.pos.x, (float)brick.pos.y, (float)brick.size.x, (float)brick.size.y);
                e.Graphics.DrawRectangle(Pens.Black, (float)brick.pos.x, (float)brick.pos.y, (float)brick.size.x, (float)brick.size.y);
            }

            SolidBrush racketBrush = new SolidBrush(racket.color);
            e.Graphics.FillRectangle(racketBrush, (float)racket.pos.x, (float)racket.pos.y, (float)racket.size.x, (float)racket.size.y);
            e.Graphics.DrawRectangle(Pens.Black, (float)racket.pos.x, (float)racket.pos.y, (float)racket.size.x, (float)racket.size.y);

            // this.DoubleBuffered = true;
            foreach (Ball ball in ballList)
            {

                SolidBrush brush = new SolidBrush(ball.color);
                e.Graphics.FillEllipse(brush, (float)ball.pos.x, (float)ball.pos.y, (float)ball.size, (float)ball.size);
                e.Graphics.DrawEllipse(Pens.Black, (float)ball.pos.x, (float)ball.pos.y, (float)ball.size, (float)ball.size);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < ballList.Count; i++)
            {
                ballList[i].update();
     
            }
            if (brickList.Count == 0)
            {
                gameInit();
            }
            racket.update();
            this.Invalidate();
            pictureBoxGame.Refresh();
        }

        private void buttonLeaderboard_Click(object sender, EventArgs e)
        {
            FormLeaderboard leaderboard = new FormLeaderboard();
            Hide();
            leaderboard.FormClosing += formClosing;
            leaderboard.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBoxGame;
            gameInit();
        }
        private void gameInit()
        {
            ballList.Clear();
            brickList.Clear();

            Color racketcolor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            racketPos = new Vector2(pictureBoxGame.ClientSize.Width / 2 - 50, pictureBoxGame.ClientSize.Height * 0.9);
            racketSize = new Vector2(100, 10);
            racket = new Brick(pictureBoxGame, racketSize, racketPos, racketcolor);

            buildBricks(54);
            size = 20;
            pos = racket.pos.add(new Vector2(racket.size.x / 2, -size));
            speed = new Vector2(random.Next(-5, 5), random.Next(-5, -1)).setLength(6);
            while (speed.x==0)
                speed = new Vector2(random.Next(-5, 5), random.Next(-5, -1)).setLength(6);

            r = random.Next(0, 255);
            g = random.Next(0, 255);
            b = random.Next(0, 255);
            Color color = Color.FromArgb(r, g, b);

            ballList.Add(new Ball(pictureBoxGame, size, pos, speed, color));
            //Thread tid1 = new Thread(new ThreadStart(balls[i].update));
            //tid1.Start();

            timer1.Interval = 10;
            timer1.Enabled = true;
        }

        private void buildBricks(int length)
        {
            brickPos = new Vector2(3, 0);
            r = random.Next(0, 255);
            g = random.Next(0, 255);
            b = random.Next(0, 255);
            Color color = Color.FromArgb(r, g, b);

            for (int i = 0; i < length; i++)
            {
                brickList.Add(new Brick(pictureBoxGame, new Vector2(70, 20), brickPos, color));
                brickPos = brickPos.add(new Vector2(70, 0));
                if ((i + 1) % 9 == 0)
                {
                    brickPos = brickPos.add(new Vector2(-brickPos.x + 3, 20));
                }
            }
        }     

        public class Ball
        {
            public Vector2 prevPos, pos, speed, center, force;
            public double size;
            public double r, g, b;
            Control form;
            public Color color;
            public bool threadStop;
            public bool threadPause;
            public int hitBall = 0;

            public Ball(Control form, double size, Vector2 pos, Vector2 speed, Color color)
            {
                this.size = size;
                this.pos = pos;
                this.center = pos.addScalar(size / 2);
                this.speed = speed;
                this.force = new Vector2(0, 0);
                this.color = color;
                this.form = form;
            }

            public void update()
            {
                /* threadStop = false;
                 threadPause = false;

                 while (!threadStop)
                 {
                     if (!threadPause)
                     {*/
                this.prevPos = this.pos;
                this.speed = this.speed.add(this.force.multiplyScalar(1));
                this.pos = this.pos.add(this.speed.multiplyScalar(1));
                this.center = this.pos.addScalar(this.size / 2);


                //if (this.pos.y < 0 || this.pos.y + this.size > form.ClientSize.Height)
                if (this.pos.y < 0)
                {
                    this.speed.y *= -1;

                }
                if (this.pos.x < 0 || this.pos.x + this.size > form.ClientSize.Width)
                {
                    this.speed.x *= -1;

                }

                collisionBall(ballList);
                collisionBrick(brickList);
                collisionRacket(racket);
                // Thread.Sleep(10);
                // }
                //}
            }

            public void collisionBall(List<Ball> balls)
            {
                foreach (Ball ball in balls)
                {
                    if (ball != null)
                    {
                        double distance = this.center.distanceTo(ball.center);
                        if (distance < (this.size + ball.size) / 2 && distance != 0)
                        {
                            //this.speed = this.speed.multiplyScalar(-1);

                            Vector2 n = this.center.sub(ball.center).normalize();
                            Vector2 v = this.speed.sub(ball.speed);

                            this.speed = this.speed.sub(n.multiplyScalar(v.dot(n)));
                            ball.speed = ball.speed.add(n.multiplyScalar(v.dot(n)));
                            this.speed = this.speed.setLength(6);
                            ball.speed = ball.speed.setLength(6);
                            Vector2 vv = ball.center.sub(this.center);
                            double overlap = (this.size + ball.size) / 2 - vv.length();
                            vv = vv.normalize();
                            this.pos = this.prevPos;

                            this.pos = this.pos.add(vv.multiplyScalar(-overlap / 2));
                            ball.pos = ball.pos.add(vv.multiplyScalar(overlap / 2));
                        }
                    }

                }
            }

            public void collisionRacket(Brick rackets)
            {
                if (this.center.x > racket.pos.x && this.center.x < racket.pos.x + racket.size.x && this.pos.y + this.size > racket.pos.y)
                {
                    if (this.center.y < racket.pos.y)
                    {
                        this.speed = this.speed.add(racket.speed);
                        this.speed = this.speed.setLength(6);
                        this.speed.y *= -1;
                    }

                }
            }

            public void collisionBrick(List<Brick> bricks)
            {
                for (int i = 0; i < brickList.Count; i++)
                {
                    if (checkHit(brickList[i]))
                    {
                        brickList.RemoveAt(i);
                        break;
                    }
                }
            }

            public bool checkHit(Brick brick)
            {
                Vector2 localPos = brick.center.sub(this.center).sub(brick.size.divideScalar(2));
                //Vector2 localPos = brick.pos.sub(this.pos);
                Vector2 maxPos = localPos.add(brick.size);
                if (maxPos.x < 0)
                {
                    if (maxPos.y < 0)
                    {
                        if (maxPos.x * maxPos.x + maxPos.y * maxPos.y <= this.size / 2 * this.size / 2)
                            this.speed.y *= -1;
                        return (maxPos.x * maxPos.x + maxPos.y * maxPos.y <= this.size / 2 * this.size / 2);
                    }
                    else if (localPos.y > 0)
                    {
                        if (maxPos.x * maxPos.x + localPos.y * localPos.y <= this.size / 2 * this.size / 2)
                            this.speed.y *= -1;
                        return (maxPos.x * maxPos.x + localPos.y * localPos.y <= this.size / 2 * this.size / 2);
                    }
                    else
                    {
                        if (Math.Abs(maxPos.x) <= this.size / 2)
                            this.speed.x *= -1;
                        return (Math.Abs(maxPos.x) <= this.size / 2);
                    }
                }
                else if (localPos.x > 0)
                {
                    if (localPos.y > 0)
                    {
                        if (localPos.x * localPos.x + localPos.y * localPos.y <= this.size / 2 * this.size / 2)
                            this.speed.y *= -1;
                        return (localPos.x * localPos.x + localPos.y * localPos.y <= this.size / 2 * this.size / 2);
                    }
                    else if (maxPos.y < 0)
                    {
                        if (localPos.x * localPos.x + maxPos.y * maxPos.y <= this.size / 2 * this.size / 2)
                            this.speed.y *= -1;
                        return (localPos.x * localPos.x + maxPos.y * maxPos.y <= this.size / 2 * this.size / 2);
                    }
                    else
                    {
                        if (Math.Abs(localPos.x) <= this.size / 2)
                            this.speed.x *= -1;
                        return (Math.Abs(localPos.x) <= this.size / 2);
                    }
                }
                else
                {
                    if (localPos.y < 0 && Math.Abs(localPos.y) <= this.size * 1.5)
                    {
                        this.speed.y *= -1;
                        return (Math.Abs(localPos.y) <= this.size * 1.5);
                    }
                    else if (localPos.y > 0 && Math.Abs(localPos.y) <= this.size * 0.5)
                    {
                        this.speed.y *= -1;
                        return (Math.Abs(localPos.y) <= this.size * 0.5);
                    }
                    return false;
                }
            }

        }

        public class Brick
        {
            public Vector2 pos, speed, center, size, prevPos;
            public double r, g, b;
            Control form;
            public Color color;
            public bool threadStop, threadPause;

            public Brick(Control form, Vector2 size, Vector2 pos, Color color)
            {
                this.size = size;
                this.pos = pos;
                this.center = pos.add(size.divideScalar(2));
                this.speed = new Vector2();
                this.color = color;
                this.form = form;
            }

            public bool collisionRacket(Brick racket)
            {
                double distance = Math.Abs(this.pos.x - racket.pos.x);
                if (distance < this.size.x)
                    return true;
                else
                    return false;
            }
            public void setX(int x)
            {
                this.pos.x += x;
                this.center.x += x;
            }


            public void update()
            {
                if (ballList[0].pos.x + ballList[0].size / 2 + this.size.x / 2 < this.form.ClientSize.Width && ballList[0].pos.x - this.size.x / 2 + ballList[0].size / 2 >= 0)
                {
                    this.pos.x = ballList[0].pos.x - this.size.x / 2 + ballList[0].size / 2;
                }
            }
        }
    }

}
