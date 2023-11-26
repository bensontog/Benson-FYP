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
    public partial class deleteEvidence : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["V_id"] != null || Session["V_id"] != null)
            {
                Boolean found = false;

                string id = Request.QueryString["id"];

                string sql = "SELECT EVIDENCE FROM CASES_EVIDENCE WHERE EVIDENCE_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    imageEvidence.ImageUrl = dr["EVIDENCE"].ToString();
                }

                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("casesReportDetails.aspx");
                }
            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btnDelete_Click (object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            string sql = "DELETE FROM CASES_EVIDENCE WHERE EVIDENCE_ID = @id";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("id", id);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            Response.Write("<script> alert('Delete Successful !');</script>");
            Server.Transfer("userDashboard.aspx");
        }

        protected void btnBack_Click (object sender, EventArgs e)
        {
            Response.Redirect("userDashboard.aspx");
        }
    }
}