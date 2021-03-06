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
    public partial class add_new_user : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Github_Repos\Hassaan\Inventory-management-c#\Inventory-Management\Inventory.mdf;Integrated Security=True");

        public add_new_user()
        {
            InitializeComponent();
        }

        private void add_new_user_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            vDisplayUsers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            int lConvertedNumber = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from registration where username='" + textBox3.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            bool canConvert = int.TryParse(textBox6.Text, out lConvertedNumber); //i now = 108

            Console.WriteLine("DEBUG: New User Parameters = {0} {1} {2} {3} {4} {5}",
                              textBox1.Text,
                              textBox2.Text,
                              textBox3.Text,
                              textBox4.Text,
                              textBox5.Text,
                              textBox6.Text);

            if ( (textBox1.Text != "")&&
                 (textBox2.Text != "")&&
                 (textBox3.Text != "")&&
                 (textBox4.Text != ""))
            {
                if (i == 0)
                {
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into registration values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                    cmd1.ExecuteNonQuery();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";

                    vDisplayUsers();
                    MessageBox.Show("User record inserted successfully");
                }
                else
                {
                    MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                    MessageBox.Show("This username already registered please choose another","Warning", objMessageBoxButton, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                MessageBox.Show("ERROR: Compulsory Fields: FirstName, LastName, Username & Password","Error", objMessageBoxButton, MessageBoxIcon.Error);
            }


        }

        public void vDisplayUsers()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from registration";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id;

            if ((dataGridView1.SelectedCells[0].Value) != null)
            {
                id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from registration where id='" + id + "'";
                cmd.ExecuteNonQuery();

                vDisplayUsers();
            }
        }
    }
}
