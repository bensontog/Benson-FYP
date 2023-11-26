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
    public partial class unitsInChargeRegistration : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM DEPARTMENT", con);

                //table name
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ddlDepartment.DataTextField = ds.Tables[0].Columns["DEPARTMENT_NAME"].ToString();
                ddlDepartment.DataValueField = ds.Tables[0].Columns["DEPARTMENT_NAME"].ToString();

                ddlDepartment.DataSource = ds.Tables[0];
                ddlDepartment.DataBind();
            }
           
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = args.Value;

            string sql = "SELECT COUNT(*) FROM UICS WHERE UICS_USERNAME = @username";

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

            string sql = "SELECT COUNT(*) FROM UICS WHERE UICS_EMAIL = @email";
            string sql1 = "SELECT COUNT(*) FROM VICTIM WHERE VICTIM_EMAIL = @email";
            string sql2 = "SELECT COUNT(*) FROM ADMIN WHERE ADM_EMAIL = @email";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            SqlCommand cmd2 =new SqlCommand(sql2, con);

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

            string sql = "SELECT COUNT(*) FROM UICS WHERE UICS_PHONE = @phone";

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
                string sql1 = "SELECT COUNT(*) FROM Uics";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                con1.Open();

                int count = (int)cmd1.ExecuteScalar() + 1;

                string UICS_ID = "S00" + Convert.ToString(count);
                con1.Close();

                string UICS_NAME = txtName.Text;
                string UICS_USERNAME = txtUsername.Text;
                string UICS_IC = txtIcNo.Text;
                string UICS_GENDER = rblGender.Text;
                string UICS_EMAIL = txtEmail.Text;
                string UICS_PHONE = txtPhone.Text;
                string UICS_PASSWORD = txtPassword.Text;
                string DEPARTMENT = ddlDepartment.SelectedValue;
                string UICS_POSITION = ddlPosition.SelectedItem.Text;
                string UICS_ADDRESS = txtAddress.Text;

                string sql = "INSERT INTO Uics (UICS_ID, UICS_NAME, UICS_USERNAME, UICS_IC, UICS_GENDER, UICS_EMAIL, UICS_PHONE, UICS_PASSWORD, DEPARTMENT, UICS_POSITION, UICS_ADDRESS) VALUES (@UICS_ID, @UICS_NAME, @UICS_USERNAME, @UICS_IC, @UICS_GENDER, @UICS_EMAIL, @UICS_PHONE, @UICS_PASSWORD, @DEPARTMENT, @UICS_POSITION, @UICS_ADDRESS)";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@UICS_ID", UICS_ID);
                cmd.Parameters.AddWithValue("@UICS_NAME", UICS_NAME);
                cmd.Parameters.AddWithValue("@UICS_USERNAME", UICS_USERNAME);
                cmd.Parameters.AddWithValue("@UICS_IC", UICS_IC);
                cmd.Parameters.AddWithValue("@UICS_GENDER", UICS_GENDER);
                cmd.Parameters.AddWithValue("@UICS_EMAIL", UICS_EMAIL);
                cmd.Parameters.AddWithValue("@UICS_PHONE", UICS_PHONE);
                cmd.Parameters.AddWithValue("@UICS_PASSWORD", UICS_PASSWORD);
                cmd.Parameters.AddWithValue("@DEPARTMENT", DEPARTMENT);
                cmd.Parameters.AddWithValue("@UICS_POSITION", UICS_POSITION);
                cmd.Parameters.AddWithValue("@UICS_ADDRESS", UICS_ADDRESS);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                MailMessage msg = new MailMessage();
                string UICS_EMAIL1 = txtEmail.Text;
                msg.From = new MailAddress("jeffreyjtwj@gmail");

                msg.To.Add(UICS_EMAIL1);
                msg.Subject = "NEW STAFF ACCOUNT";
                msg.Body = "<h3>Your Staff Account has been created successful ! Please Login with <b>" + txtUsername.Text + "</b>,<b>" + txtConPass.Text + "</b><br/> Kindly login to your account for reseting the <b>Password</b>!</h3>";
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
                Server.Transfer("unitsInChargeDashboard.aspx");
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Server.Transfer("unitsInChargeRegistration.aspx");
        }
    }
}