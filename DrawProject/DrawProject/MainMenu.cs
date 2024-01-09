namespace DrawProject
{
    // The MainMenu_Frm class, representing the main menu form
    public partial class MainMenu_Frm : Form
    {

        // Constructor for the MainMenu_Frm class
        public MainMenu_Frm()
        {
            // Initialize the components, typically used to initialize the user interface components.
            InitializeComponent();
        }

        // Event handler for the "HowToPlay" button click
        private void HowToPlay_Button_Click(object sender, EventArgs e)
        {
            // Create a new instance of the HowToPlay_Frm form
            HowToPlay_Frm howToPlay = new HowToPlay_Frm();

            // Show the HowToPlay_Frm form
            howToPlay.Show();

            // Hide the current MainMenu_Frm form
            this.Hide();
        }

        // Event handler for the "Quit" button click
        private void Quit_Button_Click(object sender, EventArgs e)
        {
            // Exit the application
            Application.Exit();
        }

        // Event handler for the closing of the MainMenu_Frm form
        private void MainMenu_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // By default, Application.Exit() will close the entire application
            Application.Exit();
        }

        // Event handler for the "Play" button click
        private void Play_Button_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Game_Frm form
            Game_Frm game = new Game_Frm();

            // Show the Game_Frm form
            game.Show();

            // Hide the current MainMenu_Frm form
            this.Hide();
        }
    }
}
