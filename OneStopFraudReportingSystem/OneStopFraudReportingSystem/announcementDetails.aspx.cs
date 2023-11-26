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
    public partial class announcementDetails : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["A_id"] != null || Session["A_id"] != null || Request.Cookies["U_id"] != null || Session["U_id"] != null || Request.Cookies["V_id"] != null || Session["V_id"] != null)
            {
                Boolean found = false;

                string id = Request.QueryString["id"];

                string sql = "SELECT * FROM ANNOUNCEMENT WHERE ANN_ID = @id;";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    txtATitle.Text = (string)dr[1];
                    txtADate.Text = (string)dr[2];
                    txtADetails.Text = (string)dr[3];
                    txtPostedBy.Text = (string)dr[4];
                    txtDepartment.Text = (string)dr[5];
                    txtPosition.Text = (string)dr[6];
                }

                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("announcement.aspx");
                }
            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("announcement.aspx");
        }
        
    }
}