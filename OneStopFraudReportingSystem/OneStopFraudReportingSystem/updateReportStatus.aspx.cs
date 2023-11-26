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
    public partial class updateReportStatus : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["U_id"] != null || Request.Cookies["U_id"] != null)
            {
                bool found = false;

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
                    Response.Redirect("viewVictimReport.aspx");
                }
            }
            else
            {
                Response.Redirect("loginPending.aspx");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string REPORT_STATUS = ddlStatus.SelectedValue;
            string REPORT_COMMENT = txtUComment.Text;
            string sql = "UPDATE CASES_REPORT SET REPORT_STATUS = @REPORT_STATUS, REPORT_COMMENT = @REPORT_COMMENT WHERE REPORT_ID = @id";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@REPORT_STATUS", REPORT_STATUS);
            cmd.Parameters.AddWithValue("@REPORT_COMMENT", REPORT_COMMENT);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            MailMessage msg = new MailMessage();
            string email = txtEmail.Text;
            msg.From = new MailAddress("jeffreyjtwj@gmail.com");

            msg.To.Add(email);
            msg.Subject = "REPORT STATUS UPDATED";
            msg.Body = "<h3>Kindly LOGIN to your account for checking the latest <b>investigation progress.</b></h3>";
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

            Response.Write("<script> alert('Update Successful !');</script>");
            Server.Transfer("viewVictimReport.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewVictimReport.aspx");
        }
    }
}