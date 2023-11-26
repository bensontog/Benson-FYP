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
    public partial class unitsInChargeDashboard : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["U_id"] != null || Request.Cookies["U_id"] != null)
            {
                string id;

                if (Request.Cookies["U_id"] != null)
                {
                    id = Request.Cookies["U_id"].Value;
                }
                else
                {
                    id = Session["U_id"].ToString();
                }

                bool found = false;

                //retreive ID from URL (get method)

                string sql = "SELECT * FROM UICS WHERE UICS_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    //record found
                    found = true;
                    lblDepartment.Text = (string)dr[8];
                    lblUPosition.Text = (string)dr[9];
                    
                }

                dr.Close();
                con.Close();

                if(!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

                string sql1 = "SELECT * FROM ANNOUNCEMENT";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);

                DataTable dtAnnouncment = new DataTable();
                sda.Fill(dtAnnouncment);
                rptAnnouncement.DataSource = dtAnnouncment;
                rptAnnouncement.DataBind();
                con.Close();

                string DEPARTMENT = lblDepartment.Text;
                string sql2 = "SELECT Cases_Report.REPORT_ID AS REPORT_ID, Cases_Report.REPORT_DATETIME AS DATE, Cases_Report.REPORT_CATEGORY AS CATEGORY FROM CASES_REPORT WHERE DEPARTMENT = @DEPARTMENT";
                string sql3 = "SELECT COUNT(REPORT_ID) FROM CASES_REPORT WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);
                SqlCommand cmd3 = new SqlCommand(sql3, con2);

                con2.Open();

                cmd3.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                SqlDataReader dr1 = cmd3.ExecuteReader();

                while (dr1.Read())
                {
                    lblTotal.Text = "Total Cases: " + Convert.ToString(dr1[0]);
                }

                dr1.Close();

                cmd2.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                SqlDataReader dr2 = cmd2.ExecuteReader();

                gvCases.DataSource = dr2;
                gvCases.DataBind();

                dr2.Close();
                con2.Close();
                
            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }
        }
    }
}