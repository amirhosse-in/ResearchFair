using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ResearchFair
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            statistics STC = new statistics();
            STC.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (algoritma.ramz == "User")
            {
                button2.Enabled = true;
            }
            else if (algoritma.ramz == "Accepted")
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nazarsanji ns = new nazarsanji();
            ns.Show();
       
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void closeThisWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            About aa = new About();
            aa.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Raiting rt = new Raiting();
            rt.Show();
            this.Hide(); 
        }
    }
}
