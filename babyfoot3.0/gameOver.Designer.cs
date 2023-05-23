namespace babyfoot3._0
{
    partial class gameOver
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            e1 = new Label();
            e2 = new Label();
            button1 = new Button();
            label4 = new Label();
            label5 = new Label();
            miseJ = new Label();
            miseP = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 22.125F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(221, 37);
            label1.Name = "label1";
            label1.Size = new Size(325, 82);
            label1.TabIndex = 0;
            label1.Text = "game over";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 16.125F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(95, 157);
            label2.Name = "label2";
            label2.Size = new Size(178, 60);
            label2.TabIndex = 1;
            label2.Text = "equipe1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 16.125F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(542, 157);
            label3.Name = "label3";
            label3.Size = new Size(178, 60);
            label3.TabIndex = 1;
            label3.Text = "equipe2";
            // 
            // e1
            // 
            e1.AutoSize = true;
            e1.Font = new Font("Comic Sans MS", 22.125F, FontStyle.Bold, GraphicsUnit.Point);
            e1.Location = new Point(133, 236);
            e1.Name = "e1";
            e1.Size = new Size(71, 82);
            e1.TabIndex = 2;
            e1.Text = "0";
            // 
            // e2
            // 
            e2.AutoSize = true;
            e2.Font = new Font("Comic Sans MS", 22.125F, FontStyle.Bold, GraphicsUnit.Point);
            e2.Location = new Point(595, 236);
            e2.Name = "e2";
            e2.Size = new Size(71, 82);
            e2.TabIndex = 2;
            e2.Text = "0";
            // 
            // button1
            // 
            button1.Location = new Point(286, 526);
            button1.Name = "button1";
            button1.Size = new Size(223, 68);
            button1.TabIndex = 3;
            button1.Text = "restart";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 358);
            label4.Name = "label4";
            label4.Size = new Size(321, 32);
            label4.TabIndex = 4;
            label4.Text = "mise obtenus par les joueurs";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 422);
            label5.Name = "label5";
            label5.Size = new Size(356, 32);
            label5.TabIndex = 5;
            label5.Text = "mise obtenus par le proprietaire";
            // 
            // miseJ
            // 
            miseJ.AutoSize = true;
            miseJ.Location = new Point(384, 358);
            miseJ.Name = "miseJ";
            miseJ.Size = new Size(27, 32);
            miseJ.TabIndex = 6;
            miseJ.Text = "0";
            // 
            // miseP
            // 
            miseP.AutoSize = true;
            miseP.Location = new Point(415, 428);
            miseP.Name = "miseP";
            miseP.Size = new Size(27, 32);
            miseP.TabIndex = 7;
            miseP.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 483);
            label6.Name = "label6";
            label6.Size = new Size(78, 32);
            label6.TabIndex = 8;
            label6.Text = "label6";
            // 
            // gameOver
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 649);
            Controls.Add(label6);
            Controls.Add(miseP);
            Controls.Add(miseJ);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(e2);
            Controls.Add(e1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "gameOver";
            Text = "gameOver";
            Load += gameOver_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label e1;
        private Label e2;
        private Button button1;
        private Label label4;
        private Label label5;
        private Label miseJ;
        private Label miseP;
        private Label label6;
    }
}