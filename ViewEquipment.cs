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
    public partial class ViewEquipment : Form
    {
        public ViewEquipment()
        {
            InitializeComponent();
        }

        private void ViewEquipment_Load(object sender, EventArgs e)
        {
            // Initialize SQL Connection.
            using (SqlConnection con = new SqlConnection("data source = DESKTOP-4G17AFM\\SQLEXPRESS; database=gym; integrated security=true"))
            {
                // Create the SQL Command.
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT * FROM Equipmenet";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    int i = 0;

                    dataGridView1.DataSource= dataSet.Tables[0];

                }
            }
        }
    }
}
