using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

namespace OneStopFraudReportingSystem
{
    public partial class viewDepartmentStaff : System.Web.UI.Page
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

                if(dr.Read())
                {
                    //record found
                    found = true;
                    lblDepartment.Text = (string)dr[1];
                }

                dr.Close();
                con.Close();
                if(!found)
                {
                    Response.Redirect("departmentDetails.aspx");
                }

                string DEPARTMENT = lblDepartment.Text;

                string sql1 = "SELECT * FROM UICS WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con1.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd1);

                DataTable dtDepartmentStaff = new DataTable();
                sda.Fill(dtDepartmentStaff);
                rptDepartmentStaff.DataSource = dtDepartmentStaff;
                rptDepartmentStaff.DataBind();

                con1.Close();

                string ADM_ID = Session["A_id"].ToString();

                bool found1 = false;

                //retrieve id from URL (get method)

                string sql2 = "SELECT * FROM ADMIN WHERE ADM_ID = @ADM_ID";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                cmd2.Parameters.AddWithValue("ADM_ID", ADM_ID);

                con2.Open();
                SqlDataReader dr1 = cmd2.ExecuteReader();

                if(dr1.Read())
                {
                    //record found
                    found1 = true;
                    if ((string)dr1["ADM_POSITION"] == "High-Level Admin")
                    {
                        btnAdd.Visible = true;
                    }
                    else
                    {
                        btnAdd.Visible = false;
                    }
                }

                dr1.Close();
                con2.Close();
                if(!found1)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else if (Request.Cookies["A_id"] != null)
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
                    lblDepartment.Text = (string)dr[1];
                }

                dr.Close();
                con.Close();
                if (!found)
                {
                    Response.Redirect("departmentDetails.aspx");
                }

                string DEPARTMENT = lblDepartment.Text;

                string sql1 = "SELECT * FROM UICS WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con1.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd1);

                DataTable dtDepartmentStaff = new DataTable();
                sda.Fill(dtDepartmentStaff);
                rptDepartmentStaff.DataSource = dtDepartmentStaff;
                rptDepartmentStaff.DataBind();

                con1.Close();

                string ADM_ID = Request.Cookies["A_id"].Value;

                bool found1 = false;

                //retrieve id from URL (get method)

                string sql2 = "SELECT * FROM ADMIN WHERE ADM_ID = @ADM_ID";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                cmd2.Parameters.AddWithValue("ADM_ID", ADM_ID);

                con2.Open();
                SqlDataReader dr1 = cmd2.ExecuteReader();

                if (dr1.Read())
                {
                    //record found
                    found1 = true;
                    if ((string)dr1["ADM_POSITION"] == "High-Level Admin")
                    {
                        btnAdd.Visible = true;
                    }
                    else
                    {
                        btnAdd.Visible = false;
                    }
                }

                dr1.Close();
                con2.Close();
                if (!found1)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else if (Session["V_id"] != null || Request.Cookies["V_id"] != null)
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
                    lblDepartment.Text = (string)dr[1];
                }

                dr.Close();
                con.Close();
                if (!found)
                {
                    Response.Redirect("departmentDetails.aspx");
                }

                string DEPARTMENT = lblDepartment.Text;

                string sql1 = "SELECT * FROM UICS WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con1.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd1);

                DataTable dtDepartmentStaff = new DataTable();
                sda.Fill(dtDepartmentStaff);
                rptDepartmentStaff.DataSource = dtDepartmentStaff;
                rptDepartmentStaff.DataBind();

                con1.Close();

                btnAdd.Visible = false;
            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("departmentDetails.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("unitsInChargeRegistration.aspx");
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
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
                    lblDepartment.Text = (string)dr[1];
                }

                dr.Close();
                con.Close();
                if (!found)
                {
                    Response.Redirect("departmentDetails.aspx");
                }

                string DEPARTMENT = lblDepartment.Text;

                string sql1 = "SELECT * FROM UICS WHERE DEPARTMENT = @DEPARTMENT";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

                con1.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd1);

                DataTable dtDepartmentStaff = new DataTable();
                sda.Fill(dtDepartmentStaff);
                rptDepartmentStaff.DataSource = dtDepartmentStaff;
                rptDepartmentStaff.DataBind();

                con1.Close();

                string ADM_ID = Session["A_id"].ToString();

                bool found1 = false;

                //retrieve id from URL (get method)

                string sql2 = "SELECT * FROM ADMIN WHERE ADM_ID = @ADM_ID";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                cmd2.Parameters.AddWithValue("ADM_ID", ADM_ID);

                con2.Open();
                SqlDataReader dr1 = cmd2.ExecuteReader();

                if (dr1.Read())
                {
                    //record found
                    found1 = true;
                    if ((string)dr1["ADM_POSITION"] == "High-Level Admin")
                    {
                        btnAdd.Visible = true;
                    }
                    else
                    {
                        btnAdd.Visible = false;
                    }
                }

                dr1.Close();
                con2.Close();
                if (!found1)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Session["A_id"] != null)
            {
                string UICS_ID = txtSearch.Text;
                string UICS_NAME = txtSearch.Text;
                string DEPARTMENT = lblDepartment.Text;

                string sql = "SELECT * FROM UICS WHERE UICS_ID = @UICS_ID OR UICS_NAME = @UICS_NAME AND DEPARTMENT = @DEPARTMENT";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@UICS_ID", UICS_ID);
                cmd.Parameters.AddWithValue("@UICS_NAME", UICS_NAME);
                cmd.Parameters.AddWithValue("@DEPARTMENT", DEPARTMENT);

                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtDepartmentStaff = new DataTable();
                sda.Fill(dtDepartmentStaff);
                rptDepartmentStaff.DataSource = dtDepartmentStaff;
                rptDepartmentStaff.DataBind();
            }
        }
    }
}