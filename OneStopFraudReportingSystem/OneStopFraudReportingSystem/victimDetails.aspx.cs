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
    public partial class victimDetails : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["A_id"] != null || Request.Cookies["A_id"] != null)
            {
                string sql = "SELECT * FROM VICTIM";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dtVictim = new DataTable();
                sda.Fill(dtVictim);
                rptVictim.DataSource = dtVictim;
                rptVictim.DataBind();
                con.Close();

                string sql1 = "SELECT * FROM VICTIM";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                con1.Open();

                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);

                DataTable dtViewVictim = new DataTable();
                sda1.Fill(dtViewVictim);
                rptViewVictim.DataSource = dtViewVictim;
                rptViewVictim.DataBind();
                con1.Close();

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
                        rptViewVictim.Visible = true;
                        rptVictim.Visible = false;
                    }
                    else
                    {
                        rptViewVictim.Visible = false;
                        rptVictim.Visible = true;
                    }
                }
                dr.Close();
                con2.Close();

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

        protected void btnSearch_Click(object sender, EventArgs e)
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
                    rptViewVictim.Visible = true;
                    rptVictim.Visible = false;
                }
                else
                {
                    rptViewVictim.Visible = false;
                    rptVictim.Visible = true;
                }
            }
            dr.Close();
            con.Close();

            if (!found)
            {
                Response.Redirect("loginPending.aspx");
            }

            string VICTIM_ID = txtSearch.Text;
            string VICTIM_NAME = txtSearch.Text;

            string sql1 = "SELECT * FROM VICTIM WHERE VICTIM_ID = @VICTIM_ID OR VICTIM_NAME = @VICTIM_NAME";

            SqlConnection con1 = new SqlConnection(cs);
            SqlCommand cmd1 = new SqlCommand(sql1, con1);

            cmd1.Parameters.AddWithValue("VICTIM_ID", VICTIM_ID);
            cmd1.Parameters.AddWithValue("VICTIM_NAME", VICTIM_NAME);

            con1.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd1);

            DataTable dtVictim = new DataTable();
            sda.Fill(dtVictim);
            rptVictim.DataSource = dtVictim;
            rptVictim.DataBind();
            con1.Close();

            string sql2 = "SELECT * FROM VICTIM WHERE VICTIM_ID = @VICTIM_ID OR VICTIM_NAME = @VICTIM_NAME";

            SqlConnection con2 = new SqlConnection(cs);
            SqlCommand cmd2 = new SqlCommand(sql2, con2);

            cmd2.Parameters.AddWithValue("VICTIM_ID", VICTIM_ID);
            cmd2.Parameters.AddWithValue("VICTIM_NAME", VICTIM_NAME);

            con2.Open();

            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);

            DataTable dtViewVictim = new DataTable();
            sda1.Fill(dtViewVictim);
            rptViewVictim.DataSource = dtViewVictim;
            rptViewVictim.DataBind();
            con2.Close();
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
                    rptViewVictim.Visible = true;
                    rptVictim.Visible = false;
                }
                else
                {
                    rptViewVictim.Visible = false;
                    rptVictim.Visible = true;
                }
            }
            dr.Close();
            con.Close();

            if (!found)
            {
                Response.Redirect("loginPending.aspx");
            }

            string sql1 = "SELECT * FROM VICTIM";

            SqlConnection con1 = new SqlConnection(cs);
            SqlCommand cmd1 = new SqlCommand(sql1, con1);

            con1.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd1);

            DataTable dtVictim = new DataTable();
            sda.Fill(dtVictim);
            rptVictim.DataSource = dtVictim;
            rptVictim.DataBind();
            con1.Close();

            string sql2 = "SELECT * FROM VICTIM";

            SqlConnection con2 = new SqlConnection(cs);
            SqlCommand cmd2 = new SqlCommand(sql2, con2);

            con2.Open();

            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);

            DataTable dtViewVictim = new DataTable();
            sda1.Fill(dtViewVictim);
            rptViewVictim.DataSource = dtViewVictim;
            rptViewVictim.DataBind();
            con2.Close();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminDashboard.aspx");
        }
    }
}