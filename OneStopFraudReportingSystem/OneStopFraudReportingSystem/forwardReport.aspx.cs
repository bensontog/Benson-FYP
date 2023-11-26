using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace OneStopFraudReportingSystem
{
    public partial class forwardReport : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["U_id"] != null || Request.Cookies["U_id"] != null)
            {
                Boolean found = false;

                string id = Request.QueryString["id"];

                string sql = "SELECT * FROM CASES_REPORT WHERE REPORT_ID = @id";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("id", id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    //record found
                    found = true;
                    txtReportID.Text = (string)dr[0];
                    txtDate.Text = (string)dr[1];
                    txtCategory.Text = (string)dr[2];
                    if (dr["BANK_NAME"] == DBNull.Value)
                    {
                        lblBankName.Visible = false;
                        txtBankName.Visible = false;
                    }
                    else
                    {
                        lblBankName.Visible = true;
                        txtBankName.Visible = true;
                        txtBankName.Text = (string)dr[3];
                    }
                    if (dr["CARD_NUMBER"] == DBNull.Value)
                    {
                        lblCardNumber.Visible = false;
                        txtCardNumber.Visible = false;
                    }
                    else
                    {
                        lblCardNumber.Visible = true;
                        txtCardNumber.Visible = true;
                        txtCardNumber.Text = (string)dr[4];
                    }
                    if (dr["SENDER_PHONE"] == DBNull.Value)
                    {
                        lblSenderPhone.Visible = false;
                        txtSenderPhone.Visible = false;
                    }
                    else
                    {
                        lblSenderPhone.Visible = true;
                        txtSenderPhone.Visible = true;
                        txtSenderPhone.Text = (string)dr[5];
                    }
                    if (dr["RECEIVED_DATE"] == DBNull.Value)
                    {
                        lblReceivedDate.Visible = false;
                        txtReceivedDate.Visible = false;
                    }
                    else
                    {
                        lblReceivedDate.Visible = true;
                        txtReceivedDate.Visible = true;
                        txtReceivedDate.Text = (string)dr[6];
                    }
                    txtODate.Text = (string)dr[7];
                    if (dr["REPORT_STATUS"] == DBNull.Value)
                    {
                        lblStatus.Visible = false;
                        txtStatus.Visible = false;
                    }
                    else
                    {
                        lblStatus.Visible = true;
                        txtStatus.Visible = true;
                        txtStatus.Text = (string)dr[7];
                    }
                    if (dr["REPORT_COMMENT"] == DBNull.Value)
                    {
                        lblComment.Visible = false;
                        txtComment.Visible = false;
                    }
                    else
                    {
                        lblComment.Visible = true;
                        txtComment.Visible = true;
                        txtComment.Text = (string)dr[8];
                    }
                    txtDepartment.Text = (string)dr[11];
                    if (dr["HANDLED_BY"] == DBNull.Value)
                    {
                        lblHandledBy.Visible = false;
                        txtHandledBy.Visible = false;
                    }
                    else
                    {
                        lblHandledBy.Visible = true;
                        txtHandledBy.Visible = true;
                        txtHandledBy.Text = (string)dr[12];
                    }
                    txtVname.Text = (string)dr[13];
                    txtEmail.Text = (string)dr[14];
                    txtRDetails.Text = (string)dr[15];
                }

                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("casesReportDetails.aspx");
                }

                string DEPARTMENT = txtDepartment.Text;

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

                if (!IsPostBack)
                {
                    string DEPARTMENT1 = txtDepartment.Text;
                    SqlConnection con2 = new SqlConnection(cs);

                    con2.Open();

                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM UICS WHERE DEPARTMENT = @DEPARTMENT", con2);

                    cmd2.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT1);

                    //table name
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);
                    DataSet ds = new DataSet();
                    sda1.Fill(ds);
                    ddlStaff.DataTextField = ds.Tables[0].Columns["UICS_NAME"].ToString();
                    ddlStaff.DataValueField = ds.Tables[0].Columns["UICS_NAME"].ToString();

                    ddlStaff.DataSource = ds.Tables[0];
                    ddlStaff.DataBind();
                }

                bool found1 = false;

                string uid = Session["U_id"].ToString();

                string sql2 = "SELECT * FROM UICS WHERE UICS_ID = @uid";

                SqlConnection con3 = new SqlConnection(cs);
                SqlCommand cmd3 = new SqlCommand(sql2, con3);

                cmd3.Parameters.AddWithValue("@uid", uid);

                con3.Open();

                SqlDataReader dr2 = cmd3.ExecuteReader();

                if(dr2.Read())
                {
                    //record found
                    found1 = true;
                    if ((string)dr2["UICS_POSITION"] == "Department Staff")
                    {
                        Response.Write("<script> alert('Only Department Head can access !');</script>");
                        Server.Transfer("viewVictimReport.aspx");
                    }
                }

                dr2.Close();
                con3.Close();

                if(!found1)
                {
                    Response.Redirect("loginPending.aspx");
                }

            }
            else
            {
                Response.Redirect("loginPedning.aspx");
            }
        }

        protected void btnForward_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string HANDLED_BY = ddlStaff.SelectedValue;
            string sql = "UPDATE CASES_REPORT SET HANDLED_BY = @HANDLED_BY WHERE REPORT_ID = @id";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@HANDLED_BY", HANDLED_BY);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            MailMessage msg = new MailMessage();
            string email = txtEmail.Text;
            msg.From = new MailAddress("jeffreyjtwj@gmail.com");

            msg.To.Add(email);
            msg.Subject = "REPORT FORWARDED TO OUR STAFF";
            msg.Body = "<h3>Your cases report has been forwarded and will be in-charge by " + HANDLED_BY + "</h3>";
            msg.IsBodyHtml = true;
            SmtpClient smt = new SmtpClient();
            smt.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntwd = new NetworkCredential();

            //company
            ntwd.UserName = "jeffreyjtwj@gmail.com";
            ntwd.Password = "hrwzvkjtgyvexivu";
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;
            smt.Port = 587;
            smt.EnableSsl = true;
            smt.Send(msg);


            Response.Write("<script> alert('Forward Successful !');</script>");
            Server.Transfer("viewVictimReport.aspx");

        }
       
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewVictimReport.aspx");
        }
    }
}