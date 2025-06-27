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
    public partial class SearchMember : Form
    {
        public SearchMember()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)

        {
            if (txtSearch.Text != "")
            {




                // Initialize SQL Connection.
                using (SqlConnection con = new SqlConnection("data source = DESKTOP-4G17AFM\\SQLEXPRESS; database=gym; integrated security=true"))
                {
                    // Create the SQL Command.
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.Connection = con;

                        cmd.CommandText = "SELECT * FROM NewMember WHERE MID = " + txtSearch.Text + "";
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();
                        sqlDataAdapter.Fill(dataSet);
                        int a = 10;

                        dataGridView1.DataSource = dataSet.Tables[0];

                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter id", "Message",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SearchMember_Load(object sender, EventArgs e)
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
