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

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        OleDbConnection baglanti;
        OleDbDataAdapter adaptor;
        OleDbCommand komut;
        

        public Form3()
        {
            InitializeComponent();
        }
        string sıra;
        private void Form3_Load(object sender, EventArgs e)
        {
             sıra = Form5.sıra;
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=cihaz veritabanı.accdb");
            adaptor = new OleDbDataAdapter("Select * from cihazlar", baglanti);

            comboBox1.Text = Form5.v1;
            comboBox3.Text = Form5.v2;
            textBox1.Text = Form5.v3;
            dateTimePicker1.Text = Form5.v4;
            comboBox2.Text = Form5.v5;

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if ((((comboBox1.Text == null) || (comboBox2.Text == null)) || (comboBox3.Text == null)) || (textBox1.Text == null))
            {
                MessageBox.Show("Lütfen Tüm Bilgileri Giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                string sorgu = "Update cihazlar set Cihaz=@p1, Marka=@p2, Seri=@p3, Tarih=@p4, Durum=@p5 where sıra=@sıra";
                komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", comboBox1.Text);
                komut.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut.Parameters.AddWithValue("@p3", textBox1.Text);
                komut.Parameters.AddWithValue("@p4", dateTimePicker1.Text);
                komut.Parameters.AddWithValue("@p5", comboBox2.Text);
                komut.Parameters.AddWithValue("@sıra", sıra);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Cihaz Başarıyla Güncellendi.", "İşlem Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form5.güncelleme = false;
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();
        }
    }
}
