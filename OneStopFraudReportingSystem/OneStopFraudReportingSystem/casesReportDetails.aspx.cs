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
    public partial class casesReportDetails : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["V_id"] != null)
            {
                string id = Request.Cookies["V_id"].Value;

                bool found = false;

                //retrieve id from URL (get method)

                string sql = "SELECT * FROM VICTIM WHERE VICTIM_ID = @id";

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
                    txtUName.Text = (string)dr[1];
                }

                dr.Close();
                con.Close();
                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

                string VICTIM_ID = txtUID.Text;
                string VICTIM_NAME = txtUName.Text;

                string sql1 = "SELECT * FROM CASES_REPORT WHERE VICTIM_ID = @VICTIM_ID AND VICTIM_NAME = @VICTIM_NAME";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("VICTIM_ID", VICTIM_ID);
                cmd1.Parameters.AddWithValue("VICTIM_NAME", VICTIM_NAME);

                con1.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataTable casesReport = new DataTable();
                sda.Fill(casesReport);
                rptCasesReport.DataSource = casesReport;
                rptCasesReport.DataBind();
                con1.Close();
            }
            else if (Session["V_id"] != null)
            {
                string id = Session["V_id"].ToString();

                bool found = false;

                //retrieve id from URL (get method)

                string sql = "SELECT * FROM VICTIM WHERE VICTIM_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand (sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    txtUID.Text = (string)dr[0];
                    txtUName.Text = (string)dr[1];
                }

                dr.Close();
                con.Close();
                if(!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

                string VICTIM_ID = txtUID.Text;
                string VICTIM_NAME = txtUName.Text;

                string sql1 = "SELECT * FROM CASES_REPORT WHERE VICTIM_ID = @VICTIM_ID AND VICTIM_NAME = @VICTIM_NAME";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("VICTIM_ID", VICTIM_ID);
                cmd1.Parameters.AddWithValue("VICTIM_NAME", VICTIM_NAME);

                con1.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataTable casesReport = new DataTable();
                sda.Fill(casesReport);
                rptCasesReport.DataSource = casesReport;
                rptCasesReport.DataBind();
                con1.Close();
            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["V_id"] != null || Session["V_id"] != null)
            {
                string REPORT_ID = txtSearch.Text;

                string sql = "SELECT * FROM CASES_REPORT WHERE REPORT_ID = @REPORT_ID";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@REPORT_ID", REPORT_ID);

                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtReport = new DataTable();
                sda.Fill(dtReport);
                rptCasesReport.DataSource = dtReport;
                rptCasesReport.DataBind();
                con.Close();
            }
        }

        protected void btnViewAll_Click (object sender, EventArgs e)
        {
            if (Request.Cookies["V_id"] != null)
            {
                string id = Request.Cookies["V_id"].Value;

                string sql = "SELECT * FROM CASES_REPORT WHERE VICTIM_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtReport = new DataTable();
                sda.Fill(dtReport);
                rptCasesReport.DataSource = dtReport;
                rptCasesReport.DataBind();
                con.Close();
            }
            else if (Session["V_id"] != null)
            {
                string id = Session["V_id"].ToString();

                string sql = "SELECT * FROM CASES_REPORT WHERE VICTIM_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtReport = new DataTable();
                sda.Fill(dtReport);
                rptCasesReport.DataSource = dtReport;
                rptCasesReport.DataBind();
                con.Close();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("userDashboard.aspx");
        }
    }
}