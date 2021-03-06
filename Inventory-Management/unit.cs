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
    public partial class unit : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Github_Repos\Hassaan\Inventory-management-c#\Inventory-Management\Inventory.mdf;Integrated Security=True");

        public unit()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from units where unit='" + textBox1.Text + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            count = Convert.ToInt32(dt1.Rows.Count.ToString());

            if ((count == 0))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into units values('" + textBox1.Text + "')";
                cmd.ExecuteNonQuery();
                vDisplayUnits();
            }
            else
            {
                MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                MessageBox.Show("This unit is already added", "Warning", objMessageBoxButton, MessageBoxIcon.Warning);
            }
        }


        private void unit_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            vDisplayUnits();
        }


        public void vDisplayUnits()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from units";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int id;

            if ((dataGridView1.Rows.Count >= 2) && (dataGridView1.SelectedCells[0].Value.ToString() != ""))
            {
                id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from units where id='" + id + "'";
                cmd.ExecuteNonQuery();

                vDisplayUnits();
            }
            else
            {
                MessageBoxButtons objMessageBoxButton = MessageBoxButtons.OK;
                MessageBox.Show("ERROR: Please select a unit", "Error", objMessageBoxButton, MessageBoxIcon.Error);
            }
        }
    }
}