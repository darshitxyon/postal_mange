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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            string name, e_id,  address, uname, pass, conpass;
            int ph_no;
            name = txtName.Text;
            e_id = txtEmail.Text;
            address = txtAddress.Text;
            ph_no = Convert.ToInt32(this.txtPhone.Text);
            uname = txtUserName.Text;
            pass = txtPassword.Text;
            conpass =txtConfirm.Text;

            if(pass==conpass)
            {
                try
                {   

                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=9490";
                    string Query = "insert into world.login values ('" + name + "','" + pass + "'," + ph_no+ ",'" + e_id + "');";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                    MessageBox.Show("Login please");
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();
                    Form6 ab = new Form6();
                    this.Hide();
                    ab.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "coded by poorvi  ");
                }
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
