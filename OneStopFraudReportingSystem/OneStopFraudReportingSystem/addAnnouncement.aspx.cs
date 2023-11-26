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
    public partial class addAnnouncement : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["A_id"] != null)
            {
                lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");

                string id = Session["A_id"].ToString();

                bool found = false;

                //retrieve id from URL (get method)

                string sql = "SELECT * FROM ADMIN WHERE ADM_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    //record found
                    found = true;
                    txtPostedBy.Text = (string)dr[1];
                    txtDepartment.Text = (string)dr[8];
                    txtPosition.Text = (string)dr[9];
                }

                dr.Close();
                con.Close();
                if(!found)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else if (Request.Cookies["A_id"] != null)
            {
                lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");

                string id = Request.Cookies["A_id"].Value;

                bool found = false;

                //retrieve id from URL (get method)

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
                    txtPostedBy.Text = (string)dr[1];
                    txtDepartment.Text = (string)dr[8];
                    txtPosition.Text = (string)dr[9];
                }

                dr.Close();
                con.Close();
                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

            }
            else if(Session["U_id"] != null)
            {
                lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");

                string id = Session["U_id"].ToString();

                bool found = false;

                //retrieve id from URL (get method)

                string sql = "SELECT * FROM UICS WHERE UICS_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    txtPostedBy.Text = (string)dr[1];
                    txtDepartment.Text = (string)dr[8];
                    txtPosition.Text = (string)dr[9];
                }

                dr.Close();
                con.Close();
                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else if(Request.Cookies["U_id"] != null)
            {
                lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");

                string id = Request.Cookies["U_id"].Value;

                bool found = false;

                //retrieve id from URL (get method)

                string sql = "SELECT * FROM UICS WHERE UICS_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    txtPostedBy.Text = (string)dr[1];
                    txtDepartment.Text = (string)dr[8];
                    txtPosition.Text = (string)dr[9];
                }

                dr.Close();
                con.Close();
                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else
            {
                Response.Write("<script> alert('Please Login !!!'); </script>");
                Server.Transfer("loginPending.aspx");
            }

            
        }

        /*protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string POSTED_BY;
            if (Page.IsValid)
            {
                if(Session["A_id"] == null || Request.Cookies["A_id"] == null)
                {
                    string sql = "SELECT COUNT(*) FROM ANNOUNCEMENT";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    con.Open();

                    int count = (int)cmd.ExecuteScalar() + 1;

                    string ANN_ID = "ANN00" + Convert.ToString(count);

                    con.Close();

                    string ANN_TITLE = txtATitle.Text;
                    string ANN_DATE = lblDate.Text;
                    string ANN_DETAILS = txtADetails.Text;

                    if (Request.Cookies["A_id"] != null)
                    {
                        POSTED_BY = Request.Cookies["A_id"].Value;
                    }
                    else
                    {
                        POSTED_BY = Session["A_id"].ToString();
                    }

                    string sql1 = "INSERT INTO Announcement (ANN_ID, ANN_TITLE, ANN_DATE, ANN_DETAILS, POSTED_BY) VALUES (@ANN_ID, @ANN_TITLE, @ANN_DATE, @ANN_DETAILS, @POSTED_BY)";

                    SqlConnection con1 = new SqlConnection(cs);
                    SqlCommand cmd1 = new SqlCommand(sql1, con1);

                    cmd1.Parameters.AddWithValue("@ANN_ID", ANN_ID);
                    cmd1.Parameters.AddWithValue("@ANN_TITLE", ANN_TITLE);
                    cmd1.Parameters.AddWithValue("@ANN_DATE", ANN_DATE);
                    cmd1.Parameters.AddWithValue("@ANN_DETAILS", ANN_DETAILS);
                    cmd1.Parameters.AddWithValue("@POSTED_BY", POSTED_BY);

                    con1.Open();

                    cmd1.ExecuteNonQuery();

                    con.Close();

                    Response.Write("<script> alert('Announcement Posted Successful !);</script>");
                    Server.Transfer("adminDashboard.aspx");
                }
                else if(Session["U_id"] == null || Request.Cookies["U_id"] == null)
                {
                    string sql = "SELECT COUNT(*) FROM ANNOUNCEMENT";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    con.Open();

                    int count = (int)cmd.ExecuteScalar() + 1;

                    string ANN_ID = "ANN00" + Convert.ToString(count);

                    con.Close();

                    string ANN_TITLE = txtATitle.Text;
                    string ANN_DATE = lblDate.Text;
                    string ANN_DETAILS = txtADetails.Text;

                    if (Request.Cookies["U_id"] != null)
                    {
                        POSTED_BY = Request.Cookies["U_id"].Value;
                    }
                    else
                    {
                        POSTED_BY = Session["U_id"].ToString();
                    }

                    string sql1 = "INSERT INTO Announcement (ANN_ID, ANN_TITLE, ANN_DATE, ANN_DETAILS, POSTED_BY) VALUES (@ANN_ID, @ANN_TITLE, @ANN_DATE, @ANN_DETAILS, @POSTED_BY)";

                    SqlConnection con1 = new SqlConnection(cs);
                    SqlCommand cmd1 = new SqlCommand(sql1, con1);

                    cmd1.Parameters.AddWithValue("@ANN_ID", ANN_ID);
                    cmd1.Parameters.AddWithValue("@ANN_TITLE", ANN_TITLE);
                    cmd1.Parameters.AddWithValue("@ANN_DATE", ANN_DATE);
                    cmd1.Parameters.AddWithValue("@ANN_DETAILS", ANN_DETAILS);
                    cmd1.Parameters.AddWithValue("@POSTED_BY", POSTED_BY);

                    con1.Open();

                    cmd1.ExecuteNonQuery();

                    con.Close();

                    Response.Write("<script> alert('Announcement Posted Successful !);</script>");
                    Server.Transfer("unitsInChargeDashboard.aspx");
                }
                
            }
        }*/

        protected void btnSubmit_Click(object sender, EventArgs e)
        { 
            string sql = "SELECT COUNT(*) FROM ANNOUNCEMENT";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();

            int count = (int)cmd.ExecuteScalar() + 1;

            string ANN_ID = "ANN00" + Convert.ToString(count);

            con.Close();

            string ANN_TITLE = txtATitle.Text;
            string ANN_DATE = lblDate.Text;
            string ANN_DETAILS = txtADetails.Text;
            string POSTED_BY = txtPostedBy.Text;
            string DEPARTMENT = txtDepartment.Text;
            string POSITION = txtPosition.Text;

            string sql1 = "INSERT INTO ANNOUNCEMENT (ANN_ID, ANN_TITLE, ANN_DATE, ANN_DETAILS, POSTED_BY, DEPARTMENT, POSITION) VALUES (@ANN_ID, @ANN_TITLE, @ANN_DATE, @ANN_DETAILS, @POSTED_BY, @DEPARTMENT, @POSITION)";

            SqlConnection con1 = new SqlConnection(cs);
            SqlCommand cmd1 = new SqlCommand(sql1, con1);

            cmd1.Parameters.AddWithValue("@ANN_ID", ANN_ID);
            cmd1.Parameters.AddWithValue("@ANN_TITLE", ANN_TITLE);
            cmd1.Parameters.AddWithValue("@ANN_DATE", ANN_DATE);
            cmd1.Parameters.AddWithValue("@ANN_DETAILS", ANN_DETAILS);
            cmd1.Parameters.AddWithValue("@POSTED_BY", POSTED_BY);
            cmd1.Parameters.AddWithValue("@DEPARTMENT", DEPARTMENT);
            cmd1.Parameters.AddWithValue("@POSITION", POSITION);

            con1.Open();

            cmd1.ExecuteNonQuery();

            con1.Close();

            Response.Write("<script> alert('Announcement Posted Successful !'); window.location='adminDashboard.aspx';</script>");
 
            
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Server.Transfer("addAnnouncement.aspx");
        }
    }
}