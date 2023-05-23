namespace babyfoot3._0
{
    partial class foot_game
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(foot_game));
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            balle = new PictureBox();
            label2 = new Label();
            gamePanel = new Panel();
            butsEquipe2 = new PictureBox();
            butsEquipe1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            E2 = new Label();
            scoreE1 = new Label();
            scoreE2 = new Label();
            ((System.ComponentModel.ISupportInitialize)balle).BeginInit();
            gamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)butsEquipe2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)butsEquipe1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(712, 32);
            label1.Name = "label1";
            label1.Size = new Size(78, 32);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 50;
            timer1.Tick += mainGameTimer;
            // 
            // balle
            // 
            balle.BackgroundImage = (Image)resources.GetObject("balle.BackgroundImage");
            balle.BackgroundImageLayout = ImageLayout.Stretch;
            balle.Image = (Image)resources.GetObject("balle.Image");
            balle.Location = new Point(784, 469);
            balle.Name = "balle";
            balle.Size = new Size(30, 30);
            balle.TabIndex = 1;
            balle.TabStop = false;
            balle.Tag = "balle";
            balle.Click += balle_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(128, 1139);
            label2.Name = "label2";
            label2.Size = new Size(78, 32);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // gamePanel
            // 
            gamePanel.BackColor = Color.MediumSeaGreen;
            gamePanel.Controls.Add(butsEquipe2);
            gamePanel.Controls.Add(butsEquipe1);
            gamePanel.Controls.Add(balle);
            gamePanel.Location = new Point(102, 68);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(1667, 1068);
            gamePanel.TabIndex = 3;
            // 
            // butsEquipe2
            // 
            butsEquipe2.BackColor = SystemColors.ActiveBorder;
            butsEquipe2.Location = new Point(1563, 392);
            butsEquipe2.Name = "butsEquipe2";
            butsEquipe2.Size = new Size(101, 282);
            butsEquipe2.TabIndex = 2;
            butsEquipe2.TabStop = false;
            butsEquipe2.Tag = "buts";
            // 
            // butsEquipe1
            // 
            butsEquipe1.BackColor = SystemColors.ActiveBorder;
            butsEquipe1.Location = new Point(-6, 362);
            butsEquipe1.Name = "butsEquipe1";
            butsEquipe1.Size = new Size(101, 282);
            butsEquipe1.TabIndex = 2;
            butsEquipe1.TabStop = false;
            butsEquipe1.Tag = "buts";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(78, 32);
            label3.TabIndex = 4;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 16.125F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(1857, 96);
            label4.Name = "label4";
            label4.Size = new Size(157, 60);
            label4.TabIndex = 5;
            label4.Text = "scores";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(1813, 182);
            label5.Name = "label5";
            label5.Size = new Size(62, 52);
            label5.TabIndex = 6;
            label5.Text = "E1";
            // 
            // E2
            // 
            E2.AutoSize = true;
            E2.Font = new Font("Comic Sans MS", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            E2.Location = new Point(1996, 182);
            E2.Name = "E2";
            E2.Size = new Size(68, 52);
            E2.TabIndex = 6;
            E2.Text = "E2";
            E2.Click += E2_Click;
            // 
            // scoreE1
            // 
            scoreE1.AutoSize = true;
            scoreE1.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            scoreE1.ForeColor = Color.Green;
            scoreE1.Location = new Point(1813, 268);
            scoreE1.Name = "scoreE1";
            scoreE1.Size = new Size(58, 67);
            scoreE1.TabIndex = 7;
            scoreE1.Text = "0";
            // 
            // scoreE2
            // 
            scoreE2.AutoSize = true;
            scoreE2.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            scoreE2.ForeColor = Color.Green;
            scoreE2.Location = new Point(1996, 268);
            scoreE2.Name = "scoreE2";
            scoreE2.Size = new Size(58, 67);
            scoreE2.TabIndex = 7;
            scoreE2.Text = "0";
            // 
            // foot_game
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(2118, 1197);
            Controls.Add(scoreE2);
            Controls.Add(scoreE1);
            Controls.Add(E2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(gamePanel);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "foot_game";
            Text = "foot_game";
            Load += foot_game_Load;
            KeyDown += key_is_down;
            KeyPress += key_isPressed;
            KeyUp += key_is_up;
            ((System.ComponentModel.ISupportInitialize)balle).EndInit();
            gamePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)butsEquipe2).EndInit();
            ((System.ComponentModel.ISupportInitialize)butsEquipe1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private PictureBox balle;
        private Label label2;
        private Panel gamePanel;
        private PictureBox butEquipe2;
        private PictureBox butsEquipe1;
        private PictureBox butsEquipe2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label E2;
        private Label scoreE1;
        private Label scoreE2;
    }
}