// Libraries
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
        // Variables to keep track of drawing state
        private Point lastPoint = Point.Empty;
        private bool isMouseDown = false;

        // Variables for handling drawing properties
        private Color currentColor = Color.Black;
        private Color previousColor = Color.Black;
        private bool isEraserMode = false;
        private float lineSize = 2.0f; // Default line size

        public Game_Frm()
        {
            InitializeComponent();
        }

        // Method to change the color of the drawing line
        private void ChangerCouleurTrait(Color nouvelleCouleur)
        {
            // Create a new image with the current color
            Bitmap nouvelleImage = new Bitmap(drawing_ptr.Width, drawing_ptr.Height);

            using (Graphics g = Graphics.FromImage(nouvelleImage))
            {
                // Copy the content of the previous image
                if (drawing_ptr.Image != null)
                {
                    g.DrawImage(drawing_ptr.Image, Point.Empty);
                }

                // Draw the line with the new color
                using (Pen pen = new Pen(nouvelleCouleur, lineSize))
                {
                    g.DrawLine(pen, lastPoint, lastPoint); // Draw a point at the current position
                }
            }

            // Assign the new image to the PictureBox
            drawing_ptr.Image = nouvelleImage;
        }

        // Event handler for mouse down on the drawing area
        private void drawing_ptr_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isMouseDown = true;
        }

        // Event handler for mouse move on the drawing area
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
                        // Use the current color to create the pen
                        using (Pen pen = new Pen(currentColor, lineSize))
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

        // Event handler for mouse up on the drawing area
        private void drawing_ptr_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            lastPoint = Point.Empty;
        }

        // Event handler for selecting a new drawing color
        private void selectColor_btn_Click(object sender, EventArgs e)
        {
            // Show a dialog to choose a color
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Change the color of the line
                currentColor = colorDialog.Color;
            }
        }

        // Event handler for resetting the drawing image
        private void reset_btn_Click(object sender, EventArgs e)
        {
            // Reset the image of the drawing area
            drawing_ptr.Image = null;
        }

        // Event handler for selecting the eraser mode
        private void selectEraser_btn_Click(object sender, EventArgs e)
        {
            if (isEraserMode)
            {
                // Revert to the previous color before enabling eraser mode
                currentColor = previousColor;
            }
            else
            {
                // Save the current color before switching to eraser mode
                previousColor = currentColor;
                // Enable eraser mode by changing the color to white
                currentColor = Color.White;
            }

            // Toggle between normal mode and eraser mode
            isEraserMode = !isEraserMode;

            // You can also change the visual appearance of the button to indicate whether eraser mode is on or off
            // For example, change the color of the button or add indicative text

            // Call Invalidate to update the drawing area
            drawing_ptr.Invalidate();
        }

        // Event handler for sending a chat message
        private void send_btn_Click(object sender, EventArgs e)
        {
            string message = send_txt.Text;

            if (!string.IsNullOrWhiteSpace(message))
            {
                AddMessage("Me", message); // Add the message to the chat box with your name (here, "Me")
                send_txt.Clear(); // Clear the text after sending the message
            }
        }

        // Method to add a message to the chat box
        private void AddMessage(string sender, string message)
        {
            string formattedMessage = $"{sender}: {message}";
            chat_lst.Items.Add(formattedMessage);
            chat_lst.SelectedIndex = chat_lst.Items.Count - 1;
        }

        // Event handler for key press in the text box
        private void send_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Prevent newline by consuming the event
                e.Handled = true;
            }
        }

        // Event handler for increasing the line size
        private void sizeIncrease_btn_Click(object sender, EventArgs e)
        {
            lineSize += 1.0f; // Increase the line size
        }

        // Event handler for decreasing the line size
        private void sizeDecrease_btn_Click(object sender, EventArgs e)
        {
            lineSize = Math.Max(1.0f, lineSize - 1.0f); // Decrease the line size, with a minimum size of 1.0
        }

        private void download_btn_Click(object sender, EventArgs e)
        {
            // Check if there is an image in the PictureBox
            if (drawing_ptr.Image != null)
            {
                // Display a SaveFileDialog to choose the save location
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PNG files (*.png)|*.png";
                saveDialog.Title = "Save Drawing As PNG";

                // If the user selects a location and clicks OK
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the image in PNG format
                    drawing_ptr.Image.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            else
            {
                // Display a warning if there is no drawing to save
                MessageBox.Show("Aucun dessin à sauvegarder.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Event handler for form closing
        private void Game_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
