using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_zespolowy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();  //seed randoma
            int dice01 = 0;         // pierwsza kosc
            int dice02 = 0;         // druga kosc
            int roll = 0;           // wartosc rzutu 

            dice01 = rnd.Next(1, 7); //losuje liczbe int od 1 do 6
            dice02 = rnd.Next(1, 7); //losuje liczbe int od 1 do 6

            roll = dice01 + dice02;

            // MessageBox.Show("dice 1: " + dice01 + "\ndice 2: " + dice02 + "\n roll  : " + roll);

            for (int i = 0; i < 30; i++)
            {
                dice01 = rnd.Next(1, 7);
                dice02 = rnd.Next(1, 7);
                roll = dice01 + dice02;
                Console.WriteLine(dice01 + "\t" + dice02 + "\t" + roll);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
