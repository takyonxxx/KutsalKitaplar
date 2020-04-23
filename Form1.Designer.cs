namespace Kuran
{
    partial class form_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_main));
            this.dataGrid_ceviri = new System.Windows.Forms.DataGridView();
            this.text_arapca = new System.Windows.Forms.TextBox();
            this.richText_sure = new System.Windows.Forms.RichTextBox();
            this.btn_sort_az = new System.Windows.Forms.Button();
            this.btn_sort_inis = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.text_latin_arapca = new System.Windows.Forms.TextBox();
            this.text_meal = new System.Windows.Forms.TextBox();
            this.text_search = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_forward = new System.Windows.Forms.Button();
            this.text_sure = new System.Windows.Forms.TextBox();
            this.text_ayet = new System.Windows.Forms.TextBox();
            this.btn_go = new System.Windows.Forms.Button();
            this.btn_zebur = new System.Windows.Forms.Button();
            this.btn_incil = new System.Windows.Forms.Button();
            this.btn_tevrat = new System.Windows.Forms.Button();
            this.btn_kuran = new System.Windows.Forms.Button();
            this.group_controls = new System.Windows.Forms.GroupBox();
            this.group_sure = new System.Windows.Forms.GroupBox();
            this.list_sure = new System.Windows.Forms.ListBox();
            this.group_ceviri = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ceviri)).BeginInit();
            this.group_controls.SuspendLayout();
            this.group_sure.SuspendLayout();
            this.group_ceviri.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid_ceviri
            // 
            this.dataGrid_ceviri.AllowUserToAddRows = false;
            this.dataGrid_ceviri.AllowUserToDeleteRows = false;
            this.dataGrid_ceviri.AllowUserToOrderColumns = true;
            this.dataGrid_ceviri.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGrid_ceviri.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid_ceviri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid_ceviri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_ceviri.Location = new System.Drawing.Point(15, 89);
            this.dataGrid_ceviri.Margin = new System.Windows.Forms.Padding(6);
            this.dataGrid_ceviri.Name = "dataGrid_ceviri";
            this.dataGrid_ceviri.ReadOnly = true;
            this.dataGrid_ceviri.RowHeadersWidth = 82;
            this.dataGrid_ceviri.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid_ceviri.Size = new System.Drawing.Size(1541, 252);
            this.dataGrid_ceviri.TabIndex = 15;
            // 
            // text_arapca
            // 
            this.text_arapca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.text_arapca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.text_arapca.ForeColor = System.Drawing.Color.White;
            this.text_arapca.Location = new System.Drawing.Point(15, 581);
            this.text_arapca.Margin = new System.Windows.Forms.Padding(6);
            this.text_arapca.Multiline = true;
            this.text_arapca.Name = "text_arapca";
            this.text_arapca.ReadOnly = true;
            this.text_arapca.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_arapca.Size = new System.Drawing.Size(1541, 100);
            this.text_arapca.TabIndex = 18;
            // 
            // richText_sure
            // 
            this.richText_sure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.richText_sure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richText_sure.ForeColor = System.Drawing.Color.White;
            this.richText_sure.Location = new System.Drawing.Point(350, 12);
            this.richText_sure.Margin = new System.Windows.Forms.Padding(6);
            this.richText_sure.Name = "richText_sure";
            this.richText_sure.ReadOnly = true;
            this.richText_sure.Size = new System.Drawing.Size(1200, 478);
            this.richText_sure.TabIndex = 11;
            this.richText_sure.Text = "";
            this.richText_sure.TextChanged += new System.EventHandler(this.richText_sure_TextChanged);
            // 
            // btn_sort_az
            // 
            this.btn_sort_az.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_sort_az.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sort_az.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sort_az.Location = new System.Drawing.Point(137, 17);
            this.btn_sort_az.Margin = new System.Windows.Forms.Padding(6);
            this.btn_sort_az.Name = "btn_sort_az";
            this.btn_sort_az.Size = new System.Drawing.Size(110, 50);
            this.btn_sort_az.TabIndex = 13;
            this.btn_sort_az.Text = "A-Z";
            this.btn_sort_az.UseVisualStyleBackColor = false;
            this.btn_sort_az.Click += new System.EventHandler(this.btn_sort_az_Click);
            // 
            // btn_sort_inis
            // 
            this.btn_sort_inis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_sort_inis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sort_inis.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sort_inis.Location = new System.Drawing.Point(15, 17);
            this.btn_sort_inis.Margin = new System.Windows.Forms.Padding(6);
            this.btn_sort_inis.Name = "btn_sort_inis";
            this.btn_sort_inis.Size = new System.Drawing.Size(110, 50);
            this.btn_sort_inis.TabIndex = 12;
            this.btn_sort_inis.Text = "İNİŞ";
            this.btn_sort_inis.UseVisualStyleBackColor = false;
            this.btn_sort_inis.Click += new System.EventHandler(this.btn_sort_inis_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.Location = new System.Drawing.Point(259, 17);
            this.btn_reset.Margin = new System.Windows.Forms.Padding(6);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(152, 50);
            this.btn_reset.TabIndex = 14;
            this.btn_reset.Text = "RESET";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // text_latin_arapca
            // 
            this.text_latin_arapca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.text_latin_arapca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.text_latin_arapca.Location = new System.Drawing.Point(15, 353);
            this.text_latin_arapca.Margin = new System.Windows.Forms.Padding(6);
            this.text_latin_arapca.Multiline = true;
            this.text_latin_arapca.Name = "text_latin_arapca";
            this.text_latin_arapca.ReadOnly = true;
            this.text_latin_arapca.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_latin_arapca.Size = new System.Drawing.Size(1541, 100);
            this.text_latin_arapca.TabIndex = 16;
            // 
            // text_meal
            // 
            this.text_meal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.text_meal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.text_meal.Location = new System.Drawing.Point(15, 465);
            this.text_meal.Margin = new System.Windows.Forms.Padding(6);
            this.text_meal.Multiline = true;
            this.text_meal.Name = "text_meal";
            this.text_meal.ReadOnly = true;
            this.text_meal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_meal.Size = new System.Drawing.Size(1541, 100);
            this.text_meal.TabIndex = 17;
            // 
            // text_search
            // 
            this.text_search.BackColor = System.Drawing.Color.White;
            this.text_search.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_search.Location = new System.Drawing.Point(1329, 37);
            this.text_search.Margin = new System.Windows.Forms.Padding(6, 10, 6, 6);
            this.text_search.Name = "text_search";
            this.text_search.Size = new System.Drawing.Size(215, 35);
            this.text_search.TabIndex = 9;
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(1207, 33);
            this.btn_search.Margin = new System.Windows.Forms.Padding(6);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(110, 50);
            this.btn_search.TabIndex = 8;
            this.btn_search.Text = "ARA";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(963, 33);
            this.btn_back.Margin = new System.Windows.Forms.Padding(6);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(110, 50);
            this.btn_back.TabIndex = 6;
            this.btn_back.Text = "GERİ";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_forward
            // 
            this.btn_forward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_forward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_forward.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_forward.Location = new System.Drawing.Point(1085, 33);
            this.btn_forward.Margin = new System.Windows.Forms.Padding(6);
            this.btn_forward.Name = "btn_forward";
            this.btn_forward.Size = new System.Drawing.Size(110, 50);
            this.btn_forward.TabIndex = 7;
            this.btn_forward.Text = "İLERİ";
            this.btn_forward.UseVisualStyleBackColor = false;
            this.btn_forward.Click += new System.EventHandler(this.btn_forward_Click);
            // 
            // text_sure
            // 
            this.text_sure.BackColor = System.Drawing.Color.Black;
            this.text_sure.Enabled = false;
            this.text_sure.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_sure.ForeColor = System.Drawing.Color.White;
            this.text_sure.Location = new System.Drawing.Point(819, 37);
            this.text_sure.Margin = new System.Windows.Forms.Padding(6);
            this.text_sure.Name = "text_sure";
            this.text_sure.ReadOnly = true;
            this.text_sure.Size = new System.Drawing.Size(132, 35);
            this.text_sure.TabIndex = 15;
            this.text_sure.Text = "1";
            // 
            // text_ayet
            // 
            this.text_ayet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.text_ayet.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_ayet.ForeColor = System.Drawing.Color.White;
            this.text_ayet.Location = new System.Drawing.Point(735, 37);
            this.text_ayet.Margin = new System.Windows.Forms.Padding(6);
            this.text_ayet.Name = "text_ayet";
            this.text_ayet.Size = new System.Drawing.Size(72, 35);
            this.text_ayet.TabIndex = 12;
            this.text_ayet.Text = "1";
            // 
            // btn_go
            // 
            this.btn_go.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_go.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_go.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_go.Location = new System.Drawing.Point(623, 33);
            this.btn_go.Margin = new System.Windows.Forms.Padding(6);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(100, 50);
            this.btn_go.TabIndex = 5;
            this.btn_go.Text = "GİT";
            this.btn_go.UseVisualStyleBackColor = false;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // btn_zebur
            // 
            this.btn_zebur.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_zebur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_zebur.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_zebur.Location = new System.Drawing.Point(471, 33);
            this.btn_zebur.Margin = new System.Windows.Forms.Padding(6);
            this.btn_zebur.Name = "btn_zebur";
            this.btn_zebur.Size = new System.Drawing.Size(140, 50);
            this.btn_zebur.TabIndex = 4;
            this.btn_zebur.Text = "ZEBUR";
            this.btn_zebur.UseVisualStyleBackColor = false;
            this.btn_zebur.Click += new System.EventHandler(this.btn_zebur_Click);
            // 
            // btn_incil
            // 
            this.btn_incil.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_incil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_incil.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_incil.Location = new System.Drawing.Point(319, 33);
            this.btn_incil.Margin = new System.Windows.Forms.Padding(6);
            this.btn_incil.Name = "btn_incil";
            this.btn_incil.Size = new System.Drawing.Size(140, 50);
            this.btn_incil.TabIndex = 3;
            this.btn_incil.Text = "İNCİL";
            this.btn_incil.UseVisualStyleBackColor = false;
            this.btn_incil.Click += new System.EventHandler(this.btn_incil_Click);
            // 
            // btn_tevrat
            // 
            this.btn_tevrat.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_tevrat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tevrat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tevrat.Location = new System.Drawing.Point(167, 33);
            this.btn_tevrat.Margin = new System.Windows.Forms.Padding(6);
            this.btn_tevrat.Name = "btn_tevrat";
            this.btn_tevrat.Size = new System.Drawing.Size(140, 50);
            this.btn_tevrat.TabIndex = 2;
            this.btn_tevrat.Text = "TEVRAT";
            this.btn_tevrat.UseVisualStyleBackColor = false;
            this.btn_tevrat.Click += new System.EventHandler(this.btn_tevrat_Click);
            // 
            // btn_kuran
            // 
            this.btn_kuran.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_kuran.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_kuran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_kuran.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_kuran.Location = new System.Drawing.Point(15, 33);
            this.btn_kuran.Margin = new System.Windows.Forms.Padding(6);
            this.btn_kuran.Name = "btn_kuran";
            this.btn_kuran.Size = new System.Drawing.Size(140, 50);
            this.btn_kuran.TabIndex = 1;
            this.btn_kuran.Text = "KURAN";
            this.btn_kuran.UseVisualStyleBackColor = false;
            this.btn_kuran.Click += new System.EventHandler(this.btn_kuran_Click);
            // 
            // group_controls
            // 
            this.group_controls.AutoSize = true;
            this.group_controls.Controls.Add(this.btn_incil);
            this.group_controls.Controls.Add(this.btn_kuran);
            this.group_controls.Controls.Add(this.text_search);
            this.group_controls.Controls.Add(this.btn_search);
            this.group_controls.Controls.Add(this.btn_tevrat);
            this.group_controls.Controls.Add(this.btn_back);
            this.group_controls.Controls.Add(this.btn_forward);
            this.group_controls.Controls.Add(this.text_sure);
            this.group_controls.Controls.Add(this.text_ayet);
            this.group_controls.Controls.Add(this.btn_zebur);
            this.group_controls.Controls.Add(this.btn_go);
            this.group_controls.Dock = System.Windows.Forms.DockStyle.Top;
            this.group_controls.Location = new System.Drawing.Point(0, 0);
            this.group_controls.Name = "group_controls";
            this.group_controls.Size = new System.Drawing.Size(1565, 116);
            this.group_controls.TabIndex = 1;
            this.group_controls.TabStop = false;
            // 
            // group_sure
            // 
            this.group_sure.AutoSize = true;
            this.group_sure.Controls.Add(this.list_sure);
            this.group_sure.Controls.Add(this.richText_sure);
            this.group_sure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_sure.Location = new System.Drawing.Point(0, 116);
            this.group_sure.Name = "group_sure";
            this.group_sure.Size = new System.Drawing.Size(3130, 970);
            this.group_sure.TabIndex = 2;
            this.group_sure.TabStop = false;
            // 
            // list_sure
            // 
            this.list_sure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.list_sure.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_sure.FormattingEnabled = true;
            this.list_sure.ItemHeight = 29;
            this.list_sure.Location = new System.Drawing.Point(6, 6);
            this.list_sure.Name = "list_sure";
            this.list_sure.Size = new System.Drawing.Size(339, 468);
            this.list_sure.TabIndex = 10;
            this.list_sure.SelectedIndexChanged += new System.EventHandler(this.list_sure_SelectedIndexChanged);
            // 
            // group_ceviri
            // 
            this.group_ceviri.Controls.Add(this.dataGrid_ceviri);
            this.group_ceviri.Controls.Add(this.text_latin_arapca);
            this.group_ceviri.Controls.Add(this.text_meal);
            this.group_ceviri.Controls.Add(this.text_arapca);
            this.group_ceviri.Controls.Add(this.btn_sort_inis);
            this.group_ceviri.Controls.Add(this.btn_sort_az);
            this.group_ceviri.Controls.Add(this.btn_reset);
            this.group_ceviri.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.group_ceviri.Location = new System.Drawing.Point(0, 601);
            this.group_ceviri.Name = "group_ceviri";
            this.group_ceviri.Size = new System.Drawing.Size(1565, 696);
            this.group_ceviri.TabIndex = 22;
            this.group_ceviri.TabStop = false;
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1565, 1297);
            this.Controls.Add(this.group_sure);
            this.Controls.Add(this.group_controls);
            this.Controls.Add(this.group_ceviri);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "form_main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " TÜRKAY BİLİYOR Kutsal_Kitaplar";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ceviri)).EndInit();
            this.group_controls.ResumeLayout(false);
            this.group_controls.PerformLayout();
            this.group_sure.ResumeLayout(false);
            this.group_ceviri.ResumeLayout(false);
            this.group_ceviri.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGrid_ceviri;
        private System.Windows.Forms.TextBox text_arapca;
        private System.Windows.Forms.RichTextBox richText_sure;
        private System.Windows.Forms.Button btn_sort_az;
        private System.Windows.Forms.Button btn_sort_inis;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.TextBox text_latin_arapca;
        private System.Windows.Forms.TextBox text_meal;
        private System.Windows.Forms.TextBox text_search;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_forward;
        private System.Windows.Forms.TextBox text_sure;
        private System.Windows.Forms.TextBox text_ayet;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.Button btn_zebur;
        private System.Windows.Forms.Button btn_incil;
        private System.Windows.Forms.Button btn_tevrat;
        private System.Windows.Forms.Button btn_kuran;
        private System.Windows.Forms.GroupBox group_controls;
        private System.Windows.Forms.GroupBox group_sure;
        private System.Windows.Forms.GroupBox group_ceviri;
        private System.Windows.Forms.ListBox list_sure;
    }
}

