using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace ResearchFair
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "User" || textBox1.Text == "user" || textBox1.Text == "Helli9" || textBox1.Text == "helli9")
            {
                algoritma.ramz = "User";
                Form1 ffrm = new Form1();
                ffrm.Show();
                this.Hide();
            }
            else if (textBox1.Text == "admindg")
            {
                algoritma.ramz = "Accepted";
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("رمز وارد شده صحیح نیست", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void checkBox1_MouseDown(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = true;
            textBox1.UseSystemPasswordChar = false;
        }
        private void checkBox1_MouseUp(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = false;
            textBox1.UseSystemPasswordChar = true;
        }

        private void Password_Load(object sender, EventArgs e)
        {
            
        }
    }
}
