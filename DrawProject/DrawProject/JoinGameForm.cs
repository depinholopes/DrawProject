using System;
using System.Windows.Forms;

namespace DrawProject
{
    // Partial class for the JoinGameForm
    public partial class JoinGameForm : Form
    {
        // Property to get the entered code
        public string EnteredCode { get; private set; }

        // Constructor for the JoinGameForm
        public JoinGameForm()
        {
            InitializeComponent();
        }

        // Event handler for the join game button click
        private void joinGame_btn_Click(object sender, EventArgs e)
        {
            // Set the entered code from the text box and close the form
            EnteredCode = gameCode_txt.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        // Event handler for the cancel button click
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            // Close the form without setting the code
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
