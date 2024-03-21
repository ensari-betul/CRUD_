using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Policy;

namespace week4Crud
{
    public partial class Book_Manager_Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] == null)
            {
                Response.Redirect("BookManagerLogin.aspx");
            }
        }

        //protected void TXT_Login_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        bool flg = false;
        //        con.Open();
        //        string qry = "select * from login";
        //        SqlCommand cmd = new SqlCommand(qry, con);
        //        SqlDataReader rd = cmd.ExecuteReader();

        //        while (rd.Read())
        //        {
        //            if (string.Equals(TXT_Email.Text.Trim(), rd["Email_ad"].ToString().Trim()))
        //            {
        //                if (string.Equals(TXT_Password.Text.Trim(), rd["password"].ToString().Trim()))
        //                {
        //                    flg = true;
        //                    if (rd["is_active"].ToString() == "Yes")
        //                    {
        //                        if (rd["is_admin"].ToString() == "Admin" || rd["is_admin"].ToString() == "User")
        //                        {
        //                            Session["New"] = rd["Email_ad"].ToString();
        //                            con.Close();
        //                            Response.Redirect("BookManagerLogin.aspx");
        //                            break;
        //                        }
        //                        else
        //                        {
        //                            Response.Write("Something went wrong");
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        if (!flg)
        //        {
        //            Response.Write("Wrong username and password");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("An error occurred: " + ex.Message);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
    }
}