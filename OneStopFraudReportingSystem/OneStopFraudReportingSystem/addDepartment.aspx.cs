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
    public partial class addDepartment : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Session["A_id"] == null || Request.Cookies["A_id"] == null)
            {
                Response.Write("<script> alert('Please Login with your admin account!'); </script>");
                Server.Transfer("loginPending.aspx");
            }*/
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            string sql = "SELECT COUNT(*) FROM DEPARTMENT";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();

            int count = (int)cmd.ExecuteScalar() + 1;

            string DEPARTMENT_ID = "D00" + Convert.ToString(count);

            con.Close();

            string DEPARTMENT_NAME = txtDName.Text;

            string sql1 = "INSERT INTO DEPARTMENT (DEPARTMENT_ID, DEPARTMENT_NAME) VALUES (@DEPARTMENT_ID, @DEPARTMENT_NAME)";

            SqlConnection con1 = new SqlConnection(cs);
            SqlCommand cmd1 = new SqlCommand(sql1, con1);

            cmd1.Parameters.AddWithValue("@DEPARTMENT_ID", DEPARTMENT_ID);
            cmd1.Parameters.AddWithValue("@DEPARTMENT_NAME", DEPARTMENT_NAME);

            con1.Open();

            cmd1.ExecuteNonQuery();

            con1.Close();

            Response.Write("<script> alert('Register Successful !');</script>");
            Server.Transfer("adminDashboard.aspx");
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("departmentDetails.aspx");
        }
    }
}