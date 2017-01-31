using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

/// <summary>
/// Miika Peltotalo
/// mvjpel@utu.fi
/// </summary>
namespace Taso3
{
    public partial class Form1 : Form
    {
        private List<Label> sanat = new List<Label>();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tarkastaa ja lisää painalluksesta uuden tekstin listaan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLisaa_Click(object sender, EventArgs e)
        {            
            String s = textBoxLisaa.Text.Trim();            

            if ( String.IsNullOrEmpty(s) )
            {
                MessageBox.Show("Yritit lisätä tyhjää!");
                return;
            }

            Random r = new Random();
            Label teksti = new System.Windows.Forms.Label();

            teksti.AutoSize = true;
            teksti.BackColor = System.Drawing.Color.Cyan;
            teksti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            //teksti.Location = new System.Drawing.Point(3, 0);
            teksti.Name = "label1";
            teksti.Padding = new System.Windows.Forms.Padding(4);
            //teksti.Size = new System.Drawing.Size(45, 23);
            teksti.TabIndex = 1;            
            teksti.Text = s;
            flowLayoutPanel1.Controls.Add(teksti);
            sanat.Add(teksti);
            
        }

        /// <summary>
        /// Avaa about-ikkunan josta löytyy tekijän ja sovelluksen tietoja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox a = new AboutBox();
            a.ShowDialog();
        }

        /// <summary>
        /// Sulkee ohjelman
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Järjestää painalluksesta lisättyjen tekstien listan siten, että
        /// lyhin nostetaan ylimmäiseksi ja pisin jätetään viimeiseksi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonJarjesta_Click(object sender, EventArgs e)
        {
            sanat = sanat.OrderBy(o => o.Text.Length).ToList();
            flowLayoutPanel1.Controls.Clear();
            foreach (Label l in sanat)
            {                
                flowLayoutPanel1.Controls.Add(l);
            }                               
        }

        /// <summary>
        /// Poistaa tuplaklikkauksella listan viimeisen lisätyistä teksteistä.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flowLayoutPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bool tyhjä = !sanat.Any();
            if (tyhjä) return;
            flowLayoutPanel1.Controls.Remove(sanat.Last());
            sanat.Remove(sanat.Last());
        }


    }
}
