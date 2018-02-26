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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=9490";
                //get curr location before updating and check it from the set....
                
                string Query1 = "select current_location from world.transport where paid_id= " + this.textBox1.Text + ";";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query1, MyConn2);
                MySqlDataAdapter adapt = new MySqlDataAdapter(MyCommand2);
                DataTable ds = new DataTable();
                adapt.Fill(ds);
                string prev_loc = ds.Rows[0][0].ToString();
                string next_loc = this.textBox2.Text;
                string[] South = { "Chennai", "Manipal", "Mangalore", "Udupi", "Goa", "Hyderabad" };
                string[] North = { "Mumbai", "Delhi", "Ahemdabad", "Agra", "Goa" };
                MessageBox.Show("Previous Location: "+prev_loc+"  Current Location: "+next_loc);

                //Final location check
                string Query3 = "select drop_location from world.delivery where paid_id= " + this.textBox1.Text + ";";
                MySqlConnection MyConn3 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand3 = new MySqlCommand(Query3, MyConn3);
                MySqlDataAdapter adapt1 = new MySqlDataAdapter(MyCommand3);
                DataTable dt = new DataTable();
                adapt1.Fill(dt);
                string final_loc = ds.Rows[0][0].ToString();

                if (final_loc == next_loc)
                {
                    this.Hide();
                    Form1 f1 = new Form1();
                    MessageBox.Show("The Location has been reached.");
                }

                if (South.Contains(prev_loc) && South.Contains(next_loc))
                {
                    try
                    {
                        string Query = "Update world.transport set current_location = '"+ this.textBox2.Text + "' where paid_id = "+ this.textBox1.Text;
                        MySqlConnection MyConn7 = new MySqlConnection(MyConnection2);
                        MySqlCommand MyCommand7 = new MySqlCommand(Query, MyConn7);
                        MySqlDataReader MyReader3;
                        MyConn7.Open();
                        MyReader3 = MyCommand7.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                        MessageBox.Show("Note: Updated the current location");
                        while (MyReader3.Read())
                        {
                        }
                        MyConn3.Close();
                   }
                    catch (Exception ex)
                    {
                       MessageBox.Show(ex.Message);
                   }
               }

                //Previous UPDATE ROUTE
               /* try
                 {
                  MessageBox.Show("FIRST ELSE");
                        string Query = "select * from world.path_finder where paid_id ="+this.textBox1.Text;
                        MySqlConnection MyConn6 = new MySqlConnection(MyConnection2);
                        MySqlCommand MyCommand6 = new MySqlCommand(Query, MyConn6);
                        MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                        MyAdapter.SelectCommand = MyCommand6;
                        DataTable dTable = new DataTable();
                        MyAdapter.Fill(dTable);
                        dataGridView1.DataSource = dTable;
                        //MyConn2.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //BACKTRACKING SHOW ROUTE IN GRID.*/
                
                if (North.Contains(prev_loc) && North.Contains(next_loc))
                {
                   try
                    {
                        string Query = "Update world.transport set current_location= '"+ this.textBox2.Text + "' where paid_id="+ this.textBox1.Text;
                        MySqlConnection MyConn4 = new MySqlConnection(MyConnection2);
                        MySqlCommand MyCommand4 = new MySqlCommand(Query, MyConn4);
                        MySqlDataReader MyReader4;
                        MyConn4.Open();
                        MyReader4 = MyCommand4.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                        MessageBox.Show("Note: Updated the current location");
                        while (MyReader4.Read())
                        {
                        }
                        MyConn4.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                try
                {

                    string Query2 = "select * from world.path_finder where paid_id =" + this.textBox1.Text;

                    MySqlConnection MyConn5 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand5 = new MySqlCommand(Query2, MyConn5);
                    MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
                    MyAdapter1.SelectCommand = MyCommand5;
                    DataTable dTable1 = new DataTable();
                    MyAdapter1.Fill(dTable1);
                    dataGridView2.DataSource = dTable1;
                    

                    




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            

        }
        catch(Exception ex)
            { MessageBox.Show(ex.Message); }
}


        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
