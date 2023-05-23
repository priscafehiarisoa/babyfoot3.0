namespace babyfoot3._0
{
    partial class addPlayer1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            joueur1 = new ComboBox();
            label1 = new Label();
            misej1 = new TextBox();
            mise1 = new Label();
            button1 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // joueur1
            // 
            joueur1.FormattingEnabled = true;
            joueur1.Location = new Point(219, 150);
            joueur1.Name = "joueur1";
            joueur1.Size = new Size(344, 40);
            joueur1.TabIndex = 0;
            joueur1.SelectedIndexChanged += joueur1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(219, 79);
            label1.Name = "label1";
            label1.Size = new Size(96, 32);
            label1.TabIndex = 1;
            label1.Text = "joueur1";
            // 
            // misej1
            // 
            misej1.Location = new Point(219, 297);
            misej1.Name = "misej1";
            misej1.Size = new Size(344, 39);
            misej1.TabIndex = 2;
            misej1.TextChanged += textBox1_TextChanged;
            // 
            // mise1
            // 
            mise1.AutoSize = true;
            mise1.Location = new Point(219, 246);
            mise1.Name = "mise1";
            mise1.Size = new Size(64, 32);
            mise1.TabIndex = 3;
            mise1.Text = "mise";
            mise1.Click += mise1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(251, 386);
            button1.Name = "button1";
            button1.Size = new Size(247, 52);
            button1.TabIndex = 4;
            button1.Text = "next";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(616, 92);
            label2.Name = "label2";
            label2.Size = new Size(78, 32);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // addPlayer1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 489);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(mise1);
            Controls.Add(misej1);
            Controls.Add(label1);
            Controls.Add(joueur1);
            Name = "addPlayer1";
            Text = "choose Player 1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox joueur1;
        private Label label1;
        private TextBox textBox1;
        private Label mise1;
        private Button button1;
        private TextBox misej1;
        private Label label2;
    }
}