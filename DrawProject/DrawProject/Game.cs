using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawProject
{
    public partial class Game_Frm : Form
    {
        // Fields for drawing functionality
        private Point lastPoint = Point.Empty;
        private bool isMouseDown = false;
        private Color currentColor = Color.Black;
        private Color previousColor = Color.Black;
        private bool isEraserMode = false;
        private float lineSize = 2.0f;
        private Graphics graphics;
        private Label gameCodeLabel; // Label for displaying the game code

        // Game-related fields
        private string currentWord;
        private HashSet<char> guessedLetters = new HashSet<char>();
        private List<string> wordsToDraw = new List<string> { "apple", "banana", "cat", "dog", "duck", "house" };
        private int gameNumber;
        private string accessCode;

        public Game_Frm(string accessCode, int gameNumber)
        {
            InitializeComponent();
            this.accessCode = accessCode;
            this.gameNumber = gameNumber;

            // Initialize and display the game code label
            gameCodeLabel = new Label();
            gameCodeLabel.Text = $"Game Code: {accessCode}";
            Controls.Add(gameCodeLabel);

            // Display the initial word to be drawn and guessed
            DisplayRandomWord();
            DisplayGuessedWord();

            // Initialize the graphics object for drawing
            graphics = drawing_ptr.CreateGraphics();
        }

        // Event handler for the "Create Game" button
        private void CreateGame_btn_Click(object sender, EventArgs e)
        {
            string accessCode = CreateGame();
            gameCodeLabel.Text = $"Game Code: {accessCode}";
        }

        // Event handler for the "Join Game" button
        private async void JoinGame_btn_Click(object sender, EventArgs e)
        {
            JoinGameForm joinGameForm = new JoinGameForm();
            DialogResult result = joinGameForm.ShowDialog();
            string enteredCode = ShowJoinGameForm();

            if (!string.IsNullOrWhiteSpace(enteredCode))
            {
                await Program.StartMultiplayerGame(enteredCode, gameNumber);
            }
            else
            {
                MessageBox.Show("Invalid game code. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to display the "Join Game" form and retrieve entered code
        private string ShowJoinGameForm()
        {
            JoinGameForm joinGameForm = new JoinGameForm();
            DialogResult result = joinGameForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                return joinGameForm.EnteredCode;
            }

            return null;
        }

        // Method to create a new game and return the access code
        private string CreateGame()
        {
            // Add logic to create a new multiplayer game and return the access code
            // For example, generate a random access code and start the server
            return "ABC123";
        }

        // Method to get a random word from the list
        private void GetRandomWord()
        {
            Random random = new Random();
            int index = random.Next(wordsToDraw.Count);
            currentWord = wordsToDraw[index];
        }

        // Method to display the initial word to be drawn
        private void DisplayRandomWord()
        {
            GetRandomWord();
            string puzzleFormat = string.Join(" ", currentWord.Select(c => "_"));
            wordToDraw_lbl.Text = $"Draw: {puzzleFormat}";
        }

        // Method to display the guessed word, updating the UI
        private void DisplayGuessedWord()
        {
            StringBuilder displayWord = new StringBuilder();

            for (int i = 0; i < currentWord.Length; i++)
            {
                char currentChar = currentWord[i];

                if (guessedLetters.Contains(currentChar))
                {
                    displayWord.Append(currentChar);
                }
                else
                {
                    displayWord.Append("_");
                }

                if (i < currentWord.Length - 1)
                {
                    displayWord.Append(" ");
                }
            }

            wordToDraw_lbl.Text = $"Draw: {displayWord.ToString()}";

            if (displayWord.ToString().Replace(" ", "") == currentWord)
            {
                AddMessage("System", $"Congratulations! You found the word '{currentWord}'!");
            }
        }

        // Method to add a message to the chat ListBox
        private void AddMessage(string sender, string message)
        {
            string formattedMessage = $"{sender}: {message}";
            chat_lst.Items.Add(formattedMessage);
            chat_lst.SelectedIndex = chat_lst.Items.Count - 1;
        }

        // Event handler for the mouse down event on the drawing panel
        private void drawing_ptr_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isMouseDown = true;
        }

        // Event handler for the mouse move event on the drawing panel
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

        // Event handler for the mouse up event on the drawing panel
        private void drawing_ptr_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            lastPoint = Point.Empty;

            // Add logic to send drawing update to the server
            Point startPoint = e.Location;
            Point endPoint = e.Location;

            Task.Run(() => SendDrawingUpdateToServer(startPoint, endPoint));
        }

        // Async method to send drawing update to the server
        private async Task SendDrawingUpdateToServer(Point startPoint, Point endPoint)
        {
            // Add logic to send drawing update to the server
            // For example: await Program.SendDrawingUpdateToServer(startPoint, endPoint);
        }

        // Event handler for the "Select Color" button
        private void selectColor_btn_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color;
            }
        }

        // Event handler for the "Reset" button
        private void reset_btn_Click(object sender, EventArgs e)
        {
            drawing_ptr.Image = null;
        }

        // Event handler for the "Select Eraser" button
        private void selectEraser_btn_Click(object sender, EventArgs e)
        {
            if (isEraserMode)
            {
                currentColor = previousColor;
            }
            else
            {
                previousColor = currentColor;
                currentColor = Color.White;
            }

            isEraserMode = !isEraserMode;
            drawing_ptr.Invalidate();
        }

        // Event handler for the "Send" button
        private void send_btn_Click(object sender, EventArgs e)
        {
            string message = send_txt.Text;

            if (!string.IsNullOrWhiteSpace(message))
            {
                AddMessage("Me", message);
                send_txt.Clear();
            }
        }

        // Event handler for the "Enter" key press in the text box
        private void send_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string guessedText = send_txt.Text.Trim().ToLower();

                if (!string.IsNullOrWhiteSpace(guessedText))
                {
                    if (guessedText == currentWord)
                    {
                        guessedLetters = new HashSet<char>(currentWord.ToLower());
                        DisplayGuessedWord();
                    }
                    else
                    {
                        foreach (char guessedLetter in guessedText)
                        {
                            if (currentWord.ToLower().Contains(guessedLetter) && !guessedLetters.Contains(guessedLetter))
                            {
                                guessedLetters.Add(guessedLetter);
                            }
                        }

                        DisplayGuessedWord();
                    }

                    send_txt.Clear();
                }

                e.Handled = true;
            }
        }

        // Event handler for the "Increase Size" button
        private void sizeIncrease_btn_Click(object sender, EventArgs e)
        {
            lineSize += 1.0f;
        }

        // Event handler for the "Decrease Size" button
        private void sizeDecrease_btn_Click(object sender, EventArgs e)
        {
            lineSize = Math.Max(1.0f, lineSize - 1.0f);
        }

        // Event handler for the "Download" button
        private void download_btn_Click(object sender, EventArgs e)
        {
            if (drawing_ptr.Image != null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PNG files (*.png)|*.png";
                saveDialog.Title = "Save Drawing As PNG";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    drawing_ptr.Image.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            else
            {
                MessageBox.Show("No drawing to save", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Async method to connect to the local server
        private async Task ConnectToLocalServerAsync()
        {
            try
            {
                if (!CheckAccessCode())
                {
                    MessageBox.Show("Incorrect access code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Initialize TCP client and connect to the server
                tcpClient = new TcpClient();
                await tcpClient.ConnectAsync("127.0.0.1", 12345);
                stream = tcpClient.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream) { AutoFlush = true };

                // Start a task to receive updates from the server
                Task.Run(() => ReceiveUpdatesFromServer());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Async method to continuously receive updates from the server
        private async Task ReceiveUpdatesFromServer()
        {
            try
            {
                while (true)
                {
                    // Read a line of data from the server
                    string data = await reader.ReadLineAsync();

                    if (data != null)
                    {
                        // Process the received update
                        ProcessServerUpdate(data);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error communicating with the server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Async method to send a drawing update to the server
        private async Task SendDrawingUpdateToServer(Point startPoint, Point endPoint)
        {
            await writer.WriteLineAsync($"DRAW|{startPoint.X},{startPoint.Y},{endPoint.X},{endPoint.Y}");
        }

        // Method to process a drawing update received from the server
        private void ProcessServerUpdate(string update)
        {
            string[] parts = update.Split('|');

            if (parts.Length == 2 && parts[0] == "DRAW")
            {
                string[] coordinates = parts[1].Split(',');

                if (coordinates.Length == 4)
                {
                    int startX = int.Parse(coordinates[0]);
                    int startY = int.Parse(coordinates[1]);
                    int endX = int.Parse(coordinates[2]);
                    int endY = int.Parse(coordinates[3]);

                    using (Pen pen = new Pen(currentColor, lineSize))
                    {
                        graphics.DrawLine(pen, startX, startY, endX, endY);
                    }
                }
            }
        }

        // Method to check the access code by displaying a form
        private bool CheckAccessCode()
        {
            AccessCodeForm accessCodeForm = new AccessCodeForm();
            DialogResult result = accessCodeForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                return accessCodeForm.EnteredCode == accessCode;
            }

            return false;
        }

        // Event handler for the form closing event
        private void Game_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
