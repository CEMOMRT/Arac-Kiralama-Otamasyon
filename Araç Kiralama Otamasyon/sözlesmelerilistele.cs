﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Araç_Kiralama_Otamasyon
{
    public partial class sözlesmelerilistele : Form
    {
        public sözlesmelerilistele()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabanı.mdb");
        public void verilerigöster(string veriler)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void sözlesmelerilistele_Load(object sender, EventArgs e)
        {
            verilerigöster("Select * from yenisözleşme");
            dataGridView1.Columns[0].Visible = false;
            this.WindowState = FormWindowState.Maximized;
        }

        private void sözlesmelerilistele_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
