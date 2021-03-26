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
    public partial class Form5 : Form
    {
        OleDbConnection baglanti;
        OleDbDataAdapter adaptor;
        DataSet veri;

        public static string sıra;
        public static bool silme = false;
        public static bool güncelleme=false;

        void vericek()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=cihaz veritabanı.accdb");
            adaptor = new OleDbDataAdapter("Select * from Cihazlar", baglanti);
            veri = new DataSet();
            baglanti.Open();
            adaptor.Fill(veri, "Cihazlar");
            dataGridView1.DataSource = veri.Tables["Cihazlar"];
            baglanti.Close();
            veriler();
        }

        public Form5()
        {
            InitializeComponent();
            veriler();
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            vericek();
            this.Hide();
            this.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            vericek();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {

                MessageBox.Show("Lütfen Güncellemek İstediğiniz Cihazın Üstüne Çift Tıklayın", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                güncelleme = true;
                silme = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
                MessageBox.Show("Lütfen Silmek İstediğiniz Cihazın Üstüne Çift Tıklayın", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                silme = true;
                güncelleme = false; 
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sıra = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (güncelleme == true)
            {
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
            }
            if (silme == true)
            {
                Form4 f4 = new Form4();
                f4.Show();
                this.Hide();
            }
        }

      

        public static string v1, v2, v3, v4, v5;


        void veriler()
        {
            if (dataGridView1.Rows.Count <= 1)
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            if(dataGridView1.Rows.Count>=2)
            {
                button3.Enabled = true;
                button2.Enabled = true;
                v1 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                v2 = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                v3 = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                v4 = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                v5 = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            

        }
    }
}
