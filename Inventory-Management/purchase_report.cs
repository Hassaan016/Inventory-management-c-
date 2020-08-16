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
    public partial class purchase_report : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Github_Repos\Hassaan\Inventory-management-c#\Inventory-Management\Inventory.mdf;Integrated Security=True");
        string query = "";

        public purchase_report()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG_PURCHASE_REPORT: Search Button Clicked!");

            string startdate;
            string enddate;

            startdate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            enddate = dateTimePicker1.Value.ToString("dd-MM-yyyy");

            if((textBox1.Text != ""))
            {
                query = "select * from purchase_master where product_name='" + textBox1.Text + "' OR product_quantity='" + textBox1.Text + "' OR product_unit='" + textBox1.Text + "' OR product_price='" + textBox1.Text + "'";
            }
            else
            {
                query = "select * from purchase_master where product_date>='" + startdate.ToString() + "' AND product_date<='" + enddate.ToString() + "'";
            }


            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            foreach (DataRow dr in dt.Rows)
            {
                i = i + Convert.ToInt32(dr["product_total"].ToString());
            }

            //label3.Text = i.ToString();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG_PURCHASE_REPORT: All Purchase Button Clicked!");

            query = "select * from purchase_master";

            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            foreach(DataRow dr in dt.Rows)
            {
                i = i + Convert.ToInt32(dr["product_total"].ToString());
            }

            //label3.Text = i.ToString();

        }


        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG_PURCHASE_REPORT: Print Button Clicked!");

            genereate_purchase_report objGeneratePurchaseReport = new genereate_purchase_report();
            objGeneratePurchaseReport.get_value(query.ToString());
            objGeneratePurchaseReport.Show();
        }


        private void purchase_report_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
        }
    }
}
