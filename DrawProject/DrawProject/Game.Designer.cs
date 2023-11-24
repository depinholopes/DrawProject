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
            Draw_pnl = new Panel();
            SuspendLayout();
            // 
            // Draw_pnl
            // 
            Draw_pnl.Location = new Point(211, 58);
            Draw_pnl.Name = "Draw_pnl";
            Draw_pnl.Size = new Size(319, 303);
            Draw_pnl.TabIndex = 0;
            Draw_pnl.Paint += Draw_pnl_Paint;
            // 
            // Game_Frm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Draw_pnl);
            Name = "Game_Frm";
            Text = "Game";
            Load += Game_Frm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel Draw_pnl;
    }
}