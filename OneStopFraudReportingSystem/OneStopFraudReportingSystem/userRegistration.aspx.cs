using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace OneStopFraudReportingSystem
{
    public partial class userRegistration : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = args.Value;

            string sql = "SELECT COUNT(*) FROM VICTIM WHERE VICTIM_USERNAME = @username";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("username", username);

            con.Open();
            int count = (int)cmd.ExecuteScalar();

            con.Close();

            if(count > 0)
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string email = args.Value;

            string sql = "SELECT COUNT(*) FROM VICTIM WHERE VICTIM_EMAIL = @email";
            string sql1 = "SELECT COUNT(*) FROM ADMIN WHERE ADM_EMAIL = @email";
            string sql2 = "SELECT COUNT(*) FROM UICS WHERE UICS_EMAIL = @email";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            SqlCommand cmd2 = new SqlCommand(sql2, con);

            cmd.Parameters.AddWithValue("email", email);
            cmd1.Parameters.AddWithValue("email", email);
            cmd2.Parameters.AddWithValue("email", email);

            con.Open();
            int count = (int)cmd.ExecuteScalar();
            int count1 = (int)cmd1.ExecuteScalar();
            int count2 = (int)cmd2.ExecuteScalar();

            con.Close();

            if(count > 0 || count1 > 0 || count2 > 0)
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string phone = args.Value;

            string sql = "SELECT COUNT(*) FROM VICTIM WHERE VICTIM_PHONE = @phone";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@phone", phone);

            con.Open();

            int count = (int)cmd.ExecuteScalar();

            con.Close();

            if(count > 0)
            {
                args.IsValid = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string sql1 = "SELECT COUNT(*) FROM Victim";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                con1.Open();

                int count = (int)cmd1.ExecuteScalar() + 1;

                string VICTIM_ID = "V00" + Convert.ToString(count);
                con1.Close();

                string VICTIM_NAME = txtName.Text;
                string VICTIM_USERNAME = txtUsername.Text;
                string VICTIM_IC = txtIcNo.Text;
                string VICTIM_GENDER = rblGender.Text;
                string VICTIM_EMAIL = txtEmail.Text;
                string VICTIM_PHONE = txtPhone.Text;
                string VICTIM_PASSWORD = txtPassword.Text;
                string VICTIM_ADDRESS = txtAddress.Text;

                string sql = "INSERT INTO Victim (VICTIM_ID, VICTIM_NAME, VICTIM_USERNAME, VICTIM_IC, VICTIM_GENDER, VICTIM_EMAIL, VICTIM_PHONE, VICTIM_PASSWORD, VICTIM_ADDRESS) VALUES (@VICTIM_ID, @VICTIM_NAME, @VICTIM_USERNAME, @VICTIM_IC, @VICTIM_GENDER, @VICTIM_EMAIL, @VICTIM_PHONE, @VICTIM_PASSWORD, @VICTIM_ADDRESS)";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@VICTIM_ID", VICTIM_ID);
                cmd.Parameters.AddWithValue("@VICTIM_NAME", VICTIM_NAME);
                cmd.Parameters.AddWithValue("@VICTIM_USERNAME", VICTIM_USERNAME);
                cmd.Parameters.AddWithValue("@VICTIM_IC", VICTIM_IC);
                cmd.Parameters.AddWithValue("@VICTIM_GENDER", VICTIM_GENDER);
                cmd.Parameters.AddWithValue("@VICTIM_EMAIL", VICTIM_EMAIL);
                cmd.Parameters.AddWithValue("@VICTIM_PHONE", VICTIM_PHONE);
                cmd.Parameters.AddWithValue("@VICTIM_PASSWORD", VICTIM_PASSWORD);
                cmd.Parameters.AddWithValue("@VICTIM_ADDRESS", VICTIM_ADDRESS);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script> alert('Register Successful !');</script>");
                Server.Transfer("loginPending.aspx");

            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Server.Transfer("userRegistration.aspx");
        }
    }
}