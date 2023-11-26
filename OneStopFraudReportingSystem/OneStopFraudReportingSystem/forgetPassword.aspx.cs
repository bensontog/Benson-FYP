using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Mail;
using System.Net;

namespace OneStopFraudReportingSystem
{
    public partial class forgetPassword : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPasswordReset_Click(object sender, EventArgs e)
        {
            string VICTIM_EMAIL = txtEmail.Text;

            string sql = "SELECT * FROM VICTIM WHERE VICTIM_EMAIL = @VICTIM_EMAIL";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@VICTIM_EMAIL", VICTIM_EMAIL);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string aGUID = Guid.NewGuid().ToString();

                string id = (string)dr[0];
                string name = (string)dr[1];
                string sql1 = "INSERT INTO FORGOT_PASSWORD_REQUEST_VICTIM VALUES ('" + aGUID + "','" + id + "',getdate())";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                con1.Open();

                cmd1.ExecuteNonQuery();

                con1.Close();

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("jeffreyjtwj@gmail.com");

                //customer email
                msg.To.Add(VICTIM_EMAIL);
                msg.Subject = "Reset Password";
                msg.Body = "Hi User - " + name + ",<br/><br/> Please Click the link below to recover your password. <br/><br/>https://localhost:44377/passwordRecover.aspx?id=" + aGUID;
                msg.IsBodyHtml = true;
                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                NetworkCredential ntwd = new NetworkCredential();

                //company
                ntwd.UserName = "jeffreyjtwj@gmail.com";
                ntwd.Password = "hrwzvkjtgyvexivu";
                smt.UseDefaultCredentials = true;
                smt.Credentials = ntwd;
                smt.Port = 587;
                smt.EnableSsl = true;
                smt.Send(msg);

                lblPasswordReset.Text = "Check your email to reset your password";
                lblPasswordReset.ForeColor = Color.Green;

            }
            else
            {
                lblPasswordReset.Text = "Email does not exist";
                lblPasswordReset.ForeColor = Color.Red;
            }
        }
    }
}