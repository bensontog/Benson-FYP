using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace OneStopFraudReportingSystem
{
    public partial class unitsInChargeProfile : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["U_id"] != null)
            {
                string id = Request.Cookies["U_id"].Value;

                bool found = false;

                //retrieve id from URL (get method)

                string sql = "SELECT * FROM UICS WHERE UICS_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
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
                    txtDepartment.Text = (string)dr[8];
                    txtPosition.Text = (string)dr[9];
                    txtAddress.Text = (string)dr[10];
                }

                dr.Close();
                con.Close();
                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else if (Session["U_id"] != null)
            {
                string id = Session["U_id"].ToString();

                bool found = false;

                //retrieve id from URL (get method)

                string sql = "SELECT * FROM UICS WHERE UICS_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
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
                    txtDepartment.Text = (string)dr[8];
                    txtPosition.Text = (string)dr[9];
                    txtAddress.Text = (string)dr[10];
                }

                dr.Close();
                con.Close();
                if (!found)
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
            Response.Redirect("unitsInChargeUpdateProfile.aspx");
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