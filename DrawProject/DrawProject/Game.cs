using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawProject
{
    public partial class Game_Frm : Form
    {
        private Point lastPoint = Point.Empty;
        private bool isMouseDown = false;
        private Color currentColor = Color.Black;
        private Color previousColor = Color.Black;
        private bool isEraserMode = false;
        public Game_Frm()
        {
            InitializeComponent();

        }

        private void drawing_ptr_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isMouseDown = true;
        }

        private void drawing_ptr_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (lastPoint != null)
                {
                    if (drawing_ptr.Image == null)
                    {
                        Bitmap bmp = new Bitmap(drawing_ptr.Width, drawing_ptr.Height);
                        drawing_ptr.Image = bmp;
                    }

                    using (Graphics g = Graphics.FromImage(drawing_ptr.Image))
                    {
                        // Utilisation de la couleur actuelle pour créer le stylo
                        using (Pen pen = new Pen(currentColor, 2))
                        {
                            g.DrawLine(pen, lastPoint, e.Location);
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                        }
                    }

                    drawing_ptr.Invalidate();
                    lastPoint = e.Location;
                }
            }
        }

        private void drawing_ptr_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            lastPoint = Point.Empty;
        }

        private void selectColor_btn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            // Affichez la boîte de dialogue de couleur et mettez à jour la couleur actuelle si l'utilisateur sélectionne une nouvelle couleur
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Mettez à jour la couleur actuelle
                currentColor = colorDialog.Color;
            }
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            // Réinitialiser l'image de la zone de dessin
            drawing_ptr.Image = null;
        }

        private void selectEraser_btn_Click(object sender, EventArgs e)
        {
            if (isEraserMode)
            {
                // Revenir à la couleur précédente avant d'activer le mode gomme
                currentColor = previousColor;
            }
            else
            {
                // Enregistrer la couleur actuelle avant de passer en mode gomme
                previousColor = currentColor;
                // Activer le mode gomme en changeant la couleur en blanc
                currentColor = Color.White;
            }

            // Basculer entre le mode normal et le mode gomme
            isEraserMode = !isEraserMode;

            // Vous pouvez également changer l'apparence visuelle du bouton pour indiquer si le mode gomme est activé ou désactivé
            // Par exemple, changez la couleur du bouton ou ajoutez un texte indicatif

            // Appeler Invalidate pour mettre à jour la zone de dessin
            drawing_ptr.Invalidate();
        }
    }
}