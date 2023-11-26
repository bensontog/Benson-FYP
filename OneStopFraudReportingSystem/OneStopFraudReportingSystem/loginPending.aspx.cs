using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace OneStopFraudReportingSystem
{
    public partial class loginPending : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["V_ID"] != null || Request.Cookies["V_ID"] != null)
            {
                Response.Redirect("userDashboard.aspx");
            }
            else if (Session["U_ID"] != null || Request.Cookies["U_ID"] != null)
            {
                Response.Redirect("unitsInChargeDashboard.aspx");
            }
            else if (Session["A_ID"] != null || Request.Cookies["A_ID"] != null)
            {
                Response.Redirect("adminDashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string VICTIM_USERNAME = txtUsername.Text;
                string VICTIM_PASSWORD = txtPassword.Text;

                string UICS_USERNAME = txtUsername.Text;
                string UICS_PASSWORD = txtPassword.Text;

                string ADM_USERNAME = txtUsername.Text;
                string ADM_PASSWORD = txtPassword.Text;

                string sql = "SELECT * FROM VICTIM WHERE VICTIM_USERNAME = @VICTIM_USERNAME AND VICTIM_PASSWORD = @VICTIM_PASSWORD";
                string sql1 = "SELECT * FROM UICS WHERE UICS_USERNAME = @UICS_USERNAME AND UICS_PASSWORD = @UICS_PASSWORD";
                string sql2 = "SELECT * FROM ADMIN WHERE ADM_USERNAME = @ADM_USERNAME AND ADM_PASSWORD = @ADM_PASSWORD";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);


                cmd.Parameters.AddWithValue("@VICTIM_USERNAME", VICTIM_USERNAME);
                cmd.Parameters.AddWithValue("@VICTIM_PASSWORD", VICTIM_PASSWORD);

                cmd1.Parameters.AddWithValue("@UICS_USERNAME", UICS_USERNAME);
                cmd1.Parameters.AddWithValue("@UICS_PASSWORD", UICS_PASSWORD);

                cmd2.Parameters.AddWithValue("@ADM_USERNAME", ADM_USERNAME);
                cmd2.Parameters.AddWithValue("@ADM_PASSWORD", ADM_PASSWORD);

                con.Open();
                con1.Open();
                con2.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                SqlDataReader dr2 = cmd2.ExecuteReader();

                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        Session["V_id"] = dr.GetValue(0).ToString();
                        Session["V_name"] = dr.GetValue(1).ToString();
                        Session["V_username"] = dr.GetValue(2).ToString();
                        Session["V_ic"] = dr.GetValue(3).ToString();
                        Session["V_gender"] = dr.GetValue(4).ToString();
                        Session["V_email"] = dr.GetValue(5).ToString();
                        Session["V_phone"] = dr.GetValue(6).ToString();
                        Session["V_address"] = dr.GetValue(7).ToString();

                        if(chkRememberMe.Checked)
                        {
                            Response.Cookies["V_id"].Value = dr.GetValue(0).ToString();
                            Response.Cookies["V_name"].Value = dr.GetValue(1).ToString();
                            Response.Cookies["V_username"].Value = dr.GetValue(2).ToString();
                            Response.Cookies["V_ic"].Value = dr.GetValue(3).ToString();
                            Response.Cookies["V_gender"].Value = dr.GetValue(4).ToString();
                            Response.Cookies["V_email"].Value = dr.GetValue(5).ToString();
                            Response.Cookies["V_phone"].Value = dr.GetValue(6).ToString();
                            Response.Cookies["V_address"].Value = dr.GetValue(7).ToString();

                            Response.Cookies["V_id"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["V_name"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["V_username"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["V_ic"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["V_gender"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["V_email"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["V_phone"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["V_address"].Expires = DateTime.Now.AddDays(30);
                        }
                        else
                        {
                            Response.Cookies["V_id"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["V_name"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["V_username"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["V_ic"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["V_gender"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["V_email"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["V_phone"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["V_address"].Expires = DateTime.Now.AddDays(-1);
                        }
                        Response.Write("<script> alert('Welcome: " + dr.GetValue(2).ToString() + "!" + "'); window.location= 'userDashboard.aspx'; </script>");
                    }
                }
                else if(dr1.HasRows)
                {
                    while(dr1.Read())
                    {
                        Session["U_id"] = dr1.GetValue(0).ToString();
                        Session["U_name"] = dr1.GetValue(1).ToString();
                        Session["U_username"] = dr1.GetValue(2).ToString();
                        Session["U_ic"] = dr1.GetValue(3).ToString();
                        Session["U_gender"] = dr1.GetValue(4).ToString();
                        Session["U_email"] = dr1.GetValue(5).ToString();
                        Session["U_phone"] = dr1.GetValue(6).ToString();
                        Session["U_department"] = dr1.GetValue(7).ToString();
                        Session["U_address"] = dr1.GetValue(8).ToString();

                        if (chkRememberMe.Checked)
                        {
                            Response.Cookies["U_id"].Value = dr1.GetValue(0).ToString();
                            Response.Cookies["U_name"].Value = dr1.GetValue(1).ToString();
                            Response.Cookies["U_username"].Value = dr1.GetValue(2).ToString();
                            Response.Cookies["U_ic"].Value = dr1.GetValue(3).ToString();
                            Response.Cookies["U_gender"].Value = dr1.GetValue(4).ToString();
                            Response.Cookies["U_email"].Value = dr1.GetValue(5).ToString();
                            Response.Cookies["U_phone"].Value = dr1.GetValue(6).ToString();
                            Response.Cookies["U_department"].Value = dr1.GetValue(7).ToString();
                            Response.Cookies["U_address"].Value = dr1.GetValue(8).ToString();

                            Response.Cookies["U_id"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["U_name"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["U_username"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["U_ic"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["U_gender"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["U_email"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["U_phone"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["U_department"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["U_address"].Expires = DateTime.Now.AddDays(30);
                        }
                        else
                        {
                            Response.Cookies["U_id"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["U_name"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["U_username"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["U_ic"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["U_gender"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["U_email"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["U_phone"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["U_department"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["U_address"].Expires = DateTime.Now.AddDays(-1);
                        }
                        Response.Write("<script> alert('Welcome: " + dr1.GetValue(2).ToString() + "!" + "'); window.location= 'unitsInChargeDashboard.aspx'; </script>");
                    } 
                }
                else if(dr2.HasRows)
                {
                    while(dr2.Read())
                    {
                        Session["A_id"] = dr2.GetValue(0).ToString();
                        Session["A_name"] = dr2.GetValue(1).ToString();
                        Session["A_username"] = dr2.GetValue(2).ToString();
                        Session["A_ic"] = dr2.GetValue(3).ToString();
                        Session["A_gender"] = dr2.GetValue(4).ToString();
                        Session["A_email"] = dr2.GetValue(5).ToString();
                        Session["A_phone"] = dr2.GetValue(6).ToString();
                        Session["A_position"] = dr2.GetValue(7).ToString();
                        Session["A_address"] = dr2.GetValue(8).ToString();

                        if (chkRememberMe.Checked)
                        {
                            Response.Cookies["A_id"].Value = dr2.GetValue(0).ToString();
                            Response.Cookies["A_name"].Value = dr2.GetValue(1).ToString();
                            Response.Cookies["A_username"].Value = dr2.GetValue(2).ToString();
                            Response.Cookies["A_ic"].Value = dr2.GetValue(3).ToString();
                            Response.Cookies["A_gender"].Value = dr2.GetValue(4).ToString();
                            Response.Cookies["A_email"].Value = dr2.GetValue(5).ToString();
                            Response.Cookies["A_phone"].Value = dr2.GetValue(6).ToString();
                            Response.Cookies["A_position"].Value = dr2.GetValue(7).ToString();
                            Response.Cookies["A_address"].Value = dr2.GetValue(8).ToString();

                            Response.Cookies["A_id"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["A_name"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["A_username"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["A_ic"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["A_gender"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["A_email"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["A_phone"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["A_position"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["A_address"].Expires = DateTime.Now.AddDays(30);
                        }
                        else
                        {
                            Response.Cookies["A_id"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["A_name"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["A_username"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["A_ic"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["A_gender"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["A_email"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["A_phone"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["A_position"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["A_address"].Expires = DateTime.Now.AddDays(-1);
                        }
                        Response.Write("<script> alert('Welcome: " + dr2.GetValue(2).ToString() + "!" + "'); window.location= 'adminDashboard.aspx'; </script>");
                    }
                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Invalid Username OR Password !";
                }

                con.Close();
                con1.Close();
                con2.Close();
            }
        }
    }
}