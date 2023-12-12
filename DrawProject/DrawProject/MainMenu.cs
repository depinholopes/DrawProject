namespace DrawProject
{
    public partial class MainMenu_Frm : Form
    {
        public MainMenu_Frm()
        {
            InitializeComponent();

        }

        private void HowToPlay_Button_Click(object sender, EventArgs e)
        {
            HowToPlay_Frm howToPlay = new HowToPlay_Frm();
            howToPlay.Show();
            this.Hide();
        }

        private void Quit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenu_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Vous pouvez ajouter des opérations de nettoyage ici si nécessaire

            // Par défaut, Application.Exit() fermera l'ensemble de l'application
            Application.Exit();
        }

        private void Play_Button_Click(object sender, EventArgs e)
        {
            Game_Frm game = new Game_Frm();
            game.Show();
            this.Hide();
        }
    }
}