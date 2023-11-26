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
    public partial class viewCasesEvidence : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["U_id"] != null || Session["U_id"] != null)
            {
                Boolean found = false;

                string id = Request.QueryString["id"];

                string sql = "SELECT * FROM CASES_REPORT WHERE REPORT_ID = @id";
                string sql1 = "SELECT * FROM CASES_EVIDENCE WHERE REPORT_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd.Parameters.AddWithValue("id", id);
                cmd1.Parameters.AddWithValue("id", id);

                con.Open();
                con1.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataTable dtEvidence = new DataTable();
                sda.Fill(dtEvidence);
                rptEvidence.DataSource = dtEvidence;
                rptEvidence.DataBind();
                con1.Close();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    lblReportID.Text = (string)dr[0];
                    lblReportDate.Text = (string)dr[1];
                    lblReportCategory.Text = (string)dr[2];
                    lblReportDetails.Text = (string)dr[3];
                    lblVictimID.Text = (string)dr[6];
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string REPORT_STATUS = ddlStatus.Text;
            string REPORT_COMMENT = txtComment.Text;

            string sql = "UPDATE CASES_REPORT SET REPORT_STATUS = @REPORT_STATUS, REPORT_COMMENT = @REPORT_COMMENT WHERE REPORT_ID = @id";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@REPORT_STATUS", REPORT_STATUS);
            cmd.Parameters.AddWithValue("@REPORT_COMMENT", REPORT_COMMENT);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            Response.Write("<script> alert('Update Successful !');</script>");
            Server.Transfer("viewVictimReport.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewVictimReport.aspx");
        }
    }
}