using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postal_mange
{
    public partial class Form2 : Form
    {
        public String unm, paa;
        public Form2()
        {
            InitializeComponent();
        }
        
        public Form2(string u, string e)
        {
           /* unm = "LOL";
            ema = "TEST";
            phno = 123;*/
            unm = u;
            paa = e;
            MessageBox.Show("Username: " + unm + "  passw :" + paa);

            textBox1.Text = u;
            // textBox2.Text = ema;
            // textBox3.Text = phno.ToString();
            /*label5.Text = this.unm;
            string MyConnection2 = "datasource=localhost;port=3306;username=root;password=9490";
            string Query = "select phone,email from world.login where username= '" + unm + "' and password = '" + paa + "'";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            //MyConn2.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter(MyCommand2);
            DataTable ds = new DataTable();
            adapt.Fill(ds);
            label6.Text = ds.Rows[0][0].ToString();
            label6.Text = ds.Rows[0][1].ToString();*/

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
        }
    }
}
