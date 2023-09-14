using System;
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
    public partial class bosaraclar : Form
    {
        public bosaraclar()
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
        private void bosaraclar_Load(object sender, EventArgs e)
        {
            verilerigöster("Select * from boşaraçlar");
            dataGridView1.Columns[0].Visible = false;
        }

        private void bosaraclar_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
