namespace DrawProject
{
    partial class HowToPlay_Frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HowToPlay_Frm));
            Description_TxtBox = new TextBox();
            DescriptionTitle_TxtBox = new TextBox();
            HowToPlayTitle_TxtBox = new TextBox();
            HowToPlay_TxtBox = new TextBox();
            BackToMenu_Btn = new Button();
            logo_ptr = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)logo_ptr).BeginInit();
            SuspendLayout();
            // 
            // Description_TxtBox
            // 
            Description_TxtBox.BackColor = Color.White;
            Description_TxtBox.BorderStyle = BorderStyle.None;
            Description_TxtBox.HideSelection = false;
            Description_TxtBox.Location = new Point(418, 424);
            Description_TxtBox.MinimumSize = new Size(450, 350);
            Description_TxtBox.Multiline = true;
            Description_TxtBox.Name = "Description_TxtBox";
            Description_TxtBox.ReadOnly = true;
            Description_TxtBox.Size = new Size(450, 350);
            Description_TxtBox.TabIndex = 0;
            Description_TxtBox.Text = resources.GetString("Description_TxtBox.Text");
            // 
            // DescriptionTitle_TxtBox
            // 
            DescriptionTitle_TxtBox.BackColor = Color.White;
            DescriptionTitle_TxtBox.BorderStyle = BorderStyle.None;
            DescriptionTitle_TxtBox.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            DescriptionTitle_TxtBox.Location = new Point(474, 324);
            DescriptionTitle_TxtBox.Name = "DescriptionTitle_TxtBox";
            DescriptionTitle_TxtBox.ReadOnly = true;
            DescriptionTitle_TxtBox.Size = new Size(330, 86);
            DescriptionTitle_TxtBox.TabIndex = 1;
            DescriptionTitle_TxtBox.Text = "Description";
            // 
            // HowToPlayTitle_TxtBox
            // 
            HowToPlayTitle_TxtBox.BackColor = Color.White;
            HowToPlayTitle_TxtBox.BorderStyle = BorderStyle.None;
            HowToPlayTitle_TxtBox.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            HowToPlayTitle_TxtBox.Location = new Point(1169, 324);
            HowToPlayTitle_TxtBox.Name = "HowToPlayTitle_TxtBox";
            HowToPlayTitle_TxtBox.ReadOnly = true;
            HowToPlayTitle_TxtBox.Size = new Size(463, 86);
            HowToPlayTitle_TxtBox.TabIndex = 4;
            HowToPlayTitle_TxtBox.Text = "Comment Jouer";
            // 
            // HowToPlay_TxtBox
            // 
            HowToPlay_TxtBox.BackColor = Color.White;
            HowToPlay_TxtBox.BorderStyle = BorderStyle.None;
            HowToPlay_TxtBox.Location = new Point(1169, 423);
            HowToPlay_TxtBox.MinimumSize = new Size(450, 350);
            HowToPlay_TxtBox.Multiline = true;
            HowToPlay_TxtBox.Name = "HowToPlay_TxtBox";
            HowToPlay_TxtBox.ReadOnly = true;
            HowToPlay_TxtBox.Size = new Size(450, 350);
            HowToPlay_TxtBox.TabIndex = 5;
            HowToPlay_TxtBox.Text = resources.GetString("HowToPlay_TxtBox.Text");
            // 
            // BackToMenu_Btn
            // 
            BackToMenu_Btn.Location = new Point(418, 730);
            BackToMenu_Btn.Name = "BackToMenu_Btn";
            BackToMenu_Btn.Size = new Size(77, 44);
            BackToMenu_Btn.TabIndex = 6;
            BackToMenu_Btn.Text = "Retour au menu";
            BackToMenu_Btn.UseVisualStyleBackColor = true;
            BackToMenu_Btn.Click += BackToMenu_Btn_Click;
            // 
            // logo_ptr
            // 
            logo_ptr.Image = (Image)resources.GetObject("logo_ptr.Image");
            logo_ptr.Location = new Point(872, 25);
            logo_ptr.Name = "logo_ptr";
            logo_ptr.Size = new Size(251, 254);
            logo_ptr.TabIndex = 7;
            logo_ptr.TabStop = false;
            // 
            // HowToPlay_Frm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1904, 1041);
            Controls.Add(logo_ptr);
            Controls.Add(BackToMenu_Btn);
            Controls.Add(HowToPlay_TxtBox);
            Controls.Add(HowToPlayTitle_TxtBox);
            Controls.Add(DescriptionTitle_TxtBox);
            Controls.Add(Description_TxtBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "HowToPlay_Frm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HowToPlay";
            WindowState = FormWindowState.Maximized;
            Load += HowToPlay_Frm_Load;
            ((System.ComponentModel.ISupportInitialize)logo_ptr).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Description_TxtBox;
        private TextBox DescriptionTitle_TxtBox;
        private TextBox HowToPlayTitle_TxtBox;
        private TextBox HowToPlay_TxtBox;
        private Button BackToMenu_Btn;
        private PictureBox logo_ptr;
    }
}