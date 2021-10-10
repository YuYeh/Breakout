namespace finalProject
{
    partial class FormLeaderboard
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.Rank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.player = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.score = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonEasy = new System.Windows.Forms.Button();
            this.buttonNormal = new System.Windows.Forms.Button();
            this.buttonHard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Rank,
            this.player,
            this.score,
            this.date});
            this.listView1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(35, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(800, 421);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Rank
            // 
            this.Rank.Text = "排名";
            this.Rank.Width = 50;
            // 
            // player
            // 
            this.player.Text = "玩家";
            this.player.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.player.Width = 240;
            // 
            // score
            // 
            this.score.Text = "分數";
            this.score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.score.Width = 120;
            // 
            // date
            // 
            this.date.Text = "日期";
            this.date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.date.Width = 170;
            // 
            // buttonEasy
            // 
            this.buttonEasy.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonEasy.Location = new System.Drawing.Point(46, 472);
            this.buttonEasy.Name = "buttonEasy";
            this.buttonEasy.Size = new System.Drawing.Size(81, 34);
            this.buttonEasy.TabIndex = 2;
            this.buttonEasy.Text = "簡單";
            this.buttonEasy.UseVisualStyleBackColor = true;
            this.buttonEasy.Click += new System.EventHandler(this.buttonMode_Click);
            // 
            // buttonNormal
            // 
            this.buttonNormal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonNormal.Location = new System.Drawing.Point(133, 472);
            this.buttonNormal.Name = "buttonNormal";
            this.buttonNormal.Size = new System.Drawing.Size(81, 34);
            this.buttonNormal.TabIndex = 3;
            this.buttonNormal.Text = "普通";
            this.buttonNormal.UseVisualStyleBackColor = true;
            this.buttonNormal.Click += new System.EventHandler(this.buttonMode_Click);
            // 
            // buttonHard
            // 
            this.buttonHard.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonHard.Location = new System.Drawing.Point(220, 472);
            this.buttonHard.Name = "buttonHard";
            this.buttonHard.Size = new System.Drawing.Size(81, 34);
            this.buttonHard.TabIndex = 4;
            this.buttonHard.Text = "困難";
            this.buttonHard.UseVisualStyleBackColor = true;
            this.buttonHard.Click += new System.EventHandler(this.buttonMode_Click);
            // 
            // FormLeaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.buttonHard);
            this.Controls.Add(this.buttonNormal);
            this.Controls.Add(this.buttonEasy);
            this.Controls.Add(this.listView1);
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FormLeaderboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打打磚塊";
            this.Load += new System.EventHandler(this.FormLeaderboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Rank;
        private System.Windows.Forms.ColumnHeader player;
        private System.Windows.Forms.ColumnHeader score;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.Button buttonEasy;
        private System.Windows.Forms.Button buttonNormal;
        private System.Windows.Forms.Button buttonHard;
    }
}