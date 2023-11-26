using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace OneStopFraudReportingSystem
{
    public partial class adminRegistration : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDepartment.Text = "System Admin";

            /*if (Session["A_id"] == null || Request.Cookies["A_id"] == null)
            {
                Response.Write("<script> alert('Please Login with your admin account !'); </script>");
                Server.Transfer("loginPending.aspx");
            }*/
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = args.Value;

            string sql = "SELECT COUNT(*) FROM ADMIN WHERE ADM_USERNAME = @username";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@username", username);

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

            string sql = "SELECT COUNT(*) FROM ADMIN WHERE ADM_EMAIL = @email";
            string sql1 = "SELECT COUNT(*) FROM VICTIM WHERE VICTIM_EMAIL = @email";
            string sql2 = "SELECT COUNT(*) FROM UICS WHERE UICS_EMAIL = @email";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            SqlCommand cmd2 = new SqlCommand(sql2, con);

            cmd.Parameters.AddWithValue("@email", email);
            cmd1.Parameters.AddWithValue("@email", email);
            cmd2.Parameters.AddWithValue("@email", email);

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

            string sql = "SELECT COUNT(*) FROM ADMIN WHERE ADM_PHONE = @phone";

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
            if(Page.IsValid)
            {
                string sql1 = "SELECT COUNT(*) FROM Admin";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                con1.Open();

                int count = (int)cmd1.ExecuteScalar() + 1;

                string ADM_ID = "A00" + Convert.ToString(count);
                con1.Close();

                string ADM_NAME = txtName.Text;
                string ADM_USERNAME = txtUsername.Text;
                string ADM_IC = txtIcNo.Text;
                string ADM_GENDER = rblGender.Text;
                string ADM_EMAIL = txtEmail.Text;
                string ADM_PHONE = txtPhone.Text;
                string ADM_PASSWORD = txtPassword.Text;
                string ADM_DEPARTMENT = txtDepartment.Text;
                string ADM_POSITION = ddlPosition.Text;
                string ADM_ADDRESS = txtAddress.Text;

                string sql = "INSERT INTO Admin (ADM_ID, ADM_NAME, ADM_USERNAME, ADM_IC, ADM_GENDER, ADM_EMAIL, ADM_PHONE, ADM_PASSWORD, ADM_DEPARTMENT, ADM_POSITION, ADM_ADDRESS) VALUES (@ADM_ID, @ADM_NAME, @ADM_USERNAME, @ADM_IC, @ADM_GENDER, @ADM_EMAIL, @ADM_PHONE, @ADM_PASSWORD, @ADM_DEPARTMENT, @ADM_POSITION, @ADM_ADDRESS)";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@ADM_ID", ADM_ID);
                cmd.Parameters.AddWithValue("@ADM_NAME", ADM_NAME);
                cmd.Parameters.AddWithValue("@ADM_USERNAME", ADM_USERNAME);
                cmd.Parameters.AddWithValue("@ADM_IC", ADM_IC);
                cmd.Parameters.AddWithValue("@ADM_GENDER", ADM_GENDER);
                cmd.Parameters.AddWithValue("@ADM_EMAIL", ADM_EMAIL);
                cmd.Parameters.AddWithValue("@ADM_PHONE", ADM_PHONE);
                cmd.Parameters.AddWithValue("@ADM_PASSWORD", ADM_PASSWORD);
                cmd.Parameters.AddWithValue("@ADM_DEPARTMENT", ADM_DEPARTMENT);
                cmd.Parameters.AddWithValue("@ADM_POSITION", ADM_POSITION);
                cmd.Parameters.AddWithValue("@ADM_ADDRESS", ADM_ADDRESS);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
                
                MailMessage msg = new MailMessage();
                string ADM_EMAIL1 = txtEmail.Text;
                msg.From = new MailAddress("jeffreyjtwj@gmail.com");

                //admin email
                msg.To.Add(ADM_EMAIL1);
                msg.Subject = "NEW ADMIN ACCOUNT";
                msg.Body = "<h3>Your Admin Account has been created successful ! Please Login with <b>" + txtUsername.Text + "</b>,<b>" + txtConPass.Text + "</b><br/> Kindly login to your account for reseting the <b>Password</b>!</h3>";
                msg.IsBodyHtml = true;
                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntwd = new NetworkCredential();

                //company
                ntwd.UserName = "jeffreyjtwj@gmail.com";
                ntwd.Password = "hrwzvkjtgyvexivu";
                smt.UseDefaultCredentials = true;
                smt.Credentials = ntwd;
                smt.Port = 587;
                smt.EnableSsl = true;
                smt.Send(msg);

                Response.Write("<script> alert('Register Successful !');</script>");
                Server.Transfer("adminDashboard.aspx");
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Server.Transfer("adminRegistration.aspx");
        }
    }
}