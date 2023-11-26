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
    public partial class viewVictimReport : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["U_id"] != null)
            {
                bool found = false;

                string UICS_ID = Session["U_id"].ToString();

                string sql = "SELECT * FROM UICS WHERE UICS_ID = @UICS_ID";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("UICS_ID", UICS_ID);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    //record found
                    found = true;
                    txtUID.Text = (string)dr[0];
                    txtUName.Text = (string)dr[1];
                    lblDepartment.Text = (string)dr[8];
                    if ((string)dr["UICS_POSITION"] == "Department Staff")
                    {
                        rptCasesReport.Visible = false;
                    }
                    else
                    {
                        rptCasesReport.Visible = true;
                        rptCasesInCharge.Visible = false;
                    }
                }

                dr.Close();
                con.Close();
                if(!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

                string UName = txtUName.Text;
                string DEPARTMENT = lblDepartment.Text;

                string sql1 = "SELECT * FROM CASES_REPORT WHERE DEPARTMENT = @DEPARTMENT AND HANDLED_BY = @UName";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);
                cmd1.Parameters.AddWithValue("UName", UName);

                con1.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd1);

                DataTable dtReport = new DataTable();
                sda.Fill(dtReport);
                rptCasesInCharge.DataSource = dtReport;
                rptCasesInCharge.DataBind();

                con1.Close(); 

                string sql2 = "SELECT * FROM CASES_REPORT WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                cmd2.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con2.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);

                DataTable dtReport1 = new DataTable();
                sda1.Fill(dtReport1);
                rptCasesReport.DataSource = dtReport1;
                rptCasesReport.DataBind();
                con2.Close();
            }
            else if (Request.Cookies["A_id"] != null || Session["A_id"] != null)
            {
                string sql = "SELECT * FROM CASES_REPORT";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtReport = new DataTable();
                sda.Fill(dtReport);
                rptAdminView.DataSource = dtReport;
                rptAdminView.DataBind();
                con.Close();

                lblUID.Visible = false;
                lblUName.Visible = false;
                txtUID.Visible = false;
                txtUName.Visible = false;
            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["U_id"] != null || Session["U_id"] != null)
            {
                Response.Redirect("unitsInChargeDashboard.aspx");
            }
            else if(Request.Cookies["A_id"] != null || Session["A_id"] != null)
            {
                Response.Redirect("adminDashboard.aspx");
            }
            
        }
    }
}