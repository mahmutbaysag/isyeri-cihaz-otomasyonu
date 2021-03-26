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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form5.silme = false;
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();

        }
        string sıra = Form5.sıra;
        OleDbConnection baglanti;
        OleDbDataAdapter adaptor;
        OleDbCommand komut;
        private void Form4_Load(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=cihaz veritabanı.accdb");
            adaptor = new OleDbDataAdapter("Select * from cihazlar", baglanti);

            textBox2.Text = Form5.v1;
            textBox3.Text = Form5.v2;
            textBox4.Text = Form5.v3;
            textBox5.Text = Form5.v4;
            textBox6.Text = Form5.v5;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete from cihazlar Where sıra=@sıra";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@sıra", sıra);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Cihaz Başarıyla Silindi.", "İşlem Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
