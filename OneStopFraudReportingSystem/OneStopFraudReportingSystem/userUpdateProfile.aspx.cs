using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace OneStopFraudReportingSystem
{
    public partial class userUpdateProfile : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Cookies["V_id"] != null)
                {
                    string id = Request.Cookies["V_id"].Value;

                    bool found = false;

                    //retrieve Id from URL(get method)

                    string sql = "SELECT * FROM VICTIM WHERE VICTIM_ID = @id";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                    {
                        //record found
                        found = true;
                        txtVID.Text = (string)dr[0];
                        txtName.Text = (string)dr[1];
                        txtUsername.Text = (string)dr[2];
                        txtIcNo.Text = (string)dr[3];
                        txtGender.Text = (string)dr[4];
                        txtEmail.Text = (string)dr[5];
                        txtPhone.Text = (string)dr[6];
                        txtAddress.Text = (string)dr[8];
                    }

                    dr.Close();
                    con.Close();
                    if (!found)
                    {
                        Response.Redirect("loginPending.aspx");
                    }
                }
                else if (Session["V_id"] != null)
                {
                    string id = Session["V_id"].ToString();

                    bool found = false;

                    //retrieve Id from URL (get method)

                    string sql = "SELECT * FROM VICTIM WHERE VICTIM_ID = @id";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        //record found 
                        found = true;
                        txtVID.Text = (string)dr[0];
                        txtName.Text = (string)dr[1];
                        txtUsername.Text = (string)dr[2];
                        txtIcNo.Text = (string)dr[3];
                        txtGender.Text = (string)dr[4];
                        txtEmail.Text = (string)dr[5];
                        txtPhone.Text = (string)dr[6];
                        txtAddress.Text = (string)dr[8];
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

                string VICTIM_NAME = txtName.Text;
                string VICTIM_USERNAME = txtUsername.Text;
                string VICTIM_IC = txtIcNo.Text;
                string VICTIM_GENDER = txtGender.Text;
                string VICTIM_EMAIL = txtEmail.Text;
                string VICTIM_PHONE = txtPhone.Text;
                string VICTIM_ADDRESS = txtAddress.Text;
                string VICTIM_ID = txtVID.Text;

                string sql = "UPDATE VICTIM SET VICTIM_NAME = @VICTIM_NAME, VICTIM_USERNAME = @VICTIM_USERNAME, VICTIM_IC = @VICTIM_IC, VICTIM_GENDER = @VICTIM_GENDER, VICTIM_EMAIL = @VICTIM_EMAIL, VICTIM_PHONE = @VICTIM_PHONE, VICTIM_ADDRESS = @VICTIM_ADDRESS WHERE VICTIM_ID = @VICTIM_ID";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@VICTIM_NAME", VICTIM_NAME);
                cmd.Parameters.AddWithValue("@VICTIM_USERNAME", VICTIM_USERNAME);
                cmd.Parameters.AddWithValue("@VICTIM_IC", VICTIM_IC);
                cmd.Parameters.AddWithValue("@VICTIM_GENDER", VICTIM_GENDER);
                cmd.Parameters.AddWithValue("@VICTIM_EMAIL", VICTIM_EMAIL);
                cmd.Parameters.AddWithValue("@VICTIM_PHONE", VICTIM_PHONE);
                cmd.Parameters.AddWithValue("@VICTIM_ADDRESS", VICTIM_ADDRESS);
                cmd.Parameters.AddWithValue("@VICTIM_ID", VICTIM_ID);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script> alert('Update Successful !');  window.location= 'userProfile.aspx'; </script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }
    }
}