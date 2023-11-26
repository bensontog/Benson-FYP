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
    public partial class viewVictim : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                string id = Request.QueryString["id"];

                bool found = false;

                string sql = "SELECT * FROM VICTIM WHERE VICTIM_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    //record found
                    found = true;
                    txtVID.Text = (string)dr[0];
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
                }

                dr.Close();
                con.Close();

                if(!found)
                {
                    Response.Redirect("victimDetails.aspx");
                }
            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("victimDetails.aspx");
        }
    }
}