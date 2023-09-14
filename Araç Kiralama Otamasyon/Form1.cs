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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabanı.mdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataReader dr;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int sayı1 = rastgele.Next(0, 10);
            int sayı2 = rastgele.Next(0, 10);
            int sayı3 = rastgele.Next(0, 10);
            int sayı4 = rastgele.Next(0, 10);
            label5.Text = sayı1.ToString() + sayı2.ToString() + sayı3.ToString() + sayı4.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Yönetici") 
            {
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "Select * from yönetici where Kullanıcıİsmi='" + textBox1.Text + "' and KullanıcıŞifre='" + textBox2.Text + "'";
                dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    Form2 frm2 = new Form2();
                    if (textBox3.Text == label5.Text)
                    {
                        
                        frm2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Güvenlik Kodunu Kontrol Ediniz !");
                        textBox3.Clear();
                        textBox3.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Lütfen Kullanıcı Adınızı veya Şifrenizi Kontrol Ediniz !");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
                baglan.Close();
                }
            if (comboBox1.Text == "Çalışan")
            {
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "Select * from çalışan where Kullanıcıİsmi='" + textBox1.Text + "' and KullanıcıŞifre='" + textBox2.Text + "'";
                dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    Form2 frm2 = new Form2();
                    if (textBox3.Text == label5.Text)
                    {
                        MessageBox.Show("Giriş Yapılıyor Lütfen Bekleyiniz...");
                        frm2.toolStripMenuItem3.Visible = false;
                        frm2.asdToolStripMenuItem.Visible = false;
                        frm2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Güvenlik Kodunu Kontrol Ediniz !");
                        textBox3.Clear();
                        textBox3.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Lütfen Kullanıcı Adınızı veya Şifrenizi Kontrol Ediniz !");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
                baglan.Close();
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Lütfen Yetki Türünü Seçiniz...");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}