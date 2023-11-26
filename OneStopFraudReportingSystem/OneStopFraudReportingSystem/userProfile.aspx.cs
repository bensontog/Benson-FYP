using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace OneStopFraudReportingSystem
{
    public partial class userProfile : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["V_id"] != null)
            {
                string id = Request.Cookies["V_id"].Value;

                bool found = false;

                //retrieve id from URL(get method)

                string sql = "SELECT * FROM VICTIM WHERE VICTIM_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    //record found
                    found = true;
                    txtUID.Text = (string)dr[0];
                    txtName.Text = (string)dr[1];
                    txtUsername.Text = (string)dr[2];
                    txtIcNo.Text = (string)dr[3];
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
                    txtAddress.Text = (string)dr[8];

                }

                dr.Close();
                con.Close();
                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else if (Session["V_id"] != null)
            {
                string id = Session["V_id"].ToString();

                bool found = false;

                //retrieve id from URL(get method)

                string sql = "SELECT * FROM VICTIM WHERE VICTIM_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    //record found
                    found = true;
                    txtUID.Text = (string)dr[0];
                    txtName.Text = (string)dr[1];
                    txtUsername.Text = (string)dr[2];
                    txtIcNo.Text = (string)dr[3];
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
                    txtAddress.Text = (string)dr[8];
                }

                dr.Close();
                con.Close();
                if(!found)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("userUpdateProfile.aspx");
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