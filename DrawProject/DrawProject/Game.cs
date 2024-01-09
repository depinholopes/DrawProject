// Libraries
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Sockets;
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
        private string currentWord;
        private HashSet<char> guessedLetters = new HashSet<char>();
        private List<string> wordsToDraw = new List<string>
        {
            "apple",
            "banana",
            "cat",
            "dog",
            "duck",
            "house"
        };
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private Graphics graphics;
        private int gameNumber;
        private string accessCode;
        private void GetRandomWord()
        {
            Random random = new Random();
            int index = random.Next(wordsToDraw.Count);
            currentWord = wordsToDraw[index];
        }


        private void DisplayRandomWord()
        {
            GetRandomWord();

            // Convert the word to puzzle format (e.g., "_ _ _ _")
            string puzzleFormat = string.Join(" ", currentWord.Select(c => "_"));

            wordToDraw_lbl.Text = $"Draw: {puzzleFormat}";
        }
        private void DisplayGuessedWord()
        {
            // Initialize a StringBuilder to build the displayed word
            StringBuilder displayWord = new StringBuilder();

            // Iterate through each character in the current word
            for (int i = 0; i < currentWord.Length; i++)
            {
                char currentChar = currentWord[i];

                // Check if the letter has been guessed
                if (guessedLetters.Contains(currentChar))
                {
                    // Guessed letter, append it to the display word
                    displayWord.Append(currentChar);
                }
                else
                {
                    // Letter not guessed, append an underscore
                    displayWord.Append("_");
                }

                // Append a space after each character except the last one
                if (i < currentWord.Length - 1)
                {
                    displayWord.Append(" ");
                }
            }

            // Update the label with the constructed display word
            wordToDraw_lbl.Text = $"Draw: {displayWord.ToString()}";

            // Check if the guessed word matches the current word
            if (displayWord.ToString().Replace(" ", "") == currentWord)
            {
                // Word is found, display a congratulatory message in the chat
                AddMessage("System", $"Congratulations! You found the word '{currentWord}'!");
            }
        }


        public Game_Frm(string accessCode, int gameNumber)
        {
            InitializeComponent();
            this.accessCode = accessCode;
            this.gameNumber = gameNumber;
            ConnectToLocalServerAsync();
            DisplayRandomWord();
            DisplayGuessedWord();
            graphics = drawing_ptr.CreateGraphics();
            gameCode_lbl.Text = $"Code de la partie : {accessCode}";
        }

        public Game_Frm()
        {
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
        // Event handler for key press in the text box
        private void send_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Get the guessed text
                string guessedText = send_txt.Text.Trim().ToLower();

                if (!string.IsNullOrWhiteSpace(guessedText))
                {
                    // Check if the guessed text matches the current word
                    if (guessedText == currentWord)
                    {
                        // Reveal all letters in the hidden word
                        guessedLetters = new HashSet<char>(currentWord.ToLower());

                        // Update the displayed word
                        DisplayGuessedWord();
                    }
                    else
                    {
                        // Check for correct letters in the guessed word
                        foreach (char guessedLetter in guessedText)
                        {
                            if (currentWord.ToLower().Contains(guessedLetter) && !guessedLetters.Contains(guessedLetter))
                            {
                                guessedLetters.Add(guessedLetter);
                            }
                        }

                        // Update the displayed word
                        DisplayGuessedWord();
                    }

                    // Clear the text after guessing
                    send_txt.Clear();
                }

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
                MessageBox.Show("No drawing to save", "Waring !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task ConnectToLocalServerAsync()
        {
            try
            {
                if (!CheckAccessCode())
                {
                    MessageBox.Show("Code d'accès incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                tcpClient = new TcpClient();
                await tcpClient.ConnectAsync("127.0.0.1", 12345);
                stream = tcpClient.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream) { AutoFlush = true };

                Task.Run(() => ReceiveUpdatesFromServer());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de connexion au serveur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async Task ReceiveUpdatesFromServer()
        {
            try
            {
                while (true)
                {
                    string data = await reader.ReadLineAsync();

                    if (data != null)
                    {
                        // Process updates received from the server
                        ProcessServerUpdate(data);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error communicating with the server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task SendDrawingUpdateToServer(Point startPoint, Point endPoint)
        {
            // Send drawing coordinates to the server
            await writer.WriteLineAsync($"DRAW|{startPoint.X},{startPoint.Y},{endPoint.X},{endPoint.Y}");
        }

        private void ProcessServerUpdate(string update)
        {
            // Split the update string to get the necessary information
            string[] parts = update.Split('|');

            if (parts.Length == 2 && parts[0] == "DRAW")
            {
                string[] coordinates = parts[1].Split(',');

                if (coordinates.Length == 4)
                {
                    // Get the drawing coordinates
                    int startX = int.Parse(coordinates[0]);
                    int startY = int.Parse(coordinates[1]);
                    int endX = int.Parse(coordinates[2]);
                    int endY = int.Parse(coordinates[3]);

                    // Draw on the form using these coordinates
                    using (Pen pen = new Pen(currentColor, lineSize))
                    {
                        graphics.DrawLine(pen, startX, startY, endX, endY);
                    }
                }
            }
        }
        private bool CheckAccessCode()
        {
            // Affichez un formulaire ou une boîte de dialogue pour saisir le code de connexion
            AccessCodeForm accessCodeForm = new AccessCodeForm();
            DialogResult result = accessCodeForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Vérifiez si le code entré correspond au code attendu
                return accessCodeForm.EnteredCode == accessCode;
            }

            return false;
        }
        // Event handler for form closing
        private void Game_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
