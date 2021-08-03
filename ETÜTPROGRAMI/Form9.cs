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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-M4Q4SMD\SQLEXPRESS;Initial Catalog=giriş;Integrated Security=True");
        SqlConnection baglanti2 = new SqlConnection(@"Data Source=DESKTOP-M4Q4SMD\SQLEXPRESS;Initial Catalog=ETUT;Integrated Security=True");


        private void Form9_Load(object sender, EventArgs e)
        {
            baglanti2.Open();
            SqlCommand komut2 = new SqlCommand("select * from tbl_ogrt",baglanti2);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                comboBox1.Items.Add(dr2[1]);
            }
            baglanti2.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("BU ALANLAR BOŞ BIRAKILAMAZ!");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from tbl_g where SIFRE=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    Form11 frm11 = new Form11();
                    frm11.ad = comboBox1.Text;
                    frm11.Show();

                }
                else
                {
                    MessageBox.Show("HESAP BİLGİLERİ YANLIŞ LÜTFEN TEKRAR DENEYİNİZ");
                }
                baglanti.Close();
            }
            

        }
    }
}
