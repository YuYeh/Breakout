namespace finalProject
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonLeaderboard = new System.Windows.Forms.Button();
            this.buttonRule = new System.Windows.Forms.Button();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.groupBoxGame = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxGame = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(259, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "來打磚塊啊";
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Transparent;
            this.buttonStart.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonStart.Location = new System.Drawing.Point(343, 280);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(172, 38);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "開始";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonLeaderboard
            // 
            this.buttonLeaderboard.BackColor = System.Drawing.Color.Transparent;
            this.buttonLeaderboard.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonLeaderboard.Location = new System.Drawing.Point(343, 329);
            this.buttonLeaderboard.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLeaderboard.Name = "buttonLeaderboard";
            this.buttonLeaderboard.Size = new System.Drawing.Size(172, 38);
            this.buttonLeaderboard.TabIndex = 2;
            this.buttonLeaderboard.Text = "排行榜";
            this.buttonLeaderboard.UseVisualStyleBackColor = false;
            this.buttonLeaderboard.Click += new System.EventHandler(this.buttonLeaderboard_Click);
            // 
            // buttonRule
            // 
            this.buttonRule.BackColor = System.Drawing.Color.Transparent;
            this.buttonRule.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonRule.Location = new System.Drawing.Point(343, 374);
            this.buttonRule.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRule.Name = "buttonRule";
            this.buttonRule.Size = new System.Drawing.Size(172, 38);
            this.buttonRule.TabIndex = 3;
            this.buttonRule.Text = "遊戲說明";
            this.buttonRule.UseVisualStyleBackColor = false;
            this.buttonRule.Click += new System.EventHandler(this.buttonRule_Click);
            // 
            // buttonEnd
            // 
            this.buttonEnd.BackColor = System.Drawing.Color.Transparent;
            this.buttonEnd.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonEnd.Location = new System.Drawing.Point(343, 419);
            this.buttonEnd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(172, 38);
            this.buttonEnd.TabIndex = 4;
            this.buttonEnd.Text = "結束";
            this.buttonEnd.UseVisualStyleBackColor = false;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // groupBoxGame
            // 
            this.groupBoxGame.Controls.Add(this.label2);
            this.groupBoxGame.Controls.Add(this.pictureBoxGame);
            this.groupBoxGame.Location = new System.Drawing.Point(12, 12);
            this.groupBoxGame.Name = "groupBoxGame";
            this.groupBoxGame.Size = new System.Drawing.Size(850, 529);
            this.groupBoxGame.TabIndex = 5;
            this.groupBoxGame.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(262, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Copyright © 2019/06/20 by YuYeh Tsai";
            // 
            // pictureBoxGame
            // 
            this.pictureBoxGame.Location = new System.Drawing.Point(1, 11);
            this.pictureBoxGame.Name = "pictureBoxGame";
            this.pictureBoxGame.Size = new System.Drawing.Size(847, 486);
            this.pictureBoxGame.TabIndex = 1;
            this.pictureBoxGame.TabStop = false;
            this.pictureBoxGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGame_Paint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.buttonEnd);
            this.Controls.Add(this.buttonRule);
            this.Controls.Add(this.buttonLeaderboard);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxGame);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打打磚塊";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxGame.ResumeLayout(false);
            this.groupBoxGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonLeaderboard;
        private System.Windows.Forms.Button buttonRule;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.GroupBox groupBoxGame;
        private System.Windows.Forms.PictureBox pictureBoxGame;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
    }
}

