﻿using System;
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

        private void BackToMenu_Btn_Click(object sender, EventArgs e)
        {
            MainMenu_Frm mainMenu_Frm = new MainMenu_Frm();
            mainMenu_Frm.Show();
            this.Close();
        }

        private void HowToPlay_Frm_Load(object sender, EventArgs e)
        {
            Description_TxtBox.SelectionStart = Description_TxtBox.Text.Length;
        }
        private void HowToPlay_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }   
    }
}
