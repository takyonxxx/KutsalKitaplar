using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;

namespace Kuran
{
    public partial class Form1 : Form
    {
        public OleDbConnection Conn;
        public OleDbDataAdapter dAdapter;
        public DataSet dSet;
        public int formheight, formwidth;
        public string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.IO.Directory.GetCurrentDirectory() + "\\Kutsal_Kitaplar.accdb;Persist Security Info=False;";
        public string kitap = "K";
        public string kitapad = "";
        public bool kitapsec = false;
        public Form1()
        {
            InitializeComponent();
            this.SizeChanged += new EventHandler(Form1_Resize);
        }
        FormWindowState LastWindowState = FormWindowState.Minimized;
        private void Form1_Resize(object sender, EventArgs e)
        {

            // When window state changes
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;

                if (this.WindowState == FormWindowState.Minimized)
                {
                  
                }
                if (this.WindowState == FormWindowState.Normal)
                {
                    Control control = (Control)sender;
                    formheight = control.Size.Height;
                    formwidth = control.Size.Width;
                    //MessageBox.Show(height.ToString() + " " + width.ToString());
                    richTextBox1.Width = formwidth - listBox1.Width - 36;
                    richTextBox1.Height = formheight - panel1.Height - 80;
                    listBox1.Height = formheight -panel2.Height - panel1.Height - 70;
                    //richTextBox1.Height = formheight - 80;
                    //listBox1.Height = formheight - 80;
                    panel1.Location = new Point(panel1.Left, formheight - panel1.Height);
                    panel2.Location = new Point(panel2.Left, formheight - panel2.Height - panel1.Height - 36);
                    panel1.Width = formwidth - 10;
                    dataGridView1.Width = formwidth - 30;
                    textBox1.Width = formwidth - 30;
                    textBox2.Width = formwidth - 30;
                    textBox4.Width = formwidth - 30;
                    dataGridView1.Columns[0].Width = (formwidth - 60) / 2;
                    dataGridView1.Columns[1].Width = (formwidth - 60) / 2;
                }

                if (this.WindowState == FormWindowState.Maximized)
                {
                    Control control = (Control)sender;
                    formheight = control.Size.Height;
                    formwidth = control.Size.Width;
                    //MessageBox.Show(height.ToString() + " " + width.ToString());
                    richTextBox1.Width = formwidth - listBox1.Width - 36;
                    richTextBox1.Height = formheight - panel1.Height - 80;
                    listBox1.Height = formheight -panel2.Height - panel1.Height -70;
                    //richTextBox1.Height = formheight - 80;
                    //listBox1.Height = formheight - 80;
                    panel1.Location = new Point(panel1.Left, formheight-panel1.Height);
                    panel2.Location = new Point(panel2.Left, formheight - panel2.Height - panel1.Height -36);
                    panel1.Width = formwidth - 10;
                    dataGridView1.Width = formwidth - 30;
                    textBox1.Width = formwidth - 30;
                    textBox2.Width = formwidth - 30;
                    textBox4.Width = formwidth - 30;
                    dataGridView1.Columns[0].Width = (formwidth - 60) / 2;
                    dataGridView1.Columns[1].Width = (formwidth - 60) / 2;

                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();            
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            Control control = (Control)sender;
            formheight = control.Size.Height;
            formwidth = control.Size.Width;

            Conn = new OleDbConnection();
             try
                {
                    listBox1.DataSource = null;
                    Conn.ConnectionString = conString;
                    Conn.Open();
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM sureler ", Conn);
                    DataSet dSet = new DataSet();
                    dAdapter.Fill(dSet, "sureler");
                    listBox1.DisplayMember = "suretam";
                    listBox1.ValueMember = "sure";
                    listBox1.DataSource = dSet.Tables["sureler"];           
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                finally
                {
                    Conn.Close();
                }
            
        }
             
        public int ayetno = 0;
        public int ayetcount = 0;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {          
            Conn = new OleDbConnection();           
            try
            {
                if (kitap == "K")
                {
                    int sure = Convert.ToInt16(listBox1.SelectedValue.ToString());
                    textBox5.Text = "Sure:" + sure.ToString();
                    richTextBox1.Text = "";                   
                    listBox1.Enabled = false;
                    Conn.ConnectionString = conString;
                    Conn.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT count(*) FROM meal where meal.sure=" + sure, Conn);
                    ayetcount = (Int32)cmd.ExecuteScalar();
                    ayetno = 1;
                    textBox3.Text = ayetno.ToString();
                    cmd = new OleDbCommand("SELECT * FROM meal where meal.sure=" + sure + " ORDER BY ayet ASC", Conn);
                    OleDbDataReader table = cmd.ExecuteReader();
                    string data = "";
                    while (table.Read())
                    {
                        data = data + table["ayet"].ToString() + ". " + table["meal"].ToString() + "\r\n";
                    }
                    richTextBox1.Text = data;
                    table.Close();
                    cmd = new OleDbCommand("SELECT  meal.* FROM meal where sure= " + sure + " and ayet=" + ayetno, Conn);
                    table = cmd.ExecuteReader();
                    while (table.Read())
                    {
                        textBox1.Text = table["ayet"].ToString() + ". " + table["meal"].ToString();
                        textBox2.Text = table["ayet"].ToString() + ". " + table["latince"].ToString();
                        textBox4.Text = table["ayet"].ToString() + ". " + table["arapca"].ToString();
                    }
                    table.Close();
                    dAdapter = new OleDbDataAdapter("SELECT kuran.latince ,kuran.turkce FROM meal INNER JOIN kuran ON (meal.ayet = kuran.ayet) AND (meal.sure = kuran.sure) where meal.sure= " + sure + " and meal.ayet=" + ayetno, Conn);
                    dSet = new DataSet();
                    dAdapter.Fill(dSet, "meal");
                    DataTable dt = dSet.Tables["meal"];
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Width = (formwidth-60) / 2;
                    dataGridView1.Columns[1].Width = (formwidth - 60) / 2;
                    listBox1.Enabled = true;
                }
                else if (kitap == "T")
                {
                    int sure = Convert.ToInt16(listBox1.SelectedValue.ToString());
                    richTextBox1.Text = "";
                    listBox1.Enabled = false;
                    Conn.ConnectionString = conString;
                    Conn.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM tevrat where tevrat.sureno=" + sure , Conn);
                    OleDbDataReader table = cmd.ExecuteReader();
                    string data = "";
                    while (table.Read())
                    {
                        data = data + table["ayet"].ToString()+ "\r\n";                       
                    }
                    richTextBox1.Text = data;
                    table.Close();
                    listBox1.Enabled = true;         
                }
                else if (kitap == "Z")
                {
                    int sure = Convert.ToInt16(listBox1.SelectedValue.ToString());
                    richTextBox1.Text = "";
                    listBox1.Enabled = false;
                    Conn.ConnectionString = conString;
                    Conn.Open();
                    OleDbCommand cmd= new OleDbCommand("SELECT * FROM zebur where zebur.sureno=" + sure, Conn);
                    OleDbDataReader table = cmd.ExecuteReader();
                    string data = "";
                    while (table.Read())
                    {
                        data = data + table["ayet"].ToString() + "\r\n"; ;
                    }
                    richTextBox1.Text = data;
                    table.Close();
                    listBox1.Enabled = true;         
                }
                else if (kitap == "I")
                {                    
                    string info = listBox1.SelectedValue.ToString();
                    richTextBox1.Text = "";
                    string[] words = info.Split('-');
                    listBox1.Enabled = false;
                    Conn.ConnectionString = conString;
                    Conn.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM incil where incil.sureno=" + Convert.ToInt32(words[1]) + "AND incil.kitap='" + words[0] + "'", Conn);
                    OleDbDataReader table = cmd.ExecuteReader();
                    string data = "";
                    while (table.Read())
                    {
                        data = data + table["ayet"].ToString() + "\r\n"; ;
                    }
                    richTextBox1.Text = data;                   
                    table.Close();
                    listBox1.Enabled = true;
                }               
                Conn.Close();               
                          
            }
            catch (Exception ex)
            {
               //MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sure = Convert.ToInt16(listBox1.SelectedValue.ToString());         
            Conn = new OleDbConnection();
            try
            {                
                Conn.ConnectionString = conString;
                Conn.Open();                
                if (ayetno < ayetcount && ayetno>0)
                {
                    ayetno = ayetno + 1;
                    textBox3.Text = ayetno.ToString();
                    OleDbCommand cmd = new OleDbCommand("SELECT  meal.* FROM meal where sure= " + sure + " and ayet=" + ayetno, Conn);
                    OleDbDataReader table = cmd.ExecuteReader();
                    while (table.Read())
                    {
                        textBox1.Text = table["ayet"].ToString() + ". " + table["meal"].ToString();
                        textBox2.Text = table["ayet"].ToString() + ". " + table["latince"].ToString();
                        textBox4.Text = table["ayet"].ToString() + ". " + table["arapca"].ToString();     
                    }              
                    dAdapter = new OleDbDataAdapter("SELECT kuran.latince ,kuran.turkce FROM meal INNER JOIN kuran ON (meal.ayet = kuran.ayet) AND (meal.sure = kuran.sure) where meal.sure= " + sure + " and meal.ayet=" + ayetno, Conn);
                    dSet = new DataSet();
                    dAdapter.Fill(dSet, "meal");
                    DataTable dt = dSet.Tables["meal"];
                    dataGridView1.DataSource = dt;
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sure = Convert.ToInt16(listBox1.SelectedValue.ToString());
            Conn = new OleDbConnection();
            try
            {
                Conn.ConnectionString = conString;
                Conn.Open();
                if (ayetno <= ayetcount && ayetno > 1)
                {
                    ayetno = ayetno - 1;
                    textBox3.Text = ayetno.ToString();
                    OleDbCommand cmd = new OleDbCommand("SELECT  meal.* FROM meal where sure= " + sure + " and ayet=" + ayetno, Conn);
                    OleDbDataReader table = cmd.ExecuteReader();
                    while (table.Read())
                    {
                        textBox1.Text = table["ayet"].ToString() + ". " + table["meal"].ToString();
                        textBox2.Text = table["ayet"].ToString() + ". " + table["latince"].ToString();
                        textBox4.Text = table["ayet"].ToString() + ". " + table["arapca"].ToString();     
                    }              
               

                    dAdapter = new OleDbDataAdapter("SELECT kuran.latince ,kuran.turkce FROM meal INNER JOIN kuran ON (meal.ayet = kuran.ayet) AND (meal.sure = kuran.sure) where meal.sure= " + sure + " and meal.ayet=" + ayetno, Conn);
                    dSet = new DataSet();
                    dAdapter.Fill(dSet, "meal");
                    DataTable dt = dSet.Tables["meal"];
                    dataGridView1.DataSource = dt;

                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Size sz = new Size(textBox1.ClientSize.Width, int.MaxValue);
            TextFormatFlags flags = TextFormatFlags.WordBreak;
            int padding = 3;
            int borders = textBox1.Height - textBox1.ClientSize.Height;
            sz = TextRenderer.MeasureText(textBox1.Text, textBox1.Font, sz, flags);
            int h = sz.Height + borders + padding;
            if (textBox1.Top + h > this.ClientSize.Height - 10)
            {
                h = this.ClientSize.Height - 10 - textBox1.Top;
            }
            textBox1.Height = h;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Size sz = new Size(textBox4.ClientSize.Width, int.MaxValue);
            TextFormatFlags flags = TextFormatFlags.WordBreak;
            int padding = 3;
            int borders = textBox4.Height - textBox4.ClientSize.Height;
            sz = TextRenderer.MeasureText(textBox4.Text, textBox4.Font, sz, flags);
            int h = sz.Height + borders + padding;
            if (textBox4.Top + h > this.ClientSize.Height - 10)
            {
                h = this.ClientSize.Height - 10 - textBox4.Top;
            }
            textBox4.Height = h;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sure = Convert.ToInt16(listBox1.SelectedValue.ToString());
            Conn = new OleDbConnection();
            ayetno = Convert.ToInt16(textBox3.Text);
            try
            {
                Conn.ConnectionString = conString;
                Conn.Open();
               
                    OleDbCommand cmd = new OleDbCommand("SELECT  meal.* FROM meal where sure= " + sure + " and ayet=" + ayetno, Conn);
                    OleDbDataReader table = cmd.ExecuteReader();
                    while (table.Read())
                    {
                        textBox1.Text = table["ayet"].ToString() + ". " + table["meal"].ToString();
                        textBox2.Text = table["ayet"].ToString() + ". " + table["latince"].ToString();
                        textBox4.Text = table["ayet"].ToString() + ". " + table["arapca"].ToString();
                    }


                    dAdapter = new OleDbDataAdapter("SELECT kuran.latince ,kuran.turkce FROM meal INNER JOIN kuran ON (meal.ayet = kuran.ayet) AND (meal.sure = kuran.sure) where meal.sure= " + sure + " and meal.ayet=" + ayetno, Conn);
                    dSet = new DataSet();
                    dAdapter.Fill(dSet, "meal");
                    DataTable dt = dSet.Tables["meal"];
                    dataGridView1.DataSource = dt;                
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            Size sz = new Size(textBox2.ClientSize.Width, int.MaxValue);
            TextFormatFlags flags = TextFormatFlags.WordBreak;
            int padding = 3;
            int borders = textBox2.Height - textBox2.ClientSize.Height;
            sz = TextRenderer.MeasureText(textBox2.Text, textBox2.Font, sz, flags);
            int h = sz.Height + borders + padding;
            if (textBox2.Top + h > this.ClientSize.Height - 10)
            {
                h = this.ClientSize.Height - 10 - textBox2.Top;
            }
            textBox2.Height = h;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {                
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                listBox1.Enabled = false;
                Conn = new OleDbConnection();
                string ara = textBox6.Text;
                richTextBox1.Text = "";
                try
                {
                    Conn.ConnectionString = conString;
                    Conn.Open();
                    if (kitap == "K")
                    {
                        OleDbCommand cmd = new OleDbCommand("SELECT  meal.* FROM meal where meal like '%" + ara + "%'", Conn);
                        OleDbDataReader table = cmd.ExecuteReader();
                        string data = "";
                        while (table.Read())
                        {
                            data = data + table["sureadi"].ToString() + "." + table["ayet"].ToString() + ". " + table["meal"].ToString() + "\r\n";                            
                        }
                        richTextBox1.Text = data;
                        dAdapter = new OleDbDataAdapter("SELECT kuran.latince ,kuran.turkce FROM meal INNER JOIN kuran ON (meal.ayet = kuran.ayet) AND (meal.sure = kuran.sure) where kuran.turkce like '%" + ara + "%'", Conn);
                        dSet = new DataSet();
                        dAdapter.Fill(dSet, "meal");
                        DataTable dt = dSet.Tables["meal"];
                        dataGridView1.DataSource = dt;                       
                    }
                    else if (kitap == "T")
                    {
                        OleDbCommand cmd = new OleDbCommand("SELECT  tevrat.* FROM tevrat where tevrat.ayet like '%" + ara + "%'", Conn);
                        OleDbDataReader table = cmd.ExecuteReader();
                        string data = "";
                        while (table.Read())
                        {
                            data = data + table["ayet"].ToString() + "\r\n";  
                        }
                        richTextBox1.Text = data;                        
                    }
                    else if (kitap == "Z")
                    {
                        OleDbCommand cmd = new OleDbCommand("SELECT  zebur.* FROM zebur where zebur.ayet like '%" + ara + "%'", Conn);
                        OleDbDataReader table = cmd.ExecuteReader();
                        string data = "";
                        while (table.Read())
                        {
                            data = data + table["ayet"].ToString() + "\r\n"; ;
                        }
                        richTextBox1.Text = data;
                    }
                    else if (kitap == "I")
                    {
                        OleDbCommand cmd = new OleDbCommand("SELECT  incil.* FROM incil where incil.ayet like '%" + ara + "%'", Conn);
                        OleDbDataReader table = cmd.ExecuteReader();
                        string data = "";
                        while (table.Read())
                        {
                            data = data + table["ayet"].ToString() + "\r\n"; ;
                        }
                        richTextBox1.Text = data;
                    }
                    Conn.Close();
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    listBox1.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                finally
                {
                    Conn.Close();
                }
            }
            else  MessageBox.Show("Aranacak kelimeyi giriniz!");
        }
       
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
                this.CheckKeyword(textBox6.Text, Color.Yellow, 0);
            Application.DoEvents();
    
        }
       
      

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTextBox1.SelectionStart;

                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index + startIndex), word.Length);
                    this.richTextBox1.SelectionColor = color;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                    Application.DoEvents();
                }
            }
        }            

        private void button6_Click(object sender, EventArgs e)
        {
            Conn = new OleDbConnection();
            try
            {
                listBox1.DataSource = null;
                Conn.ConnectionString = conString;
                Conn.Open();               
                OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM sureler order by sureadi", Conn);
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet, "sureler");
                listBox1.DisplayMember = "suretam";
                listBox1.ValueMember = "sure";
                listBox1.DataSource = dSet.Tables["sureler"];                           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                Conn.Close();      
            }         

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Conn = new OleDbConnection();
            try
            {
                listBox1.DataSource = null;
                Conn.ConnectionString = conString;
                Conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM sureler", Conn);
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet, "sureler");
                listBox1.DisplayMember = "sureinistam";
                listBox1.ValueMember = "sureinis";
                listBox1.DataSource = dSet.Tables["sureler"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }         
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Conn = new OleDbConnection();
            try
            {
                listBox1.DataSource = null;
                Conn.ConnectionString = conString;
                Conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM sureler ", Conn);
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet, "sureler");
                listBox1.DisplayMember = "suretam";
                listBox1.ValueMember = "sure";
                listBox1.DataSource = dSet.Tables["sureler"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }
            
        }

       

        private void button10_Click(object sender, EventArgs e)
        {
            kitap = "T";
            richTextBox1.Height = formheight-80;
            listBox1.Height = formheight-80;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            panel1.Visible = false;
            textBox3.Visible = false;
            textBox5.Visible = false;
                
            Conn = new OleDbConnection();
            try
            {
                listBox1.DataSource = null;
                Conn.ConnectionString = conString;
                Conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM tevrat_sureler ", Conn);
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet, "tevrat_sureler");
                listBox1.DisplayMember = "sureadi";
                listBox1.ValueMember = "sureno";
                listBox1.DataSource = dSet.Tables["tevrat_sureler"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            kitap = "Z";
            richTextBox1.Height = formheight - 80;
            listBox1.Height = formheight - 80;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            panel1.Visible = false;
            textBox3.Visible = false;
            textBox5.Visible = false;
            Conn = new OleDbConnection();
            try
            {
                listBox1.DataSource = null;
                Conn.ConnectionString = conString;
                Conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM zebur_sureler ", Conn);
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet, "zebur_sureler");
                listBox1.DisplayMember = "sureadi";
                listBox1.ValueMember = "sureno";
                listBox1.DataSource = dSet.Tables["zebur_sureler"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            kitap = "K";
            richTextBox1.Width = formwidth - listBox1.Width - 36;
            richTextBox1.Height = formheight - panel1.Height - 80;
            listBox1.Height = formheight - panel2.Height - panel1.Height - 70;
            //richTextBox1.Height = formheight - 80;
            //listBox1.Height = formheight - 80;
            panel1.Location = new Point(panel1.Left, formheight - panel1.Height);
            panel2.Location = new Point(panel2.Left, formheight - panel2.Height - panel1.Height - 36);
            panel1.Width = formwidth - 10;
            dataGridView1.Width = formwidth - 30;
            textBox1.Width = formwidth - 30;
            textBox2.Width = formwidth - 30;
            textBox4.Width = formwidth - 30;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            panel1.Visible = true;
            textBox3.Visible = true;
            textBox5.Visible = true;
            Conn = new OleDbConnection();
            try
            {
                listBox1.DataSource = null;
                Conn.ConnectionString = conString;
                Conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM sureler ", Conn);
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet, "sureler");
                listBox1.DisplayMember = "suretam";
                listBox1.ValueMember = "sure";
                listBox1.DataSource = dSet.Tables["sureler"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kitap = "I";
            kitapsec = false;
            richTextBox1.Height = formheight - 80;
            listBox1.Height = formheight - 80;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            panel1.Visible = false;
            textBox3.Visible = false;
            textBox5.Visible = false;
            Conn = new OleDbConnection();
            try
            {
                listBox1.DataSource = null;
                Conn.ConnectionString = conString;
                Conn.Open();               
                OleDbCommand cmd = new OleDbCommand("SELECT  incil_sureler.* FROM incil_sureler", Conn);
                OleDbDataReader table = cmd.ExecuteReader();
                ArrayList IncilSureler = new ArrayList();
                while (table.Read())
                {
                    IncilSureler.Add(new Kitapinfo(table["kitap"].ToString() + "-" + table["sureadi"].ToString(), table["kitap"].ToString() + "-" + table["sureno"].ToString()));    
                } 
                listBox1.DisplayMember = "LongName";
                listBox1.ValueMember = "ShortName";
                listBox1.DataSource = IncilSureler;
                table.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }
       
      
    }
    public class Kitapinfo
    {
        private string myShortName;
        private string myLongName;

        public Kitapinfo(string strLongName, string strShortName)
        {

            this.myShortName = strShortName;
            this.myLongName = strLongName;
        }

        public string ShortName
        {
            get
            {
                return myShortName;
            }
        }

        public string LongName
        {

            get
            {
                return myLongName;
            }
        }

    }

   
}
