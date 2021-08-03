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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-M4Q4SMD\SQLEXPRESS;Initial Catalog=ETUT;Integrated Security=True");

        public string ad;
        private void Form11_Load(object sender, EventArgs e)
        {



            
            baglanti.Open();

            SqlDataAdapter dr = new SqlDataAdapter("select * from tbl_ogrt", baglanti);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            comboBox2.ValueMember = "OGRTID";          
            comboBox2.DisplayMember = "AD";
            comboBox2.DataSource = dt;
            //comboBox2.Text = ad;
            
            baglanti.Close();





            baglanti.Open();

            SqlDataAdapter dr2 = new SqlDataAdapter("select * from tbl_ders where DERSID=" + comboBox2.SelectedValue, baglanti);
            DataTable dt2 = new DataTable();
            dr2.Fill(dt2);
            comboBox1.ValueMember = "DERSID";
            comboBox1.DisplayMember = "DERSAD";
            comboBox1.DataSource = dt2;

            baglanti.Close();



        }
    }
}
