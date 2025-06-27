using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace gym
{
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
         
        
            try
            {
                // Get input values from form fields.
                String equipName = txtEquipName.Text.Trim();
                String description = txtDescription.Text.Trim();
                String mUsed = txtMuclesUsed.Text.Trim();
                String dDate = dateTimePickerDeliveryDate.Value.ToString("yyyy-MM-dd"); // Proper date format
                Int64 cost;

                // Validate cost input.
                if (!Int64.TryParse(txtCost.Text.Trim(), out cost))
                {
                    MessageBox.Show("Please enter a valid cost.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Initialize SQL Connection.
                using (SqlConnection con = new SqlConnection("data source = DESKTOP-4G17AFM\\SQLEXPRESS; database=gym; integrated security=true"))
                {
                    // Create the SQL Command.
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.Connection = con;

                        // Use parameterized query to prevent SQL injection.
                        cmd.CommandText = "INSERT INTO Equipmenet (EquipName, EDescription, MUsed, DDate, Cost) " +
                                          "VALUES (@EquipName, @Description, @MUsed, @DDate, @Cost)";

                        // Add parameters to prevent SQL injection.
                        cmd.Parameters.AddWithValue("@EquipName", equipName);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@MUsed", mUsed);
                        cmd.Parameters.AddWithValue("@DDate", dDate);
                        cmd.Parameters.AddWithValue("@Cost", cost);

                        // Open the connection.
                        con.Open();

                        // Execute the command.
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No rows were affected. Please check your query and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                // Display error message for any exceptions.
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEquipName.Clear();
            txtDescription.Clear();
            txtCost.Clear();
            dateTimePickerDeliveryDate.Value = DateTime.Now;
            txtMuclesUsed.Clear();
        }

        private void btnViewEquipment_Click(object sender, EventArgs e)
        {
            ViewEquipment viewEquipment = new ViewEquipment();
            viewEquipment.Show();
        }
    }
}

