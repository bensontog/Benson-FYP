using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace OneStopFraudReportingSystem
{
    public partial class addEvidence : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["V_id"] != null || Session["V_id"] != null)
            {
                bool found = false;

                string id = Request.QueryString["id"];

                string sql = "SELECT * FROM CASES_REPORT WHERE REPORT_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    //record found
                    found = true;
                    txtReportID.Text = (string)dr[0];
                    txtDate.Text = (string)dr[1];
                    txtVname.Text = (string)dr[13];
                    txtPhone.Text = (string)dr[14];
                }

                dr.Close();
                con.Close();

                if(!found)
                {
                    Response.Redirect("casesReportDetails.aspx");
                }
            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string sql = "SELECT COUNT(*) FROM CASES_REPORT";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();

            int count = (int)cmd.ExecuteScalar() + 1;

            string EVIDENCE_ID = "E00" + Convert.ToString(count);

            con.Close();

            if(fileEvidence.HasFiles)
            {
                foreach(HttpPostedFile fu in fileEvidence.PostedFiles)
                {
                    string REPORT_ID = txtReportID.Text;

                    string sql1 = "INSERT INTO CASES_EVIDENCE (EVIDENCE_ID, REPORT_ID, EVIDENCE) VALUES (@EVIDENCE_ID, @REPORT_ID, @EVIDENCE)";

                    SqlConnection con1 = new SqlConnection(cs);
                    SqlCommand cmd1 = new SqlCommand(sql1, con1);

                    con1.Open();

                    string path = "CasesEvidence/" + fu.FileName;
                    cmd1.Parameters.AddWithValue("@EVIDENCE_ID", EVIDENCE_ID);
                    cmd1.Parameters.AddWithValue("@REPORT_ID", REPORT_ID);
                    cmd1.Parameters.AddWithValue("@EVIDENCE", path);

                    if(cmd1.ExecuteNonQuery() > 0)
                    {
                        fileEvidence.SaveAs(Path.Combine(Server.MapPath("/CasesEvidence/"), fu.FileName));
                        Response.Write("<script> alert('Evidence Add Successful !'); window.location= 'casesReportDetails.aspx';</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script> alert('Evidence Add Unsuccessful !'); window.location= 'casesReportDetails.aspx';</script>");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("casesReportDetails.aspx");
        }
    }
}