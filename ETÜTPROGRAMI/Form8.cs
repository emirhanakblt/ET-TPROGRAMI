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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-M4Q4SMD\SQLEXPRESS;Initial Catalog=ETUT;Integrated Security=True");


        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("BOŞ ALAN BIRAKILAMAZ !");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * from tbl_ogr where AD=@p1 and MAIL=@p2 and TELEFON=@p3", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3", textBox3.Text);


                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    Form10 frm10 = new Form10();
                    frm10.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("HESAP BİLGİLERİ YANLIŞ LÜTFEN TEKRAR DENEYİNİZ!");
                }
                baglanti.Close();
            }
        }
    }
}
