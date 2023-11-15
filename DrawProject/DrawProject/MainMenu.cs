namespace DrawProject
{
    public partial class MainMenu_Box : Form
    {
        public MainMenu_Box()
        {
            InitializeComponent();
        }

        private void HowToPlay_Button_Click(object sender, EventArgs e)
        {
            Form f2 = new Form();

            this.Hide();

            HowToPlay.show
        }

        private void Quit_Button_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}