namespace babyfoot3._0
{
    partial class addPlayer2
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
            button1 = new Button();
            joueur2 = new ComboBox();
            labelj2 = new Label();
            mise2 = new Label();
            misej2 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(254, 351);
            button1.Name = "button1";
            button1.Size = new Size(188, 51);
            button1.TabIndex = 0;
            button1.Text = "next";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // joueur2
            // 
            joueur2.FormattingEnabled = true;
            joueur2.Location = new Point(230, 127);
            joueur2.Name = "joueur2";
            joueur2.Size = new Size(242, 40);
            joueur2.TabIndex = 1;
            // 
            // labelj2
            // 
            labelj2.AutoSize = true;
            labelj2.Location = new Point(230, 83);
            labelj2.Name = "labelj2";
            labelj2.Size = new Size(96, 32);
            labelj2.TabIndex = 2;
            labelj2.Text = "joueur2";
            // 
            // mise2
            // 
            mise2.AutoSize = true;
            mise2.Location = new Point(230, 214);
            mise2.Name = "mise2";
            mise2.Size = new Size(77, 32);
            mise2.TabIndex = 3;
            mise2.Text = "mise2";
            // 
            // misej2
            // 
            misej2.Location = new Point(230, 259);
            misej2.Name = "misej2";
            misej2.Size = new Size(242, 39);
            misej2.TabIndex = 4;
            // 
            // addPlayer2
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(misej2);
            Controls.Add(mise2);
            Controls.Add(labelj2);
            Controls.Add(joueur2);
            Controls.Add(button1);
            Name = "addPlayer2";
            Text = "addPlayer2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox joueur2;
        private Label labelj2;
        private Label mise2;
        private TextBox misej2;
    }
}