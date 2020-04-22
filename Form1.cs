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
    public partial class form_main : Form
    {
        public OleDbConnection Conn;
        public OleDbDataAdapter dAdapter;
        public DataSet dSet;
        public string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.IO.Directory.GetCurrentDirectory() + "\\Kutsal_Kitaplar.accdb";
        public int kitap = 0;
        public string kitapad = "";
        public bool kitapsec = false;
        private FormWindowState LastWindowState = FormWindowState.Minimized;
        public int formheight = 600;
        public int formwidth = 800;
        public form_main()
        {
            InitializeComponent(); 
            this.SizeChanged += new EventHandler(FormMain_Resize);
            this.WindowState = FormWindowState.Maximized;

            dataGrid_ceviri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //MessageBox.Show(System.IO.Directory.GetCurrentDirectory() + "\\Kutsal_Kitaplar.accdb");
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;
                Control control = (Control)sender;

                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.formheight = control.Size.Height;
                    this.formwidth = control.Size.Width;

                    richText_sure.Width = this.formwidth - list_sure.Width - 36;
                    richText_sure.Height = group_sure.Height;
                    list_sure.Height = richText_sure.Height;
                    dataGrid_ceviri.Width = group_ceviri.Width - 18;
                    text_latin_arapca.Width = group_ceviri.Width - 18;
                    text_meal.Width = group_ceviri.Width - 18;
                    text_arapca.Width = group_ceviri.Width - 18;
                    
                    //MessageBox.Show(formheight.ToString() + " " + formwidth.ToString());       
                }
                else if (this.WindowState == FormWindowState.Normal)
                {
                    control.Size = new System.Drawing.Size(800, 600);

                    this.formheight = control.Size.Height;
                    this.formwidth = control.Size.Width;

                    group_ceviri.Width = this.formwidth;
                    group_ceviri.Width = this.formwidth;
                    group_sure.Width = this.formwidth;

                    richText_sure.Width = group_sure.Width - list_sure.Width - 36;
                    richText_sure.Height = group_sure.Height;
                    list_sure.Height = richText_sure.Height;
                    dataGrid_ceviri.Width = group_ceviri.Width - 18;
                    text_latin_arapca.Width = group_ceviri.Width - 18;
                    text_meal.Width = group_ceviri.Width - 18;
                    text_arapca.Width = group_ceviri.Width - 18;                    
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
                    list_sure.DataSource = null;
                    Conn.ConnectionString = conString;
                    Conn.Open();
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM sureler ", Conn);
                    DataSet dSet = new DataSet();
                    dAdapter.Fill(dSet, "sureler");
                    list_sure.DisplayMember = "suretam";
                    list_sure.ValueMember = "sure";
                    list_sure.DataSource = dSet.Tables["sureler"];
                    
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
        private void list_sure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_sure.SelectedItem == null)
            {
                return;
            }
           
            Conn = new OleDbConnection();
            Conn.ConnectionString = conString;
            Conn.Open();

            try
            {
                if (kitap == 0)
                {
                    int sure = Convert.ToInt16(list_sure.SelectedValue.ToString());
                    text_sure.Text = "Sure:" + sure.ToString();
                    richText_sure.Text = "";
                    list_sure.Enabled = false;

                    OleDbCommand cmd = new OleDbCommand("SELECT count(*) FROM meal where meal.sure=" + sure, Conn);
                    ayetcount = (Int32)cmd.ExecuteScalar();
                    ayetno = 1;
                    text_ayet.Text = ayetno.ToString();
                    cmd = new OleDbCommand("SELECT * FROM meal where meal.sure=" + sure + " ORDER BY ayet ASC", Conn);
                    OleDbDataReader table = cmd.ExecuteReader();
                    string data = "";
                    while (table.Read())
                    {
                        data = data + table["ayet"].ToString() + ". " + table["meal"].ToString() + "\r\n";
                    }
                    richText_sure.Text = data;
                    table.Close();
                    cmd = new OleDbCommand("SELECT  meal.* FROM meal where sure= " + sure + " and ayet=" + ayetno, Conn);
                    table = cmd.ExecuteReader();
                    while (table.Read())
                    {
                        text_meal.Text = table["ayet"].ToString() + ". " + table["meal"].ToString();
                        text_latin_arapca.Text = table["ayet"].ToString() + ". " + table["latince"].ToString();
                        text_arapca.Text = table["ayet"].ToString() + ". " + table["arapca"].ToString();
                    }
                    table.Close();
                    dAdapter = new OleDbDataAdapter("SELECT kuran.latince ,kuran.turkce FROM meal INNER JOIN kuran ON (meal.ayet = kuran.ayet) AND (meal.sure = kuran.sure) where meal.sure= " + sure + " and meal.ayet=" + ayetno, Conn);
                    dSet = new DataSet();
                    dAdapter.Fill(dSet, "meal");
                    DataTable dt = dSet.Tables["meal"];
                    dataGrid_ceviri.DataSource = dt;
                    list_sure.Enabled = true;
                }
                else if (kitap == 1)
                {
                    int sure = Convert.ToInt16(list_sure.SelectedValue.ToString());
                    richText_sure.Text = "";
                    list_sure.Enabled = false;                  
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM tevrat where tevrat.sureno=" + sure, Conn);
                    OleDbDataReader table = cmd.ExecuteReader();
                    string data = "";
                    while (table.Read())
                    {
                        data = data + table["ayet"].ToString() + "\r\n";
                    }
                    richText_sure.Text = data;
                    table.Close();
                    list_sure.Enabled = true;
                }
                else if (kitap == 2)
                {
                    string info = list_sure.SelectedValue.ToString();
                    richText_sure.Text = "";
                    string[] words = info.Split('-');
                    list_sure.Enabled = false;
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM incil where incil.sureno=" + Convert.ToInt32(words[1]) + "AND incil.kitap='" + words[0] + "'", Conn);
                    OleDbDataReader table = cmd.ExecuteReader();
                    string data = "";
                    while (table.Read())
                    {
                        data = data + table["ayet"].ToString() + "\r\n"; ;
                    }
                    richText_sure.Text = data;
                    table.Close();
                    list_sure.Enabled = true;
                }
                else if (kitap == 3)
                {   
                    int sure = Convert.ToInt16(list_sure.SelectedValue.ToString());
                    richText_sure.Text = "";
                    list_sure.Enabled = false;
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM zebur where zebur.sureno=" + sure, Conn);
                    OleDbDataReader table = cmd.ExecuteReader();
                    string data = "";
                    while (table.Read())
                    {
                        data = data + table["ayet"].ToString() + "\r\n"; ;
                    }
                    richText_sure.Text = data;
                    table.Close();
                    list_sure.Enabled = true;
                }
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

        private void btn_forward_Click(object sender, EventArgs e)
        {
            int sure = Convert.ToInt16(list_sure.SelectedValue.ToString());         
            Conn = new OleDbConnection();
            try
            {                
                Conn.ConnectionString = conString;
                Conn.Open();                
                if (ayetno < ayetcount && ayetno>0)
                {
                    ayetno = ayetno + 1;
                    text_ayet.Text = ayetno.ToString();
                    OleDbCommand cmd = new OleDbCommand("SELECT  meal.* FROM meal where sure= " + sure + " and ayet=" + ayetno, Conn);
                    OleDbDataReader table = cmd.ExecuteReader();
                    while (table.Read())
                    {
                        text_meal.Text = table["ayet"].ToString() + ". " + table["meal"].ToString();
                        text_latin_arapca.Text = table["ayet"].ToString() + ". " + table["latince"].ToString();
                        text_arapca.Text = table["ayet"].ToString() + ". " + table["arapca"].ToString();     
                    }              
                    dAdapter = new OleDbDataAdapter("SELECT kuran.latince ,kuran.turkce FROM meal INNER JOIN kuran ON (meal.ayet = kuran.ayet) AND (meal.sure = kuran.sure) where meal.sure= " + sure + " and meal.ayet=" + ayetno, Conn);
                    dSet = new DataSet();
                    dAdapter.Fill(dSet, "meal");
                    DataTable dt = dSet.Tables["meal"];
                    dataGrid_ceviri.DataSource = dt;
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

        private void btn_back_Click(object sender, EventArgs e)
        {
            int sure = Convert.ToInt16(list_sure.SelectedValue.ToString());
            Conn = new OleDbConnection();
            try
            {
                Conn.ConnectionString = conString;
                Conn.Open();
                if (ayetno <= ayetcount && ayetno > 1)
                {
                    ayetno = ayetno - 1;
                    text_ayet.Text = ayetno.ToString();
                    OleDbCommand cmd = new OleDbCommand("SELECT  meal.* FROM meal where sure= " + sure + " and ayet=" + ayetno, Conn);
                    OleDbDataReader table = cmd.ExecuteReader();
                    while (table.Read())
                    {
                        text_meal.Text = table["ayet"].ToString() + ". " + table["meal"].ToString();
                        text_latin_arapca.Text = table["ayet"].ToString() + ". " + table["latince"].ToString();
                        text_arapca.Text = table["ayet"].ToString() + ". " + table["arapca"].ToString();     
                    }              
               

                    dAdapter = new OleDbDataAdapter("SELECT kuran.latince ,kuran.turkce FROM meal INNER JOIN kuran ON (meal.ayet = kuran.ayet) AND (meal.sure = kuran.sure) where meal.sure= " + sure + " and meal.ayet=" + ayetno, Conn);
                    dSet = new DataSet();
                    dAdapter.Fill(dSet, "meal");
                    DataTable dt = dSet.Tables["meal"];
                    dataGrid_ceviri.DataSource = dt;

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
      
        private void btn_go_Click(object sender, EventArgs e)
        {
            int sure = Convert.ToInt16(list_sure.SelectedValue.ToString());
            Conn = new OleDbConnection();
            ayetno = Convert.ToInt16(text_ayet.Text);
            try
            {
                Conn.ConnectionString = conString;
                Conn.Open();
               
                    OleDbCommand cmd = new OleDbCommand("SELECT  meal.* FROM meal where sure= " + sure + " and ayet=" + ayetno, Conn);
                    OleDbDataReader table = cmd.ExecuteReader();
                    while (table.Read())
                    {
                        text_meal.Text = table["ayet"].ToString() + ". " + table["meal"].ToString();
                        text_latin_arapca.Text = table["ayet"].ToString() + ". " + table["latince"].ToString();
                        text_arapca.Text = table["ayet"].ToString() + ". " + table["arapca"].ToString();
                    }


                    dAdapter = new OleDbDataAdapter("SELECT kuran.latince ,kuran.turkce FROM meal INNER JOIN kuran ON (meal.ayet = kuran.ayet) AND (meal.sure = kuran.sure) where meal.sure= " + sure + " and meal.ayet=" + ayetno, Conn);
                    dSet = new DataSet();
                    dAdapter.Fill(dSet, "meal");
                    DataTable dt = dSet.Tables["meal"];
                    dataGrid_ceviri.DataSource = dt;                
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

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (text_search.Text != "")
            {                
                btn_forward.Enabled = false;
                btn_back.Enabled = false;
                btn_go.Enabled = false;
                btn_search.Enabled = false;
                list_sure.Enabled = false;
                Conn = new OleDbConnection();
                string ara = text_search.Text;
                richText_sure.Text = "";
                try
                {
                    Conn.ConnectionString = conString;
                    Conn.Open();
                    if (kitap == 0)
                    {
                        OleDbCommand cmd = new OleDbCommand("SELECT  meal.* FROM meal where meal like '%" + ara + "%'", Conn);
                        OleDbDataReader table = cmd.ExecuteReader();
                        string data = "";
                        while (table.Read())
                        {
                            data = data + table["sureadi"].ToString() + "." + table["ayet"].ToString() + ". " + table["meal"].ToString() + "\r\n";                            
                        }
                        richText_sure.Text = data;
                        dAdapter = new OleDbDataAdapter("SELECT kuran.latince ,kuran.turkce FROM meal INNER JOIN kuran ON (meal.ayet = kuran.ayet) AND (meal.sure = kuran.sure) where kuran.turkce like '%" + ara + "%'", Conn);
                        dSet = new DataSet();
                        dAdapter.Fill(dSet, "meal");
                        DataTable dt = dSet.Tables["meal"];
                        dataGrid_ceviri.DataSource = dt;                       
                    }
                    else if (kitap == 1)
                    {
                        OleDbCommand cmd = new OleDbCommand("SELECT  tevrat.* FROM tevrat where tevrat.ayet like '%" + ara + "%'", Conn);
                        OleDbDataReader table = cmd.ExecuteReader();
                        string data = "";
                        while (table.Read())
                        {
                            data = data + table["ayet"].ToString() + "\r\n";  
                        }
                        richText_sure.Text = data;                        
                    }
                    else if (kitap == 2)
                    {
                        OleDbCommand cmd = new OleDbCommand("SELECT  zebur.* FROM zebur where zebur.ayet like '%" + ara + "%'", Conn);
                        OleDbDataReader table = cmd.ExecuteReader();
                        string data = "";
                        while (table.Read())
                        {
                            data = data + table["ayet"].ToString() + "\r\n"; ;
                        }
                        richText_sure.Text = data;
                    }
                    else if (kitap == 3)
                    {
                        OleDbCommand cmd = new OleDbCommand("SELECT  incil.* FROM incil where incil.ayet like '%" + ara + "%'", Conn);
                        OleDbDataReader table = cmd.ExecuteReader();
                        string data = "";
                        while (table.Read())
                        {
                            data = data + table["ayet"].ToString() + "\r\n"; ;
                        }
                        richText_sure.Text = data;
                    }
                    Conn.Close();
                    btn_forward.Enabled = true;
                    btn_back.Enabled = true;
                    btn_go.Enabled = true;
                    btn_search.Enabled = true;
                    list_sure.Enabled = true;
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
       
        private void richText_sure_TextChanged(object sender, EventArgs e)
        {
            if (text_search.Text != "")
                this.CheckKeyword(text_search.Text, Color.Yellow, 0);
            Application.DoEvents();
    
        }             

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.richText_sure.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richText_sure.SelectionStart;

                while ((index = this.richText_sure.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richText_sure.Select((index + startIndex), word.Length);
                    this.richText_sure.SelectionColor = color;
                    this.richText_sure.Select(selectStart, 0);
                    this.richText_sure.SelectionColor = Color.Black;
                    Application.DoEvents();
                }
            }
        }            

        private void btn_sort_az_Click(object sender, EventArgs e)
        {            
            try
            {
                list_sure.DataSource = null;
                Conn = new OleDbConnection();
                Conn.ConnectionString = conString;
                Conn.Open();               
                OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM sureler order by sureadi", Conn);
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet, "sureler");
                list_sure.DisplayMember = "suretam";
                list_sure.ValueMember = "sure";
                list_sure.DataSource = dSet.Tables["sureler"];                           
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

        private void btn_sort_inis_Click(object sender, EventArgs e)
        {            
            try
            {
                list_sure.DataSource = null;
                Conn = new OleDbConnection();
                Conn.ConnectionString = conString;
                Conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM sureler", Conn);
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet, "sureler");
                list_sure.DisplayMember = "sureinistam";
                list_sure.ValueMember = "sureinis";
                list_sure.DataSource = dSet.Tables["sureler"];
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

        private void btn_reset_Click(object sender, EventArgs e)
        {            
            try
            {
                list_sure.DataSource = null;
                Conn = new OleDbConnection();
                Conn.ConnectionString = conString;
                Conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM sureler ", Conn);
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet, "sureler");
                list_sure.DisplayMember = "suretam";
                list_sure.ValueMember = "sure";
                list_sure.DataSource = dSet.Tables["sureler"];
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

        private void btn_kuran_Click(object sender, EventArgs e)
        {
            kitap = 0;
          
            btn_forward.Visible = true;
            btn_back.Visible = true;
            btn_go.Visible = true;
            text_ayet.Visible = true;
            text_sure.Visible = true;            
            try
            {
                list_sure.DataSource = null;
                Conn = new OleDbConnection();
                Conn.ConnectionString = conString;
                Conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM sureler ", Conn);
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet, "sureler");
                list_sure.DisplayMember = "sureadi";
                list_sure.ValueMember = "sure";
                list_sure.DataSource = dSet.Tables["sureler"];
                list_sure.SelectedIndex = 0;
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

        private void btn_tevrat_Click(object sender, EventArgs e)
        {
            kitap = 1;

            btn_forward.Visible = false;
            btn_back.Visible = false;
            btn_go.Visible = false;
            text_ayet.Visible = false;
            text_sure.Visible = false;            
            try
            {
                list_sure.DataSource = null;
                Conn = new OleDbConnection();
                Conn.ConnectionString = conString;
                Conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM tevrat_sureler ", Conn);
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet, "tevrat_sureler");
                list_sure.DisplayMember = "sureadi";
                list_sure.ValueMember = "sureno";
                list_sure.DataSource = dSet.Tables["tevrat_sureler"];
                list_sure.SelectedIndex = 0;
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

        private void btn_incil_Click(object sender, EventArgs e)
        {
            kitap = 2;
            kitapsec = false;
            btn_forward.Visible = false;
            btn_back.Visible = false;
            btn_go.Visible = false;
            text_ayet.Visible = false;
            text_sure.Visible = false;            
            try
            {
                list_sure.DataSource = null;
                Conn = new OleDbConnection();
                Conn.ConnectionString = conString;
                Conn.Open();               
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM incil_sureler", Conn);
                OleDbDataReader table = cmd.ExecuteReader();
                ArrayList IncilSureler = new ArrayList();
                while (table.Read())
                {
                    IncilSureler.Add(new Kitapinfo(table["kitap"].ToString() + "-" + table["sureadi"].ToString(), table["kitap"].ToString() + "-" + table["sureno"].ToString()));                    
                } 
                list_sure.DisplayMember = "LongName";
                list_sure.ValueMember = "ShortName";
                list_sure.DataSource = IncilSureler;
                list_sure.SelectedIndex = 0;
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

        private void btn_zebur_Click(object sender, EventArgs e)
        {
            kitap = 3;

            btn_forward.Visible = false;
            btn_back.Visible = false;
            btn_go.Visible = false;
            text_ayet.Visible = false;
            text_sure.Visible = false;           
            try
            {
                list_sure.DataSource = null;
                Conn = new OleDbConnection();
                Conn.ConnectionString = conString;
                Conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter("SELECT * FROM zebur_sureler ", Conn);
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet, "zebur_sureler");
                list_sure.DisplayMember = "sureadi";
                list_sure.ValueMember = "sureno";
                list_sure.DataSource = dSet.Tables["zebur_sureler"];
                list_sure.SelectedIndex = 0;
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
