using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        static string path = Path.GetFullPath(Environment.CurrentDirectory);
        static string databaseName = "u_DB.mdf";

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=" + path + @"\" + databaseName + "; Integrated Security=True;";

        private void button1_Click(object sender, EventArgs e)
        {
            // string query = "INSERT INTO  UserInfo  '" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
            string query = "INSERT INTO UserInfo ([username], [email], [number]) values(@username,@email,@number)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = textBox3.Text;
                        cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = textBox2.Text;
                        cmd.Parameters.AddWithValue("@number", SqlDbType.VarChar).Value = textBox1.Text;

                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                            MessageBox.Show("Added to Database");
                        else
                            MessageBox.Show("Nothing was added");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
                con.Close();
            }

        }
    }
 }

