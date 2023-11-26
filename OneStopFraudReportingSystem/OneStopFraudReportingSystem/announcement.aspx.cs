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
    public partial class announcement : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["A_id"] != null || Session["A_id"] != null)
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
                    lblDepartment.Text = (string)dr[8];
                    if ((string)dr["ADM_POSITION"] == "High-Level Admin")
                    {
                        rptModifyAnnouncement.Visible = true;
                        rptAnnouncement.Visible = false;
                        rptUpdateAnnouncement.Visible = false;
                    }
                    else
                    {
                        rptModifyAnnouncement.Visible = false;
                        rptAnnouncement.Visible = false;
                        rptUpdateAnnouncement.Visible = true;
                    }
                }
                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

                string DEPARTMENT = lblDepartment.Text;
                string sql1 = "SELECT * FROM ANNOUNCEMENT WHERE DEPARTMENT = @DEPARTMENT";
                
                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con1.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);

                DataTable dtAnnouncement = new DataTable();
                sda.Fill(dtAnnouncement);
                rptAnnouncement.DataSource = dtAnnouncement;
                rptAnnouncement.DataBind();
                con1.Close();

                string sql2 = "SELECT * FROM ANNOUNCEMENT WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                cmd2.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con2.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);

                DataTable dtModifyAnnouncment = new DataTable();
                sda1.Fill(dtModifyAnnouncment);
                rptModifyAnnouncement.DataSource = dtModifyAnnouncment;
                rptModifyAnnouncement.DataBind();
                con2.Close();

                string sql3 = "SELECT * FROM ANNOUNCEMENT WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con3 = new SqlConnection(cs);
                SqlCommand cmd3 = new SqlCommand(sql3, con3);

                cmd3.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con3.Open();

                SqlDataAdapter sda2 = new SqlDataAdapter(cmd3);

                DataTable dtUpdateAnnouncement = new DataTable();
                sda2.Fill(dtUpdateAnnouncement);
                rptUpdateAnnouncement.DataSource = dtUpdateAnnouncement;
                rptUpdateAnnouncement.DataBind();
                con3.Close();
            }
            else if (Request.Cookies["U_id"] != null || Session["U_id"] != null)
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
                    lblDepartment.Text = (string)dr[8];
                    if ((string)dr["UICS_POSITION"] == "Department Head")
                    {
                        rptModifyAnnouncement.Visible = true;
                        rptAnnouncement.Visible = false;
                        rptUpdateAnnouncement.Visible = false;
                    }
                    else
                    {
                        rptModifyAnnouncement.Visible = false;
                        rptAnnouncement.Visible = false;
                        rptUpdateAnnouncement.Visible = true;
                    }
                }
                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

                string DEPARTMENT = lblDepartment.Text;

                string sql1 = "SELECT * FROM ANNOUNCEMENT WHERE DEPARTMENT = @DEPARTMENT";
                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con1.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);

                DataTable dtAnnouncement = new DataTable();
                sda.Fill(dtAnnouncement);
                rptAnnouncement.DataSource = dtAnnouncement;
                rptAnnouncement.DataBind();
                con1.Close();

                string sql2 = "SELECT * FROM ANNOUNCEMENT WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                cmd2.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con2.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);

                DataTable dtModifyAnnouncment = new DataTable();
                sda1.Fill(dtModifyAnnouncment);
                rptModifyAnnouncement.DataSource = dtModifyAnnouncment;
                rptModifyAnnouncement.DataBind();
                con2.Close();

                string sql3 = "SELECT * FROM ANNOUNCEMENT WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con3 = new SqlConnection(cs);
                SqlCommand cmd3 = new SqlCommand(sql3, con3);

                cmd3.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con3.Open();

                SqlDataAdapter sda2 = new SqlDataAdapter(cmd3);

                DataTable dtUpdateAnnouncement = new DataTable();
                sda2.Fill(dtUpdateAnnouncement);
                rptUpdateAnnouncement.DataSource = dtUpdateAnnouncement;
                rptUpdateAnnouncement.DataBind();
                con3.Close();
            }
            else if (Request.Cookies["V_id"] != null || Session["V_id"] != null)
            {
                string sql = "SELECT * FROM ANNOUNCEMENT";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtAnnouncement = new DataTable();
                sda.Fill(dtAnnouncement);
                rptAnnouncement.DataSource = dtAnnouncement;
                rptAnnouncement.DataBind();
                con.Close();

                btnAdd.Visible = false;
            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btnAdd_Click (object sender, EventArgs e)
        {
            if (Request.Cookies["A_id"] != null || Session["A_id"] != null || Request.Cookies["U_id"] != null || Session["U_id"] != null)
            {
                Response.Redirect("addAnnouncement.aspx");
            }
                
        }

        protected void btnSearch_Click (object sender, EventArgs e)
        {
            if (Request.Cookies["A_id"] != null || Session["A_id"] != null)
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
                    lblDepartment.Text = (string)dr[8];
                    if ((string)dr["ADM_POSITION"] == "High-Level Admin")
                    {
                        rptModifyAnnouncement.Visible = true;
                        rptAnnouncement.Visible = false;
                        rptUpdateAnnouncement.Visible = false;
                    }
                    else
                    {
                        rptModifyAnnouncement.Visible = false;
                        rptAnnouncement.Visible = false;
                        rptUpdateAnnouncement.Visible = true;
                    }
                }
                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

                string DEPARTMENT = lblDepartment.Text;
                string ANN_TITLE = txtSearch.Text;

                string sql1 = "SELECT * FROM ANNOUNCEMENT WHERE ANN_TITLE = @ANN_TITLE AND DEPARTMENT = @DEPARTMENT";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con);

                cmd1.Parameters.AddWithValue("@ANN_TITLE", ANN_TITLE);
                cmd1.Parameters.AddWithValue("@DEPARTMENT", DEPARTMENT);

                con1.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd1);

                DataTable dtAnnouncement = new DataTable();
                sda.Fill(dtAnnouncement);
                rptAnnouncement.DataSource = dtAnnouncement;
                rptAnnouncement.DataBind();
                con.Close();

                string sql2 = "SELECT * FROM ANNOUNCEMENT WHERE ANN_TITLE = @ANN_TITLE AND DEPARTMENT = @DEPARTMENT";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                cmd2.Parameters.AddWithValue("@ANN_TITLE", ANN_TITLE);
                cmd2.Parameters.AddWithValue("@DEPARTMENT", DEPARTMENT);

                con2.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);

                DataTable dtModifyAnnouncment = new DataTable();
                sda1.Fill(dtModifyAnnouncment);
                rptModifyAnnouncement.DataSource = dtModifyAnnouncment;
                rptModifyAnnouncement.DataBind();
                con2.Close();

                string sql3 = "SELECT * FROM ANNOUNCEMENT WHERE ANN_TITLE = @ANN_TITLE AND DEPARTMENT = @DEPARTMENT";

                SqlConnection con3 = new SqlConnection(cs);
                SqlCommand cmd3 = new SqlCommand(sql3, con3);

                cmd3.Parameters.AddWithValue("@ANN_TITLE", ANN_TITLE);
                cmd3.Parameters.AddWithValue("@DEPARTMENT", DEPARTMENT);

                con3.Open();

                SqlDataAdapter sda2 = new SqlDataAdapter(cmd3);

                DataTable dtUpdateAnnouncement = new DataTable();
                sda2.Fill(dtUpdateAnnouncement);
                rptUpdateAnnouncement.DataSource = dtUpdateAnnouncement;
                rptUpdateAnnouncement.DataBind();
                con3.Close();

                
            }
            else if (Request.Cookies["U_id"] != null || Session["U_id"] != null)
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
                    lblDepartment.Text = (string)dr[8];
                    if ((string)dr["UICS_POSITION"] == "Department Head")
                    {
                        rptModifyAnnouncement.Visible = true;
                        rptAnnouncement.Visible = false;
                        rptUpdateAnnouncement.Visible = false;
                    }
                    else
                    {
                        rptModifyAnnouncement.Visible = false;
                        rptAnnouncement.Visible = false;
                        rptUpdateAnnouncement.Visible = true;
                    }
                }
                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

                string DEPARTMENT = lblDepartment.Text;
                string ANN_TITLE = txtSearch.Text;

                string sql1 = "SELECT * FROM ANNOUNCEMENT WHERE ANN_TITLE = @ANN_TITLE AND DEPARTMENT = @DEPARTMENT";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con);

                cmd1.Parameters.AddWithValue("@ANN_TITLE", ANN_TITLE);
                cmd1.Parameters.AddWithValue("@DEPARTMENT", DEPARTMENT);

                con1.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd1);

                DataTable dtAnnouncement = new DataTable();
                sda.Fill(dtAnnouncement);
                rptAnnouncement.DataSource = dtAnnouncement;
                rptAnnouncement.DataBind();
                con.Close();

                string sql2 = "SELECT * FROM ANNOUNCEMENT WHERE ANN_TITLE = @ANN_TITLE AND DEPARTMENT = @DEPARTMENT";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                cmd2.Parameters.AddWithValue("@ANN_TITLE", ANN_TITLE);
                cmd2.Parameters.AddWithValue("@DEPARTMENT", DEPARTMENT);

                con2.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);

                DataTable dtModifyAnnouncment = new DataTable();
                sda1.Fill(dtModifyAnnouncment);
                rptModifyAnnouncement.DataSource = dtModifyAnnouncment;
                rptModifyAnnouncement.DataBind();
                con2.Close();

                string sql3 = "SELECT * FROM ANNOUNCEMENT WHERE ANN_TITLE = @ANN_TITLE AND DEPARTMENT = @DEPARTMENT";

                SqlConnection con3 = new SqlConnection(cs);
                SqlCommand cmd3 = new SqlCommand(sql3, con3);

                cmd3.Parameters.AddWithValue("@ANN_TITLE", ANN_TITLE);
                cmd3.Parameters.AddWithValue("@DEPARTMENT", DEPARTMENT);

                con3.Open();

                SqlDataAdapter sda2 = new SqlDataAdapter(cmd3);

                DataTable dtUpdateAnnouncement = new DataTable();
                sda2.Fill(dtUpdateAnnouncement);
                rptUpdateAnnouncement.DataSource = dtUpdateAnnouncement;
                rptUpdateAnnouncement.DataBind();
                con3.Close();
            }
            else if (Request.Cookies["V_id"] != null || Session["V_id"] != null)
            {
                string ANN_TITLE = txtSearch.Text;

                string sql = "SELECT * FROM ANNOUNCEMENT WHERE ANN_TITLE = @ANN_TITLE";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@ANN_TITLE", ANN_TITLE);

                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtAnnouncement = new DataTable();
                sda.Fill(dtAnnouncement);
                rptAnnouncement.DataSource = dtAnnouncement;
                rptAnnouncement.DataBind();
                con.Close();
            }
            
            
        }

        protected void btnViewAll_Click (object sender, EventArgs e)
        {
            if (Request.Cookies["A_id"] != null || Session["A_id"] != null)
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
                    lblDepartment.Text = (string)dr[8];
                    if ((string)dr["ADM_POSITION"] == "High-Level Admin")
                    {
                        rptModifyAnnouncement.Visible = true;
                        rptAnnouncement.Visible = false;
                        rptUpdateAnnouncement.Visible = false;
                    }
                    else
                    {
                        rptModifyAnnouncement.Visible = false;
                        rptAnnouncement.Visible = false;
                        rptUpdateAnnouncement.Visible = true;
                    }
                }
                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

                string DEPARTMENT = lblDepartment.Text;
                string sql1 = "SELECT * FROM ANNOUNCEMENT WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con1.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);

                DataTable dtAnnouncement = new DataTable();
                sda.Fill(dtAnnouncement);
                rptAnnouncement.DataSource = dtAnnouncement;
                rptAnnouncement.DataBind();
                con1.Close();

                string sql2 = "SELECT * FROM ANNOUNCEMENT WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                cmd2.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con2.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);

                DataTable dtModifyAnnouncment = new DataTable();
                sda1.Fill(dtModifyAnnouncment);
                rptModifyAnnouncement.DataSource = dtModifyAnnouncment;
                rptModifyAnnouncement.DataBind();
                con2.Close();

                string sql3 = "SELECT * FROM ANNOUNCEMENT WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con3 = new SqlConnection(cs);
                SqlCommand cmd3 = new SqlCommand(sql3, con3);

                cmd3.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con3.Open();

                SqlDataAdapter sda2 = new SqlDataAdapter(cmd3);

                DataTable dtUpdateAnnouncement = new DataTable();
                sda2.Fill(dtUpdateAnnouncement);
                rptUpdateAnnouncement.DataSource = dtUpdateAnnouncement;
                rptUpdateAnnouncement.DataBind();
                con3.Close();
            }
            else if (Request.Cookies["U_id"] != null || Session["U_id"] != null)
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
                    lblDepartment.Text = (string)dr[8];
                    if ((string)dr["UICS_POSITION"] == "Department Head")
                    {
                        rptModifyAnnouncement.Visible = true;
                        rptAnnouncement.Visible = false;
                        rptUpdateAnnouncement.Visible = false;
                    }
                    else
                    {
                        rptModifyAnnouncement.Visible = false;
                        rptAnnouncement.Visible = false;
                        rptUpdateAnnouncement.Visible = true;
                    }
                }
                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

                string DEPARTMENT = lblDepartment.Text;

                string sql1 = "SELECT * FROM ANNOUNCEMENT WHERE DEPARTMENT = @DEPARTMENT";
                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con1.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);

                DataTable dtAnnouncement = new DataTable();
                sda.Fill(dtAnnouncement);
                rptAnnouncement.DataSource = dtAnnouncement;
                rptAnnouncement.DataBind();
                con1.Close();

                string sql2 = "SELECT * FROM ANNOUNCEMENT WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                cmd2.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con2.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);

                DataTable dtModifyAnnouncment = new DataTable();
                sda1.Fill(dtModifyAnnouncment);
                rptModifyAnnouncement.DataSource = dtModifyAnnouncment;
                rptModifyAnnouncement.DataBind();
                con2.Close();

                string sql3 = "SELECT * FROM ANNOUNCEMENT WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con3 = new SqlConnection(cs);
                SqlCommand cmd3 = new SqlCommand(sql3, con3);

                cmd3.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con3.Open();

                SqlDataAdapter sda2 = new SqlDataAdapter(cmd3);

                DataTable dtUpdateAnnouncement = new DataTable();
                sda2.Fill(dtUpdateAnnouncement);
                rptUpdateAnnouncement.DataSource = dtUpdateAnnouncement;
                rptUpdateAnnouncement.DataBind();
                con3.Close();
            }
            else if (Request.Cookies["V_id"] != null || Session["V_id"] != null)
            {
                string sql = "SELECT * FROM ANNOUNCEMENT";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtAnnouncement = new DataTable();
                sda.Fill(dtAnnouncement);
                rptAnnouncement.DataSource = dtAnnouncement;
                rptAnnouncement.DataBind();
                con.Close();

                btnAdd.Visible = false;
            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }

        }

        protected void btnBack_Click (object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                Response.Redirect("adminDashboard.aspx");
            }
            else if(Session["U_id"] != null || Request.Cookies["U_id"] != null)
            {
                Response.Redirect("unitsInChargeDashboard.aspx");
            }
            else if (Session["V_id"] != null || Request.Cookies["V_id"] != null)
            {
                Response.Redirect("userDashboard.aspx");
            }
        }
    }
}