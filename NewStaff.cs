using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym
{
    public partial class NewStaff : Form
    {
        public NewStaff()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String fname = txtFname.Text;
            String lname = txtLname.Text;

            String gender = "";

            bool isChecked = radioButton1.Checked;
            if (isChecked)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }

            String dob = dateTimePickerDOB.Text;
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String email = txtEmail.Text;   
            String joindate = dateTimePickerJoinDate.Text;
            String state = txtState.Text;
            String city = txtCity.Text;



            SqlConnection con = new SqlConnection();
            
            con.ConnectionString = "data source = DESKTOP-4G17AFM\\SQLEXPRESS; database =gym; integrated security=true";


            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;

            cmd.CommandText = "INSERT INTO NewStaff(Fname,Lname,Gender,Dob,Mobile,Email,JoinDate,Statee,City) values ('" + fname + "','" + lname + "','" + gender + "', '" + dob + "','" + mobile + "','" + email + "','" + joindate + "','" + state + "','" + city + "')";


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            SqlDataAdapter DA = sqlDataAdapter;
            var ds = new DataSet();
            DataSet DS = ds;
            int v1 = DA.Fill(DS);
            MessageBox.Show("Data Saved");



        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFname.Clear();
            txtLname.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            dateTimePickerDOB.Value = DateTime.Now;
            txtMobile.Clear();
            txtEmail.Clear();

            dateTimePickerJoinDate.Value = DateTime.Now;
            txtCity.Clear();
            txtState.Clear();
        }
    }
}
