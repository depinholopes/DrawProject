namespace DrawProject
{
    public partial class MainMenu_Frm : Form
    {
        public MainMenu_Frm()
        {
            InitializeComponent();

            // Le constructeur de la classe, généralement utilisé pour initialiser les composants de l'interface utilisateur.
        }

        private void HowToPlay_Button_Click(object sender, EventArgs e)
        {
            // Gestionnaire d'événements appelé lorsque le bouton "HowToPlay" est cliqué.

            // Créer une nouvelle instance du formulaire HowToPlay_Frm
            HowToPlay_Frm howToPlay = new HowToPlay_Frm();

            // Afficher le formulaire HowToPlay_Frm
            howToPlay.Show();

            // Masquer le formulaire MainMenu_Frm actuel
            this.Hide();
        }

        private void Quit_Button_Click(object sender, EventArgs e)
        {
            // Gestionnaire d'événements appelé lorsque le bouton "Quit" est cliqué.

            // Quitter l'application
            Application.Exit();
        }

        private void MainMenu_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Gestionnaire d'événements appelé lorsque le formulaire MainMenu_Frm est en cours de fermeture.

            // Par défaut, Application.Exit() fermera l'ensemble de l'application
            Application.Exit();
        }

        private void Play_Button_Click(object sender, EventArgs e)
        {
            // Gestionnaire d'événements appelé lorsque le bouton "Play" est cliqué.

            // Créer une nouvelle instance du formulaire Game_Frm
            Game_Frm game = new Game_Frm();

            // Afficher le formulaire Game_Frm
            game.Show();

            // Masquer le formulaire MainMenu_Frm actuel
            this.Hide();
        }
    }
}