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
    public partial class unitsInChargeSetPassword : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["U_id"] == null && Request.Cookies["U_id"] == null)
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btlReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("unitsInChargeSetPassword.aspx");
        }

        protected void btlSave_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                if (Request.Cookies["U_id"] != null)
                {
                    string UID = Request.Cookies["U_id"].Value;
                    string currentPass = txtUCurPass.Text;
                    string newPass = txtUNewPass.Text;

                    string sql = "SELECT * FROM UICS WHERE UICS_ID = @id AND UICS_PASSWORD = @password";
                    string sql2 = "UPDATE UICS SET UICS_PASSWORD = @newPass WHERE @U_id AND UICS_PASSWORD = @U_password";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@id", UID);
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
                            cmd1.Parameters.AddWithValue("@U_id", UID);
                            cmd1.Parameters.AddWithValue("U_password", currentPass);

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
                    string UID = Session["U_id"].ToString();
                    string currentPass = txtUCurPass.Text;
                    string newPass = txtUNewPass.Text;

                    string sql = "SELECT * FROM UICS WHERE UICS_ID = @id AND UICS_PASSWORD = @password";
                    string sql2 = "UPDATE UICS SET UICS_PASSWORD = @newPass WHERE UICS_ID = @U_id AND UICS_PASSWORD = @U_password";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@id", UID);
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
                            cmd1.Parameters.AddWithValue("@U_id", UID);
                            cmd1.Parameters.AddWithValue("U_password", currentPass);

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

        protected void lnkUnitsInChargeProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("unitsInChargeProfile.aspx");
        }

        protected void lnkUnitsInChargeSetPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("unitsInChargeSetPassword.aspx");
        }
    }
}