using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ETÜTPROGRAMI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-M4Q4SMD\SQLEXPRESS;Initial Catalog=ETUT;Integrated Security=True");
        private void Form2_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter dr = new SqlDataAdapter("select * from tbl_ders",baglanti);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            comboBox1.ValueMember = "DERSID";
            comboBox1.DisplayMember = "DERSAD";
            comboBox1.DataSource = dt;
            baglanti.Close();
            
            
            
            baglanti.Open();
            SqlDataAdapter dr3 = new SqlDataAdapter("select * from tbl_ders", baglanti);
            DataTable dt3 = new DataTable();
            dr3.Fill(dt3);
            comboBox3.ValueMember = "DERSID";
            comboBox3.DisplayMember = "DERSAD";
            comboBox3.DataSource = dt3;
            baglanti.Close();

            baglanti.Open();
            SqlDataAdapter dr4 = new SqlDataAdapter("select * from tbl_ogr", baglanti);
            DataTable dt4 = new DataTable();
            dr4.Fill(dt4);
            comboBox4.ValueMember = "OGRID";
            comboBox4.DisplayMember = "AD";
            comboBox4.DataSource = dt4;
            baglanti.Close();









        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_ogr (AD,SOYAD,FOTOGRAF,SINIF,TELEFON,MAIL,SUBE) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)",baglanti);
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox2.Text);
            komut.Parameters.AddWithValue("@p3",textBox3.Text);
            komut.Parameters.AddWithValue("@p4",textBox4.Text);
            komut.Parameters.AddWithValue("@p5",textBox6.Text);
            komut.Parameters.AddWithValue("@p6",textBox5.Text);
            komut.Parameters.AddWithValue("@p7",textBox7.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt başarılı");
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into tbl_ders (DERSAD) values (@p8)", baglanti);
            komut2.Parameters.AddWithValue("@p8", textBox8.Text);
            
            komut2.ExecuteNonQuery();
            MessageBox.Show("Kayıt başarılı");
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("insert into tbl_ogrt (AD,SOYAD,BRANSID) values (@h1,@h2,@h3)",baglanti);
            komut3.Parameters.AddWithValue("@h1",textBox10.Text);
            komut3.Parameters.AddWithValue("@h2",textBox9.Text);
            komut3.Parameters.AddWithValue("@h3",comboBox1.SelectedValue);
            komut3.ExecuteNonQuery();
            MessageBox.Show("Kayıt başarılı");
            baglanti.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 gt = new Form3();
            gt.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 jk = new Form4();
            jk.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            SqlDataAdapter dr2 = new SqlDataAdapter("select * from tbl_ogrt where BRANSID="+comboBox3.SelectedValue, baglanti);
            DataTable dt2 = new DataTable();
            dr2.Fill(dt2);
            comboBox2.ValueMember = "OGRTID";
            comboBox2.DisplayMember = "AD";
            comboBox2.DataSource = dt2;
            comboBox2.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("insert into tbl_kurs (DERSID,OGRENCIID,OGRETMENID,TARIH,SAAT,DURUM) values (@k1,@k2,@k3,@k4,@k5,@k6)",baglanti);
            komut4.Parameters.AddWithValue("@k1",comboBox3.SelectedValue);
            komut4.Parameters.AddWithValue("@k2", comboBox4.SelectedValue);
            komut4.Parameters.AddWithValue("@k3", comboBox2.SelectedValue);
            komut4.Parameters.AddWithValue("@k4", maskedTextBox1.Text);
            komut4.Parameters.AddWithValue("@k5", maskedTextBox2.Text);
            komut4.Parameters.AddWithValue("@k6", label12.Text);
            komut4.ExecuteNonQuery();
            MessageBox.Show("Etüt oluşturuldu!");
            baglanti.Close();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
        }
    }
}
