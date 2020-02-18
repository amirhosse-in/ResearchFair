using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using People;



namespace ResearchFair
{
    
    public partial class statistics : Form
    {
        string noemoraje;
        int Barresi = 0;
        nazarsanji nrc = new nazarsanji();
        SaveFileDialog sddd = new SaveFileDialog();
        public statistics()
        {
            
          
          
            InitializeComponent();
        }
        string filename = "";

        public object Now { get; private set; }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (StudentsValue.Text != "")
            //{
            //    StudentsValue.Text = Convert.ToString(Convert.ToInt32(StudentsValue.Text) + 1);
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (StudentsValue.Text != "")
            //{
            //    if (StudentsValue.Text != "0")
            //    {
            //        StudentsValue.Text = Convert.ToString(Convert.ToInt32(StudentsValue.Text) - 1);
            //    }
            //}
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
             noemoraje = "عمومی";
                groupBox5.Visible = radioButton4.Checked;
                groupBox4.Visible = false;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int id = 0;
            for (int i = 0; i <= dgv1.Rows.Count - 1; i++)
            {
                if (id < int.Parse(dgv1.Rows[i].Cells[0].Value.ToString()))
                {
                    id = int.Parse(dgv1.Rows[i].Cells[0].Value.ToString());
                }
            }
            // MessageBox.Show(id.ToString());
            string kind = "";
            if (gheir.Checked)
            {
                kind = "غیر دولتی";
            }
            if (usual.Checked)
            {
                kind = "دولتی";
            }
            if (Sampad.Checked)
            {
                kind = "سمپاد";
            }
            if (dolati.Checked)
            {
                kind = "نمونه دولتی";
            }
            string sex = "";
            if (radioButton1.Checked)
            {
                sex = "پسرانه";
            }

            if (radioButton2.Checked)
            {
                sex = "دخترانه";
            }

            
            dgv1.Rows.Add(id + 1, SchoolName.Text, kind, comboBox1.SelectedItem.ToString(), studentvaluess.Value.ToString(), SupervisorName.Text, SupervisorID.Text, sex, System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString());
            listBox1.Items.Add(SchoolName.Text.Replace(' ','_') + " " + kind.Replace(' ','_') + " " + comboBox1.SelectedItem.ToString() + " " + studentvaluess.Value.ToString() + " " + SupervisorName.Text.Replace(' ', '_') + " " + SupervisorID.Text + " " + sex+" "+ (System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString()));

        }

        private void StudentsValue_KeyDown(object sender, KeyEventArgs e)
        {
            
                //if (e.KeyCode == Keys.Down)
                //{
                //    if (StudentsValue.Text != "")
                //    {
                //        if (StudentsValue.Text != "0")
                //        {
                //            StudentsValue.Text = Convert.ToString(Convert.ToInt32(StudentsValue.Text) - 1);
                //        }
                //    }
                //}
                //else if (e.KeyCode == Keys.Up)
                //{
                //    if (StudentsValue.Text != "")
                //    {
                //        StudentsValue.Text = Convert.ToString(Convert.ToInt32(StudentsValue.Text) + 1);
                //    }
                //}
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //int i = 0;

            //  List =new Persons();
            //  List.Clear();

            int id = 0;

            
            }


        private void StudentsValue_Leave(object sender, EventArgs e)
        {
           
        }

        private void StudentsValue_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void statistics_Load(object sender, EventArgs e)
        {

            DialogResult s = MessageBox.Show("آیا مایلید فایل دیتابیس را بارگذاری کنید ؟", "بارگذاری دیتابیس", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (s == DialogResult.Cancel)
            {
                Form1 frm = new Form1();
                statistics stc = new statistics();
                frm.Show();
                this.Close();
                stc.Close();
                
                
            }
            else if (s == DialogResult.Yes)
            {
                OpenFileDialog LOL = new OpenFileDialog();
                LOL.Filter = "Data base File (*.rf) |*.rf";

                if (LOL.ShowDialog() == DialogResult.OK)
                {
                    filename = LOL.FileName;
                    dgv1.Rows.Clear();
                    dgv1.Columns.Clear();
                    string[] aaa = new string[5000];

                    using (System.IO.StreamReader aa = new System.IO.StreamReader(LOL.FileName))
                    {

                        int x = Convert.ToInt32(aa.ReadLine()) - 1;
                        string kj = "";

                        for (int ii = 0; ii <= x; ii++)
                        {
                            kj = aa.ReadLine();
                            dgv1.Columns.Add(kj, kj);
                            dgv1.Columns[kj].SortMode = DataGridViewColumnSortMode.Programmatic;
                        }
                        string d = aa.ReadLine();

                        while (d != "♫")
                        {
                            aaa[0] = d;

                            for (int i = 1; i <= x; i++)
                            {

                                aaa[i] = aa.ReadLine();

                            }

                            dgv1.Rows.Add(aaa);
                            d = aa.ReadLine();
                        }


                        int xx = Convert.ToInt32(aa.ReadLine()) - 1;
                        string kjj = "";

                        for (int ii = 0; ii <= xx; ii++)
                        {
                            kjj = aa.ReadLine();
                            dgv2.Columns.Add(kjj, kjj);
                            dgv2.Columns[kjj].SortMode = DataGridViewColumnSortMode.Programmatic;
                        }
                        string dd = aa.ReadLine();
                        while (dd != null)
                        {
                            aaa[0] = dd;

                            for (int i = 1; i <= xx; i++)
                            {

                                aaa[i] = aa.ReadLine();

                            }

                            dgv2.Rows.Add(aaa);
                            dd = aa.ReadLine();
                        }





                        aa.Close();
                    }
                    List<object> Data = new List<object>();

                    XmlSerializer Ser = new XmlSerializer(typeof(List<object>));

                    using (StreamReader Reader = new StreamReader(LOL.FileName + ".RFDM"))
                    {
                        Data = (List<object>)Ser.Deserialize(Reader);

                        foreach (object obj in Data)
                        {
                            listBox3.Items.Add(obj);
                        }
                    }
                    int adad = 0;
                    for (int adda = 0; adda < listBox3.Items.Count; adda++)
                    {
                        if (adad == 0)
                        {
                            if (listBox3.Items[adda].ToString() != "Amnam")
                            {
                                listBox1.Items.Add(listBox3.Items[adda].ToString());
                            }
                            else if (listBox3.Items[adda].ToString() == "Amnam")
                            {
                                adad = 1;
                            }
                        }
                        else if (adad == 1)
                        {
                            listBox2.Items.Add(listBox3.Items[adda].ToString());
                        }
                    }
                    listBox3.Items.Clear();
                    this.BringToFront();
                }
                else
                {

                    dgv2.Rows.Clear();
                    dgv2.Columns.Add("کد", "کد");
                    dgv2.Columns.Add("کد", "نام مراجعه کننده");
                    dgv2.Columns.Add("کد", "سن");
                    dgv2.Columns.Add("کد", "مدرک تحصیلی");
                    dgv2.Columns.Add("کد", "جنسیت");
                    dgv2.Columns.Add("کد", "منطقه سکونت");
                    dgv2.Columns.Add("کد", "شماره تماس");
                    dgv2.Columns[0].Width = 25;
                    dgv1.Columns.Clear();
                    dgv1.Rows.Clear();
                    dgv1.Columns.Add("کد", "کد");
                    dgv1.Columns.Add("کد", "نام مدرسه");
                    dgv1.Columns.Add("کد", "نوع مدرسه");
                    dgv1.Columns.Add("کد", "منطقه");
                    dgv1.Columns.Add("کد", "تعداد دانش آموزان");
                    dgv1.Columns.Add("کد", "نام سرپرست");
                    dgv1.Columns.Add("کد", "شماره تماس سرپرست");
                    dgv1.Columns.Add("کد", "جنسیت");
                    dgv1.Columns.Add("کد", "ساعت مراجعه");
                    dgv1.Columns[0].Width = 25;
                }
            }
            else
            {
                dgv2.Rows.Clear();
                dgv2.Columns.Add("کد", "کد");
                dgv2.Columns.Add("کد", "نام مراجعه کننده");
                dgv2.Columns.Add("کد", "سن");
                dgv2.Columns.Add("کد", "مدرک تحصیلی");
                dgv2.Columns.Add("کد", "جنسیت");
                dgv2.Columns.Add("کد", "منطقه سکونت");
                dgv2.Columns.Add("کد", "شماره تماس");
                dgv2.Columns.Add("کد", "ساعت مراجعه");
                dgv2.Columns[0].Width = 25;
                dgv1.Columns.Clear();
                dgv1.Rows.Clear();
                dgv1.Columns.Add("کد", "کد");
                dgv1.Columns.Add("کد", "نام مدرسه");
                dgv1.Columns.Add("کد", "نوع مدرسه");
                dgv1.Columns.Add("کد", "منطقه");
                dgv1.Columns.Add("کد", "تعداد دانش آموزان");
                dgv1.Columns.Add("کد", "نام سرپرست");
                dgv1.Columns.Add("کد", "شماره تماس سرپرست");
                dgv1.Columns.Add("کد", "جنسیت");
                dgv1.Columns.Add("کد", "ساعت مراجعه");
                dgv1.Columns[0].Width = 25;
            }
                                           
        }
    

        private void button5_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow[] aaad = new DataGridViewRow[1000];
            DataGridViewRow[] aaad2 = new DataGridViewRow[1000];

            string[,] aaa = new string[1000, 1000];
            string[,] aaa2 = new string[1000, 1000];


            int x = dgv1.ColumnCount;
            int f = 0;
            int i = 0;
            int x2 = dgv2.ColumnCount;
            int f2 = 0;
            int i2 = 0;
            foreach (DataGridViewRow an in dgv1.Rows)
            {
                aaad[i] = an;
                foreach (DataGridViewCell sd in aaad[i].Cells)
                {
                    if (sd.Value.ToString() != "")
                    {
                        aaa[i, f] = sd.Value.ToString();
                    }
                    else
                    {
                        aaa[i, f] = " ";

                    }
                    f++;

                }
                i++;
                f = 0;
            }
            foreach (DataGridViewRow an in dgv2.Rows)
            {
                aaad2[i2] = an;
                foreach (DataGridViewCell sd in aaad2[i2].Cells)
                {
                    if (sd.Value.ToString() != "")
                    {
                        aaa2[i2, f2] = sd.Value.ToString();
                    }
                    else
                    {
                        aaa2[i2, f2] = " ";

                    }
                    f2++;

                }
                i2++;
                f2 = 0;
            }

            
            sddd.Filter = "Database (*.rf) |*.rf";
            if (sddd.ShowDialog()==DialogResult.OK) {
                using (System.IO.StreamWriter aa = new System.IO.StreamWriter(sddd.FileName))
                {

                    aa.WriteLine(x.ToString());
                    for (int mk = 0; mk <= dgv1.ColumnCount - 1; mk++) { aa.WriteLine(dgv1.Columns[mk].HeaderText); }
                    for (int sdd = 0; sdd <= dgv1.RowCount - 1; sdd++)
                    {
                        for (int kj = 0; kj <= dgv1.ColumnCount - 1; kj++)
                        {

                            aa.WriteLine(aaa[sdd, kj]);

                        }
                    }
                    
                    aa.WriteLine("♫");
                    aa.WriteLine(x2.ToString());
                    for (int mk = 0; mk <= dgv2.ColumnCount - 1; mk++) { aa.WriteLine(dgv2.Columns[mk].HeaderText); }
                    for (int sdd = 0; sdd <= dgv2.RowCount - 1; sdd++)
                    {
                        for (int kj = 0; kj <= dgv2.ColumnCount - 1; kj++)
                        {

                            aa.WriteLine(aaa2[sdd, kj]);

                        }
                    }
                }
                int alaki1alaki = listBox1.Items.Count; 
                int alaki2alaki = listBox2.Items.Count;
                for (int ii = 0; ii < alaki1alaki; ii++)
                {
                    listBox3.Items.Add(listBox1.Items[ii].ToString());
                }
                listBox3.Items.Add("Amnam");
                for (int cc = 0; cc < alaki2alaki; cc++)
                {
                    listBox3.Items.Add(listBox2.Items[cc].ToString());
                }
                List <object> Data = new List<object>();
                foreach (object obj in listBox3.Items)
              
                {
                    Data.Add(obj);
                }

                XmlSerializer Ser = new XmlSerializer(typeof(List<object>));

                using (StreamWriter Writer = new StreamWriter(sddd.FileName+".RFDM"))
                {
                    Ser.Serialize(Writer, Data);
                }
                listBox3.Items.Clear();
            }
            Barresi = 1;        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {


                if (radioButton7.Checked) {


                    for (int idd = 0; idd <= dgv2.RowCount - 1; idd++)
                    {
                        if (dgv2.Rows[idd].Cells[1].Value.ToString() == textBox1.Text)
                        {
                            dgv2.CurrentRow.Selected = false;
                            for (int n = 0; n <= dgv2.RowCount - 1; n++)
                            {
                                for (int m = 0; m <= dgv2.ColumnCount-1; m++)
                                {

                                    dgv2.Rows[n].Cells[m].Selected = false;

                                }


                            }
                            dgv2.CurrentRow.Selected = false;
                            dgv2.Rows[idd].Cells[1].Selected = true;
                            dgv2.FirstDisplayedScrollingRowIndex = idd;


                        }

                    }

                    }
                    if (radioButton8.Checked) {

                for (int idd = 0; idd <= dgv1.RowCount - 1; idd++)
                {
                    if (dgv1.Rows[idd].Cells[1].Value.ToString() == textBox1.Text)
                    {
                        dgv1.CurrentRow.Selected = false;
                        for (int n = 0; n <= dgv1.RowCount - 1; n++)
                        {
                            for (int m = 0; m <= 7; m++)
                            {

                                dgv1.Rows[n].Cells[m].Selected = false;

                            }


                        }
                        dgv1.CurrentRow.Selected = false;
                        dgv1.Rows[idd].Cells[1].Selected = true;
                        dgv1.FirstDisplayedScrollingRowIndex = idd;


                    }


                }



            }
           
            }
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dgv1.Rows.Clear();
            dgv1.Columns.Clear();
            string[] aaa = new string[5000];

            using (System.IO.StreamReader aa = new System.IO.StreamReader(filename))
            {
                int x = Convert.ToInt32(aa.ReadLine()) - 1;

                string kj = "";

                for (int ii = 0; ii <= x; ii++)
                {
                    kj = aa.ReadLine();
                    dgv1.Columns.Add(kj, kj);
                    dgv1.Columns[kj].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
                string d = aa.ReadLine();

                while (d != null)
                {
                    aaa[0] = d;

                    for (int i = 1; i <= x; i++)
                    {

                        aaa[i] = aa.ReadLine();

                    }

                    dgv1.Rows.Add(aaa);
                    d = aa.ReadLine();
                }
                aa.Close();
            }
            this.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

         
        }

        private void dgv1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
          

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                noemoraje = "مدرسه";
                groupBox4.Visible = true;
                groupBox5.Visible = false;

            }

        }

        private void button4_Click_2(object sender, EventArgs e)
        {
           // hmnAge.Text = Convert.ToString(Convert.ToInt32(hmnAge.Text) + 1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
        //    hmnAge.Text = Convert.ToString(Convert.ToInt32(hmnAge.Text) - 1);

        }

        private void hmnAge_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //{
            //    button8.PerformClick();
            //}
            //else if (e.KeyCode == Keys.Up)
            //{
            //    button4.PerformClick();
            //}
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int id = 0;
            for (int i = 0; i <= dgv2.Rows.Count - 1; i++)
            {
                if (id < int.Parse(dgv2.Rows[i].Cells[0].Value.ToString()))
                {
                    id = int.Parse(dgv2.Rows[i].Cells[0].Value.ToString());
                }
            }
            string jensiat = "";
  
            if (radioButton5.Checked == true)
            {
                jensiat = "مذکر";
              
            }
            else if (radioButton6.Checked == true)
            {
                jensiat = "مونث";
          
            }
            string ey_khodaaa = madrak.SelectedItem.ToString();
            ey_khodaaa = ey_khodaaa.Replace(' ', '_');
            string omoomi = hmnName.Text.Replace(' ','_') + " " + hmnagee.Value.ToString()+ " " +ey_khodaaa+" "+jensiat + " " + mantaghe.Text + " " + hmnID.Text + " " + (System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute);
            listBox2.Items.Add(omoomi);
            /*

        dgv2.Columns.Add("کد", "کد");
                 dgv2.Columns.Add("کد", "نام مراجعه کننده");
                 dgv2.Columns.Add("کد", "سن");
                 dgv2.Columns.Add("کد", "مدرک تحصیلی");
                 dgv2.Columns.Add("کد", "جنسیت");
                 dgv2.Columns.Add("کد", "منطقه سکونت");
                 dgv2.Columns.Add("کد", "شماره تماس");                                  
                 dgv2.Columns[0].Width = 25;

     */
            dgv2.Rows.Add((id+1).ToString(),hmnName.Text, hmnagee.Value.ToString(), madrak.SelectedItem.ToString(),jensiat,mantaghe.Text,hmnID.Text,(System.DateTime.Now.Hour+":"+System.DateTime.Now.Minute));
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void studentvaluess_KeyDown(object sender, KeyEventArgs e)
        {
        //    if (e.KeyCode == Keys.Tab)
        //    {
        //        SupervisorName.Focus();
        //    }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Barresi == 0)
            {

            }
            else if (Barresi == 1)
            {
                DataGridViewRow[] aaad = new DataGridViewRow[1000];
                DataGridViewRow[] aaad2 = new DataGridViewRow[1000];

                string[,] aaa = new string[1000, 1000];
                string[,] aaa2 = new string[1000, 1000];


                int x = dgv1.ColumnCount;
                int f = 0;
                int i = 0;
                int x2 = dgv2.ColumnCount;
                int f2 = 0;
                int i2 = 0;
                foreach (DataGridViewRow an in dgv1.Rows)
                {
                    aaad[i] = an;
                    foreach (DataGridViewCell sd in aaad[i].Cells)
                    {
                        if (sd.Value.ToString() != "")
                        {
                            aaa[i, f] = sd.Value.ToString();
                        }
                        else
                        {
                            aaa[i, f] = " ";

                        }
                        f++;

                    }
                    i++;
                    f = 0;
                }
                foreach (DataGridViewRow an in dgv2.Rows)
                {
                    aaad2[i2] = an;
                    foreach (DataGridViewCell sd in aaad2[i2].Cells)
                    {
                        if (sd.Value.ToString() != "")
                        {
                            aaa2[i2, f2] = sd.Value.ToString();
                        }
                        else
                        {
                            aaa2[i2, f2] = " ";

                        }
                        f2++;

                    }
                    i2++;
                    f2 = 0;
                }


                sddd.Filter = "Database (*.rf) |*.rf";
                if (Barresi == 1)
                {
                    using (System.IO.StreamWriter aa = new System.IO.StreamWriter(sddd.FileName))
                    {

                        aa.WriteLine(x.ToString());
                        for (int mk = 0; mk <= dgv1.ColumnCount - 1; mk++) { aa.WriteLine(dgv1.Columns[mk].HeaderText); }
                        for (int sdd = 0; sdd <= dgv1.RowCount - 1; sdd++)
                        {
                            for (int kj = 0; kj <= dgv1.ColumnCount - 1; kj++)
                            {

                                aa.WriteLine(aaa[sdd, kj]);

                            }
                        }

                        aa.WriteLine("♫");
                        aa.WriteLine(x2.ToString());
                        for (int mk = 0; mk <= dgv2.ColumnCount - 1; mk++) { aa.WriteLine(dgv2.Columns[mk].HeaderText); }
                        for (int sdd = 0; sdd <= dgv2.RowCount - 1; sdd++)
                        {
                            for (int kj = 0; kj <= dgv2.ColumnCount - 1; kj++)
                            {

                                aa.WriteLine(aaa2[sdd, kj]);

                            }
                        }
                    }
                    int alaki1alaki = listBox1.Items.Count;
                    int alaki2alaki = listBox2.Items.Count;
                    for (int ii = 0; ii < alaki1alaki; ii++)
                    {
                        listBox3.Items.Add(listBox1.Items[ii].ToString());
                    }
                    listBox3.Items.Add("Amnam");
                    for (int cc = 0; cc < alaki2alaki; cc++)
                    {
                        listBox3.Items.Add(listBox2.Items[cc].ToString());
                    }
                    List<object> Data = new List<object>();
                    foreach (object obj in listBox3.Items)

                    {
                        Data.Add(obj);
                    }

                    XmlSerializer Ser = new XmlSerializer(typeof(List<object>));

                    using (StreamWriter Writer = new StreamWriter(sddd.FileName + ".RFDM"))
                    {
                        Ser.Serialize(Writer, Data);
                    }
                    listBox3.Items.Clear();
                }
            }
        }

        private void hmnagee_ValueChanged(object sender, EventArgs e)
        {

        }

        private void closeThisWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5.PerformClick();
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

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

      

        private void chartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            nrc.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nrc.Close();
        }
    }
}
    
