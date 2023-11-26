using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace OneStopFraudReportingSystem
{
    public partial class addReport : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM FRAUD_CASES", con);

                //table name
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                ddlCategory.DataTextField = ds.Tables[0].Columns["CASES_NAME"].ToString();
                ddlCategory.DataValueField = ds.Tables[0].Columns["CASES_NAME"].ToString();

                ddlCategory.DataSource = ds.Tables[0];
                ddlCategory.DataBind();
            }

            lblSenderPhone.Visible = false;
            txtSenderPhone.Visible = false;

            lblReceivedDate.Visible = false;
            txtReceivedDate.Visible = false;

            if (Session["V_id"] != null)
            {
                lblSDate.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");

                string sql = "SELECT COUNT(*) FROM CASES_REPORT";
  
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
       
                int count = (int)cmd.ExecuteScalar() + 1;

                string REPORT_ID = "R00" + Convert.ToString(count);

                con.Close();

                txtReportID.Text = REPORT_ID;

                //fetch session data
                string id = Session["V_id"].ToString();

                bool found = false;

                string sql1 = "SELECT * FROM VICTIM WHERE VICTIM_ID = @id";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("id", id);

                con1.Open();
                SqlDataReader dr = cmd1.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    txtVname.Text = (string)dr[1];
                    txtVEmail.Text = (string)dr[5];
                }

                dr.Close();
                con1.Close();

                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else if (Request.Cookies["V_id"] != null)
            {
                lblSDate.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");

                string sql = "SELECT COUNT(*) FROM CASES_REPORT";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();

                int count = (int)cmd.ExecuteScalar() + 1;

                string REPORT_ID = "R00" + Convert.ToString(count);

                con.Close();

                txtReportID.Text = REPORT_ID;

                //fetch session data
                string id = Request.Cookies["V_id"].Value;

                bool found = false;

                string sql1 = "SELECT * FROM VICTIM WHERE VICTIM_ID = @id";

                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                cmd1.Parameters.AddWithValue("id", id);

                con1.Open();
                SqlDataReader dr = cmd1.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    txtVname.Text = (string)dr[1];
                    txtVEmail.Text = (string)dr[5];
                }

                dr.Close();
                con1.Close();

                if (!found)
                {
                    Response.Redirect("loginPending.aspx");
                }
            }
            else
            {
                Response.Write("<script> alert('Please LOGIN to your account!');</script>");
                Server.Transfer("loginPending.aspx");
            }
        }

        /*protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string VICTIM_ID;
            if (Page.IsValid)
            {
               string REPORT_ID = txtReportID.Text;
               string REPORT_DATETIME = lblSDate.Text;
               string REPORT_CATEGORY = ddlCategory.Text;
               string REPORT_DETAILS = txtRDetails.Text;

               if (Request.Cookies["V_id"] != null)
               {
                    VICTIM_ID = Request.Cookies["V_id"].Value;
               }
               else
               {
                    VICTIM_ID = Session["V_id"].ToString();
               }

               string sql = "INSERT INTO CASES_REPORT (REPORT_ID, REPORT_DATETIME, REPORT_CATEGORY, REPORT_DETAILS, VICTIM_ID) VALUES (@REPORT_ID, @REPORT_DATETIME, @REPORT_CATEGORY, @REPORT_DETAILS, @VICTIM_ID)";

               SqlConnection con = new SqlConnection(cs);
               SqlCommand cmd = new SqlCommand(sql, con);

               cmd.Parameters.AddWithValue("@REPORT_ID", REPORT_ID);
               cmd.Parameters.AddWithValue("@REPORT_DATETIME", REPORT_DATETIME);
               cmd.Parameters.AddWithValue("@REPORT_CATEGORY", REPORT_CATEGORY);
               cmd.Parameters.AddWithValue("@REPORT_DETAILS", REPORT_DETAILS);
               cmd.Parameters.AddWithValue("@VICTIM_ID", VICTIM_ID);

               con.Open();

               cmd.ExecuteNonQuery();

               con.Close();

               Response.Write("<script> alert('Report Made Successful ! Proceed To Upload Evidence !');</script>");
               Server.Transfer("casesReportDetails.aspx");
                
                
            }
        }*/

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string VICTIM_ID;

            string sql = "SELECT COUNT(*) FROM CASES_EVIDENCE";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();

            int count = (int)cmd.ExecuteScalar() + 1;

            string EVIDENCE_ID = "E00" + Convert.ToString(count);

            con.Close();

            if(fileEvidence.HasFiles && ddlCategory.SelectedValue == "Debit and Credit Card Fraud")
            {
                foreach(HttpPostedFile fu in fileEvidence.PostedFiles)
                {
                    string REPORT_ID = txtReportID.Text;
                    string REPORT_DATETIME = lblSDate.Text;
                    string REPORT_CATEGORY = ddlCategory.SelectedValue;
                    string BANK_NAME = txtBankName.Text;
                    string CARD_NUMBER = txtCardNumber.Text;
                    string OCCURRED_DATE = txtOccurredDate.Text;
                    string REPORT_DETAILS = txtRDetails.Text;
                    if (Request.Cookies["V_id"] != null)
                    {
                        VICTIM_ID = Request.Cookies["V_id"].Value;
                    }
                    else
                    {
                        VICTIM_ID = Session["V_id"].ToString();
                    }
                    string DEPARTMENT = "Bank Negara Malaysia (BNM)";

                    string VICTIM_NAME = txtVname.Text;
                    string VICTIM_EMAIL = txtVEmail.Text;

                    string sql1 = "INSERT INTO CASES_REPORT (REPORT_ID, REPORT_DATETIME, REPORT_CATEGORY, BANK_NAME, CARD_NUMBER, OCCURRED_DATE, VICTIM_ID, DEPARTMENT, VICTIM_NAME, VICTIM_EMAIL, REPORT_DETAILS) VALUES (@REPORT_ID, @REPORT_DATETIME, @REPORT_CATEGORY, @BANK_NAME, @CARD_NUMBER, @OCCURRED_DATE, @VICTIM_ID, @DEPARTMENT, @VICTIM_NAME, @VICTIM_EMAIL, @REPORT_DETAILS)";
                    string sql2 = "INSERT INTO CASES_EVIDENCE (EVIDENCE_ID, REPORT_ID, EVIDENCE) VALUES (@EVIDENCE_ID, @REPORT_ID, @EVIDENCE)";
                
                    SqlConnection con1 = new SqlConnection(cs);
                    SqlCommand cmd1 = new SqlCommand(sql1, con1);

                    cmd1.Parameters.AddWithValue("@REPORT_ID", REPORT_ID);
                    cmd1.Parameters.AddWithValue("@REPORT_DATETIME", REPORT_DATETIME);
                    cmd1.Parameters.AddWithValue("@REPORT_CATEGORY", REPORT_CATEGORY);
                    cmd1.Parameters.AddWithValue("@BANK_NAME", BANK_NAME);
                    cmd1.Parameters.AddWithValue("@CARD_NUMBER", CARD_NUMBER);
                    cmd1.Parameters.AddWithValue("@OCCURRED_DATE", OCCURRED_DATE);
                    cmd1.Parameters.AddWithValue("@REPORT_DETAILS", REPORT_DETAILS);
                    cmd1.Parameters.AddWithValue("@VICTIM_ID", VICTIM_ID);
                    cmd1.Parameters.AddWithValue("@DEPARTMENT", DEPARTMENT);
                    cmd1.Parameters.AddWithValue("@VICTIM_NAME", VICTIM_NAME);
                    cmd1.Parameters.AddWithValue("@VICTIM_EMAIL", VICTIM_EMAIL);
                    
                    con1.Open();

                    cmd1.ExecuteNonQuery();

                    con1.Close();

                    SqlConnection con2 = new SqlConnection(cs);
                    SqlCommand cmd2 = new SqlCommand(sql2, con2);

                    con2.Open();

                    string path = "CasesEvidence/" + fu.FileName;
                    cmd2.Parameters.AddWithValue("@EVIDENCE_ID", EVIDENCE_ID);
                    cmd2.Parameters.AddWithValue("@REPORT_ID", REPORT_ID);
                    cmd2.Parameters.AddWithValue("@EVIDENCE", path);

                    if(cmd2.ExecuteNonQuery() > 0)
                    {
                        fileEvidence.SaveAs(Path.Combine(Server.MapPath("/CasesEvidence/"), fu.FileName));
                        Response.Write("<script> alert('Report Made Successful !'); window.location= 'userDashboard.aspx';</script>");
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<div style='font-size: 18px; border: 3px solid black'>");
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td align='center' style='background-color:#18B5F0' colspan='2'><b>Cases Report</b></td></tr>");
                    sb.Append("<tr><td colspan='2'></td></tr>");
                    sb.Append("<tr><td> <b>Report ID: </b>");
                    sb.Append(txtReportID.Text);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Date: </b>");
                    sb.Append(lblSDate.Text);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Name: </b>");
                    sb.Append(txtVname.Text);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Email: </b>");
                    sb.Append(txtVEmail.Text);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Category: </b>");
                    sb.Append(ddlCategory.SelectedValue);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Bank Name: </b>");
                    sb.Append(txtBankName.Text);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Card Number: </b>");
                    sb.Append(txtCardNumber.Text);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Cases Occurred Date: </b>");
                    sb.Append(txtOccurredDate.Text);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Report Details: </b>");
                    sb.Append(txtRDetails.Text);
                    sb.Append("</td></tr>");
                    sb.Append("</table>");
                    sb.Append("</div>");

                    MailMessage msg = new MailMessage();
                    //company
                    string VICTIM_EMAIL1;
                    if (Request.Cookies["V_id"] != null)
                    {
                        VICTIM_EMAIL1 = Request.Cookies["V_email"].Value;
                    }
                    else
                    {
                        VICTIM_EMAIL1 = Session["V_email"].ToString();
                    }

                    msg.From = new MailAddress("jeffreyjtwj@gmail.com");
                    //victim email
                    msg.To.Add(VICTIM_EMAIL1);
                    msg.Subject = "CASES REPORT " + txtReportID.Text;
                    msg.Body = sb.ToString() + "<br/><br/><h3>Here is your reporting details, please wait for the investigation progress !</h3>";
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
                }
                
            }
            else if(fileEvidence.HasFiles && ddlCategory.SelectedValue == "Phone Message Fraud")
            {
                foreach (HttpPostedFile fu in fileEvidence.PostedFiles)
                {
                    string REPORT_ID = txtReportID.Text;
                    string REPORT_DATETIME = lblSDate.Text;
                    string REPORT_CATEGORY = ddlCategory.SelectedValue;
                    string SENDER_PHONE = txtSenderPhone.Text;
                    string RECEIVED_DATE = txtReceivedDate.Text;
                    string OCCURRED_DATE = txtOccurredDate.Text;
                    string REPORT_DETAILS = txtRDetails.Text;
                    if (Request.Cookies["V_id"] != null)
                    {
                        VICTIM_ID = Request.Cookies["V_id"].Value;
                    }
                    else
                    {
                        VICTIM_ID = Session["V_id"].ToString();
                    }
                    string DEPARTMENT = "Malaysian Communication and Multimedia Commission (MCMC)";

                    string VICTIM_NAME = txtVname.Text;
                    string VICTIM_EMAIL = txtVEmail.Text;

                    string sql1 = "INSERT INTO CASES_REPORT (REPORT_ID, REPORT_DATETIME, REPORT_CATEGORY, SENDER_PHONE, RECEIVED_DATE, OCCURRED_DATE, VICTIM_ID, DEPARTMENT, VICTIM_NAME, VICTIM_EMAIL, REPORT_DETAILS) VALUES (@REPORT_ID, @REPORT_DATETIME, @REPORT_CATEGORY, @SENDER_PHONE, @RECEIVED_DATE, @OCCURRED_DATE, @VICTIM_ID, @DEPARTMENT, @VICTIM_NAME, @VICTIM_EMAIL, @REPORT_DETAILS)";
                    string sql2 = "INSERT INTO CASES_EVIDENCE (EVIDENCE_ID, REPORT_ID, EVIDENCE) VALUES (@EVIDENCE_ID, @REPORT_ID, @EVIDENCE)";

                    SqlConnection con1 = new SqlConnection(cs);
                    SqlCommand cmd1 = new SqlCommand(sql1, con1);

                    cmd1.Parameters.AddWithValue("@REPORT_ID", REPORT_ID);
                    cmd1.Parameters.AddWithValue("@REPORT_DATETIME", REPORT_DATETIME);
                    cmd1.Parameters.AddWithValue("@REPORT_CATEGORY", REPORT_CATEGORY);
                    cmd1.Parameters.AddWithValue("@SENDER_PHONE", SENDER_PHONE);
                    cmd1.Parameters.AddWithValue("@RECEIVED_DATE", RECEIVED_DATE);
                    cmd1.Parameters.AddWithValue("@OCCURRED_DATE", OCCURRED_DATE);
                    cmd1.Parameters.AddWithValue("@REPORT_DETAILS", REPORT_DETAILS);
                    cmd1.Parameters.AddWithValue("@VICTIM_ID", VICTIM_ID);
                    cmd1.Parameters.AddWithValue("@DEPARTMENT", DEPARTMENT);
                    cmd1.Parameters.AddWithValue("@VICTIM_NAME", VICTIM_NAME);
                    cmd1.Parameters.AddWithValue("@VICTIM_EMAIL", VICTIM_EMAIL);

                    con1.Open();

                    cmd1.ExecuteNonQuery();

                    con1.Close();

                    SqlConnection con2 = new SqlConnection(cs);
                    SqlCommand cmd2 = new SqlCommand(sql2, con2);

                    con2.Open();

                    string path = "CasesEvidence/" + fu.FileName;
                    cmd2.Parameters.AddWithValue("@EVIDENCE_ID", EVIDENCE_ID);
                    cmd2.Parameters.AddWithValue("@REPORT_ID", REPORT_ID);
                    cmd2.Parameters.AddWithValue("@EVIDENCE", path);

                    if (cmd2.ExecuteNonQuery() > 0)
                    {
                        fileEvidence.SaveAs(Path.Combine(Server.MapPath("/CasesEvidence/"), fu.FileName));
                        Response.Write("<script> alert('Report Made Successful !'); window.location= 'userDashboard.aspx';</script>");
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<div style='font-size: 18px; border: 3px solid black'>");
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td align='center' style='background-color:#18B5F0' colspan='2'><b>Cases Report</b></td></tr>");
                    sb.Append("<tr><td colspan='2'></td></tr>");
                    sb.Append("<tr><td> <b>Report ID: </b>");
                    sb.Append(txtReportID.Text);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Date: </b>");
                    sb.Append(lblSDate.Text);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Name: </b>");
                    sb.Append(txtVname.Text);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Email: </b>");
                    sb.Append(txtVEmail.Text);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Category: </b>");
                    sb.Append(ddlCategory.SelectedValue);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Sender Phone: </b>");
                    sb.Append(txtSenderPhone.Text);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Received Date: </b>");
                    sb.Append(txtReceivedDate.Text);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Cases Occurred Date: </b>");
                    sb.Append(txtOccurredDate.Text);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan='2'><b>Report Details: </b>");
                    sb.Append(txtRDetails.Text);
                    sb.Append("</td></tr>");
                    sb.Append("</table>");
                    sb.Append("</div>");

                    MailMessage msg = new MailMessage();
                    //company
                    string VICTIM_EMAIL1;
                    if (Request.Cookies["V_id"] != null)
                    {
                        VICTIM_EMAIL1 = Request.Cookies["V_email"].Value;
                    }
                    else
                    {
                        VICTIM_EMAIL1 = Session["V_email"].ToString();
                    }

                    msg.From = new MailAddress("jeffreyjtwj@gmail.com");
                    //victim email
                    msg.To.Add(VICTIM_EMAIL1);
                    msg.Subject = "CASES REPORT " + txtReportID.Text;
                    msg.Body = sb.ToString() + "<br/><br/><h3>Here is your reporting details, please wait for the investigation progress !</h3>";
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
                }
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Server.Transfer("addReport.aspx");
        }

        protected void ddlCategory_Changed(object sender, EventArgs e)
        {
            if(ddlCategory.SelectedValue == "Debit and Credit Card Fraud")
            {
                lblBankName.Visible = true;
                txtBankName.Visible = true;
                lblSenderPhone.Visible = false;
                txtSenderPhone.Visible = false;
                lblCardNumber.Visible = true;
                txtCardNumber.Visible = true;
                lblReceivedDate.Visible = false;
                txtReceivedDate.Visible = false;
                lblOccurredDate.Visible = true;
                txtOccurredDate.Visible = true;
            }
            else if(ddlCategory.SelectedValue == "Phone Message Fraud")
            {
                lblBankName.Visible = false;
                txtBankName.Visible = false;
                lblSenderPhone.Visible = true;
                txtSenderPhone.Visible = true;
                lblCardNumber.Visible = false;
                txtCardNumber.Visible = false;
                lblReceivedDate.Visible = true;
                txtReceivedDate.Visible = true;
                lblOccurredDate.Visible = true;
                txtOccurredDate.Visible = true;
            }

        }
    }
}