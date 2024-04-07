using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace week4Crud
{
    public partial class BookReturn : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] == null)
            {
                Response.Redirect("BookMnagerLogin2.aspx");
            }
            else
            {
                LBL_Message.Text = "";
                if (!IsPostBack)
                {
                    DDL_ISBN.Items.Clear();

                    try
                    {
                        con.Open();
                        String QRY = "SELECT DISTINCT TNo FROM Book_RentInfo WHERE is_turn=0 ";
                        SqlCommand CMD = new SqlCommand(QRY, con);
                        SqlDataReader rd = CMD.ExecuteReader();
                        string tno = "";
                        if (rd != null)
                        {
                            while (rd.Read())
                            {
                                tno = rd["TNo"].ToString();
                                DDL_TNO.Items.Add(new ListItem(tno, tno));
                            }
                        }
                        con.Close();
                        DDL_TNO_SelectedIndexChanged(null, null);
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString());
                    }
                }
            }

        }
        protected void BTN_ReturnDate_Click(object sender, EventArgs e)
        {
            if (DDL_TNO.SelectedIndex > -1 && DDL_ISBN.SelectedIndex > -1) //CHECKING IS ANYTHING SELECTED OR NOT
            {
                try
                {
                    string tno = DDL_TNO.SelectedItem.ToString();
                    string ISBN = DDL_ISBN.SelectedItem.ToString();
                    con.Open();
                    String QRY = "update Book_RentInfo set is_turn=1 where TNo='" + tno + "' and ISBN='" + ISBN + "'";
                    SqlCommand CMD = new SqlCommand(QRY, con);
                    CMD.ExecuteNonQuery();
                    con.Close();
                    DDL_TNO_SelectedIndexChanged(null, null);

                    //rELOADING THE WHOLE PAGE
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
        }

        protected void DDL_TNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDL_TNO.SelectedIndex > -1) //CHECKING t NUMBER SELECTED OR NOT
            {
                try
                {
                    DDL_ISBN.Items.Clear();
                    con.Open();
                    String QRY = "SELECT ISBN FROM Book_RentInfo WHERE is_turn=0 and Tno='" + DDL_TNO.SelectedItem.ToString() + "'";
                    SqlCommand CMD = new SqlCommand(QRY, con);
                    SqlDataReader rd = CMD.ExecuteReader();
                    string ISBN = "";
                    if (rd != null)
                    {
                        while (rd.Read())
                        {
                            ISBN = rd["ISBN"].ToString();
                            DDL_ISBN.Items.Add(new ListItem(ISBN, ISBN));
                        }
                    }
                    con.Close();
                    DDL_ISBN_SelectedIndexChanged(null, null);

                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
        }

        protected void DDL_ISBN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDL_TNO.SelectedIndex > -1 && DDL_ISBN.SelectedIndex > -1) // CHECKING ANY ISBN SELECTED OR NOT
                {
                    string tno = DDL_TNO.SelectedItem.ToString();
                    string ISBN = DDL_ISBN.SelectedItem.ToString();
                    string s_name = "", s_email = "", book_name = "", book_subject = "", rent_date = "", return_date = "";
                    con.Open();
                    String QRY = "select s.S_Name,s.S_Email,b.Book_Name,b.Book_Subject,i.Rent_Date,i.Retun_Date from book_rentinfo i inner join student_info s on i.TNo=s.TNo inner join Book_Info_2 b on b.ISBN=i.ISBN where s.TNo='" + tno + "' and i.ISBN='" + ISBN + "' and i.is_turn=0";

                    SqlCommand CMD = new SqlCommand(QRY, con);
                    SqlDataReader rd = CMD.ExecuteReader();

                    if (rd != null)
                    {
                        while (rd.Read())
                        {
                            s_name = rd["s_name"].ToString();
                            s_email = rd["s_email"].ToString();
                            book_name = rd["book_name"].ToString();
                            book_subject = rd["book_subject"].ToString();
                            rent_date = Convert.ToDateTime(rd["rent_date"].ToString()).ToLongDateString();
                            return_date = Convert.ToDateTime(rd["retun_date"].ToString()).ToLongDateString();
                            break;
                        }
                    }
                    LBL_BookName.Text = book_name;
                    LBL_bookSubject.Text = book_subject;
                    LBL_StudentName.Text = s_name;
                    LBL_Email.Text = s_email;
                    LBL_RentDate.Text = rent_date;
                    LBL_ReturnDate.Text = return_date;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("BookMnagerLogin2.aspx");
        }

        protected void BTN_studentinfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manage_Book.aspx");
        }

        protected void BTN_ReturnBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("Return_Book.aspx");
        }


    }
}
