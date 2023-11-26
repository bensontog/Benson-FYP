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
    public partial class deleteStaff : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["U_id"] != null)
            {
                string uid = Request.QueryString["uid"];

                bool found = false;

                string sql = "SELECT * FROM UICS WHERE UICS_ID = @uid";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("uid", uid);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    txtUID.Text = (string)dr[0];
                    txtName.Text = (string)dr[1];
                    string gender = (string)dr[4];
                    if (gender.Equals("M"))
                    {
                        txtGender.Text = "Male (M)";
                    }
                    else
                    {
                        txtGender.Text = "Female (F)";
                    }
                    txtEmail.Text = (string)dr[5];
                    txtPhone.Text = (string)dr[6];
                    txtPosition.Text = (string)dr[9];
                }
                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("departmentStaff.aspx");
                }
            }
            else if (Request.Cookies["U_id"] != null)
            {
                string uid = Request.QueryString["uid"];

                bool found = false;

                string sql = "SELECT * FROM UICS WHERE UICS_ID = @uid";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("uid", uid);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    txtUID.Text = (string)dr[0];
                    txtName.Text = (string)dr[1];
                    string gender = (string)dr[4];
                    if (gender.Equals("M"))
                    {
                        txtGender.Text = "Male (M)";
                    }
                    else
                    {
                        txtGender.Text = "Female (F)";
                    }
                    txtEmail.Text = (string)dr[5];
                    txtPhone.Text = (string)dr[6];
                    txtPosition.Text = (string)dr[9];
                }
                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("departmentStaff.aspx");
                }
            }
            else
            {
                Response.Redirect("loginPending.asps");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string uid = Request.QueryString["uid"];

            string sql = "DELETE FROM UICS WHERE UICS_ID = @uid";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("uid", uid);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            Response.Write("<script> alert('Delete Successful !');</script>");
            Server.Transfer("departmentStaff.aspx");
        }

        protected void btnBack_Click (object sender, EventArgs e)
        {
            Response.Redirect("departmentStaff.aspx");
        }
    }
}