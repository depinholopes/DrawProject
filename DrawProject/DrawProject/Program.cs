/**
 * 
 * Author       : Daniel de Pinho Lopes Ferreira
 * Project      : DrawProject
 * Description  : It's a game where, in turn, you draw a word given at the start of the round and the others have to find out what you're drawing.
 * Version      : 0.2, dated 12.01.2024
 * 
 * */

// Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawProject
{
    static class Program
    {
        // Main entry point for the application
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create an instance of the MainMenu_Frm form
            MainMenu_Frm mainMenu = new MainMenu_Frm();

            // Run the application with the MainMenu_Frm form
            Application.Run(mainMenu);
        }

        // Method to start the multiplayer game
        public static async Task StartMultiplayerGame(string accessCode, int gameNumber)
        {
            // Create an instance of the Game_Frm form with the provided access code and game number
            Game_Frm gameForm = new Game_Frm(accessCode, gameNumber);

            // Connect to the local server
            await gameForm.ConnectToLocalServerAsync();

            // Show the Game_Frm form
            gameForm.Show();

            // Hide the current MainMenu_Frm form
            foreach (Form form in Application.OpenForms)
            {
                if (form is MainMenu_Frm)
                {
                    form.Hide();
                    break;
                }
            }
        }

        // Method to create and show the main menu form
        public static void ShowMainMenu()
        {
            // Create an instance of the MainMenu_Frm form
            MainMenu_Frm mainMenu = new MainMenu_Frm();

            // Show the MainMenu_Frm form
            mainMenu.Show();
        }
    }
}