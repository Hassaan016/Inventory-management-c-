using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Inventory_Management
{
    public partial class add_product_name : Form
    {
        bool bHandlingDataGridEvent = false;

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Github_Repos\Hassaan\Inventory-management-c#\Inventory-Management\Inventory.mdf;Integrated Security=True");

        public add_product_name()
        {
            InitializeComponent();
        }


        private void add_product_name_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            vFillSelectUnitInfo();
            vFillProductNameInfo();
        }


        public void vFillSelectUnitInfo()
        {
            comboBox1.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from units";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["unit"].ToString());
            }
        }


        public void vFillProductNameInfo()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from product_name";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if((bHandlingDataGridEvent == true))
            {
                return;
            }

            Console.WriteLine("DEBUG_PRODUCT_NAME: dataGridView1_CellContentClick() Called!");

            bHandlingDataGridEvent = true;

            if ((dataGridView1.SelectedCells[0].Value.ToString() != ""))
            {
                panel2.Visible = true;
                comboBox2.Items.Clear();
                comboBox2.Text = "";


                int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from units";
                cmd2.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(dt2);

                foreach (DataRow dr2 in dt2.Rows)
                {
                    comboBox2.Items.Add(dr2["unit"].ToString());
                }

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from product_name where id=" + i + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["product_name"].ToString();
                    comboBox2.SelectedText = dr["units"].ToString();
                }
            }

            bHandlingDataGridEvent = false;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((bHandlingDataGridEvent == true))
            {
                return;
            }

            Console.WriteLine("DEBUG_PRODUCT_NAME: dataGridView1_CellClick() Called!");
            bHandlingDataGridEvent = true;

            if ((dataGridView1.SelectedCells[0].Value.ToString() != ""))
            {
                panel2.Visible = true;
                comboBox2.Items.Clear();
                comboBox2.Text = "";

                int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from units";
                cmd2.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(dt2);

                foreach (DataRow dr2 in dt2.Rows)
                {
                    comboBox2.Items.Add(dr2["unit"].ToString());
                }

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from product_name where id=" + i + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["product_name"].ToString();
                    comboBox2.SelectedItem = dr["units"].ToString();
                }
            }

            bHandlingDataGridEvent = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG_PRODUCT_NAME: Insert Button clicked!");

            if ((comboBox1.SelectedIndex != -1))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into product_name values('" + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "')";
                cmd.ExecuteNonQuery();

                textBox1.Text = "";
                vFillProductNameInfo();
                MessageBox.Show("Record Inserted Successfully", "Message");
            }
            else
            {
                MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                MessageBox.Show("ERROR: Invalid fields used:\nProduct Name\nSelect Unit", "Error", objMessageBoxButton, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG_PRODUCT_NAME: Update Button clicked!");

            if ((comboBox2.SelectedIndex != -1) && ((dataGridView1.Rows.Count >= 2) && (dataGridView1.SelectedCells[0].Value.ToString() != "")))
            {
                int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update product_name set product_name= '" + textBox2.Text + "',units='" + comboBox2.SelectedItem.ToString() + "' where id=" + i + "";
                cmd.ExecuteNonQuery();

                panel2.Visible = false;
                vFillProductNameInfo();

                MessageBox.Show("Record Updated Successfully","Message");
            }
            else
            {
                MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                MessageBox.Show("ERROR: Please select a unit", "Error", objMessageBoxButton, MessageBoxIcon.Error);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            int id;

            Console.WriteLine("DEBUG_PRODUCT_NAME: Delete Button clicked!");


            if ((dataGridView1.Rows.Count >= 2) && (dataGridView1.SelectedCells[0].Value.ToString() != ""))
            {
                id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from product_name where id='" + id + "'";
                cmd.ExecuteNonQuery();

                vFillProductNameInfo();
            }
        }
    }
}

