using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace OneStopFraudReportingSystem
{
    public partial class promoteAdmin : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["A_id"] != null)
            {
                string aid = Request.QueryString["aid"];

                bool found = false;

                string sql = "SELECT * FROM ADMIN WHERE ADM_ID = @aid";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("aid", aid);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    txtAID.Text = (string)dr[0];
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
                    /*if ((string)dr["UICS_POSITION"] == "Department Head")
                    {
                        btnPromote.Visible = true;
                    }
                    else
                    {
                        btnPromote.Visible = false;
                    }*/
                }
                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("adminDetails.aspx");
                }

                string id = Session["A_id"].ToString();

                bool found1 = false;

                string sql1 = "SELECT * FROM ADMIN WHERE ADM_ID = @id";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("id", id);

                con1.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();

                if (dr1.Read())
                {
                    //record found
                    found1 = true;
                    if ((string)dr1["ADM_POSITION"] == "High-Level Admin")
                    {
                        btnPromote.Visible = true;
                    }
                    else
                    {
                        ddlPosition.Enabled = false;
                        btnPromote.Visible = false;
                    }
                }
                dr1.Close();
                con1.Close();

                if (!found1)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else if (Request.Cookies["A_id"] != null)
            {
                string aid = Request.QueryString["aid"];

                bool found = false;

                string sql = "SELECT * FROM ADMIN WHERE ADM_ID = @aid";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("aid", aid);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    txtAID.Text = (string)dr[0];
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
                    /*if ((string)dr["UICS_POSITION"] == "Department Head")
                    {
                        btnPromote.Visible = true;
                    }
                    else
                    {
                        btnPromote.Visible = false;
                    }*/
                }
                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("adminDetails.aspx");
                }

                string id = Request.Cookies["A_id"].Value;

                bool found1 = false;

                string sql1 = "SELECT * FROM ADMIN WHERE ADM_ID = @id";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("id", id);

                con1.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();

                if (dr1.Read())
                {
                    //record found
                    found1 = true;
                    if ((string)dr1["ADM_POSITION"] == "High-Level Admin")
                    {
                        btnPromote.Visible = true;
                    }
                    else
                    {
                        ddlPosition.Enabled = false;
                        btnPromote.Visible = false;
                    }
                }
                dr1.Close();
                con1.Close();

                if (!found1)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btnPromote_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string ADM_POSITION = ddlPosition.SelectedItem.ToString();
                string ADM_ID = txtAID.Text;

                string sql = "UPDATE ADMIN SET ADM_POSITION = @ADM_POSITION WHERE ADM_ID = @ADM_ID";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@ADM_POSITION", ADM_POSITION);
                cmd.Parameters.AddWithValue("@ADM_ID", ADM_ID);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script> alert('Update Successful !');  window.location= 'adminDetails.aspx'; </script>");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminDetails.aspx");
        }
    }
}