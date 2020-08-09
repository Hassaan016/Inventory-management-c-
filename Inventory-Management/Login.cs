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

    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Github_Repos\Hassaan\Inventory-management-c#\Inventory-Management\Inventory.mdf;Integrated Security=True");

        public Login()
        {
            InitializeComponent();
        }


        private void button1_click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from registration where username='"+textBox1.Text+"' and password='"+ textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            Console.WriteLine("DEBUG: Username={0} Password={1}", textBox1.Text,textBox2.Text);

            if (i == 0)
            {
                MessageBox.Show("This username & password does not match");
            }
            else
            {
                this.Hide();
                MDIParent1 mdi = new MDIParent1();
                mdi.Show();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
        }
    }
}
