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
        public HowToPlay_Frm()
        {
            InitializeComponent();
        }

        // Event handler for the "Back to Menu" button click
        private void BackToMenu_Btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the MainMenu_Frm and show it
            MainMenu_Frm mainMenu_Frm = new MainMenu_Frm();
            mainMenu_Frm.Show();

            // Hide the current form (HowToPlay_Frm)
            this.Hide();
        }

        // Event handler for the form load
        private void HowToPlay_Frm_Load(object sender, EventArgs e)
        {
            // Set the selection start of the Description_TxtBox to the end for scrolling to the bottom
            Description_TxtBox.SelectionStart = Description_TxtBox.Text.Length;
        }

        // Event handler for the form closing
        private void HowToPlay_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Exit the application when the form is closing
            Application.Exit();
        }
    }
}
