using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace finalProject
{
    public partial class FormGame : Form
    {
        int size, r, g, b, doubleCheck, timeNow, timeRnd = 0, getBall = 0, racketSpeed = 7;
        Vector2 pos, speed, racketPos, racketSize, brickPos;
        bool check = false,  gameOver = false,gameStart = false;
        bool leftDown = false, rightDown = false, leftDown2 = false, rightDown2 = false;
        double distance;
        Random random = new Random();
        string mode;
        static int finalScore = 0, ballSpeed = 6;
        static Brick racket,racket2;

        static List<Brick>racketsList = new List<Brick>();

        static List<Ball> ballList = new List<Ball>();

        static List<Brick> brickList = new List<Brick>();

        public FormGame()
        {
            InitializeComponent();
            this.KeyPreview = true; 
            this.DoubleBuffered = true;
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            //labelDebug.Text = timeRnd.ToString();

            timeNow++;
            if(mode == "hard")
            {
                if (timeNow % 5 == 0)
                {
                    ballSpeed++;
                    racketSpeed++;
                }
            }          
            if(timeRnd == 0)
            {
                foreach(Brick brick in brickList)
                {
                    brick.pos.y += 20;
                    brick.center.y += 20;


                }
                buildBricks(9,3);
                
                
            }
            timeRnd = random.Next(0, 3);
            for (int i = 0; i < brickList.Count; i++)
            {
                if (brickList[i].pos.y > 300)
                {
                    gameOver = true;
                    groupBoxUpload.Visible = true;
                    labelMyScore.Text = labelScore.Text.Remove(0, 3);
                    break;
                }
            }
            if (finalScore > 0 && finalScore % 5 == 0)
                getBall++;
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            List<Record> records = new List<Record>();
            int i,scoreNow = Int32.Parse(labelScore.Text.Remove(0, 3));


            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string data1 = getData("https://bouncingball-a3510.firebaseio.com/scoreHistory/" + mode + ".json");
            List<Record> downloadData = javaScriptSerializer.Deserialize<List<Record>>(data1);

            foreach (Record record in downloadData)
            {  
                records.Add(new Record(record.date, record.name.ToString(), record.score));
            }

            for (i = 0; i < records.Count; i++)
            {
                 if (scoreNow >= records[i].score)
                {
                    break;
                }
            }
            records.Insert(i, new Record(DateTime.Now.ToShortDateString(), textBoxName.Text, scoreNow));
            //records.RemoveAt(records.Count - 1);

            JavaScriptSerializer stringToJson = new JavaScriptSerializer();
            //string data2 = stringToJson.Serialize(records);
            string data2 = stringToJson.Serialize(records);
            
            if (putData("https://bouncingball-a3510.firebaseio.com/scoreHistory/" + mode + ".json", data2).Contains("OK"))
            {
                MessageBox.Show("OK");
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (groupBoxMode.Visible ==false)
            {
                if (e.KeyCode == Keys.A)
                {
                    //racket.pos.x -= 15;
                    leftDown = true;
                    racket.speed.set(-5, 5);
                }
                else if (e.KeyCode == Keys.D)
                {
                    //racket.pos.x += 15;
                    rightDown = true;
                    racket.speed.set(5, 5);
                }
                else if (e.KeyCode == Keys.Space)
                {

                    if (mode == "hard" && !gameStart)
                    {
                        timer2.Interval = 1000;
                        timer2.Enabled = true;
                    }
                    gameStart = true;
                } else if (e.KeyCode == Keys.W|| e.KeyCode == Keys.Up)
                {
                    int index = e.KeyCode == Keys.W ? 0 : 1;
                    if (getBall > 0)
                    {
                        doubleCheck = 0;
                        pos = racketsList[index].pos.add(new Vector2(racket.size.x / 2, -size));
                        speed = new Vector2(random.Next(-5, 5), random.Next(-5, -1)).setLength(ballSpeed);
                        //speed = new Vector2(random.Next(-5, 5), random.Next(-5, -1)).setLength(6);

                        r = random.Next(0, 255);
                        g = random.Next(0, 255);
                        b = random.Next(0, 255);
                        Color color = Color.FromArgb(r, g, b);

                        //balls[i] = new Ball(pictureBoxGame, size, pos, speed, color);


                        ballList.Add(new Ball(pictureBoxGame, size, pos, speed, color));
                        //Thread tid1 = new Thread(new ThreadStart(balls[i].update));
                        //tid1.Start();
                        getBall--;
                    }
                }

                if (mode != "easy")
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        leftDown2 = true;
                        racket2.speed.set(-5, 3);
                    }
                    else if (e.KeyCode == Keys.Right)
                    {
                        rightDown2 = true;
                        racket2.speed.set(5, 3);
                    }
                }
            }
               
        }

        private void FormGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (groupBoxMode.Visible == false)
            {
                if (e.KeyCode == Keys.A)
                {
                    leftDown = false;
                }
                else if (e.KeyCode == Keys.D)
                {
                    rightDown = false;
                }

                if (mode != "easy")
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        leftDown2 = false;
                    }
                    else if (e.KeyCode == Keys.Right)
                    {
                        rightDown2 = false;
                    }
                    racket2.speed.set(0, 0);
                }
                racket.speed.set(0, 0);
            }
            
        }

        private void frmBouncingBall_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void pictureBoxGame_Paint(object sender, PaintEventArgs e)
        {
            
            foreach (Brick brick in brickList)
            {
               // if (brick.isVisible)
               // {
                    SolidBrush brickBrush = new SolidBrush(brick.color);
                    e.Graphics.FillRectangle(brickBrush, (float)brick.pos.x, (float)brick.pos.y, (float)brick.size.x, (float)brick.size.y);
                    e.Graphics.DrawRectangle(Pens.Black, (float)brick.pos.x, (float)brick.pos.y, (float)brick.size.x, (float)brick.size.y);
              //  }
            }

            SolidBrush racketBrush = new SolidBrush(racket.color);
            e.Graphics.FillRectangle(racketBrush, (float)racket.pos.x, (float)racket.pos.y, (float)racket.size.x, (float)racket.size.y);
            e.Graphics.DrawRectangle(Pens.Black, (float)racket.pos.x, (float)racket.pos.y, (float)racket.size.x, (float)racket.size.y);

            if (mode != "easy")
            {
                SolidBrush racket2Brush = new SolidBrush(racket2.color);
                e.Graphics.FillRectangle(racket2Brush, (float)racket2.pos.x, (float)racket2.pos.y, (float)racket2.size.x, (float)racket2.size.y);
                e.Graphics.DrawRectangle(Pens.Black, (float)racket2.pos.x, (float)racket2.pos.y, (float)racket2.size.x, (float)racket2.size.y);

            }

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
            if (!gameOver && gameStart)
            {
                for (int i = 0; i < ballList.Count; i++)
                {
                    ballList[i].update();

                    if (ballList[i].pos.y > pictureBoxGame.ClientSize.Height)
                        ballList.RemoveAt(i);
                }
                if (ballList.Count == 0)
                {
                    gameOver = true;
                    label2.Text = "Game Over!";
                    groupBoxUpload.Visible = true;
                    labelMyScore.Text = labelScore.Text.Remove(0,3);
                }

                if (mode != "hard")
                {
                    if(brickList.Count == 0)
                    {
                        gameOver = true;
                        label2.Text = "You Win!";
                        groupBoxUpload.Visible = true;
                        labelMyScore.Text = labelScore.Text.Remove(0, 3);
                    }
                }

                if (leftDown)
                {
                    if (racket.pos.x > 1)
                    {   
                        racket.pos.x -= racketSpeed;
                        racket.center.x -= racketSpeed;
                        if (mode != "easy" && racketsList[0].collisionRacket(racketsList[1])  )
                        {
                            racket.pos.x = racketsList[1].pos.x - racket.size.x;
                            racket.center.x = racketsList[1].center.x - racket.size.x;
                        }
                    }           
                }
                if (rightDown)
                {
                    if (racket.pos.x + racket.size.x + 5 < pictureBoxGame.ClientSize.Width)
                    {
                        racket.pos.x += racketSpeed;
                        racket.center.x += racketSpeed;
                        if (mode != "easy" && racketsList[0].collisionRacket(racketsList[1])  )
                        {
                            racket.pos.x = racketsList[1].pos.x - racket.size.x;
                            racket.center.x = racketsList[1].center.x - racket.size.x;
                        }
                    }          
                }
                
                if (leftDown2)
                {
                    if (racket2.pos.x > 1)
                    {
                        racket2.pos.x -= racketSpeed;
                        racket2.center.x -= racketSpeed;
                        if (mode != "easy" && racketsList[1].collisionRacket(racketsList[0]))
                        {
                            racket2.pos.x = racketsList[0].pos.x+racket.size.x;
                            racket2.center.x = racketsList[0].center.x + racket.size.x;
                        }
                    }
                }
                if (rightDown2)
                {
                    if (racket2.pos.x + racket2.size.x + 5 < pictureBoxGame.ClientSize.Width)
                    {
                        racket2.pos.x += racketSpeed;
                        racket2.center.x += racketSpeed;
                        if (mode != "easy" && racketsList[1].collisionRacket(racketsList[0]))
                        {
                            racket2.pos.x = racketsList[0].pos.x - racket.size.x;
                            racket2.center.x = racketsList[0].center.x - racket.size.x;
                        }
                    }
                }
                   
                //racket.update();
                this.Invalidate();
                pictureBoxGame.Refresh();
                labelScore.Text = labelScore.Text.Substring(0, 3) + finalScore;
                labeLlife.Text = labeLlife.Text.Substring(0, 3) + ballList.Count;
                labelBall.Text = labelBall.Text.Substring(0, 4) + (ballList.Count + getBall);
                labelReward.Text = labelReward.Text.Substring(0, 5) +  getBall;
                //labelDebug.Text = getBall.ToString();
            }
        }

        private void modeSelection(object sender, EventArgs e)
        {
            if (!gameStart)
            {
                Button modeNow = (Button)sender;
                if (modeNow.Text == "簡單")
                    mode = "easy";
                else if (modeNow.Text == "普通")
                    mode = "normal";
                else if (modeNow.Text == "困難")
                    mode = "hard";

                groupBoxGame.Visible = true;
                groupBoxMode.Visible = false;
                labelBall.Visible = true;
                labeLlife.Visible = true;
                labelScore.Visible = true;
                labelReward.Visible = true;

                gameInit();
            }           
        }

        private void gameInit()
        {
            ballList.Clear();
            racketsList.Clear();
            brickList.Clear();
            finalScore = 0;
            timeNow = 0;
            ballSpeed = 6;
            racketSpeed = 7;
            labelBall.Text = labelBall.Text.Substring(0, 4);
            labeLlife.Text = labeLlife.Text.Substring(0, 3);
            labelScore.Text = labelScore.Text.Substring(0, 3);
            int ballLength = 1;
            if (!gameStart)
            {
                Color racketcolor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                racketPos = new Vector2(pictureBoxGame.ClientSize.Width / 2 - 50, pictureBoxGame.ClientSize.Height * 0.9);
                racketSize = new Vector2(100, 10);
                racket = new Brick(pictureBoxGame, racketSize, racketPos, racketcolor);
                racketsList.Add(racket);
                //labelDebug.Text = racketPos.x.ToString();

                if (mode == "easy")
                {
                    buildBricks(18,0);
                    ballLength = 1;

                }
                else
                {
                    buildBricks(18,0);
                    ballLength = 2;
                    racket.pos.x = pictureBoxGame.ClientSize.Width * 0.25 - 50;
                    racketcolor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                    racketPos = new Vector2(pictureBoxGame.ClientSize.Width * 0.75 - 50, pictureBoxGame.ClientSize.Height * 0.9);
                    racketSize = new Vector2(100, 10);
                    racket2 = new Brick(pictureBoxGame, racketSize, racketPos, racketcolor);
                    racketsList.Add(racket2);
                }

                for (int i = 0; i < ballLength; i++)
                {
                    size = 20;
                    check = false;
                    while (!check)
                    {
                        doubleCheck = 0;
                        pos = racketsList[i].pos.add(new Vector2(racket.size.x/2,-size));
                        //pos = new Vector2(racketsList[i].pos.x, 10);
                        foreach (var ball in ballList)
                        {
                            if (ball != null)
                            {
                                distance = pos.addScalar(size / 2).distanceTo(ball.center);
                                if (distance > (size + ball.size) / 2)
                                    doubleCheck++;
                            }
                        }
                        if (doubleCheck == i)
                            check = true;

                    }
                    speed = new Vector2(random.Next(-5, 5), random.Next(-5, -1)).setLength(ballSpeed);
                    //speed = new Vector2(random.Next(-5, 5), random.Next(-5, -1)).setLength(6);

                    r = random.Next(0, 255);
                    g = random.Next(0, 255);
                    b = random.Next(0, 255);
                    Color color = Color.FromArgb(r, g, b);

                    //balls[i] = new Ball(pictureBoxGame, size, pos, speed, color);


                    ballList.Add(new Ball(pictureBoxGame, size, pos, speed, color));
                    //Thread tid1 = new Thread(new ThreadStart(balls[i].update));
                    //tid1.Start();

                }
                labelBall.Text += ballList.Count.ToString();
                labeLlife.Text += ballList.Count.ToString();

                timer1.Interval = 10;
                timer1.Enabled = true;
            }   
        }

        private void buildBricks(int length,int c)
        {
            brickPos = new Vector2(3, 0);
            r = random.Next(0, 255);
            g = random.Next(0, 255);
            b = random.Next(0, 255);
            Color color = Color.FromArgb(r, g, b);

            for (int i = 0; i < length; i++)
            {
                int tmp = random.Next(0, c);
                if (c == 0)
                {
                    brickList.Add(new Brick(pictureBoxGame, new Vector2(70, 20), brickPos, color));
                    brickPos = brickPos.add(new Vector2(70, 0));
                    if ((i + 1) % 9 == 0)
                    {
                        brickPos = brickPos.add(new Vector2(-brickPos.x + 3, 20));
                    }
                }
                else if (tmp == 0)
                {
                    brickList.Add(new Brick(pictureBoxGame, new Vector2(70, 20), brickPos, color));
                    brickPos = brickPos.add(new Vector2(70, 0));
                    if ((i + 1) % 9 == 0) brickPos = brickPos.add(new Vector2(-brickPos.x + 3, 20));
                }
                else
                {
                    brickPos = brickPos.add(new Vector2(70, 0));
                    if ((i + 1) % 9 == 0)
                    {
                        brickPos = brickPos.add(new Vector2(-brickPos.x + 3, 20));
                    }

                }  
            }
        }

        private string getData(string URL)
        {
            // Create a request for the URL.   
            string data = "";
            WebRequest request = WebRequest.Create(URL);
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            //textBoxResponce.Text = ((HttpWebResponse)response).StatusDescription + "\r\n";

            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                data += responseFromServer;
            }
            // Close the response.  
            response.Close();
            return data;
        }

        private string putData(string URL,string data)
        {
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(URL);
            //通訊協定
            request.Method = "PUT";

            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            // Set the ContentType property of the WebRequest.  
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;

            // Get the request stream.  
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.  
            dataStream.Close();
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            response.Close();
            return ((HttpWebResponse)response).StatusDescription;
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
                collisionRacket(racketsList);
                collisionBrick(brickList);
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
                            this.speed = this.speed.setLength(ballSpeed);
                            ball.speed = ball.speed.setLength(ballSpeed);
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

            public void collisionRacket(List<Brick> rackets)
            {
                for(int i =0; i< rackets.Count; i++)
                {
                    if (this.center.x > rackets[i].pos.x && this.center.x < rackets[i].pos.x + rackets[i].size.x && this.pos.y + this.size > rackets[i].pos.y)
                    {
                        if (this.center.y < rackets[i].pos.y)
                        {
                            this.speed = this.speed.add(rackets[i].speed);
                            this.speed = this.speed.setLength(ballSpeed);
                            this.speed.y *= -1;
                        }

                    }
                }
                
            }

            public void collisionBrick(List<Brick> bricks)
            {
                for(int i = 0; i < brickList.Count; i++)
                {
                    if (checkHit(brickList[i]))
                    {
                        finalScore += ballList.Count;
                        brickList.RemoveAt(i);
                        break;
                    }
                        
                    /*if (checkHit(brickList[i]))
                    {
                        if (this.center.x > brickList[i].pos.x && this.center.x < brickList[i].pos.x + brickList[i].size.x)
                        {
                                this.speed.y *= -1;
                        }
                        else if(this.center.y < brickList[i].pos.y+ brickList[i].size.y&& this.center.y > brickList[i].pos.y)
                        {
                            this.speed.x *= -1;
                        }
                        finalScore += ballList.Count;
                        //hitBall++;
                        
                        brickList.RemoveAt(i);
                        break;
                    }*/
                }
               /* foreach (Brick brick in bricks)
                {
                    if (brick.isVisible)
                    {
                        if (checkHit(brick))
                        {
                            finalScore += ballList.Count;
                            //hitBall++;
                            this.speed.y *= -1;
                            brick.isVisible = false;
                        }
                    }
                }*/
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
                        if(maxPos.x * maxPos.x + maxPos.y * maxPos.y <= this.size / 2 * this.size / 2)
                            this.speed.y *= -1;
                        return (maxPos.x * maxPos.x + maxPos.y * maxPos.y <= this.size / 2 * this.size / 2);
                    }
                    else if (localPos.y > 0)
                    {
                        if(maxPos.x * maxPos.x + localPos.y * localPos.y <= this.size / 2 * this.size / 2)
                            this.speed.y *= -1;
                        return (maxPos.x * maxPos.x + localPos.y * localPos.y <= this.size / 2 * this.size / 2);
                    }
                    else
                    {
                        if(Math.Abs(maxPos.x) <= this.size / 2)
                            this.speed.x *= -1;
                        return (Math.Abs(maxPos.x) <= this.size / 2);
                    }
                }
                else if (localPos.x > 0)
                {
                    if (localPos.y > 0)
                    {
                        if(localPos.x * localPos.x + localPos.y * localPos.y <= this.size / 2 * this.size / 2)
                            this.speed.y *= -1;
                        return (localPos.x * localPos.x + localPos.y * localPos.y <= this.size / 2 * this.size / 2);
                    }
                    else if (maxPos.y < 0)
                    {
                        if(localPos.x * localPos.x + maxPos.y * maxPos.y <= this.size / 2 * this.size / 2)
                            this.speed.y *= -1;
                        return (localPos.x * localPos.x + maxPos.y * maxPos.y <= this.size / 2 * this.size / 2);
                    }
                    else
                    {
                        if(Math.Abs(localPos.x) <= this.size / 2)
                            this.speed.x *= -1;
                        return (Math.Abs(localPos.x) <= this.size / 2);
                    }
                }
                else
                {
                    if(localPos.y<0&& Math.Abs(localPos.y) <= this.size * 1.5)
                    {
                        this.speed.y *= -1;
                        return (Math.Abs(localPos.y) <= this.size * 1.5);
                    } else if (localPos.y > 0 && Math.Abs(localPos.y) <= this.size * 0.5)
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
            public Vector2 pos, speed, center, size,prevPos;
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
                double distance = Math.Abs(this.pos.x-racket.pos.x);
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


            /*public void update()
            {
                if (ballList[0].pos.x + ballList[0].size / 2 + this.size.x / 2 < this.form.ClientSize.Width && ballList[0].pos.x - this.size.x / 2 + ballList[0].size / 2 >= 0)
                {
                    this.pos.x = ballList[0].pos.x - this.size.x / 2 + ballList[0].size / 2;
                }
            }*/
        }
    }

    public struct Vector2
    {
        public double x, y;

        public Vector2(double x = 0, double y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public void set(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2 add(Vector2 vector)
        {
            return new Vector2(this.x + vector.x, this.y + vector.y);
        }

        public Vector2 addScalar(double scalar)
        {
            return new Vector2(this.x + scalar, this.y + scalar);
        }

        public Vector2 sub(Vector2 vector)
        {
            return new Vector2(this.x - vector.x, this.y - vector.y);
        }

        public Vector2 subScalar(double scalar)
        {
            return new Vector2(this.x - scalar, this.y - scalar);
        }

        public Vector2 multiplyScalar(double scalar)
        {
            return new Vector2(this.x * scalar, this.y * scalar);
        }

        public Vector2 divideScalar(double scalar)
        {
            return new Vector2(this.x / scalar, this.y / scalar);
        }

        public Vector2 setLength(double n)
        {
            double length = Math.Sqrt(this.x * this.x + this.y * this.y);
            return new Vector2(this.x / length * n, this.y / length * n);
        }

        public double length()
        {

            return Math.Sqrt(this.x * this.x + this.y * this.y);
        }

        public double distanceTo(Vector2 vector)
        {

            return this.sub(vector).length();
        }

        public double dot(Vector2 vector)
        {
            return this.x * vector.x + this.y * vector.y;
        }

        public Vector2 normalize()
        {
            double length = Math.Sqrt(this.x * this.x + this.y * this.y);

            return new Vector2(this.x / length, this.y / length);
        }
    }

    public class Record
    {
        public string date, name;
        public int score;
        public Record()
        {
            this.date = "";
            this.name = "";
            this.score = 0;
        }
        public Record(string date,string name, int score )
        {
            this.date = date;
            this.name = name;
            this.score = score;
        }
    }
}
