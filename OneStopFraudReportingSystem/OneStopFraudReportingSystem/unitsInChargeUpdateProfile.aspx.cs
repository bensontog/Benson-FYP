using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace OneStopFraudReportingSystem
{
    public partial class unitsInChargeUpdateProfile : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Cookies["U_id"] != null)
                {
                    string id = Request.Cookies["U_id"].Value;

                    bool found = false;

                    //retrieve Id from URL (get method)

                    string sql = "SELECT * FROM UICS WHERE UICS_ID = @id";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        //record found
                        found = true;
                        txtUID.Text = (string)dr[0];
                        txtName.Text = (string)dr[1];
                        txtUsername.Text = (string)dr[2];
                        txtIcNo.Text = (string)dr[3];
                        txtGender.Text = (string)dr[4];
                        txtEmail.Text = (string)dr[5];
                        txtPhone.Text = (string)dr[6];
                        txtDepartment.Text = (string)dr[8];
                        txtAddress.Text = (string)dr[9];
                    }

                    dr.Close();
                    con.Close();
                    if (!found)
                    {
                        Response.Redirect("loginPending.aspx");
                    }
                }
                else if (Session["U_id"] != null)
                {
                    string id = Session["U_id"].ToString();

                    bool found = false;

                    //retrieve Id from URL (get method)

                    string sql = "SELECT * FROM UICS WHERE UICS_ID = @id";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                    {
                        //record found
                        found = true;
                        txtUID.Text = (string)dr[0];
                        txtName.Text = (string)dr[1];
                        txtUsername.Text = (string)dr[2];
                        txtIcNo.Text = (string)dr[3];
                        txtGender.Text = (string)dr[4];
                        txtEmail.Text = (string)dr[5];
                        txtPhone.Text = (string)dr[6];
                        txtDepartment.Text = (string)dr[8];
                        txtPosition.Text = (string)dr[9];
                        txtAddress.Text = (string)dr[10];
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
                    Response.Redirect("loginPending.aspx");
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //server control event

            string UICS_NAME = txtName.Text;
            string UICS_USERNAME = txtUsername.Text;
            string UICS_IC = txtIcNo.Text;
            string UICS_GENDER = txtGender.Text;
            string UICS_EMAIL = txtEmail.Text;
            string UICS_PHONE = txtPhone.Text;
            string UICS_DEPARTMENT = txtDepartment.Text;
            string UICS_ADDRESS = txtAddress.Text;
            string UICS_ID = txtUID.Text;

            string sql = "UPDATE UICS SET UICS_NAME = @UICS_NAME, UICS_USERNAME = @UICS_USERNAME, UICS_IC = @UICS_IC, UICS_GENDER = @UICS_GENDER, UICS_EMAIL = @UICS_EMAIL, UICS_PHONE = @UICS_PHONE, UICS_ADDRESS = @UICS_ADDRESS WHERE UICS_ID = @UICS_ID";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@UICS_NAME", UICS_NAME);
            cmd.Parameters.AddWithValue("@UICS_USERNAME", UICS_USERNAME);
            cmd.Parameters.AddWithValue("@UICS_IC", UICS_IC);
            cmd.Parameters.AddWithValue("@UICS_GENDER", UICS_GENDER);
            cmd.Parameters.AddWithValue("@UICS_EMAIL", UICS_EMAIL);
            cmd.Parameters.AddWithValue("@UICS_PHONE", UICS_PHONE);
            cmd.Parameters.AddWithValue("@UICS_DEPARTMENT", UICS_DEPARTMENT);
            cmd.Parameters.AddWithValue("@UICS_ADDRESS", UICS_ADDRESS);
            cmd.Parameters.AddWithValue("@UICS_ID", UICS_ID);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            Response.Write("<script> alert('Update Successful !');  window.location= 'unitsInChargeProfile.aspx'; </script>");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("unitsInChargeProfile.aspx");
        }
    }
}