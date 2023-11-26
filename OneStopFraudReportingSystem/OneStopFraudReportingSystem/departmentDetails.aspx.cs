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
    public partial class departmentDetails : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["A_id"] != null || Session["A_id"] != null)
            {
                string sql = "SELECT * FROM DEPARTMENT";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtDepartment = new DataTable();
                sda.Fill(dtDepartment);
                rptDepartment.DataSource = dtDepartment;
                rptDepartment.DataBind();
                con.Close();

                string sql1 = "SELECT * FROM DEPARTMENT";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                con1.Open();

                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);

                DataTable dtAdminModify = new DataTable();
                sda1.Fill(dtAdminModify);
                rptAdminModify.DataSource = dtAdminModify;
                rptAdminModify.DataBind();
                con1.Close();

                bool found = false;

                string id;

                if (Request.Cookies["A_id"] != null)
                {
                    id = Request.Cookies["A_id"].Value;
                }
                else
                {
                    id = Session["A_id"].ToString();
                }

                string sql2 = "SELECT * FROM ADMIN WHERE ADM_ID = @id";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                cmd2.Parameters.AddWithValue("id", id);

                con2.Open();
                SqlDataReader dr = cmd2.ExecuteReader();

                if(dr.Read())
                {
                    //record found
                    found = true;
                    if ((string)dr["ADM_POSITION"] == "High-Level Admin")
                    {
                        rptAdminModify.Visible = true;
                        rptDepartment.Visible = false;
                    }
                    else
                    {
                        rptAdminModify.Visible = false;
                        rptDepartment.Visible = true;
                    }
                }

                dr.Close();
                con2.Close();

                if(!found)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else if (Request.Cookies["V_id"] != null || Session["V_id"] != null)
            {
                string sql = "SELECT * FROM DEPARTMENT";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtDepartment = new DataTable();
                sda.Fill(dtDepartment);
                rptDepartment.DataSource = dtDepartment;
                rptDepartment.DataBind();
                con.Close();

                btnAdd.Visible = false;
                rptAdminModify.Visible = false;
            }
            else
            {
                Response.Redirect("loginPedning.aspx");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("addDepartment.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["A_id"] != null || Session["A_id"] != null)
            {
                bool found = false;

                string id;

                if (Request.Cookies["A_id"] != null)
                {
                    id = Request.Cookies["A_id"].Value;
                }
                else
                {
                    id = Session["A_id"].ToString();
                }

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
                    if ((string)dr["ADM_POSITION"] == "High-Level Admin")
                    {
                        rptAdminModify.Visible = true;
                        rptDepartment.Visible = false;
                    }
                    else
                    {
                        rptAdminModify.Visible = false;
                        rptDepartment.Visible = true;
                    }
                }

                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

                string DEPARTMENT_ID = txtSearch.Text;
                string DEPARTMENT_NAME = txtSearch.Text;

                string sql1 = "SELECT * FROM DEPARTMENT WHERE DEPARTMENT_ID = @DEPARTMENT_ID OR DEPARTMENT_NAME = @DEPARTMENT_NAME";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("@DEPARTMENT_ID", DEPARTMENT_ID);
                cmd1.Parameters.AddWithValue("@DEPARTMENT_NAME", DEPARTMENT_NAME);

                con1.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd1);

                DataTable dtDepartment = new DataTable();
                sda.Fill(dtDepartment);
                rptDepartment.DataSource = dtDepartment;
                rptDepartment.DataBind();
                con.Close();

                string sql2 = "SELECT * FROM DEPARTMENT WHERE DEPARTMENT_ID = @DEPARTMENT_ID OR DEPARTMENT_NAME = @DEPARTMENT_NAME";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                cmd2.Parameters.AddWithValue("@DEPARTMENT_ID", DEPARTMENT_ID);
                cmd2.Parameters.AddWithValue("@DEPARTMENT_NAME", DEPARTMENT_NAME);

                con2.Open();

                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);

                DataTable dtAdminModify = new DataTable();
                sda2.Fill(dtAdminModify);
                rptAdminModify.DataSource = dtAdminModify;
                rptAdminModify.DataBind();
                con2.Close();

            }
            else if(Request.Cookies["V_id"] != null || Session["V_id"] != null)
            {
                string DEPARTMENT_ID = txtSearch.Text;
                string DEPARTMENT_NAME = txtSearch.Text;

                string sql = "SELECT * FROM DEPARTMENT WHERE DEPARTMENT_ID = @DEPARTMENT_ID OR DEPARTMENT_NAME = @DEPARTMENT_NAME";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@DEPARTMENT_ID", DEPARTMENT_ID);
                cmd.Parameters.AddWithValue("@DEPARTMENT_NAME", DEPARTMENT_NAME);

                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtDepartment = new DataTable();
                sda.Fill(dtDepartment);
                rptDepartment.DataSource = dtDepartment;
                rptDepartment.DataBind();
                con.Close();
            }
        }

        protected void btnViewAll_Click (object sender, EventArgs e)
        {
            if (Request.Cookies["A_id"] != null || Session["A_id"] != null)
            {
                string sql = "SELECT * FROM DEPARTMENT";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtDepartment = new DataTable();
                sda.Fill(dtDepartment);
                rptDepartment.DataSource = dtDepartment;
                rptDepartment.DataBind();
                con.Close();

                string sql1 = "SELECT * FROM DEPARTMENT";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                con1.Open();

                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);

                DataTable dtAdminModify = new DataTable();
                sda1.Fill(dtAdminModify);
                rptAdminModify.DataSource = dtAdminModify;
                rptAdminModify.DataBind();
                con1.Close();

                bool found = false;

                string id;

                if (Request.Cookies["A_id"] != null)
                {
                    id = Request.Cookies["A_id"].Value;
                }
                else
                {
                    id = Session["A_id"].ToString();
                }

                string sql2 = "SELECT * FROM ADMIN WHERE ADM_ID = @id";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                cmd2.Parameters.AddWithValue("id", id);

                con2.Open();
                SqlDataReader dr = cmd2.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    if ((string)dr["ADM_POSITION"] == "High-Level Admin")
                    {
                        rptAdminModify.Visible = true;
                        rptDepartment.Visible = false;
                    }
                    else
                    {
                        rptAdminModify.Visible = false;
                        rptDepartment.Visible = true;
                    }
                }

                dr.Close();
                con2.Close();

                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else if (Request.Cookies["U_id"] != null || Session["U_id"] != null)
            {
                string sql = "SELECT * FROM DEPARTMENT";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtDepartment = new DataTable();
                sda.Fill(dtDepartment);
                rptDepartment.DataSource = dtDepartment;
                rptDepartment.DataBind();
                con.Close();
            }
            else if (Request.Cookies["V_id"] != null || Session["V_id"] != null)
            {
                string sql = "SELECT * FROM DEPARTMENT";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtDepartment = new DataTable();
                sda.Fill(dtDepartment);
                rptDepartment.DataSource = dtDepartment;
                rptDepartment.DataBind();
                con.Close();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminDashboard.aspx");
        }
    }
}