using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace ResearchFair
{
    public partial class Raiting : Form
    {
        OpenFileDialog OpenData = new OpenFileDialog();
        SaveFileDialog SaveData = new SaveFileDialog();
        string rate = "";
        bool first = true;
        public Raiting()
        {
            InitializeComponent();
        }

        private void Raiting_Load(object sender, EventArgs e)
        {
            //Data base File (*.rf) |*.rf
            OpenData.Filter = "Rating File (*.ns) |*.ns";
            if (OpenData.ShowDialog() == DialogResult.OK)
            {
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            string data = "";
            bool yaddasht = false;
            bool emal = false;
            string notet = "";
            string fullnote = "";
            {  
                
            if (email.Text == "")
            {
                emal = false;
            }
            else if (email.Text != "")
            {
                emal = true;
            }
            }
            {
             
                if (note.Text == "")
                {
                    yaddasht = false;
                }
                else if (note.Text != "")
                {
                    yaddasht = true;
                }
                    }
            if (rate != "" & numericUpDown1.Value.ToString() != "0" & school.Text != "")
            {
                data = rate + "♫" + numericUpDown1.Value.ToString() + "♫" + school.Text;
                if (yaddasht == true)
                {
                    notet = note.Text.Replace(' ', '_');
                    fullnote = notet.Replace('\n', '•');
                    data += "♫" + fullnote;
                }
                if (emal == true)
                {
                    data += "♫" + email.Text;
                }
                listBox1.Items.Add(data);
            }
            else if (numericUpDown1.Value.ToString() == "0"|school.Text == ""|rate == "")
            {
                MessageBox.Show("اطلاعات به درستی وارد نشده است.", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
             
        }

        private void awli_CheckedChanged(object sender, EventArgs e)
        {
            if (awli.Checked == true)
            {
                rate = "ali";
            }
        }

        private void khoob_CheckedChanged(object sender, EventArgs e)
        {
            if (khoob.Checked == true)
            {
                rate = "khoob";
            }
        }

        private void motavaset_CheckedChanged(object sender, EventArgs e)
        {
            if (motavaset.Checked == true)
            {
                rate = "motavaset";
            }

        }

        private void zaiif_CheckedChanged(object sender, EventArgs e)
        {
            if (motavaset.Checked == true)
            {
                rate = "zaiif";
            }
        }

        private void daghoon_CheckedChanged(object sender, EventArgs e)
        {
            if (daghoon.Checked == true)
            {
                rate = "daghoon";
            }
        }

        private void checkBox1_MouseDown(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = true;
            email.UseSystemPasswordChar = false;

        }

        private void checkBox1_MouseUp(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = false;
            email.UseSystemPasswordChar = true;
        }
    }
}
            
