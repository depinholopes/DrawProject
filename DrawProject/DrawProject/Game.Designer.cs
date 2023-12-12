namespace DrawProject
{
    partial class Game_Frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game_Frm));
            logo_ptr = new PictureBox();
            drawing_ptr = new PictureBox();
            selectColor_btn = new Button();
            selectEraser_btn = new Button();
            reset_btn = new Button();
            chat_txt = new TextBox();
            send_txt = new TextBox();
            colorDialog = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)logo_ptr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)drawing_ptr).BeginInit();
            SuspendLayout();
            // 
            // logo_ptr
            // 
            logo_ptr.Image = (Image)resources.GetObject("logo_ptr.Image");
            logo_ptr.Location = new Point(783, 12);
            logo_ptr.Name = "logo_ptr";
            logo_ptr.Size = new Size(251, 254);
            logo_ptr.TabIndex = 4;
            logo_ptr.TabStop = false;
            // 
            // drawing_ptr
            // 
            drawing_ptr.BorderStyle = BorderStyle.FixedSingle;
            drawing_ptr.Location = new Point(378, 272);
            drawing_ptr.Name = "drawing_ptr";
            drawing_ptr.Size = new Size(1102, 735);
            drawing_ptr.TabIndex = 5;
            drawing_ptr.TabStop = false;
            drawing_ptr.MouseDown += drawing_ptr_MouseDown;
            drawing_ptr.MouseMove += drawing_ptr_MouseMove;
            drawing_ptr.MouseUp += drawing_ptr_MouseUp;
            // 
            // selectColor_btn
            // 
            selectColor_btn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            selectColor_btn.Location = new Point(1652, 272);
            selectColor_btn.Name = "selectColor_btn";
            selectColor_btn.Size = new Size(248, 76);
            selectColor_btn.TabIndex = 6;
            selectColor_btn.Text = "Select Color";
            selectColor_btn.UseVisualStyleBackColor = true;
            selectColor_btn.Click += selectColor_btn_Click;
            // 
            // selectEraser_btn
            // 
            selectEraser_btn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            selectEraser_btn.Location = new Point(1652, 354);
            selectEraser_btn.Name = "selectEraser_btn";
            selectEraser_btn.Size = new Size(248, 76);
            selectEraser_btn.TabIndex = 8;
            selectEraser_btn.Text = "Eraser";
            selectEraser_btn.UseVisualStyleBackColor = true;
            selectEraser_btn.Click += selectEraser_btn_Click;
            // 
            // reset_btn
            // 
            reset_btn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            reset_btn.Location = new Point(1652, 931);
            reset_btn.Name = "reset_btn";
            reset_btn.Size = new Size(248, 76);
            reset_btn.TabIndex = 9;
            reset_btn.Text = "Reset";
            reset_btn.UseVisualStyleBackColor = true;
            reset_btn.Click += reset_btn_Click;
            // 
            // chat_txt
            // 
            chat_txt.BackColor = Color.White;
            chat_txt.Location = new Point(12, 272);
            chat_txt.Multiline = true;
            chat_txt.Name = "chat_txt";
            chat_txt.ReadOnly = true;
            chat_txt.Size = new Size(346, 659);
            chat_txt.TabIndex = 10;
            // 
            // send_txt
            // 
            send_txt.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            send_txt.ForeColor = Color.Silver;
            send_txt.Location = new Point(12, 937);
            send_txt.Multiline = true;
            send_txt.Name = "send_txt";
            send_txt.Size = new Size(346, 70);
            send_txt.TabIndex = 12;
            send_txt.Text = "text to send...";
            // 
            // Game_Frm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1904, 1041);
            Controls.Add(send_txt);
            Controls.Add(chat_txt);
            Controls.Add(reset_btn);
            Controls.Add(selectEraser_btn);
            Controls.Add(selectColor_btn);
            Controls.Add(drawing_ptr);
            Controls.Add(logo_ptr);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Game_Frm";
            Text = "Game";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)logo_ptr).EndInit();
            ((System.ComponentModel.ISupportInitialize)drawing_ptr).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox logo_ptr;
        private PictureBox drawing_ptr;
        private Button selectColor_btn;
        private Button selectEraser_btn;
        private Button reset_btn;
        private TextBox chat_txt;
        private TextBox send_txt;
        private ColorDialog colorDialog;
    }
}