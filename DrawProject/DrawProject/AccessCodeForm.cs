using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawProject
{
    internal class AccessCodeForm : Form
    {
        private TextBox codeTextBox;
        private Button okButton;

        public string EnteredCode { get; private set; }

        public AccessCodeForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Ajoutez ici le code pour créer les composants du formulaire (TextBox, Button, etc.)
            // N'oubliez pas de définir le gestionnaire d'événements pour le bouton OK
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            // Récupérez le code saisi par l'utilisateur
            EnteredCode = codeTextBox.Text;
            // Fermez le formulaire
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
