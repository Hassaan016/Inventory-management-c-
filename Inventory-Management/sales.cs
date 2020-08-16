using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Inventory_Management
{
    public partial class sales : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Github_Repos\Hassaan\Inventory-management-c#\Inventory-Management\Inventory.mdf;Integrated Security=True");
        DataTable dt = new DataTable();
        int tot = 0;

        public sales()
        {
            InitializeComponent();
        }


        public UInt32 ulSalesCalculateProductTotal()
        {
            UInt32 ulResult = 0;
            UInt32 ulProductQuantity = 0;
            UInt32 ulProductPrice = 0;

            bool bProductQuantityStatus = UInt32.TryParse(textBox4.Text, out ulProductQuantity);
            bool bProductPriceStatus = UInt32.TryParse(textBox5.Text, out ulProductPrice);


            if ((bProductQuantityStatus == true) && (bProductPriceStatus == true))
            {
                ulResult = (ulProductQuantity * ulProductPrice);
            }
            return (ulResult);
        }

        private void sales_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            vSalesFetchProductNameinfo();


            dt.Clear();
            dt.Columns.Add("firstname");
            dt.Columns.Add("lastname");
            dt.Columns.Add("billtype");
            dt.Columns.Add("product");
            dt.Columns.Add("price");
            dt.Columns.Add("quantity");
            dt.Columns.Add("purchase_date");
            dt.Columns.Add("total");
        }

        public void vSalesFetchProductNameinfo()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stock";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                //  comboBox2.Text = dr["product_name"].ToString();
                comboBox2.Items.Add(dr["product_name"].ToString());
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG_SALES: Add Sale Record Button Clicked!");

            string strSelectionType = "";
            bool bComboBoxValidTextField = false;
            bool bComboBoxValidSelectionMade = false;


            if ((comboBox2.Text != ""))
            {
                strSelectionType = comboBox2.Text;
                bComboBoxValidTextField = true;
            }

            if ((comboBox2.SelectedIndex != -1))
            {
                strSelectionType = comboBox2.SelectedItem.ToString();
                bComboBoxValidSelectionMade = true;
            }

            if ((bComboBoxValidTextField == true) && (bComboBoxValidSelectionMade == true))
            {
                int stock = 0;
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select * from stock where product_name='" + strSelectionType + "'";
                cmd1.ExecuteNonQuery();

                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(dt1);

                foreach (DataRow dr1 in dt1.Rows)
                {
                    stock = Convert.ToInt32(dr1["product_quantity"].ToString());
                }

                if ((Convert.ToInt32(textBox5.Text)) > stock)
                {
                    MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                    MessageBox.Show("ERROR: This much stock item not available", "Error", objMessageBoxButton, MessageBoxIcon.Error);
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["firstname"] = textBox1.Text;
                    dr["lastname"] = textBox2.Text;
                    dr["billtype"] = comboBox1.Text;
                    dr["product"] = comboBox2.Text;
                    dr["price"] = textBox4.Text;
                    dr["quantity"] = textBox5.Text;
                    dr["purchase_date"] = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                    dr["total"] = textBox6.Text;

                    dt.Rows.Add(dr);
                    dataGridView1.DataSource = dt;

                    tot = tot + Convert.ToInt32(dr["total"].ToString());

                    label10.Text = tot.ToString();
                }
            }
            else
            {
                MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                MessageBox.Show("ERROR: Please enter valid record fields", "Error", objMessageBoxButton, MessageBoxIcon.Error);
            }


            label12.Text = "0";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG_SALES: Delete Record Button Clicked!");
            bool bSalesDatagridValidSelection = ((dataGridView1.CurrentRow != null) && (dataGridView1.SelectedCells[0].Value != null) && (dataGridView1.SelectedCells[0].Value.ToString() != ""));

            if (bSalesDatagridValidSelection == true)
            {
                //tot = 0;
                tot = tot - Convert.ToInt32(dataGridView1.Rows[Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString())].Cells[3].Value);
                label10.Text = tot.ToString();
                label12.Text = "";

                dt.Rows.RemoveAt(Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString()));

//                 foreach (DataRow dr1 in dt.Rows)
//                 {
//                     Console.WriteLine("Total Field: {0}", Convert.ToInt32(dr1["total"].ToString()));
//                     tot = tot - Convert.ToInt32(dr1["total"].ToString());
//                     label10.Text = tot.ToString();
//                     label12.Text = "";
//                 }
            }
            else
            {
                MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                MessageBox.Show("ERROR: Please select a valid record", "Error", objMessageBoxButton, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG_SALES: Save & Print Button Clicked!");

            bool bSalesDatagridValidSelection = ((dataGridView1.CurrentRow != null) && (dataGridView1.SelectedCells[0].Value != null) && (dataGridView1.SelectedCells[0].Value.ToString() != ""));


            if ((bSalesDatagridValidSelection == true))
            {
                string orderid = "";
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into order_user values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "')";
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select top 1 * from order_user order by id desc";
                cmd2.ExecuteNonQuery();

                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(dt2);

                foreach (DataRow dr2 in dt2.Rows)
                {
                    orderid = dr2["id"].ToString();
                }

                foreach (DataRow dr in dt.Rows)
                {
                    int qty = 0;
                    string pname = "";

                    SqlCommand cmd3 = con.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "insert into order_item values('" + orderid.ToString() + "','" + dr["product"].ToString() + "','" + dr["price"].ToString() + "','" + dr["quantity"].ToString() + "','" + dr["total"].ToString() + "')";
                    cmd3.ExecuteNonQuery();

                    qty = Convert.ToInt32(dr["quantity"].ToString());
                    pname = (dr["product"].ToString());

                    SqlCommand cmd4 = con.CreateCommand();
                    cmd4.CommandType = CommandType.Text;
                    cmd4.CommandText = "update stock set product_quantity=product_quantity-" + qty + " where product_name='" + pname.ToString() + "'";
                    cmd4.ExecuteNonQuery();
                }

                vClearSalesInfoFields();
                dt.Clear();
                dataGridView1.DataSource = dt;

                generate_sales_bill_report objGenerateSalesBill = new generate_sales_bill_report();
                objGenerateSalesBill.get_value(Convert.ToInt32(orderid.ToString()));
                objGenerateSalesBill.Show();

                MessageBox.Show("Record Inserted Successfully", "Message");
            }
            else
            {
                MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                MessageBox.Show("ERROR: Please select a valid record", "Error", objMessageBoxButton, MessageBoxIcon.Error);
            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                textBox6.Text = Convert.ToString(ulSalesCalculateProductTotal());
            }
            catch (Exception ex)
            {

            }
        }


        public void vClearSalesInfoFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            label10.Text = "";
            label12.Text = "0";
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("comboBox2_SelectedIndexChanged() Called!");

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select top 1 * from stock where product_name='" + comboBox2.SelectedItem.ToString() + "' order by id desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                label12.Text = dr["product_quantity"].ToString();
            }

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select top 1 * from purchase_master where product_name='" + comboBox2.SelectedItem.ToString() + "' order by id desc";
            cmd1.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);

            foreach (DataRow dr1 in dt1.Rows)
            {
                textBox4.Text = (dr1["product_price"].ToString());
            }
        }

        private void btnClearSalesInfoFieldsClickCb(object sender, EventArgs e)
        {
            vClearSalesInfoFields();
        }
    }
}

//
// private void listBox1_KeyUp(object sender, KeyEventArgs e)
// {
//     string strSelectionType = "";
//     bool bComboBoxValidTextField = false;
//     bool bComboBoxValidSelectionMade = false;
//
//     Console.WriteLine("listBox1_KeyUp!");
//
//     if ((comboBox2.Text != ""))
//     {
//         strSelectionType = comboBox2.Text;
//         bComboBoxValidTextField = true;
//     }
//
//     if ((comboBox2.SelectedIndex != -1))
//     {
//         strSelectionType = comboBox2.SelectedIndex.ToString();
//         bComboBoxValidSelectionMade = true;
//     }
//
//     if ((bComboBoxValidTextField == true) || (bComboBoxValidSelectionMade == true))
//     {
//         listBox1.Visible = true;
//
//         listBox1.Items.Clear();
//         SqlCommand cmd = con.CreateCommand();
//         cmd.CommandType = CommandType.Text;
//         cmd.CommandText = "select * from stock where product_name like('" + strSelectionType + "%')";
//         cmd.ExecuteNonQuery();
//
//         DataTable dt = new DataTable();
//         SqlDataAdapter da = new SqlDataAdapter(cmd);
//         da.Fill(dt);
//
//         foreach (DataRow dr in dt.Rows)
//         {
//             listBox1.Items.Add(dr["product_name"].ToString());
//         }
//     }
//
// }
