using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym
{
    public partial class DeleteMember : Form
    {
        public DeleteMember()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will delete your data. Confirm?", "Delete data", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                // Initialize SQL Connection.
                using (SqlConnection con = new SqlConnection("data source = DESKTOP-4G17AFM\\SQLEXPRESS; database=gym; integrated security=true"))
                {
                    // Create the SQL Command.
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.Connection = con;

                        cmd.CommandText = "DELETE FROM NewMember WHERE MID = " + textBox1.Text + "";
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();
                        sqlDataAdapter.Fill(dataSet);




                    }
                }
            }
            else
            {
                this.Activate();
                // Initialize SQL Connection.
                using (SqlConnection con = new SqlConnection("data source = DESKTOP-4G17AFM\\SQLEXPRESS; database=gym; integrated security=true"))
                {
                    // Create the SQL Command.
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.Connection = con;

                        cmd.CommandText = "SELECT * FROM NewMember ";
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();
                        sqlDataAdapter.Fill(dataSet);
                        int a = 10;

                        dataGridView1.DataSource = dataSet.Tables[0];

                    }
                }
            }
        }

        private void DeleteMember_Load(object sender, EventArgs e)
        {
            // Initialize SQL Connection.
            using (SqlConnection con = new SqlConnection("data source = DESKTOP-4G17AFM\\SQLEXPRESS; database=gym; integrated security=true"))
            {
                // Create the SQL Command.
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT * FROM NewMember ";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    int a = 10;

                    dataGridView1.DataSource = dataSet.Tables[0];

                }
            }
        }
    }
}
