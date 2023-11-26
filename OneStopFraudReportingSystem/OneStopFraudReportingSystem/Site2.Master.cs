using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace OneStopFraudReportingSystem
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["V_id"] != null || Request.Cookies["V_id"] != null)
            {
                lnkUser.Visible = true;
                lnkAddAnnouncement.Visible = false;
                Admin.Visible = false;
                lblAdmin.Visible = false;
                lnkAddDepartment.Visible = false;
                lnkCasesInCharge.Visible = false;
                lnkNewReport.Visible = true;

                string id;

                if (Request.Cookies["V_id"] != null)
                {
                    id = Request.Cookies["V_id"].Value;
                }
                else
                {
                    id = Session["V_id"].ToString();
                }

                bool found = false;

                //retrieve ID from URL(get method)

                string sql1 = "SELECT * FROM VICTIM WHERE VICTIM_ID = @id";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("@id", id);

                con1.Open();
                SqlDataReader dr = cmd1.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    lblHello.Text = "Hello " + (string)dr[2];
                }

                dr.Close();
                con1.Close();
                if (!found)
                {
                    Response.Redirect("userLogin.aspx");
                }
            }
            else if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                lnkUser.Visible = true;
                lnkNewReport.Visible = false;

                string id;

                if (Request.Cookies["A_id"] != null)
                {
                    id = Request.Cookies["A_id"].Value;
                }
                else
                {
                    id = Session["A_id"].ToString();
                }

                bool found = false;

                //retrieve ID from URL(get method)

                string sql1 = "SELECT * FROM ADMIN WHERE ADM_ID = @id";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("@id", id);

                con1.Open();
                SqlDataReader dr = cmd1.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    lblHello.Text = "Hello " + (string)dr[2];
                    if ((string)dr["ADM_POSITION"] == "Normal Admin")
                    {
                        lnkAddAdmin.Visible = false;
                        
                    }
                    else
                    {
                        lnkAddAdmin.Visible = true;
                    }
                }

                dr.Close();
                con1.Close();
                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

            }
            else if (Session["U_id"] != null || Request.Cookies["U_id"] != null)
            {
                lnkUser.Visible = true;
                Admin.Visible = false;
                lblAdmin.Visible = false;
                lnkAddDepartment.Visible = false;
                lnkNewReport.Visible = false;
                
                string id;

                if (Request.Cookies["U_id"] != null)
                {
                    id = Request.Cookies["U_id"].Value;
                }
                else
                {
                    id = Session["U_id"].ToString();
                }

                bool found = false;

                //retrieve ID from URL(get method)

                string sql1 = "SELECT * FROM UICS WHERE UICS_ID = @id";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("@id", id);

                con1.Open();
                SqlDataReader dr = cmd1.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    lblHello.Text = "Hello " + (string)dr[2];
                }

                dr.Close();
                con1.Close();
                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
        }

        protected void lnkDashboard_Click(object sender, EventArgs e)
        {
            if (Session["V_id"] != null || Request.Cookies["V_id"] != null)
            {
                Response.Redirect("userDashboard.aspx");
            }
            else if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                Response.Redirect("adminDashboard.aspx");
            }
            else if (Session["U_id"] != null || Request.Cookies["U_id"] != null)
            {
                Response.Redirect("unitsInChargeDashboard.aspx");
            }
        }

        protected void lnkProfile_Click(object sender, EventArgs e)
        {
            if (Session["V_id"] != null || Request.Cookies["V_id"] != null)
            {
                Response.Redirect("userProfile.aspx");
            }
            else if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                Response.Redirect("adminProfile.aspx");
            }
            else if (Session["U_id"] != null || Request.Cookies["U_id"] != null)
            {
                Response.Redirect("unitsInChargeProfile.aspx");
            }
        }

        protected void lnkSetPassword_Click(object sender, EventArgs e)
        {
            if (Session["V_id"] != null || Request.Cookies["V_id"] != null)
            {
                Response.Redirect("userSetPassword.aspx");
            }
            else if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                Response.Redirect("adminSetPassword.aspx");
            }
            else if (Session["U_id"] != null || Request.Cookies["U_id"] != null)
            {
                Response.Redirect("unitsInChargeSetPassword.aspx");
            }
        }

        protected void lnkAnnouncment_Click(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                Response.Redirect("announcement.aspx");
            }
            else if (Session["V_id"] != null || Request.Cookies["V_id"] != null)
            {
                Response.Redirect("announcement.aspx");
            }
            else if (Session["U_id"] != null || Request.Cookies["U_id"] != null)
            {
                Response.Redirect("announcement.aspx");
            }
        }

        protected void lnkAddAnnouncement_Click(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                Response.Redirect("addAnnouncement.aspx");
            }
            else if (Session["U_id"] != null || Request.Cookies["U_id"] != null)
            {
                Response.Redirect("addAnnouncement.aspx");
            }
        }

        protected void lnkViewAdmin_Click(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                Response.Redirect("adminDetails.aspx");
            }
        }

        protected void lnkAddAdmin_Click(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                Response.Redirect("adminRegistration.aspx");
            }
        }

        protected void lnkAddDepartment_Click(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                Response.Redirect("addDepartment.aspx");
            }
        }

        protected void lnkViewDepartment_Click(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                Response.Redirect("departmentDetails.aspx");
            }
            else if(Session["U_id"] != null || Request.Cookies["U_id"] != null)
            {
                Response.Redirect("departmentStaff.aspx");
            }
            else if (Session["V_id"] != null || Request.Cookies["V_id"] != null)
            {
                Response.Redirect("departmentDetails.aspx");
            }
        }

        protected void lnkCasesReport_Click(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null || Session["U_id"] != null || Request.Cookies["U_id"] != null)
            {
                Response.Redirect("viewVictimReport.aspx");
            }
        }

        protected void lnkNewReport_Click(object sender, EventArgs e)
        {
            if (Session["V_id"] != null || Request.Cookies["V_id"] != null)
            {
                Response.Redirect("addReport.aspx");
            }
        }

        protected void lnkViewVictim_Click(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["V_id"] != null)
            {
                Response.Redirect("victimDetails.aspx");
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();

            HttpCookie mycookie = new HttpCookie("V_id");
            HttpCookie mycookie1 = new HttpCookie("V_name");
            HttpCookie mycookie2 = new HttpCookie("V_username");
            HttpCookie mycookie3 = new HttpCookie("V_ic");
            HttpCookie mycookie4 = new HttpCookie("V_gender");
            HttpCookie mycookie5 = new HttpCookie("V_email");
            HttpCookie mycookie6 = new HttpCookie("V_phone");
            HttpCookie mycookie7 = new HttpCookie("V_address");

            mycookie.Expires = DateTime.Now.AddDays(-1d);
            mycookie1.Expires = DateTime.Now.AddDays(-1d);
            mycookie2.Expires = DateTime.Now.AddDays(-1d);
            mycookie3.Expires = DateTime.Now.AddDays(-1d);
            mycookie4.Expires = DateTime.Now.AddDays(-1d);
            mycookie5.Expires = DateTime.Now.AddDays(-1d);
            mycookie6.Expires = DateTime.Now.AddDays(-1d);
            mycookie7.Expires = DateTime.Now.AddDays(-1d);

            Response.Cookies.Add(mycookie);
            Response.Cookies.Add(mycookie1);
            Response.Cookies.Add(mycookie2);
            Response.Cookies.Add(mycookie3);
            Response.Cookies.Add(mycookie4);
            Response.Cookies.Add(mycookie5);
            Response.Cookies.Add(mycookie6);
            Response.Cookies.Add(mycookie7);


            HttpCookie mycookie8 = new HttpCookie("A_id");
            HttpCookie mycookie9 = new HttpCookie("A_name");
            HttpCookie mycookie10 = new HttpCookie("A_username");
            HttpCookie mycookie11 = new HttpCookie("A_ic");
            HttpCookie mycookie12 = new HttpCookie("A_gender");
            HttpCookie mycookie13 = new HttpCookie("A_email");
            HttpCookie mycookie14 = new HttpCookie("A_phone");
            HttpCookie mycookie15 = new HttpCookie("A_position");
            HttpCookie mycookie16 = new HttpCookie("A_address");

            mycookie8.Expires = DateTime.Now.AddDays(-1d);
            mycookie9.Expires = DateTime.Now.AddDays(-1d);
            mycookie10.Expires = DateTime.Now.AddDays(-1d);
            mycookie11.Expires = DateTime.Now.AddDays(-1d);
            mycookie12.Expires = DateTime.Now.AddDays(-1d);
            mycookie13.Expires = DateTime.Now.AddDays(-1d);
            mycookie14.Expires = DateTime.Now.AddDays(-1d);
            mycookie15.Expires = DateTime.Now.AddDays(-1d);
            mycookie16.Expires = DateTime.Now.AddDays(-1d);

            Response.Cookies.Add(mycookie8);
            Response.Cookies.Add(mycookie9);
            Response.Cookies.Add(mycookie10);
            Response.Cookies.Add(mycookie11);
            Response.Cookies.Add(mycookie12);
            Response.Cookies.Add(mycookie13);
            Response.Cookies.Add(mycookie14);
            Response.Cookies.Add(mycookie15);
            Response.Cookies.Add(mycookie16);


            HttpCookie mycookie17 = new HttpCookie("U_id");
            HttpCookie mycookie18 = new HttpCookie("U_name");
            HttpCookie mycookie19 = new HttpCookie("U_username");
            HttpCookie mycookie20 = new HttpCookie("U_ic");
            HttpCookie mycookie21 = new HttpCookie("U_gender");
            HttpCookie mycookie22 = new HttpCookie("U_email");
            HttpCookie mycookie23 = new HttpCookie("U_phone");
            HttpCookie mycookie24 = new HttpCookie("U_department");
            HttpCookie mycookie25 = new HttpCookie("U_address");
            HttpCookie mycookie26 = new HttpCookie("U_position");

            mycookie17.Expires = DateTime.Now.AddDays(-1d);
            mycookie18.Expires = DateTime.Now.AddDays(-1d);
            mycookie19.Expires = DateTime.Now.AddDays(-1d);
            mycookie20.Expires = DateTime.Now.AddDays(-1d);
            mycookie21.Expires = DateTime.Now.AddDays(-1d);
            mycookie22.Expires = DateTime.Now.AddDays(-1d);
            mycookie23.Expires = DateTime.Now.AddDays(-1d);
            mycookie24.Expires = DateTime.Now.AddDays(-1d);
            mycookie25.Expires = DateTime.Now.AddDays(-1d);
            mycookie26.Expires = DateTime.Now.AddDays(-1d);

            Response.Cookies.Add(mycookie17);
            Response.Cookies.Add(mycookie18);
            Response.Cookies.Add(mycookie19);
            Response.Cookies.Add(mycookie20);
            Response.Cookies.Add(mycookie21);
            Response.Cookies.Add(mycookie22);
            Response.Cookies.Add(mycookie23);
            Response.Cookies.Add(mycookie24);
            Response.Cookies.Add(mycookie25);
            Response.Cookies.Add(mycookie26);

            Response.Redirect("Home.aspx");

        }
    }
}