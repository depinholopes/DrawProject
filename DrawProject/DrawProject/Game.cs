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
        private float tailleTrait = 2.0f; // Taille du trait par défaut

        public Game_Frm()
        {
            InitializeComponent();

        }
        private void ChangerCouleurTrait(Color nouvelleCouleur)
        {
            // Créer une nouvelle image avec la couleur actuelle
            Bitmap nouvelleImage = new Bitmap(drawing_ptr.Width, drawing_ptr.Height);

            using (Graphics g = Graphics.FromImage(nouvelleImage))
            {
                // Copier le contenu de l'image précédente
                if (drawing_ptr.Image != null)
                {
                    g.DrawImage(drawing_ptr.Image, Point.Empty);
                }

                // Dessiner le trait avec la nouvelle couleur
                using (Pen pen = new Pen(nouvelleCouleur, tailleTrait))
                {
                    g.DrawLine(pen, lastPoint, lastPoint); // Dessiner un point à la position actuelle
                }
            }

            // Affecter la nouvelle image à la PictureBox
            drawing_ptr.Image = nouvelleImage;
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
                            g.DrawLine(new Pen(Color.Black, tailleTrait), lastPoint, e.Location);
                            g.SmoothingMode = SmoothingMode.AntiAlias;
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
            // Afficher une boîte de dialogue pour choisir la couleur
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Changer la couleur du trait
                ChangerCouleurTrait(colorDialog.Color);
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

            // Vous pouvez également ch anger l'apparence visuelle du bouton pour indiquer si le mode gomme est activé ou désactivé
            // Par exemple, changez la couleur du bouton ou ajoutez un texte indicatif

            // Appeler Invalidate pour mettre à jour la zone de dessin
            drawing_ptr.Invalidate();
        }
        private void Game_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void send_btn_Click(object sender, EventArgs e)
        {
            string message = send_txt.Text;

            if (!string.IsNullOrWhiteSpace(message))
            {
                AddMessage("Moi", message); // Ajoutez le message à la boîte de chat avec votre nom (ici, "Moi")
                send_txt.Clear(); // Efface le texte après l'envoi du message
            }
        }
        private void AddMessage(string sender, string message)
        {
            string formattedMessage = $"{sender}: {message}";
            chat_lst.Items.Add(formattedMessage);
            chat_lst.SelectedIndex = chat_lst.Items.Count - 1;
        }
        private void send_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Empêcher le retour à la ligne en consommant l'événement
                e.Handled = true;
            }
        }

        private void sizeIncrease_btn_Click(object sender, EventArgs e)
        {
            tailleTrait += 1.0f; // Augmenter la taille du trait
        }

        private void sizeDecrease_btn_Click(object sender, EventArgs e)
        {
            tailleTrait = Math.Max(1.0f, tailleTrait - 1.0f); // Diminuer la taille du trait, avec une taille minimale de 1.0
        }
    }
}