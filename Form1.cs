using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace postal_mange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //public string u_name, e_mail,p;
        // public int ph_no;

        public string u_name;
        public string p_as;

        public Form1(string un,string em)
        {
            InitializeComponent();

            u_name = un;
            p_as = em;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            string MyConnection2 = "datasource=localhost;port=3306;username=root;password=9490";
            string Query = "select phone,email from world.login where username= '" + u_name + "' and password = '" + p_as+ "'";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            //MyConn2.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter(MyCommand2);
            DataTable ds = new DataTable();
            adapt.Fill(ds);
            int ph = Convert.ToInt32(ds.Rows[0][0].ToString());
            string ema = ds.Rows[0][1].ToString();
            MessageBox.Show("User name: " + u_name + "\n\nPhone Number: " + ph +"\n\nE-mail: "+ema );
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form3().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form4().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int p_id = rnd.Next(1, 100000);
            try
            {
                
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=9490";

                
                //string Query = "insert into world.delivery values ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + p_id + "','" + u_name +"');";
                string Query = "insert into world.delivery values ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + p_id + "','" + u_name + "');";
                string Query2 = "insert into world.transport values ('" + p_id + "','" + u_name + "','" + this.textBox1.Text + "');";


                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                MessageBox.Show("Pay at the reception and collect paid_id");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();

               MySqlConnection MyConn3 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand3 = new MySqlCommand(Query2, MyConn3);
                MySqlDataReader MyReader3;
                MyConn3.Open();
                MyReader3 = MyCommand3.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                while (MyReader3.Read())
                {
                }
                MyConn3.Close();

           }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "---> RANDOM NUMBER REPREAT   ");
            }

            //now depending on the values of pickup and drop we pur check constrain in the transport table.
        }
    }
}
