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
using System.Xml.Serialization;

namespace ResearchFair
{
    public partial class nazarsanji : Form
    {
     
        public nazarsanji()
        {
            InitializeComponent();
        }

        private void nazarsanji_Load(object sender, EventArgs e)
        {
            DialogResult s = MessageBox.Show("آیا مایلید فایل دیتابیس را بارگذاری کنید ؟", "بارگذاری دیتابیس", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (s == DialogResult.Yes)
            {

                LOL.Filter = "Data base File (*.RFDM) |*.RFDM";

                if (LOL.ShowDialog() == DialogResult.OK && LOL.FileName != "")
                {
                    algoritma.Close_Nazarsajni = "false";
                    List<object> Data = new List<object>();

                    XmlSerializer Ser = new XmlSerializer(typeof(List<object>));

                    using (StreamReader Reader = new StreamReader(LOL.FileName))
                    {
                        Data = (List<object>)Ser.Deserialize(Reader);

                        foreach (object obj in Data)
                        {
                            listBox1.Items.Add(obj);
                        }
                    }
                    int loloe = listBox1.Items.Count;
                    int maskhare = 0;
                    for (int z = 0; z < loloe; z++)
                    {
                        string zi = listBox1.Items[z].ToString();
                        if (maskhare == 0)
                        {
                            if (zi == "Amnam")
                            {
                                maskhare = 1;

                            }
                            else if (zi != "Amnam")
                            {
                                Madares.Items.Add(zi);
                            }
                        }
                        else if (maskhare == 1)
                        {
                            Omoomi.Items.Add(zi);
                        }

                    }

                    int sampad = 0;
                    int nemoone = 0;
                    int dolati = 0;
                    int gheir = 0;
                    int pesar = 0;
                    int dokhtar = 0;
                    int afrad = 0;
                    int pesaroone =0;
                    int dokhtaroone=0;
                    int kindkind = 0;
                    for (int alaki = 0; alaki < Madares.Items.Count; alaki++)
                    {
                        string[] Coder_Man = Madares.Items[alaki].ToString().Split(' ');
                        string Kind = Coder_Man[1];
                        afrad += Convert.ToInt32(Coder_Man[3]);
                        string jensiat = Coder_Man[6];
                        if (jensiat == "پسرانه")
                        {
                            pesaroone += 1;
                            pesar +=Convert.ToInt32(Coder_Man[3]);
                            pesar += 1;
                        }
                        else if (jensiat == "دخترانه")
                        {
                            dokhtaroone += 1;
                            dokhtar += Convert.ToInt32(Coder_Man[3]);
                            dokhtar += 1;
                        }
                        switch (Kind)
                        {
                            case "نمونه_دولتی": nemoone += 1; break;
                            case "سمپاد": sampad += 1; break;
                            case "دولتی": dolati += 1; break;
                            case "غیر_دولتی": gheir += 1; break;
                            default: MessageBox.Show("Application has a bug :|", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        }

                    }
                    for (int sher = 0; sher < Omoomi.Items.Count; sher++)
                    {
                        string[] CODER = Omoomi.Items[sher].ToString().Split(' ');
                        string alle = CODER[3];
                        if (alle == "مونث")
                        {
                            dokhtar += 1;
                       
                        }
                        else if (alle == "مذکر")
                        {
                            pesar += 1;
                       
                        }
                    }
                    //sarparast count
                    afrad =afrad+ Madares.Items.Count;
                    afrad += Omoomi.Items.Count;
                    int LOLL = nemoone + gheir + sampad + dolati;
                    int lolol = pesar + dokhtar;
                    chart1.Series["KINDS"].Points.AddXY("(" + Math.Round((Convert.ToDouble(sampad) / LOLL) * 100).ToString() + "%" + ")سمپاد", sampad);
                    chart1.Series["KINDS"].Points.AddXY("(" + Math.Round((Convert.ToDouble(nemoone) / LOLL) * 100).ToString() + "%" + ")نمونه دولتی", nemoone);
                    chart1.Series["KINDS"].Points.AddXY("(" + Math.Round((Convert.ToDouble(dolati) / LOLL) * 100).ToString() + "%" + ")دولتی", dolati);
                    chart1.Series["KINDS"].Points.AddXY("(" + Math.Round((Convert.ToDouble(gheir) / LOLL) * 100).ToString() + "%" + ")غیر دولتی", gheir);
                    SCHART.Series["SEX"].Points.AddXY("(" + Math.Round((Convert.ToDouble(pesar) / lolol) * 100).ToString() + "%" + ")مذکر", pesar);
                    SCHART.Series["SEX"].Points.AddXY("(" + Math.Round((Convert.ToDouble(dokhtar) / lolol) * 100).ToString() + "%" + ")مونث", dokhtar);
                    label1.Text =  afrad.ToString();
                    label2.Text = pesar.ToString();
                    label3.Text = dokhtar.ToString();
                    chart2.Series["Man"].Points.AddXY("کل مراجعه کنندگان"+(afrad.ToString()), afrad);
                    chart2.Series["Man"].Points.AddXY("(" + Math.Round((Convert.ToDouble(pesar) / lolol) * 100).ToString() + "%" + ")مذکر", pesar);
                    chart2.Series["Man"].Points.AddXY("(" + Math.Round((Convert.ToDouble(dokhtar) / lolol) * 100).ToString() + "%" + ")مونث", dokhtar);
                    timer1.Enabled = true;
                }
                else { this.Hide(); this.Close(); }                                                     
            
                  

                }
                else if (s == DialogResult.No)
                {
                    MessageBox.Show("Load DataBase", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Form1 frm = new Form1();
                    //frm.show();
                    nazarsanji ns = new nazarsanji();
                    this.Close();
                
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (algoritma.Close_Nazarsajni == "true")
            {
                //nazarsanji nrc = new nazarsanji();
                this.Close();
            }
            else
            {
                chart1.Series["KINDS"].Points.Clear();
                SCHART.Series["SEX"].Points.Clear();
                chart2.Series["Man"].Points.Clear();
                listBox1.Items.Clear();
                Omoomi.Items.Clear();
                Madares.Items.Clear();
                List<object> Data = new List<object>();

                XmlSerializer Ser = new XmlSerializer(typeof(List<object>));

                using (StreamReader Reader = new StreamReader(LOL.FileName))
                {
                    Data = (List<object>)Ser.Deserialize(Reader);

                    foreach (object obj in Data)
                    {
                        listBox1.Items.Add(obj);
                    }
                }
                int loloe = listBox1.Items.Count;
                int maskhare = 0;
                for (int z = 0; z < loloe; z++)
                {
                    string zi = listBox1.Items[z].ToString();
                    if (maskhare == 0)
                    {
                        if (zi == "Amnam")
                        {
                            maskhare = 1;

                        }
                        else if (zi != "Amnam")
                        {
                            Madares.Items.Add(zi);
                        }
                    }
                    else if (maskhare == 1)
                    {
                        Omoomi.Items.Add(zi);
                    }

                }

                int sampad = 0;
                int nemoone = 0;
                int dolati = 0;
                int gheir = 0;
                int pesar = 0;
                int dokhtar = 0;
                int afrad = 0;
                int pesaroone = 0;
                int dokhtaroone = 0;
                int kindkind = 0;
                for (int alaki = 0; alaki < Madares.Items.Count; alaki++)
                {
                    string[] Coder_Man = Madares.Items[alaki].ToString().Split(' ');
                    string Kind = Coder_Man[1];
                    afrad += Convert.ToInt32(Coder_Man[3]);
                    string jensiat = Coder_Man[6];
                    if (jensiat == "پسرانه")
                    {
                        pesaroone += 1;
                        pesar += Convert.ToInt32(Coder_Man[3]);
                        pesar += 1;
                    }
                    else if (jensiat == "دخترانه")
                    {
                        dokhtaroone += 1;
                        dokhtar += Convert.ToInt32(Coder_Man[3]);
                        dokhtar += 1;
                    }
                    switch (Kind)
                    {
                        case "نمونه_دولتی": nemoone += 1; break;
                        case "سمپاد": sampad += 1; break;
                        case "دولتی": dolati += 1; break;
                        case "غیر_دولتی": gheir += 1; break;
                        default: MessageBox.Show("Application has a bug :|", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                    }

                }
                for (int sher = 0; sher < Omoomi.Items.Count; sher++)
                {
                    string[] CODER = Omoomi.Items[sher].ToString().Split(' ');
                    string AAAA = CODER[3];
                    if (AAAA == "مونث")
                    {
                        dokhtar += 1;

                    }
                    else if (AAAA == "مذکر")
                    {
                        pesar += 1;

                    }
                }
                //sarparast count
                afrad = afrad + Madares.Items.Count;
                afrad += Omoomi.Items.Count;
                int LOLL = nemoone + gheir + sampad + dolati;
                int lolol = pesar + dokhtar;
                chart1.Series["KINDS"].Points.AddXY("(" + Math.Round((Convert.ToDouble(sampad) / LOLL) * 100).ToString() + "%" + ")سمپاد", sampad);
                chart1.Series["KINDS"].Points.AddXY("(" + Math.Round((Convert.ToDouble(nemoone) / LOLL) * 100).ToString() + "%" + ")نمونه دولتی", nemoone);
                chart1.Series["KINDS"].Points.AddXY("(" + Math.Round((Convert.ToDouble(dolati) / LOLL) * 100).ToString() + "%" + ")دولتی", dolati);
                chart1.Series["KINDS"].Points.AddXY("(" + Math.Round((Convert.ToDouble(gheir) / LOLL) * 100).ToString() + "%" + ")غیر دولتی", gheir);
                SCHART.Series["SEX"].Points.AddXY("(" + Math.Round((Convert.ToDouble(pesar) / lolol) * 100).ToString() + "%" + ")مذکر", pesar);
                SCHART.Series["SEX"].Points.AddXY("(" + Math.Round((Convert.ToDouble(dokhtar) / lolol) * 100).ToString() + "%" + ")مونث", dokhtar);
                label1.Text = afrad.ToString();
                label2.Text = pesar.ToString();
                label3.Text = dokhtar.ToString();
                
                chart2.Series["Man"].Points.AddXY("مذکر",pesar);
                chart2.Series["Man"].Points.AddXY("مونث",dokhtar);
                //timer1.Enabled = true;
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
            }
            else if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
            }
        }

        private void closeThisWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About aa = new About();
            aa.Show();
        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
