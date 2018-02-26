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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=9490";
                string Query = "select count(*) from world.login where username= '" + this.textBox1.Text + "' and password = '" + this.textBox2.Text+"'";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //MyConn2.Open();
                MySqlDataAdapter adapt = new MySqlDataAdapter(MyCommand2);
                DataTable ds = new DataTable();
                adapt.Fill(ds);

                //int count = ds.Tables[0].Rows.Count;
                //MyConn2.Close();

                if (ds.Rows[0][0].ToString()== "1")
                {
                    String u_n, pa;
                    u_n = textBox1.Text;
                    pa = textBox2.Text;
                    Form1 fo = new Form1(u_n,pa);
                    this.Hide();
                    fo.Show();
                    MessageBox.Show("Login Successful");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form7 fw = new Form7();
            fw.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 r = new Form8();
            r.Show();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form7 fw = new Form7();
            fw.Show();
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form8 r = new Form8();
            r.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
