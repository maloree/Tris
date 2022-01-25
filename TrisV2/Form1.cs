using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrisV2
{
    public partial class trisForm : Form
    {
        bool playerTurn = true;     //true = x; false = o
        int numTurn = 0;    //numero dei turni (max 9)
        bool winner = false;    //indica se è stato trovato un vincitore
        int secondi = 0;
        int minuti = 0;

        public trisForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (numTurn == 0)
                game_timer.Start(); //avvio timer
            
            if (playerTurn)     //turno player X
                b.Text = "X";
            
            else                //turno player O
                b.Text = "O";
            
            b.Enabled = false;
            winCondition();
            playerTurn = !playerTurn;   //cambio player
            numTurn++;  //incremento turno
            
            if (!winner && numTurn < 9)
            {
                if (playerTurn)
                    showPlayerTurn.Text = "X";
                else
                    showPlayerTurn.Text = "O";
            }

        }

        void winCondition() //condizioni di vittoria
        {
            //righe
            if (A1.Text == B1.Text && B1.Text == C1.Text && A1.Enabled == false)
                winner = true;
            else if (A2.Text == B2.Text && B2.Text == C2.Text && A2.Enabled == false)
                winner = true;
            else if (A3.Text == B3.Text && B3.Text == C3.Text && A3.Enabled == false)
                winner = true;
            //colonne
            else if (A1.Text == A2.Text && A2.Text == A3.Text && A1.Enabled == false)
                winner = true;
            else if (B1.Text == B2.Text && B2.Text == B3.Text && B1.Enabled == false)
                winner = true;
            else if (C1.Text == C2.Text && C2.Text == C3.Text && C1.Enabled == false)
                winner = true;
            //diagonali
            else if (A1.Text == B2.Text && B2.Text == C3.Text && A1.Enabled == false)
                winner = true;
            else if (A3.Text == B2.Text && B2.Text == C1.Text && A3.Enabled == false)
                winner = true;
            
            if (winner) //vincitore trovato
            {
                foreach (Control c in Controls) //disabilitazione pulsanti
                {
                    Button b = c as Button;
                    if (b != null)
                    {
                        b.Enabled = false;
                    }
                }

                game_timer.Stop(); //stop del timer

                if (playerTurn && winner)
                    MessageBox.Show("Ha vinto il giocatore X!", "Vittoria");
                else if (!playerTurn && winner)
                    MessageBox.Show("Ha vinto il giocatore O!", "Vittoria");
            }
            
            else if (numTurn == 8)  //pareggio
            {
                game_timer.Stop();
                MessageBox.Show("Avete pareggiato!", "Pareggio");
            }

        }
        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nuovaPartitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //reset dei valori iniziali
            playerTurn = true;
            numTurn = 0;
            winner = false;
            showPlayerTurn.Text = "X";

            foreach (Control c in Controls) //reset pulsanti
            {
                Button b = c as Button;
                if (b != null)
                {
                    b.Enabled = true;
                    b.Text = "";
                }
            }

            lbl_tempo.Text = "00:00";
            secondi = 0;
            minuti = 0;
            game_timer.Stop();  //stop del timer
        }

        //stampa delle informazioni sul creatore
        private void creatoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe", "https://github.com/maloree");
        }
        private void game_timer_Tick(object sender, EventArgs e)    //cronometro
        {
            secondi++;
            if (secondi == 60) 
            {
                secondi = 0;
                minuti++;
            }

            if (secondi <= 59 && minuti <= 9)
            {
                if (secondi <= 9)
                    lbl_tempo.Text = "0" + minuti + ":" + "0" + Convert.ToString(secondi);
                else
                    lbl_tempo.Text = "0" + minuti + ":" + Convert.ToString(secondi);
            }

            else if (minuti > 9)
            {
                if (secondi <= 9)
                    lbl_tempo.Text = minuti + ":" + "0" + Convert.ToString(secondi);
                else
                    lbl_tempo.Text = minuti + ":" + Convert.ToString(secondi);
            }

            if (secondi == 59 && minuti == 59) 
            {
                game_timer.Stop();
                var ris = MessageBox.Show("Sembra che tu abbia giocato troppo tempo, è ora di prendersi una pausa.", "Attenzione!", MessageBoxButtons.OK);
                if (ris == DialogResult.OK)
                    Application.Exit();
            }
        }

        private void informazioniToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 info = new Form2();
            info.ShowDialog();
        }
    }
}
