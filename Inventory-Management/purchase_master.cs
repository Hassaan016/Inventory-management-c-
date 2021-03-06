﻿using System;
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
    public partial class purchase_master : Form
    {
        bool bHandlingDataGridEvent = false;
        string[] astrPurchaseType = { "CASH", "DEBUT" };
        string query = "";

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Github_Repos\Hassaan\Inventory-management-c#\Inventory-Management\Inventory.mdf;Integrated Security=True");

        public purchase_master()
        {
            InitializeComponent();
        }

        private void purchase_master_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            vDisplayPurchaseMasterInfo();
            vFetchProductNameInfo();
            vFetchDealerNameInfo();
        }

        public void vFetchProductNameInfo()
        {
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from product_name";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["product_name"].ToString());
            }
        }


        public void vFetchDealerNameInfo()
        {
            comboBox2.Text = "";
            comboBox2.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from dealer_info";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["dealer_name"].ToString());
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from product_name where product_name='"+comboBox1.Text+"'";

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Unit.Text=dr["units"].ToString();
            }
        }

        public UInt32 ulPurchaseMasterCalculateProductTotal()
        {
            UInt32 ulResult = 0;
            UInt32 ulProductQuantity = 0;
            UInt32 ulProductPrice = 0;

            bool bProductQuantityStatus = UInt32.TryParse(textBox1.Text, out ulProductQuantity);
            bool bProductPriceStatus = UInt32.TryParse(textBox2.Text, out ulProductPrice);


            if ((bProductQuantityStatus == true) && (bProductPriceStatus == true))
            {
                ulResult = (ulProductQuantity * ulProductPrice);
            }
            return (ulResult);
        }


        public void vDisplayPurchaseMasterInfo()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from purchase_master";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }


        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(ulPurchaseMasterCalculateProductTotal());
        }


        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(ulPurchaseMasterCalculateProductTotal());
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG_PURCHASE_MASTER: Insert Button clicked!");

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from stock where product_name='" + comboBox1.Text + "'";

            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);

            int i = Convert.ToInt32(dt1.Rows.Count.ToString());

            Console.WriteLine(dateTimePicker1.Value.ToString("dd-MM-yyyy"));
            Console.WriteLine(dateTimePicker1.Value.Date);


            if (i == 0)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into purchase_master values('" + comboBox1.Text + "','" + textBox1.Text + "','" + Unit.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MM-yyyy") + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + dateTimePicker2.Value.Date.ToString("dd-MM-yyyy") + "','" + textBox4.Text + "')";
                cmd.ExecuteNonQuery();

                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "insert into stock values('" + comboBox1.Text + "','" + textBox1.Text + "','" + Unit.Text + "')";
                cmd3.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "insert into purchase_master values('" + comboBox1.Text + "','" + textBox1.Text + "','" + Unit.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MM-yyyy") + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + dateTimePicker2.Value.Date.ToString("dd-MM-yyyy") + "','" + textBox4.Text + "')";
                cmd2.ExecuteNonQuery();


                SqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "update stock set product_quantity=product_quantity +'"+textBox1.Text+"' where product_name='"+comboBox1.Text+"'";
                cmd4.ExecuteNonQuery();
            }

            vDisplayPurchaseMasterInfo();
        }


        private void btnDeletePurchaseMasterClickCb(object sender, EventArgs e)
        {
            int id;

            Console.WriteLine("DEBUG_PURCHASE_MASTER: Delete Dealer Button clicked!");


            if ((dataGridView1.Rows.Count >= 2) && (dataGridView1.SelectedCells[0].Value.ToString() != ""))
            {
                id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from purchase_master where id='" + id + "'";
                cmd.ExecuteNonQuery();

                vDisplayPurchaseMasterInfo();

                MessageBox.Show("Dealer Info Deleted Successfully", "Message");
            }
            else
            {
                MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                MessageBox.Show("ERROR: Please select a record", "Error", objMessageBoxButton, MessageBoxIcon.Error);
            }
        }


        private void btnUpdatePurchaseMasterClickCb(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG_PURCHASE_MASTER: Update Button clicked! {0}", dataGridView1.Rows.Count);

            string strProductNameComboBox = "";
            string strDealerNameComboBox = "";
            string strPurchaseTypeComboBox = "";

            bool bComboBoxValidTextField = false;
            bool bComboBoxValidSelectionMade = false;


            if ((comboBox1.Text != "")&&((comboBox2.Text != ""))&&((comboBox3.Text != "")))
            {
                strProductNameComboBox = comboBox1.Text;
                strDealerNameComboBox = comboBox2.Text;
                strPurchaseTypeComboBox = comboBox3.Text;
                bComboBoxValidTextField = true;
                bComboBoxValidSelectionMade = true;
            }

            if ((comboBox1.SelectedIndex != -1)&& (comboBox2.SelectedIndex != -1)&& (comboBox3.SelectedIndex != -1))
            {
                strProductNameComboBox = comboBox1.SelectedIndex.ToString();
                strDealerNameComboBox = comboBox2.SelectedIndex.ToString();
                strPurchaseTypeComboBox = comboBox3.SelectedIndex.ToString();
                bComboBoxValidTextField = true;
                bComboBoxValidSelectionMade = true;
            }

            Console.WriteLine(dateTimePicker1.Value.ToString());

            if ((bComboBoxValidTextField == true) &&(bComboBoxValidSelectionMade == true) &&(dataGridView1.Rows.Count >= 2) && (dataGridView1.SelectedCells[0].Value.ToString() != ""))
            {
                int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update purchase_master set product_name= '" + strProductNameComboBox + "',product_quantity='" + textBox1.Text + "' ,product_unit='" + Unit.Text + "' ,product_price='" + textBox2.Text + "' ,product_total='" + textBox3.Text + "',product_date='"+dateTimePicker1.Value.Date.ToString("dd-MM-yyyy")+"',product_party_name='"+ strDealerNameComboBox + "',purchase_type='"+ strPurchaseTypeComboBox + "',expiry_date='"+dateTimePicker2.Value.Date.ToString("dd-MM-yyyy") +"',profit='"+textBox4.Text+"' where id=" + i + "";
                cmd.ExecuteNonQuery();

                vDisplayPurchaseMasterInfo();

                MessageBox.Show("Purchase Master Info Updated Successfully", "Message");
            }
            else
            {
                MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                MessageBox.Show("ERROR: Please select a record", "Error", objMessageBoxButton, MessageBoxIcon.Error);
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG_PURCHASE_MASTER: Search Button Clicked!");

            string startdate;
            string enddate;

            startdate = dateTimePicker4.Value.ToString("dd-MM-yyyy");
            enddate = dateTimePicker3.Value.ToString("dd-MM-yyyy");

            if ((textBox5.Text != ""))
            {
                query = "select * from purchase_master where product_name='" + textBox5.Text + "' OR product_quantity='" + textBox5.Text + "' OR product_unit='" + textBox5.Text + "' OR product_price='" + textBox5.Text + "' AND product_date>='" + startdate.ToString() + "' AND product_date<='" + enddate.ToString() + "'";
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

            //             foreach (DataRow dr in dt.Rows)
            //             {
            //                 i = i + Convert.ToInt32(dr["product_total"].ToString());
            //             }

            //label3.Text = i.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG_PURCHASE_MASTER: All Purchase Button Clicked!");

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

            //             foreach (DataRow dr in dt.Rows)
            //             {
            //                 i = i + Convert.ToInt32(dr["product_total"].ToString());
            //             }

            //label3.Text = i.ToString();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((bHandlingDataGridEvent == true))
            {
                return;
            }

            Console.WriteLine("DEBUG_PURCHASE_MASTER: dataGridView1_CellContentClick() Called!");

            bHandlingDataGridEvent = true;

            if ((dataGridView1.SelectedCells[0].Value.ToString() != ""))
            {
                vClearPurchaseMasterInfoFields();

                int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from purchase_master where id=" + i + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Text = dr["product_name"].ToString();
                    comboBox1.Items.Add(dr["product_name"].ToString());
                    textBox1.Text = dr["product_quantity"].ToString();
                    Unit.Text = dr["product_unit"].ToString();
                    textBox2.Text = dr["product_price"].ToString();
                    textBox3.Text = dr["product_total"].ToString();

                    dateTimePicker1.Value = DateTime.ParseExact(dr["product_date"].ToString(), "dd-MM-yyyy", null); //Convert.ToDateTime(dr["product_date"]);

                    comboBox2.Text = dr["product_party_name"].ToString();
                    comboBox2.Items.Add(dr["product_party_name"].ToString());
                    comboBox3.Text = dr["purchase_type"].ToString();
                    comboBox3.Items.AddRange(astrPurchaseType);

                    dateTimePicker2.Value = DateTime.ParseExact(dr["expiry_date"].ToString(), "dd-MM-yyyy", null);//Convert.ToDateTime(dr["product_date"]);

                    textBox4.Text = dr["profit"].ToString();
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

            Console.WriteLine("DEBUG_PURCHASE_MASTER: dataGridView1_CellClick() Called!");

            bHandlingDataGridEvent = true;

            if ((dataGridView1.SelectedCells[0].Value.ToString() != ""))
            {
                vClearPurchaseMasterInfoFields();


                int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from purchase_master where id=" + i + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Text = dr["product_name"].ToString();
                    comboBox1.Items.Add(dr["product_name"].ToString());
                    textBox1.Text = dr["product_quantity"].ToString();
                    Unit.Text = dr["product_unit"].ToString();
                    textBox2.Text = dr["product_price"].ToString();
                    textBox3.Text = dr["product_total"].ToString();

                    dateTimePicker1.Value = DateTime.ParseExact(dr["product_date"].ToString(), "dd-MM-yyyy", null); //Convert.ToDateTime(dr["product_date"]);

                    comboBox2.Text = dr["product_party_name"].ToString();
                    comboBox2.Items.Add(dr["product_party_name"].ToString());
                    comboBox3.Text = dr["purchase_type"].ToString();
                    comboBox3.Items.AddRange(astrPurchaseType);

                    dateTimePicker2.Value = DateTime.ParseExact(dr["expiry_date"].ToString(), "dd-MM-yyyy", null);//Convert.ToDateTime(dr["product_date"]);

                    textBox4.Text = dr["profit"].ToString();
                }
            }

            bHandlingDataGridEvent = false;
        }


        public void vClearPurchaseMasterInfoFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            comboBox1.Items.Clear();
            comboBox1.Text="";
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox3.Items.Clear();
            comboBox3.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = Convert.ToString(ulPurchaseMasterCalculateProductTotal());
            }
            catch (Exception ex)
            {

            }
        }

    }
}
