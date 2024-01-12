namespace DrawProject
{
    public partial class MainMenu_Frm : Form
    {
        // Constructor for the MainMenu form
        public MainMenu_Frm()
        {
            InitializeComponent();
        }

        // Event handler for the HowToPlay button click
        private void HowToPlay_Button_Click(object sender, EventArgs e)
        {
            // Create a new instance of the HowToPlay_Frm form for single-player mode
            HowToPlay_Frm howToPlay = new HowToPlay_Frm(false, "", 0); // Update accordingly
            howToPlay.Show();

            // Hide the current form
            this.Hide();
        }

        // Event handler for the Quit button click
        private void Quit_Button_Click(object sender, EventArgs e)
        {
            // Exit the application
            Application.Exit();
        }

        // Event handler for the Play button click
        private void Play_Button_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Game_Frm form for single-player mode
            Game_Frm game = new Game_Frm("", 0); // Update accordingly
            game.Show();

            // Hide the current form
            this.Hide();

            // Access the access code from the Game form
            string accessCode = game.AccessCode;
        }

        // Event handler for the Create Game button click
        private void CreateGame_Button_Click(object sender, EventArgs e)
        {
            // Placeholder for the logic to create a new multiplayer game
            string accessCode = CreateGame();
            // gameCodeLabel.Text = $"Game Code: {accessCode}";
        }

        // Event handler for the Join Game button click
        private async void JoinGame_Button_Click(object sender, EventArgs e)
        {
            // Show the JoinGameForm and get the entered code
            string enteredCode = ShowJoinGameForm();

            if (!string.IsNullOrWhiteSpace(enteredCode))
            {
                // Start the multiplayer game with the entered code and game number 0
                await Program.StartMultiplayerGame(enteredCode, 0);
            }
            else
            {
                // Show an error message for invalid game code
                MessageBox.Show("Invalid game code. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to show the JoinGameForm and get the entered code
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

        // Method to create a new multiplayer game and return the access code
        private string CreateGame()
        {
            // Add logic to create a new multiplayer game and return the access code
            // For example, generate a random access code and start the server
            return "ABC123";
        }

        // Event handler for the form closing event
        private void MainMenu_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Exit the application when the MainMenu form is closed
            Application.Exit();
        }
    }
}
