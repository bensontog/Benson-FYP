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
    public partial class deleteDepartment : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["A_id"] != null)
            {
                bool found = false;

                string id = Request.QueryString["id"];

                string sql = "SELECT * FROM DEPARTMENT WHERE DEPARTMENT_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    txtDID.Text = (string)dr[0];
                    txtDName.Text = (string)dr[1];
                }

                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("departmentDetails.aspx");
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string DEPARTMENT_NAME = txtDName.Text;

            string sql = "DELETE FROM DEPARTMENT WHERE DEPARTMENT_NAME = @DEPARTMENT_NAME";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("DEPARTMENT_NAME", DEPARTMENT_NAME);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            Response.Write("<script> alert('Delete Successful !');  window.location= 'departmentDetails.aspx'; </script>");
        }

        protected void btnBack_Click (object sender,  EventArgs e)
        {
            Response.Redirect("departmentDetails.aspx");
        }
    }
}