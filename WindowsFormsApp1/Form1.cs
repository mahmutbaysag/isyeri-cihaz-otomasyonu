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
    public partial class Form1 : Form
    {
        OleDbConnection baglanti;
        OleDbDataAdapter adaptor;
        OleDbCommand komut;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if((((comboBox1.Text== null) || (comboBox2.Text == null)) || (comboBox3.Text == null)) || (textBox1.Text == null))
            {
                MessageBox.Show("Lütfen Tüm Bilgileri Giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                komut.Connection = baglanti;
                komut.CommandText = "insert into cihazlar (Cihaz, Marka, Seri, Tarih, Durum) values(@p1, @p2, @p3, @p4, @p5)";

                komut.Parameters.AddWithValue("@p1", comboBox1.Text.ToString());
                komut.Parameters.AddWithValue("@p2", comboBox3.Text.ToString());
                komut.Parameters.AddWithValue("@p3", textBox1.Text.ToString());
                komut.Parameters.AddWithValue("@p4", dateTimePicker1.Text.ToString());
                komut.Parameters.AddWithValue("@p5", comboBox2.Text.ToString());


                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Cihaz Başarıyla Eklendi.", "İşlem Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=cihaz veritabanı.accdb");
            adaptor = new OleDbDataAdapter("Select * from cihazlar", baglanti);


            komut = new OleDbCommand();
        }
    }
}
