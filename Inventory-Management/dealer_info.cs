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
    public partial class dealer_info : Form
    {
        bool bHandlingDataGridEvent = false;

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Github_Repos\Hassaan\Inventory-management-c#\Inventory-Management\Inventory.mdf;Integrated Security=True");

        public dealer_info()
        {
            InitializeComponent();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG_DEALER: Insert button clicked!");
            Console.WriteLine("DEBUG_DEALER: New Dealer Parameters = {0} {1} {2} {3} {4}",
                              textBox1.Text,
                              textBox2.Text,
                              textBox3.Text,
                              textBox4.Text,
                              textBox5.Text
                             );

            bool bDealerInfoValidFields = ((textBox1.Text != "") &&
                                           (textBox2.Text != "") &&
                                           (textBox3.Text != "") &&
                                           (textBox4.Text != "") &&
                                           (textBox5.Text != ""));
//             int count = 0;
//             SqlCommand cmd1 = con.CreateCommand();
//             cmd1.CommandType = CommandType.Text;
//             cmd1.CommandText = "select * from dealer_info where dealer_name='" + textBox1.Text + "' where dealer_company_name='" + textBox2.Text + "'";
//             cmd1.ExecuteNonQuery();
//             DataTable dt1 = new DataTable();
//             SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
//             da1.Fill(dt1);
//             count = Convert.ToInt32(dt1.Rows.Count.ToString());
//
//             if ((count == 0))
//             {
            if ((bDealerInfoValidFields == true))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into dealer_info values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                cmd.ExecuteNonQuery();

                vClearDealerInfoFields();

                vDisplayDealerInfo();
                MessageBox.Show("Dealer info inserted successfully");
            }
            else
            {
                MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                MessageBox.Show("This dealer already registered please choose another", "Warning", objMessageBoxButton, MessageBoxIcon.Warning);
            }
//             }
//             else
//             {
//                 MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
//                 MessageBox.Show("This unit is already added", "Warning", objMessageBoxButton, MessageBoxIcon.Warning);
//             }
        }


        private void dealer_info_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            vDisplayDealerInfo();
        }


        public void vDisplayDealerInfo()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from dealer_info";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }


        private void btnDeleteDealerClickCb(object sender, EventArgs e)
        {
            int id;

            Console.WriteLine("DEBUG_DEALER: Delete Dealer Button clicked!");
            Console.WriteLine("DEBUG_DEALER: New Dealer Parameters = {0} {1} {2} {3} {4}",
                              textBox1.Text,
                              textBox2.Text,
                              textBox3.Text,
                              textBox4.Text,
                              textBox5.Text
                             );

            if ((dataGridView1.Rows.Count >= 2) && (dataGridView1.SelectedCells[0].Value != null))
            {
                id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from dealer_info where id='" + id + "'";
                cmd.ExecuteNonQuery();

                vDisplayDealerInfo();


                MessageBox.Show("Dealer Info Deleted Successfully", "Message");
            }
            else
            {
                MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                MessageBox.Show("ERROR: Please select a dealer", "Error", objMessageBoxButton, MessageBoxIcon.Error);
            }
        }


        private void btnUpdateDealerClickCb(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG_DEALER: Update Button clicked! {0}", dataGridView1.Rows.Count);
            Console.WriteLine("DEBUG_DEALER: New Dealer Parameters = {0} {1} {2} {3} {4}",
                              textBox1.Text,
                              textBox2.Text,
                              textBox3.Text,
                              textBox4.Text,
                              textBox5.Text
                             );

            bool bDealerInfoValidFields = ((textBox1.Text != "") &&
                                           (textBox2.Text != "") &&
                                           (textBox3.Text != "") &&
                                           (textBox4.Text != "") &&
                                           (textBox5.Text != ""));

            bool bDealerInfoDatagridValidSelection = (dataGridView1.Rows.Count >= 2) && (dataGridView1.SelectedCells[0].Value != null);

            if ((bDealerInfoValidFields == true) &&(bDealerInfoDatagridValidSelection == true))
            {
                int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update dealer_info set dealer_name= '" + textBox1.Text + "',dealer_company_name='" + textBox2.Text + "' ,contact='" + textBox3.Text + "' ,address='" + textBox4.Text + "' ,city='" + textBox5.Text + "' where id=" + i + "";
                cmd.ExecuteNonQuery();

                vDisplayDealerInfo();

                MessageBox.Show("Dealer Info Updated Successfully", "Message");
            }
            else
            {
                if ((bDealerInfoValidFields == true))
                {
                    MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                    MessageBox.Show("ERROR: Please Enter Valid Values", "Error", objMessageBoxButton, MessageBoxIcon.Error);
                }
                else if ((bDealerInfoDatagridValidSelection == true))
                {
                    MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                    MessageBox.Show("ERROR: Please select a dealer", "Error", objMessageBoxButton, MessageBoxIcon.Error);
                }

            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((bHandlingDataGridEvent == true))
            {
                return;
            }

            Console.WriteLine("DEBUG_DEALER: dataGridView1_CellContentClick() Called!");

            bHandlingDataGridEvent = true;

            if ((dataGridView1.SelectedCells[0].Value.ToString() != ""))
            {
                vClearDealerInfoFields();


                int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dealer_info where id=" + i + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    textBox1.Text = dr["dealer_name"].ToString();
                    textBox2.Text = dr["dealer_company_name"].ToString();
                    textBox3.Text = dr["contact"].ToString();
                    textBox4.Text = dr["address"].ToString();
                    textBox5.Text = dr["city"].ToString();
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

            Console.WriteLine("DEBUG_DEALER: dataGridView1_CellContentClick() Called!");

            bHandlingDataGridEvent = true;

            if ((dataGridView1.SelectedCells[0].Value.ToString() != ""))
            {
                vClearDealerInfoFields();


                int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dealer_info where id=" + i + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    textBox1.Text = dr["dealer_name"].ToString();
                    textBox2.Text = dr["dealer_company_name"].ToString();
                    textBox3.Text = dr["contact"].ToString();
                    textBox4.Text = dr["address"].ToString();
                    textBox5.Text = dr["city"].ToString();
                }
            }

            bHandlingDataGridEvent = false;
        }


        public void vClearDealerInfoFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

    }
}
