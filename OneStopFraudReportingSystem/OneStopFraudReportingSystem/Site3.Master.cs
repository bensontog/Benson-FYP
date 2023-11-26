using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace OneStopFraudReportingSystem
{
    public partial class Site3 : System.Web.UI.MasterPage
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                lnkUser.Visible = true;
                lnkAnnouncement.Visible = true;

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
                }

                dr.Close();
                con1.Close();
                if (!found)
                {
                    Response.Redirect("adminLogin.aspx");
                }
            }
        }

        protected void lnkAnnouncement_Click(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                Response.Redirect("addAnnouncement.aspx");
            }
        }

        protected void lnkDashboard_Click(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                Response.Redirect("adminDashboard.aspx");
            }
        }

        protected void lnkProfile_Click(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                Response.Redirect("adminProfile.aspx");
            }
        }

        protected void lnkSetPassword_Click(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                Response.Redirect("adminSetPassword.aspx");
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();

            HttpCookie mycookie = new HttpCookie("A_id");
            HttpCookie mycookie1 = new HttpCookie("A_name");
            HttpCookie mycookie2 = new HttpCookie("A_username");
            HttpCookie mycookie3 = new HttpCookie("A_ic");
            HttpCookie mycookie4 = new HttpCookie("A_gender");
            HttpCookie mycookie5 = new HttpCookie("A_email");
            HttpCookie mycookie6 = new HttpCookie("A_phone");
            HttpCookie mycookie7 = new HttpCookie("A_position");
            HttpCookie mycookie8 = new HttpCookie("A_address");

            mycookie.Expires = DateTime.Now.AddDays(-1d);
            mycookie1.Expires = DateTime.Now.AddDays(-1d);
            mycookie2.Expires = DateTime.Now.AddDays(-1d);
            mycookie3.Expires = DateTime.Now.AddDays(-1d);
            mycookie4.Expires = DateTime.Now.AddDays(-1d);
            mycookie5.Expires = DateTime.Now.AddDays(-1d);
            mycookie6.Expires = DateTime.Now.AddDays(-1d);
            mycookie7.Expires = DateTime.Now.AddDays(-1d);
            mycookie8.Expires = DateTime.Now.AddDays(-1d);

            Response.Cookies.Add(mycookie);
            Response.Cookies.Add(mycookie1);
            Response.Cookies.Add(mycookie2);
            Response.Cookies.Add(mycookie3);
            Response.Cookies.Add(mycookie4);
            Response.Cookies.Add(mycookie5);
            Response.Cookies.Add(mycookie6);
            Response.Cookies.Add(mycookie7);
            Response.Cookies.Add(mycookie8);

            Response.Redirect("Home.aspx");

        }
    }
}