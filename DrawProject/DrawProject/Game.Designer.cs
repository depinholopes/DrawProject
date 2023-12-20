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
            send_txt = new TextBox();
            colorDialog = new ColorDialog();
            send_btn = new Button();
            chat_lst = new ListBox();
            sizeIncrease_btn = new Button();
            sizeDecrease_btn = new Button();
            download_btn = new Button();
            Advertissement_txt = new TextBox();
            wordToDraw_lbl = new Label();
            ((System.ComponentModel.ISupportInitialize)logo_ptr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)drawing_ptr).BeginInit();
            SuspendLayout();
            // 
            // logo_ptr
            // 
            logo_ptr.Image = (Image)resources.GetObject("logo_ptr.Image");
            logo_ptr.Location = new Point(872, 12);
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
            // send_txt
            // 
            send_txt.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            send_txt.ForeColor = Color.Black;
            send_txt.Location = new Point(12, 937);
            send_txt.Multiline = true;
            send_txt.Name = "send_txt";
            send_txt.PlaceholderText = "text to send...";
            send_txt.Size = new Size(250, 70);
            send_txt.TabIndex = 12;
            send_txt.KeyPress += send_txt_KeyPress;
            // 
            // send_btn
            // 
            send_btn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            send_btn.Location = new Point(268, 937);
            send_btn.Name = "send_btn";
            send_btn.Size = new Size(90, 70);
            send_btn.TabIndex = 13;
            send_btn.Text = "Send";
            send_btn.UseVisualStyleBackColor = true;
            send_btn.Click += send_btn_Click;
            // 
            // chat_lst
            // 
            chat_lst.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            chat_lst.FormattingEnabled = true;
            chat_lst.ItemHeight = 32;
            chat_lst.Location = new Point(12, 272);
            chat_lst.Name = "chat_lst";
            chat_lst.Size = new Size(346, 644);
            chat_lst.TabIndex = 15;
            // 
            // sizeIncrease_btn
            // 
            sizeIncrease_btn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            sizeIncrease_btn.Location = new Point(1652, 436);
            sizeIncrease_btn.Name = "sizeIncrease_btn";
            sizeIncrease_btn.Size = new Size(124, 76);
            sizeIncrease_btn.TabIndex = 17;
            sizeIncrease_btn.Text = "+";
            sizeIncrease_btn.UseVisualStyleBackColor = true;
            sizeIncrease_btn.Click += sizeIncrease_btn_Click;
            // 
            // sizeDecrease_btn
            // 
            sizeDecrease_btn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            sizeDecrease_btn.Location = new Point(1776, 436);
            sizeDecrease_btn.Name = "sizeDecrease_btn";
            sizeDecrease_btn.Size = new Size(124, 76);
            sizeDecrease_btn.TabIndex = 18;
            sizeDecrease_btn.Text = "-";
            sizeDecrease_btn.UseVisualStyleBackColor = true;
            sizeDecrease_btn.Click += sizeDecrease_btn_Click;
            // 
            // download_btn
            // 
            download_btn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            download_btn.Location = new Point(1486, 931);
            download_btn.Name = "download_btn";
            download_btn.Size = new Size(160, 76);
            download_btn.TabIndex = 19;
            download_btn.Text = "Download";
            download_btn.UseVisualStyleBackColor = true;
            download_btn.Click += download_btn_Click;
            // 
            // Advertissement_txt
            // 
            Advertissement_txt.BackColor = Color.White;
            Advertissement_txt.BorderStyle = BorderStyle.None;
            Advertissement_txt.Location = new Point(1486, 865);
            Advertissement_txt.Multiline = true;
            Advertissement_txt.Name = "Advertissement_txt";
            Advertissement_txt.ReadOnly = true;
            Advertissement_txt.Size = new Size(160, 60);
            Advertissement_txt.TabIndex = 20;
            Advertissement_txt.Text = "⚠️ Background is invisible, so it will download only the lines you had drawn.";
            // 
            // wordToDraw_lbl
            // 
            wordToDraw_lbl.AutoSize = true;
            wordToDraw_lbl.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            wordToDraw_lbl.Location = new Point(378, 234);
            wordToDraw_lbl.Name = "wordToDraw_lbl";
            wordToDraw_lbl.Size = new Size(78, 32);
            wordToDraw_lbl.TabIndex = 21;
            wordToDraw_lbl.Text = "label1";
            // 
            // Game_Frm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1904, 1041);
            Controls.Add(wordToDraw_lbl);
            Controls.Add(Advertissement_txt);
            Controls.Add(download_btn);
            Controls.Add(sizeDecrease_btn);
            Controls.Add(sizeIncrease_btn);
            Controls.Add(chat_lst);
            Controls.Add(send_btn);
            Controls.Add(send_txt);
            Controls.Add(reset_btn);
            Controls.Add(selectEraser_btn);
            Controls.Add(selectColor_btn);
            Controls.Add(drawing_ptr);
            Controls.Add(logo_ptr);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Game_Frm";
            Text = "Game";
            WindowState = FormWindowState.Maximized;
            FormClosing += Game_Frm_FormClosing;
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
        private TextBox send_txt;
        private ColorDialog colorDialog;
        private Button send_btn;
        private ListBox chat_lst;
        private Button sizeIncrease_btn;
        private Button sizeDecrease_btn;
        private Button download_btn;
        private TextBox Advertissement_txt;
        private Label wordToDraw_lbl;
    }
}