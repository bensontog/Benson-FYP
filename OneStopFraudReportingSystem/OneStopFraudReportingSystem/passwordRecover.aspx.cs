using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace OneStopFraudReportingSystem
{
    public partial class passwordRecover : System.Web.UI.Page
    {
        string cs = Global.CS;
        DataTable dt = new DataTable();
        string aGUID;
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            aGUID = Request.QueryString["id"];
            if (aGUID != null)
            {
                try
                {
                    string sql = "SELECT * FROM FORGOT_PASSWORD_REQUEST_VICTIM WHERE ID = @id";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", aGUID);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                }
                catch(Exception E)
                {

                }

                if (dt.Rows.Count != 0)
                {
                    id = dt.Rows[0][1].ToString();
                }
                else
                {
                    lblErrorMsg.Text = "<b>Error 404</b> Your Password Reset Link is already Expired or Invalid!";
                    lblErrorMsg.ForeColor = Color.Red;
                }
            }
            else
            {
                Response.Redirect("forgetPassword.aspx");
            }

            if (!IsPostBack)
            {
                if(dt.Rows.Count > 0)
                {
                    txtConfirmPassword.Visible = true;
                    txtNewPass.Visible = true;
                    lblConfirmPassword.Visible = true;
                    lblPassword.Visible = true;
                    btnPassRec.Visible = true;
                }
                else
                {
                    lblErrorMsg.Text = "<b>Error 404</b> Your Password Reset Link is already Expired or Invalid!";
                    lblErrorMsg.ForeColor = Color.Red;
                }
            }
        }

        protected void btnPassRec_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                string password = txtNewPass.Text;

                string sql = "UPDATE VICTIM SET VICTIM_PASSWORD = @password WHERE VICTIM_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@id", id);

                string sql1 = "DELETE FROM FORGOT_PASSWORD_REQUEST_VICTIM WHERE VICTIM_ID = @VICTIM_ID";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("@VICTIM_ID", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                con1.Open();
                cmd1.ExecuteNonQuery();
                con1.Close();

                Response.Write("<script> alert('<<Password reset successfully!!!>>');  window.location= 'loginPending.aspx';  </script>");
            }
        }
    }
}