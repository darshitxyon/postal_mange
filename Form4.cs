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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=9490";



                string Query = "select count(*) from world.employee where emp_user= '" + this.textBox1.Text + "' and emp_login = '" + this.textBox2.Text + "'";



                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //MyConn2.Open();
                MySqlDataAdapter adapt = new MySqlDataAdapter(MyCommand2);
                DataTable ds = new DataTable();
                adapt.Fill(ds);

                //int count = ds.Tables[0].Rows.Count;
                //MyConn2.Close();

                if (ds.Rows[0][0].ToString() == "1")
                {
                    Form5 fo = new Form5();
                    this.Hide();
                    fo.Show();
                    MessageBox.Show("Login Successful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//On password being corect
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
