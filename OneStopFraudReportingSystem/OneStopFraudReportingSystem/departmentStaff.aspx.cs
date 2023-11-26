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
    public partial class departmentStaff : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["U_id"] != null || Request.Cookies["U_id"] != null)
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

                //retrieve id from URL (get method)

                string sql = "SELECT * FROM UICS WHERE UICS_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    //record found
                    found = true;
                    lblDepartment.Text = (string)dr[8];
                    if ((string)dr["UICS_POSITION"] == "Department Head")
                    {
                        btnAdd.Visible = true;
                        rptViewStaff.Visible = true;
                        rptDepartmentStaff.Visible = false;
                    }
                    else
                    {
                        btnAdd.Visible = false;
                        rptViewStaff.Visible = false;
                        rptDepartmentStaff.Visible = true;
                    }

                }

                dr.Close();
                con.Close();
                if(!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

                string DEPARTMENT = lblDepartment.Text;
                
                string sql1 = "SELECT * FROM UICS WHERE DEPARTMENT = @DEPARTMENT";
                //string sql1 = "SELECT * FROM UICS";

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

                string DEPARTMENT1 = lblDepartment.Text;

                string sql2 = "SELECT * FROM UICS WHERE DEPARTMENT = @DEPARTMENT1";
                //string sql1 = "SELECT * FROM UICS";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);
                cmd2.Parameters.AddWithValue("DEPARTMENT1", DEPARTMENT1);

                con2.Open();

                SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);

                DataTable dtViewStaff = new DataTable();
                sda1.Fill(dtViewStaff);
                rptViewStaff.DataSource = dtViewStaff;
                rptViewStaff.DataBind();
                con2.Close();

            }


        }

        protected void btnSearch_Click(object sender, EventArgs e)
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
                lblDepartment.Text = (string)dr[8];
                if ((string)dr["UICS_POSITION"] == "Department Head")
                {
                    btnAdd.Visible = true;
                    rptViewStaff.Visible = true;
                    rptDepartmentStaff.Visible = false;
                }
                else
                {
                    btnAdd.Visible = false;
                    rptViewStaff.Visible = false;
                    rptDepartmentStaff.Visible = true;
                }

            }

            dr.Close();
            con.Close();
            if (!found)
            {
                Response.Redirect("loginPending.aspx");
            }

            string UICS_ID = txtSearch.Text;
            string UICS_NAME = txtSearch.Text;
            string DEPARTMENT = lblDepartment.Text;

            string sql1 = "SELECT * FROM UICS WHERE UICS_ID = @UICS_ID OR UICS_NAME = @UICS_NAME AND DEPARTMENT = @DEPARTMENT";

            SqlConnection con1 = new SqlConnection(cs);
            SqlCommand cmd1 = new SqlCommand(sql1, con1);

            cmd1.Parameters.AddWithValue("UICS_ID", UICS_ID);
            cmd1.Parameters.AddWithValue("UICS_NAME", UICS_NAME);
            cmd1.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

            con1.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd1);

            DataTable dtDepartmentStaff = new DataTable();
            sda.Fill(dtDepartmentStaff);
            rptDepartmentStaff.DataSource = dtDepartmentStaff;
            rptDepartmentStaff.DataBind();
            con1.Close();

            string sql2 = "SELECT * FROM UICS WHERE UICS_ID = @UICS_ID OR UICS_NAME = @UICS_NAME AND DEPARTMENT = @DEPARTMENT";

            SqlConnection con2 = new SqlConnection(cs);
            SqlCommand cmd2 = new SqlCommand(sql2, con2);

            cmd2.Parameters.AddWithValue("UICS_ID", UICS_ID);
            cmd2.Parameters.AddWithValue("UICS_NAME", UICS_NAME);
            cmd2.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);

            con2.Open();

            SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);

            DataTable dtViewStaff = new DataTable();
            sda1.Fill(dtViewStaff);
            rptViewStaff.DataSource = dtViewStaff;
            rptViewStaff.DataBind();
            con2.Close();
        }

        protected void btnViewAll_Click(object sender,  EventArgs e)
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
                lblDepartment.Text = (string)dr[8];
                if ((string)dr["UICS_POSITION"] == "Department Head")
                {
                    btnAdd.Visible = true;
                    rptViewStaff.Visible = true;
                    rptDepartmentStaff.Visible = false;
                }
                else
                {
                    btnAdd.Visible = false;
                    rptViewStaff.Visible = false;
                    rptDepartmentStaff.Visible = true;
                }

            }

            dr.Close();
            con.Close();
            if (!found)
            {
                Response.Redirect("loginPending.aspx");
            }

            string DEPARTMENT = lblDepartment.Text;

            string sql1 = "SELECT * FROM UICS WHERE DEPARTMENT = @DEPARTMENT";
            //string sql1 = "SELECT * FROM UICS";

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

            string DEPARTMENT1 = lblDepartment.Text;

            string sql2 = "SELECT * FROM UICS WHERE DEPARTMENT = @DEPARTMENT1";
            //string sql1 = "SELECT * FROM UICS";

            SqlConnection con2 = new SqlConnection(cs);
            SqlCommand cmd2 = new SqlCommand(sql2, con2);
            cmd2.Parameters.AddWithValue("DEPARTMENT1", DEPARTMENT1);

            con2.Open();

            SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);

            DataTable dtViewStaff = new DataTable();
            sda1.Fill(dtViewStaff);
            rptViewStaff.DataSource = dtViewStaff;
            rptViewStaff.DataBind();
            con2.Close();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("unitsInChargeRegistration.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("unitsInChargeDashboard.aspx");
        }
    }
}