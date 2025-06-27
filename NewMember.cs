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
    public partial class NewMember : Form
    {
        public NewMember()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void NewMember_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

       

           private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Disable the Save button to prevent multiple submissions.
                btnSave.Enabled = false;

                // Get input values from form fields.
                String fname = txtFirstName.Text.Trim();
                String lname = txtLastName.Text.Trim();

                // Get the selected gender.
                String gender = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;

                // Get remaining input values.
                String dob = dateTimePickerDOB.Value.ToString("yyyy-MM-dd"); // Proper date format
                Int64 mobile = 0;

                // Validate mobile number input.
                if (!Int64.TryParse(txtMobile.Text.Trim(), out mobile))
                {
                    MessageBox.Show("Please enter a valid mobile number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                    return;
                }

                String email = txtEmail.Text.Trim();
                String joindate = dateTimePickerJoinDate.Value.ToString("yyyy-MM-dd"); // Proper date format
                String gymtime = comboBoxGymTime.Text.Trim();
                String address = txtAddress.Text.Trim();
                String membership = comboBoxMembership.Text.Trim();

                // Initialize SQL Connection.
                using (SqlConnection con = new SqlConnection("data source = DESKTOP-4G17AFM\\SQLEXPRESS; database=gym; integrated security=true"))
                {
                    // Create the SQL Command.
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.Connection = con;

                        // Use parameterized query to prevent SQL injection.
                        cmd.CommandText = "INSERT INTO NewMember (Fname, Lname, Gender, Dob, Mobile, Email, JoinDate, GymTime, Maddress, MembershipTime) " +
                                          "VALUES (@Fname, @Lname, @Gender, @Dob, @Mobile, @Email, @JoinDate, @GymTime, @Maddress, @MembershipTime)";

                        // Add parameters to prevent SQL injection.
                        cmd.Parameters.AddWithValue("@Fname", fname);
                        cmd.Parameters.AddWithValue("@Lname", lname);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Dob", dob);
                        cmd.Parameters.AddWithValue("@Mobile", mobile);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@JoinDate", joindate);
                        cmd.Parameters.AddWithValue("@GymTime", gymtime);
                        cmd.Parameters.AddWithValue("@Maddress", address);
                        cmd.Parameters.AddWithValue("@MembershipTime", membership);

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
            finally
            {
                // Re-enable the Save button.
                btnSave.Enabled = true;
            }
        }


    


        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();

            radioButton1.Checked = false;
            radioButton2.Checked = false;

            txtMobile.Clear();
            txtEmail.Clear();

            comboBoxGymTime.ResetText();
            comboBoxMembership.ResetText();
            txtAddress.Clear();

            dateTimePickerDOB.Value = DateTime.Now;
            dateTimePickerJoinDate.Value = DateTime.Now;
        }
    }
}
