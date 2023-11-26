using System;
using System.Data;
using System.Data.SqlClient;

namespace OneStopFraudReportingSystem
{
    public partial class adminDetails : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["A_id"] != null)
            {
                string sql = "SELECT * FROM ADMIN";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtAdmin = new DataTable();
                sda.Fill(dtAdmin);
                rptAdmin.DataSource = dtAdmin;
                rptAdmin.DataBind();
                con.Close();

                string sql2 = "SELECT * FROM ADMIN";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                con2.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);

                DataTable dtViewAdmin = new DataTable();
                sda1.Fill(dtViewAdmin);
                rptViewAdmin.DataSource = dtViewAdmin;
                rptViewAdmin.DataBind();
                con.Close();

                //add admin
                string id = Request.Cookies["A_id"].Value;

                bool found = false;

                string sql1 = "SELECT * FROM ADMIN WHERE ADM_ID = @id";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("id", id);

                con1.Open();

                SqlDataReader dr = cmd1.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    if ((string)dr["ADM_POSITION"] == "High-Level Admin")
                    {
                        btnAdd.Visible = true;
                        rptViewAdmin.Visible = true;
                        rptAdmin.Visible = false;
                    }
                    else
                    {
                        btnAdd.Visible = false;
                        rptViewAdmin.Visible = false;
                        rptAdmin.Visible = true;
                    }
                }

                dr.Close();
                con1.Close();

                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else if (Session["A_id"] != null)
            {
                string sql = "SELECT * FROM ADMIN";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtAdmin = new DataTable();
                sda.Fill(dtAdmin);
                rptAdmin.DataSource = dtAdmin;
                rptAdmin.DataBind();
                con.Close();

                string sql2 = "SELECT * FROM ADMIN";

                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2 = new SqlCommand(sql2, con2);

                con2.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);

                DataTable dtViewAdmin = new DataTable();
                sda1.Fill(dtViewAdmin);
                rptViewAdmin.DataSource = dtViewAdmin;
                rptViewAdmin.DataBind();
                con.Close();

                //add admin
                string id = Session["A_id"].ToString();

                bool found = false;

                string sql1 = "SELECT * FROM ADMIN WHERE ADM_ID = @id";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("id", id);

                con1.Open();

                SqlDataReader dr = cmd1.ExecuteReader();

                if(dr.Read())
                {
                    //record found
                    found = true;
                    if ((string)dr["ADM_POSITION"] == "High-Level Admin")
                    {
                        btnAdd.Visible = true;
                        rptViewAdmin.Visible = true;
                        rptAdmin.Visible = false;
                    }
                    else
                    {
                        btnAdd.Visible = false;
                        rptViewAdmin.Visible = false;
                        rptAdmin.Visible = true;
                    }
                }

                dr.Close();
                con1.Close();

                if(!found)
                {
                    Response.Redirect("loginPending.aspx");
                }

            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminRegistration.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)//need correction
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
                if ((string)dr["ADM_POSITION"] == "High-Level Admin")
                {
                    rptViewAdmin.Visible = true;
                    rptAdmin.Visible = false;
                }
                else
                {
                    rptViewAdmin.Visible = false;
                    rptAdmin.Visible = true;
                }
            }
            dr.Close();
            con.Close();

            if (!found)
            {
                Response.Redirect("loginPending.aspx");
            }

            string ADM_ID = txtSearch.Text;
            string ADM_NAME = txtSearch.Text;
            string ADM_POSITION = txtSearch.Text;

            string sql1 = "SELECT * FROM ADMIN WHERE ADM_ID = @ADM_ID OR ADM_NAME = @ADM_NAME OR ADM_POSITION = @ADM_POSITION";

            SqlConnection con1 = new SqlConnection(cs);
            SqlCommand cmd1 = new SqlCommand(sql1, con1);

            cmd1.Parameters.AddWithValue("@ADM_ID", ADM_ID);
            cmd1.Parameters.AddWithValue("@ADM_NAME", ADM_NAME);
            cmd1.Parameters.AddWithValue("@ADM_POSITION", ADM_POSITION);

            con1.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd1);

            DataTable dtAdmin = new DataTable();
            sda.Fill(dtAdmin);
            rptAdmin.DataSource = dtAdmin;
            rptAdmin.DataBind();
            con.Close();

            string sql2 = "SELECT * FROM ADMIN WHERE ADM_ID = @ADM_ID OR ADM_NAME = @ADM_NAME OR ADM_POSITION = @ADM_POSITION";

            SqlConnection con2 = new SqlConnection(cs);
            SqlCommand cmd2 = new SqlCommand(sql2, con2);

            cmd2.Parameters.AddWithValue("@ADM_ID", ADM_ID);
            cmd2.Parameters.AddWithValue("@ADM_NAME", ADM_NAME);
            cmd2.Parameters.AddWithValue("@ADM_POSITION", ADM_POSITION);

            con2.Open();

            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);

            DataTable dtViewAdmin = new DataTable();
            sda1.Fill(dtViewAdmin);
            rptViewAdmin.DataSource = dtViewAdmin;
            rptViewAdmin.DataBind();
            con.Close();


        }

        protected void btnViewAll_Click(object sender, EventArgs e)
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
                if ((string)dr["ADM_POSITION"] == "High-Level Admin")
                {
                    rptViewAdmin.Visible = true;
                    rptAdmin.Visible = false;
                }
                else
                {
                    rptViewAdmin.Visible = false;
                    rptAdmin.Visible = true;
                }
            }
            dr.Close();
            con.Close();

            if (!found)
            {
                Response.Redirect("loginPending.aspx");
            }

            string sql1 = "SELECT * FROM ADMIN";

            SqlConnection con1 = new SqlConnection(cs);
            SqlCommand cmd1 = new SqlCommand(sql1, con1);

            con1.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd1);

            DataTable dtAdmin = new DataTable();
            sda.Fill(dtAdmin);
            rptAdmin.DataSource = dtAdmin;
            rptAdmin.DataBind();
            con.Close();

            string sql2 = "SELECT * FROM ADMIN";

            SqlConnection con2 = new SqlConnection(cs);
            SqlCommand cmd2 = new SqlCommand(sql2, con2);

            con2.Open();

            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);

            DataTable dtViewAdmin = new DataTable();
            sda1.Fill(dtViewAdmin);
            rptViewAdmin.DataSource = dtViewAdmin;
            rptViewAdmin.DataBind();
            con.Close();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminDashboard.aspx");
        }
    }
}