using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DrawProject
{
    public partial class Game_Frm : Form
    {
        private TcpClient tcpClient;
        private NetworkStream stream;

        // Méthode pour se connecter au serveur local
        private async Task ConnectToLocalServerAsync()
        {
            try
            {
                tcpClient = new TcpClient();
                await tcpClient.ConnectAsync("127.0.0.1", 12345); // Utilisez l'adresse IP locale
                stream = tcpClient.GetStream();

                // TODO: Envoyer des données au serveur et recevoir les mises à jour
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de connexion au serveur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Méthode pour envoyer des données au serveur local
        private async Task SendDataToLocalServerAsync(string data)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            await stream.WriteAsync(buffer, 0, buffer.Length);
        }

        // TODO: Créer des méthodes pour recevoir et traiter les données du serveur
    }
}
