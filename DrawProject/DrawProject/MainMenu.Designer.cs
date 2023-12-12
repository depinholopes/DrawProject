namespace DrawProject
{
    partial class MainMenu_Frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu_Frm));
            Play_Button = new Button();
            HowToPlay_Button = new Button();
            Quit_Button = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Play_Button
            // 
            Play_Button.Location = new Point(872, 325);
            Play_Button.Name = "Play_Button";
            Play_Button.Size = new Size(180, 71);
            Play_Button.TabIndex = 0;
            Play_Button.Text = "Play";
            Play_Button.UseVisualStyleBackColor = true;
            Play_Button.Click += Play_Button_Click;
            // 
            // HowToPlay_Button
            // 
            HowToPlay_Button.Location = new Point(872, 402);
            HowToPlay_Button.Name = "HowToPlay_Button";
            HowToPlay_Button.Size = new Size(180, 71);
            HowToPlay_Button.TabIndex = 1;
            HowToPlay_Button.Text = "How to play";
            HowToPlay_Button.UseVisualStyleBackColor = true;
            HowToPlay_Button.Click += HowToPlay_Button_Click;
            // 
            // Quit_Button
            // 
            Quit_Button.Location = new Point(872, 479);
            Quit_Button.Name = "Quit_Button";
            Quit_Button.Size = new Size(180, 71);
            Quit_Button.TabIndex = 2;
            Quit_Button.Text = "Quit";
            Quit_Button.UseVisualStyleBackColor = true;
            Quit_Button.Click += Quit_Button_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(838, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(251, 254);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // MainMenu_Frm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1904, 1041);
            Controls.Add(pictureBox1);
            Controls.Add(Quit_Button);
            Controls.Add(HowToPlay_Button);
            Controls.Add(Play_Button);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainMenu_Frm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DrawProject";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button Play_Button;
        private Button HowToPlay_Button;
        private Button Quit_Button;
        private PictureBox pictureBox1;
    }
}