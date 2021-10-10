namespace finalProject
{
    partial class FormGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.buttonDifficulty = new System.Windows.Forms.Button();
            this.buttonNormal = new System.Windows.Forms.Button();
            this.buttonEasy = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxGame = new System.Windows.Forms.PictureBox();
            this.groupBoxGame = new System.Windows.Forms.GroupBox();
            this.groupBoxUpload = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMyScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labeLlife = new System.Windows.Forms.Label();
            this.labelBall = new System.Windows.Forms.Label();
            this.labelDebug = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.labelReward = new System.Windows.Forms.Label();
            this.groupBoxMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).BeginInit();
            this.groupBoxGame.SuspendLayout();
            this.groupBoxUpload.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.Controls.Add(this.buttonDifficulty);
            this.groupBoxMode.Controls.Add(this.buttonNormal);
            this.groupBoxMode.Controls.Add(this.buttonEasy);
            this.groupBoxMode.Location = new System.Drawing.Point(350, 200);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(200, 201);
            this.groupBoxMode.TabIndex = 0;
            this.groupBoxMode.TabStop = false;
            // 
            // buttonDifficulty
            // 
            this.buttonDifficulty.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonDifficulty.Location = new System.Drawing.Point(14, 138);
            this.buttonDifficulty.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDifficulty.Name = "buttonDifficulty";
            this.buttonDifficulty.Size = new System.Drawing.Size(172, 38);
            this.buttonDifficulty.TabIndex = 4;
            this.buttonDifficulty.Text = "困難";
            this.buttonDifficulty.UseVisualStyleBackColor = true;
            this.buttonDifficulty.Click += new System.EventHandler(this.modeSelection);
            // 
            // buttonNormal
            // 
            this.buttonNormal.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonNormal.Location = new System.Drawing.Point(14, 81);
            this.buttonNormal.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNormal.Name = "buttonNormal";
            this.buttonNormal.Size = new System.Drawing.Size(172, 38);
            this.buttonNormal.TabIndex = 3;
            this.buttonNormal.Text = "普通";
            this.buttonNormal.UseVisualStyleBackColor = true;
            this.buttonNormal.Click += new System.EventHandler(this.modeSelection);
            // 
            // buttonEasy
            // 
            this.buttonEasy.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonEasy.Location = new System.Drawing.Point(14, 25);
            this.buttonEasy.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEasy.Name = "buttonEasy";
            this.buttonEasy.Size = new System.Drawing.Size(172, 38);
            this.buttonEasy.TabIndex = 2;
            this.buttonEasy.Text = "簡單";
            this.buttonEasy.UseVisualStyleBackColor = true;
            this.buttonEasy.Click += new System.EventHandler(this.modeSelection);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            // groupBoxGame
            // 
            this.groupBoxGame.Controls.Add(this.groupBoxUpload);
            this.groupBoxGame.Controls.Add(this.pictureBoxGame);
            this.groupBoxGame.Location = new System.Drawing.Point(12, 25);
            this.groupBoxGame.Name = "groupBoxGame";
            this.groupBoxGame.Size = new System.Drawing.Size(850, 500);
            this.groupBoxGame.TabIndex = 2;
            this.groupBoxGame.TabStop = false;
            this.groupBoxGame.Visible = false;
            // 
            // groupBoxUpload
            // 
            this.groupBoxUpload.BackColor = System.Drawing.Color.White;
            this.groupBoxUpload.Controls.Add(this.label2);
            this.groupBoxUpload.Controls.Add(this.buttonCancel);
            this.groupBoxUpload.Controls.Add(this.buttonUpload);
            this.groupBoxUpload.Controls.Add(this.textBoxName);
            this.groupBoxUpload.Controls.Add(this.label3);
            this.groupBoxUpload.Controls.Add(this.labelMyScore);
            this.groupBoxUpload.Controls.Add(this.label1);
            this.groupBoxUpload.Location = new System.Drawing.Point(203, 116);
            this.groupBoxUpload.Name = "groupBoxUpload";
            this.groupBoxUpload.Size = new System.Drawing.Size(394, 302);
            this.groupBoxUpload.TabIndex = 2;
            this.groupBoxUpload.TabStop = false;
            this.groupBoxUpload.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(71, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 42);
            this.label2.TabIndex = 7;
            this.label2.Text = "Game Over !";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonCancel.Location = new System.Drawing.Point(239, 232);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 35);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonUpload
            // 
            this.buttonUpload.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonUpload.Location = new System.Drawing.Point(68, 233);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(80, 35);
            this.buttonUpload.TabIndex = 4;
            this.buttonUpload.Text = "上傳";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(95, 148);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(203, 25);
            this.textBoxName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(16, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "輸入暱稱:";
            // 
            // labelMyScore
            // 
            this.labelMyScore.AutoSize = true;
            this.labelMyScore.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelMyScore.ForeColor = System.Drawing.Color.Red;
            this.labelMyScore.Location = new System.Drawing.Point(188, 74);
            this.labelMyScore.Name = "labelMyScore";
            this.labelMyScore.Size = new System.Drawing.Size(63, 35);
            this.labelMyScore.TabIndex = 1;
            this.labelMyScore.Text = "222";
            this.labelMyScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(88, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "分數:";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelScore.Location = new System.Drawing.Point(721, 9);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(69, 25);
            this.labelScore.TabIndex = 8;
            this.labelScore.Text = "分數:0";
            this.labelScore.Visible = false;
            // 
            // labeLlife
            // 
            this.labeLlife.AutoSize = true;
            this.labeLlife.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labeLlife.Location = new System.Drawing.Point(217, 8);
            this.labeLlife.Name = "labeLlife";
            this.labeLlife.Size = new System.Drawing.Size(62, 25);
            this.labeLlife.TabIndex = 7;
            this.labeLlife.Text = "生命: ";
            this.labeLlife.Visible = false;
            // 
            // labelBall
            // 
            this.labelBall.AutoSize = true;
            this.labelBall.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelBall.Location = new System.Drawing.Point(20, 8);
            this.labelBall.Name = "labelBall";
            this.labelBall.Size = new System.Drawing.Size(82, 25);
            this.labelBall.TabIndex = 6;
            this.labelBall.Text = "總球數: ";
            this.labelBall.Visible = false;
            // 
            // labelDebug
            // 
            this.labelDebug.AutoSize = true;
            this.labelDebug.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelDebug.Location = new System.Drawing.Point(766, 528);
            this.labelDebug.Name = "labelDebug";
            this.labelDebug.Size = new System.Drawing.Size(75, 25);
            this.labelDebug.TabIndex = 9;
            this.labelDebug.Text = "debug";
            this.labelDebug.Visible = false;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // labelReward
            // 
            this.labelReward.AutoSize = true;
            this.labelReward.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelReward.Location = new System.Drawing.Point(477, 9);
            this.labelReward.Name = "labelReward";
            this.labelReward.Size = new System.Drawing.Size(102, 25);
            this.labelReward.TabIndex = 10;
            this.labelReward.Text = "獎勵球數: ";
            this.labelReward.Visible = false;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.labelReward);
            this.Controls.Add(this.labelDebug);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.labeLlife);
            this.Controls.Add(this.labelBall);
            this.Controls.Add(this.groupBoxMode);
            this.Controls.Add(this.groupBoxGame);
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打打磚塊";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyUp);
            this.groupBoxMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).EndInit();
            this.groupBoxGame.ResumeLayout(false);
            this.groupBoxUpload.ResumeLayout(false);
            this.groupBoxUpload.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMode;
        private System.Windows.Forms.Button buttonDifficulty;
        private System.Windows.Forms.Button buttonNormal;
        private System.Windows.Forms.Button buttonEasy;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBoxGame;
        private System.Windows.Forms.GroupBox groupBoxGame;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labeLlife;
        private System.Windows.Forms.Label labelBall;
        private System.Windows.Forms.GroupBox groupBoxUpload;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMyScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDebug;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelReward;
    }
}