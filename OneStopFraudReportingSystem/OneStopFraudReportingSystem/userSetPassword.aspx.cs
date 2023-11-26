using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;

namespace OneStopFraudReportingSystem
{
    public partial class userSetPassword : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["V_id"] == null && Request.Cookies["V_id"] == null)
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btlReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("userSetPassword.aspx");
        }

        protected void btlSave_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                if (Request.Cookies["V_id"] != null)
                {
                    string VID = Request.Cookies["V_id"].Value;
                    string currentPass = txtUCurPass.Text;
                    string newPass = txtUNewPass.Text;

                    string sql = "SELECT * FROM VICTIM WHERE VICTIM_ID = @id AND VICTIM_PASSWORD = @password";
                    string sql2 = "UPDATE VICTIM SET VICTIM_PASSWORD = @newPass WHERE @V_id AND VICTIM_PASSWORD = @V_password";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@id", VID);
                    cmd.Parameters.AddWithValue("@password", currentPass);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            SqlConnection con1 = new SqlConnection(cs);
                            SqlCommand cmd1 = new SqlCommand(sql2, con1);

                            cmd1.Parameters.AddWithValue("@newPass", newPass);
                            cmd1.Parameters.AddWithValue("@V_id", VID);
                            cmd1.Parameters.AddWithValue("V_password", currentPass);

                            con1.Open();
                            cmd1.ExecuteNonQuery();
                            con1.Close();
                        }
                        Response.Write("<script> alert('Password Reset Successful !!!'); window.location='loginPending.aspx';</script>");
                    }
                    else
                    {
                        lblError.ForeColor = Color.Red;
                        lblError.Text = "Invalid Current Password !!!";
                    }
                    con.Close();
                }
                else
                {
                    string VID = Session["V_id"].ToString();
                    string currentPass = txtUCurPass.Text;
                    string newPass = txtUNewPass.Text;

                    string sql = "SELECT * FROM VICTIM WHERE VICTIM_ID = @id AND VICTIM_PASSWORD = @password";
                    string sql2 = "UPDATE VICTIM SET VICTIM_PASSWORD = @newPass WHERE VICTIM_ID = @V_id AND VICTIM_PASSWORD = @V_password";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@id", VID);
                    cmd.Parameters.AddWithValue("@password", currentPass);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SqlConnection con1 = new SqlConnection(cs);
                            SqlCommand cmd1 = new SqlCommand(sql2, con1);

                            cmd1.Parameters.AddWithValue("@newPass", newPass);
                            cmd1.Parameters.AddWithValue("@V_id", VID);
                            cmd1.Parameters.AddWithValue("V_password", currentPass);

                            con1.Open();
                            cmd1.ExecuteNonQuery();
                            con1.Close();
                        }
                        Response.Write("<script> alert('Password Reset Successful !!!'); window.location='loginPending.aspx';</script>");
                    }
                    else
                    {
                        lblError.ForeColor = Color.Red;
                        lblError.Text = "Invalid Current Password !!!";
                    }
                    con.Close();
                }
            }
        }

        protected void lnkUserProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }

        protected void lnkUserSetPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("userSetPassword.aspx");
        }

    }
}