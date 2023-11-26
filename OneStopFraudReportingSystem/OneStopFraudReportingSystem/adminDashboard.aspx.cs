using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace OneStopFraudReportingSystem
{
    public partial class adminDashboard : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                string id;

                if (Request.Cookies["A_id"] != null)
                {
                    id = Request.Cookies["A_id"].Value;
                }
                else
                {
                    id = Session["A_id"].ToString();
                }

                bool found = false;

                string sql = "SELECT * FROM ADMIN WHERE ADM_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    lblAPosition.Text = (string)dr[9];
                }

                dr.Close();
                con.Close();
                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

                string sql1 = "SELECT Cases_Report.REPORT_ID AS REPORT_ID, Cases_Report.REPORT_DATETIME AS DATE, Cases_Report.REPORT_CATEGORY AS CATEGORY FROM CASES_REPORT";
                string sql2 = "SELECT COUNT(REPORT_ID) FROM CASES_REPORT";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);
                SqlCommand cmd2 = new SqlCommand(sql2, con1);

                con1.Open();

                SqlDataReader dr1 = cmd2.ExecuteReader();

                while (dr1.Read())
                {
                    lblTotal.Text = "Total Cases: " + Convert.ToString(dr1[0]);
                }

                dr1.Close();

                SqlDataReader dr2 = cmd1.ExecuteReader();

                gvCases.DataSource = dr2;
                gvCases.DataBind();

                dr2.Close();
                con1.Close();

                chrTotalReport.Legends[0].Enabled = false;
                LoadData();
                LoadData1();

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

                string sql4 = "SELECT Victim.VICTIM_ID AS VICTIM_ID, Victim.VICTIM_NAME AS NAME, Victim.VICTIM_GENDER AS GENDER FROM VICTIM";
                string sql5 = "SELECT COUNT(VICTIM_ID) FROM VICTIM";

                SqlConnection con3 = new SqlConnection(cs);
                SqlCommand cmd4 = new SqlCommand(sql4, con3);
                SqlCommand cmd5 = new SqlCommand(sql5, con3);

                con3.Open();

                SqlDataReader dr3 = cmd5.ExecuteReader();

                while (dr3.Read())
                {
                    lblTotal1.Text = "Total Victim: " + Convert.ToString(dr3[0]);
                }

                dr3.Close();

                SqlDataReader dr4 = cmd4.ExecuteReader();

                gvVictim.DataSource = dr4;
                gvVictim.DataBind();

                dr4.Close();
                con3.Close();

            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        void LoadData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT REPORT_CATEGORY, COUNT(REPORT_ID) AS TOTAL FROM CASES_REPORT GROUP BY REPORT_CATEGORY", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for(int i=0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }

            Title title = new Title("Percentage of Cases Reported");
            title.Font = new System.Drawing.Font("Calibri", 14, System.Drawing.FontStyle.Bold);
            chrTotalReport.Titles.Add(title);
            chrTotalReport.Titles[0].Alignment = System.Drawing.ContentAlignment.TopCenter;
            chrTotalReport.Series[0].Points.DataBindXY(x, y);
            chrTotalReport.Series["Series1"].YValueMembers = "REPORT_CATRGORY";
            chrTotalReport.Series[0].ChartType = SeriesChartType.Pie;
            chrTotalReport.Legends[0].Enabled = true;
            chrTotalReport.Series[0].Label = "#PERCENT{P1}";
            chrTotalReport.Series[0].LegendText = "#VALX";
        }

        void LoadData1()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT VICTIM_GENDER, count(VICTIM_ID) AS Total FROM VICTIM group by VICTIM_GENDER", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }

            Title title = new Title("Percentage of Gender of Male and Female Victim");
            title.Font = new System.Drawing.Font("Calibri", 14, System.Drawing.FontStyle.Bold);
            chrVictimGender.Titles.Add(title);
            chrVictimGender.Titles[0].Alignment = System.Drawing.ContentAlignment.TopCenter;
            chrVictimGender.Series[0].Points.DataBindXY(x, y);
            chrVictimGender.Series["Series1"].YValueMembers = "VICTIM_GENDER";
            chrVictimGender.Series[0].ChartType = SeriesChartType.Pie;
            chrVictimGender.Legends[0].Enabled = true;
            chrVictimGender.Series[0].Label = "#PERCENT{P1}";
            chrVictimGender.Series[0].LegendText = "#VALX";
        }
    }
}