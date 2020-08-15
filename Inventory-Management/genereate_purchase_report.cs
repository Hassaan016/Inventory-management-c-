using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Inventory_Management.Properties;
using CrystalDecisions.Windows.Forms;

namespace Inventory_Management
{
    public partial class genereate_purchase_report : Form
    {
        string j;
        int tot = 0;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Github_Repos\Hassaan\Inventory-management-c#\Inventory-Management\Inventory.mdf;Integrated Security=True");

        public genereate_purchase_report()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        public void get_value(string i)
        {
            j = i;
        }

        private void genereate_purchase_report_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            Console.WriteLine("DEBUG_GENERATE_PURCHASE_REPORT: genereate_purchase_report_Load() Called!");

            if (j != "")
            {
                generate_purchase_report_dataset1 ds = new generate_purchase_report_dataset1();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = j;
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds.DataTable1);
                da.Fill(dt);

                tot = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    tot = tot + Convert.ToInt32(dr["product_total"].ToString());
                }

                generate_purchase_crystal_report myreport = new generate_purchase_crystal_report();

                myreport.SetDataSource(ds);
                myreport.SetParameterValue("Total", tot.ToString());
                crystalReportViewer1.ReportSource = myreport;
            }
        }
    }
}
