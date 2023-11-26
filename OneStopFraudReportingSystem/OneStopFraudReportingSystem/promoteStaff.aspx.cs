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
    public partial class promoteSatff : System.Web.UI.Page
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

                if(dr.Read())
                {
                    //record found
                    found = true;
                    txtUID.Text = (string)dr[0];
                    txtName.Text = (string)dr[1];
                    string gender = (string)dr[4];
                    if(gender.Equals("M"))
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

                if(!found)
                {
                    Response.Redirect("departmentStaff.aspx");
                }

                string id = Session["U_id"].ToString();

                bool found1 = false;

                string sql1 = "SELECT * FROM UICS WHERE UICS_ID = @id";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("id", id);

                con1.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();

                if (dr1.Read())
                {
                    //record found
                    found1 = true;
                    if((string)dr1["UICS_POSITION"] == "Department Head")
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
                    Response.Redirect("departmentStaff.aspx");
                }

                string id = Request.Cookies["U_id"].Value;

                bool found1 = false;

                string sql1 = "SELECT * FROM UICS WHERE UICS_ID = @id";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("id", id);

                con1.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();

                if (dr1.Read())
                {
                    //record found
                    found1 = true;
                    if ((string)dr1["UICS_POSITION"] == "Department Head")
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
            if(Page.IsValid)
            {
                string UICS_POSITION = ddlPosition.SelectedItem.ToString();
                string UICS_ID = txtUID.Text;

                string sql = "UPDATE UICS SET UICS_POSITION = @UICS_POSITION WHERE UICS_ID = @UICS_ID";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@UICS_POSITION", UICS_POSITION);
                cmd.Parameters.AddWithValue("@UICS_ID", UICS_ID);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script> alert('Update Successful !');  window.location= 'departmentStaff.aspx'; </script>");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("departmentStaff.aspx");
        }
    }
}