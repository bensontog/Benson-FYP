using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IronOcr;
using System.Data.SqlClient;
using Org.BouncyCastle.Crypto.Tls;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Web.Services.Description;
using System.Web.UI.DataVisualization.Charting;

namespace OneStopFraudReportingSystem
{
    public partial class textMessageIdentification : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM FRAUD_MESSAGE";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            resultTest.Text = (string)dr[1];
                            //Response.Write("<script> alert('This is a FRAUD MESSAGE !);</script>");
                        }
                    }
                }
            }*/

            resultTest.Visible = false;
            ImagePath.Visible = false;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //if(FileUpload1.HasFile)
            //{
            //FileUpload1.SaveAs(Server.MapPath("~/Images/MessageIdentification/" + FileUpload1.FileName));
            //MyImage.ImageUrl = "~/Images/MessageIdentification/" + FileUpload1.FileName;
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string path = Path.GetFileName(FileUpload1.FileName);
            path = path.Replace(" ", "");
            string filename1 = path;
            FileUpload1.SaveAs(Server.MapPath("~/Images/MessageIdentification/") + path);
            ImagePath.Text = Server.MapPath("~/Images/MessageIdentification/") + path;

            IronTesseract IronOcr = new IronTesseract();
            var Result = IronOcr.Read(ImagePath.Text);
            resultTest.Text = Result.Text;

            if (resultTest.Text == string.Empty)
            {
                Response.Write("<script> alert('Please upload a valid image !');</script>");
                Server.Transfer("textMessageIdentification.aspx");
            }
            else
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT * FROM FRAUD_MESSAGE";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            double temp = 0;
                            while (dr.Read())
                            {
                                string Source = (string)dr[1];
                                string Target = Result.Text;

                                double similarity = findSimilarity(Source, Target)*100;

                                if (similarity > temp)
                                {
                                    temp = similarity;
                                }
                            }

                            if (temp >= 65)
                            {
                                string alert = "This is a Fraud Message! :";
                                Response.Write("<script> alert('" + alert +"' );</script>");
                                Server.Transfer("addReport.aspx");
                            }
                            else
                            {
                                Response.Write("<script> alert('This message did not consists any fraud !');</script>");
                                Server.Transfer("textMessageIdentification.aspx");
                            }
                        }
                    }
                }
            }
        }

        public static int getEditDistance(string X, string Y)
        {
            int m = X.Length;
            int n = Y.Length;

            int[][] T = new int[m + 1][];
            for (int i = 0; i < m + 1; ++i)
            {
                T[i] = new int[n + 1];
            }

            for (int i = 1; i <= m; i++)
            {
                T[i][0] = i;
            }
            for (int j = 1; j <= n; j++)
            {
                T[0][j] = j;
            }

            int cost;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    cost = X[i - 1] == Y[j - 1] ? 0 : 1;
                    T[i][j] = Math.Min(Math.Min(T[i - 1][j] + 1, T[i][j - 1] + 1),
                            T[i - 1][j - 1] + cost);
                }
            }

            return T[m][n];
        }

        public static double findSimilarity(string x, string y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentException("Strings must not be null");
            }

            double maxLength = Math.Max(x.Length, y.Length);
            if (maxLength > 0)
            {
                // optionally ignore case if needed
                return (maxLength - getEditDistance(x, y)) / maxLength;
            }
            return 1.0;
        }
    }
}