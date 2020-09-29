using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        static string path = Path.GetFullPath(Environment.CurrentDirectory);
        static string databaseName = "myDB.mdf";

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=" + path + @"\" + databaseName + "; Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * from Users where username= '" + textBox1.Text + "' and password = '" + textBox2.Text + "'";

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);

                if(datatable.Rows.Count == 1)
                {
                    Dashboard mainform = new Dashboard();
                    mainform.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please Check User Name and Password.", "Error");

                }
            }

        }
    }
}
