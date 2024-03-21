using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace week4Crud
{
    public partial class BookMnagerLogin2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["New"] == null)
            //{
            //    Response.Redirect("BookMnagerLogin2.aspx");
            //}

        }

        protected void TXT_Login_Click(object sender, EventArgs e)
        {
            try
            {
                bool flg = false;
                con.Open();
                string qry = "select * from Book_Manager_Login";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    if (string.Equals(TXT_Email.Text.Trim(), rd["Email_ad"].ToString().Trim()))
                    {
                        if (string.Equals(TXT_Password.Text.Trim(), rd["password"].ToString().Trim()))
                        {
                            flg = true;
                            if (rd["is_active"].ToString() == "Yes")
                            {
                                if (rd["is_admin"].ToString() == "Admin" || rd["is_admin"].ToString() == "User")
                                {
                                    var a = rd["Email_ad"].ToString();
                                    Session["New"] = rd["Email_ad"].ToString();
                                    con.Close();
                                    Response.Redirect("Webform1.aspx", false);
                                    break;
                                }
                                else
                                {
                                    Response.Write("Something went wrong");
                                }
                            }
                        }
                    }
                }

                if (!flg)
                {
                    Response.Write("Wrong username and password");
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}