using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawProject
{
    public partial class Game_Frm : Form
    {
        public DoubleBufferedDraw_Frm()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        public Game_Frm()
        {
            InitializeComponent();
            Draw_pnl.DoubleBuffered = true;
            Draw_pnl.Paint += Draw_pnl_Paint;
        }

        private void Game_Frm_Load(object sender, EventArgs e)
        {

        }

        private void Draw_pnl_Paint(object sender, PaintEventArgs e)
        {
            // Code de dessin ici
            Graphics g = e.Graphics;

            // Exemple de dessin : un rectangle rouge
            Pen pen = new Pen(Color.Red, 2);
            Rectangle rectangle = new Rectangle(50, 50, 100, 100);
            g.DrawRectangle(pen, rectangle);
        }
    }
}
