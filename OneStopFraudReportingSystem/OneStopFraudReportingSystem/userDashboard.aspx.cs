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
    public partial class userDashboard : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["V_id"] != null || Request.Cookies["V_id"] != null)
            {
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

                //retrieve ID from URL (get method)

                string sql1 = "SELECT * FROM VICTIM WHERE VICTIM_ID = @id";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("@id", id);

                con1.Open();
                SqlDataReader dr = cmd1.ExecuteReader();

                if(dr.Read())
                {
                    //record found
                    found = true;
                    lblUName.Text = (string)dr[1];
                }

                dr.Close();
                con1.Close();

                if(!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

                string sql3 = "SELECT * FROM ANNOUNCEMENT";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd3 = new SqlCommand(sql3, con2);

                con2.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd3);

                DataTable dtAnnouncement = new DataTable();
                sda.Fill(dtAnnouncement);
                rptAnnouncement.DataSource = dtAnnouncement;
                rptAnnouncement.DataBind();

                con2.Close();

                string VICTIM_NAME = lblUName.Text;

                string sql2 = "SELECT * FROM CASES_REPORT WHERE VICTIM_NAME = @VICTIM_NAME";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql2, con);

                cmd.Parameters.AddWithValue("VICTIM_NAME", VICTIM_NAME);

                con1.Open();

                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                DataTable casesReport = new DataTable();
                sda1.Fill(casesReport);
                rptCasesReport.DataSource = casesReport;
                rptCasesReport.DataBind();
                con1.Close();
            }
        }
    }
}