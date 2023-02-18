﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_tac_toe
{
    public partial class FormPlayerVsPlayer : Form
    {
        bool turn = true; //true = left Turn; false = right turn
        public bool Turn
        {
            get
            {
                return turn;
            }
            set
            {
                turn = value;
            }
        }
        int turn_count = 0;
        public int Turn_Count
        {
            get
            {
                return turn_count;
            }
            set
            {
                turn_count = value;
            }
        }
        public FormPlayerVsPlayer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (turn)
            {
                button.Tag = "X";
                button.BackgroundImage = Tic_tac_toe.Properties.Resources.x;
                button.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                button.Tag = "O";
                button.BackgroundImage = Tic_tac_toe.Properties.Resources.O;
                button.BackgroundImageLayout = ImageLayout.Stretch;
            }
            turn = !turn;
            button.Enabled = false;
            turn_count++;
            CheckWinner();
        }
        public void CheckWinner()
        {
            bool there_is_a_winner = false;
            //
            // horizontal check
            if ((A1.Tag == A2.Tag) && (A2.Tag == A3.Tag) && !A1.Enabled)
            {
                there_is_a_winner = true;
            }
            else if ((B1.Tag == B2.Tag) && (B2.Tag == B3.Tag) && !B1.Enabled)
            {
                there_is_a_winner = true;
            }
            else if ((C1.Tag == C2.Tag) && (C2.Tag == C3.Tag) && !C1.Enabled)
            {
                there_is_a_winner = true;
            }

            //
            // vertical check
            if ((A1.Tag == B1.Tag) && (B1.Tag == C1.Tag) && !A1.Enabled)
            {
                there_is_a_winner = true;
            }
            else if ((A2.Tag == B2.Tag) && (B2.Tag == C2.Tag) && !A2.Enabled)
            {
                there_is_a_winner = true;
            }
            else if ((A3.Tag == B3.Tag) && (B3.Tag == C3.Tag) && !A3.Enabled)
            {
                there_is_a_winner = true;
            }

            //
            // diagonal check
            if ((A1.Tag == B2.Tag) && (B2.Tag == C3.Tag) && !A1.Enabled)
            {
                there_is_a_winner = true;
            }
            else if ((A3.Tag == B2.Tag) && (B2.Tag == C1.Tag) && !A3.Enabled)
            {
                there_is_a_winner = true;
            }

            if (there_is_a_winner)
            {
                string winner = "";
                if (turn)
                {
                    winner = "O";
                }
                else
                {
                    winner = "X";
                }

                MessageBox.Show($"{winner} is win!");
                DisableButton();
                return;
            }
            if (turn_count == 9)
            {
                MessageBox.Show("Draw!");
                return;
            }

        }
        public void DisableButton()
        {
            foreach (Button button in panel1.Controls)
            {
                button.Enabled = false;
            }
        }

        #region Menu Events
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            foreach (Button button in panel1.Controls)
            {
                button.Enabled = true;
                button.Tag = "";
                button.BackgroundImage = null;
            }
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }
        #endregion


    }
}
