// Libraries
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawProject
{
    public partial class HowToPlay_Frm : Form
    {
        private bool IsMultiplayerGame { get; set; }
        private string AccessCode { get; set; }
        private int GameNumber { get; set; }

        public HowToPlay_Frm(bool isMultiplayerGame, string accessCode, int gameNumber)
        {
            InitializeComponent();
            IsMultiplayerGame = isMultiplayerGame;
            AccessCode = accessCode;
            GameNumber = gameNumber;
        }

        private void BackToMenu_Btn_Click(object sender, EventArgs e)
        {
            MainMenu_Frm mainMenu_Frm = new MainMenu_Frm();
            mainMenu_Frm.Show();
            this.Hide();
        }

        private async void MultiplayerHowToPlay_Frm_Load(object sender, EventArgs e)
        {
            if (IsMultiplayerGame)
            {
                await Program.StartMultiplayerGame(AccessCode, GameNumber);
            }
            else
            {
                Description_TxtBox.SelectionStart = Description_TxtBox.Text.Length;
            }
        }

        private void HowToPlay_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
