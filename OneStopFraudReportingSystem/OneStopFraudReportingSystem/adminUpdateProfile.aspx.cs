using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace OneStopFraudReportingSystem
{
    public partial class adminUpdateProfile : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Request.Cookies["A_id"] != null)
                {
                    string id = Request.Cookies["A_id"].Value;

                    bool found = false;

                    //retrieve Id from URL(get method)

                    string sql = "SELECT * FROM ADMIN WHERE ADM_ID = @id";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                    {
                        //record found
                        found = true;
                        txtAID.Text = (string)dr[0];
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
                        Response.Redirect("loginPedning.aspx");
                    }
                }
                else if (Session["A_id"] != null)
                {
                    string id = Session["A_id"].ToString();

                    bool found = false;

                    //retrieve Id from URL (get method)

                    string sql = "SELECT * FROM ADMIN WHERE ADM_ID = @id";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        //record found
                        found = true;
                        txtAID.Text = (string)dr[0];
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
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //server control event
            if(Page.IsValid)
            {
                //retrieve user input
                string ADM_NAME = txtName.Text;
                string ADM_USERNAME = txtUsername.Text;
                string ADM_IC = txtIcNo.Text;
                string ADM_GENDER = txtGender.Text;
                string ADM_EMAIL = txtEmail.Text;
                string ADM_PHONE = txtPhone.Text;
                string ADM_ADDRESS = txtAddress.Text;
                string ADM_ID = txtAID.Text;

                string sql = "UPDATE ADMIN SET ADM_NAME = @ADM_NAME, ADM_USERNAME = @ADM_USERNAME, ADM_IC = @ADM_IC, ADM_GENDER = @ADM_GENDER, ADM_EMAIL = @ADM_EMAIL, ADM_PHONE = @ADM_PHONE, ADM_ADDRESS = @ADM_ADDRESS WHERE ADM_ID = @ADM_ID";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@ADM_NAME", ADM_NAME);
                cmd.Parameters.AddWithValue("@ADM_USERNAME", ADM_USERNAME);
                cmd.Parameters.AddWithValue("@ADM_IC", ADM_IC);
                cmd.Parameters.AddWithValue("@ADM_GENDER", ADM_GENDER);
                cmd.Parameters.AddWithValue("@ADM_EMAIL", ADM_EMAIL);
                cmd.Parameters.AddWithValue("@ADM_PHONE", ADM_PHONE);
                cmd.Parameters.AddWithValue("@ADM_ADDRESS", ADM_ADDRESS);
                cmd.Parameters.AddWithValue("@ADM_ID", ADM_ID);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script> alert('Update Successful !');  window.location= 'adminProfile.aspx'; </script>");

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminProfile.aspx");
        }
    }
}