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
    public partial class adminSetPassword : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["A_id"] == null && Request.Cookies["A_id"] == null)
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btlReset_Click(object sender, EventArgs e)
        {
            //Response.Redirect("adminSetPassword.aspx");
            Server.Transfer("adminSetPassword.aspx");
        }

        protected void btlSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Request.Cookies["A_id"] != null)
                {
                    string AID = Request.Cookies["A_id"].Value;
                    string currentPass = txtACurPass.Text;
                    string newPass = txtANewPass.Text;

                    string sql = "SELECT * FROM ADMIN WHERE ADM_ID = @id AND ADM_PASSWORD = @password";
                    string sql2 = "UPDATE ADMIN SET ADM_PASSWORD = @newPass WHERE @A_id AND ADM_PASSWORD = @A_password";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@id", AID);
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
                            cmd1.Parameters.AddWithValue("@A_id", AID);
                            cmd1.Parameters.AddWithValue("A_password", currentPass);

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
                    string AID = Session["A_id"].ToString();
                    string currentPass = txtACurPass.Text;
                    string newPass = txtANewPass.Text;

                    string sql = "SELECT * FROM ADMIN WHERE ADM_ID = @id AND ADM_PASSWORD = @password";
                    string sql2 = "UPDATE ADMIN SET ADM_PASSWORD = @newPass WHERE ADM_ID = @A_id AND ADM_PASSWORD = @A_password";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@id", AID);
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
                            cmd1.Parameters.AddWithValue("@A_id", AID);
                            cmd1.Parameters.AddWithValue("A_password", currentPass);

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

        protected void lnkAdminProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminProfile.aspx");
        }

        protected void lnkAdminSetPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminSetPassword.aspx");
        }
    }
}