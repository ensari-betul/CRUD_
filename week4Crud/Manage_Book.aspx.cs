using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Policy;

namespace week4Crud
{
    public partial class Manage_Book : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string tno, studentname, s_email, S_dept;
                    con.Open();
                    string qry = "select * from student_info";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd != null)
                    {
                        if (rd.Read())
                        {
                            while (rd.Read())
                            {
                                tno = rd["TNo"].ToString();
                                DDL_TNo.Items.Add(new ListItem(tno, tno));
                            }
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                //loading book info
                try
                {
                    string ISBN, studentname, s_email, S_dept;
                    con.Open();
                    string qry = "select * from Book_Info_2";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd != null)
                    {
                        while (rd.Read())
                        {
                            ISBN = rd["ISBN"].ToString();
                            DDL_ISBN.Items.Add(new ListItem(ISBN, ISBN));
                        }

                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                DDL_TNo_SelectedIndexChanged(null, null);
                DDL_ISBN_SelectedIndexChanged(null, null);
            }
        }

        protected void DDL_TNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string tno = "", studentname = "", s_email = "", S_dept = "";
                tno = DDL_TNo.SelectedItem.Text.ToString();
                con.Open();
                string qry = "select * from Student_info where TNo='" + tno + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd != null)
                {

                    while (rd.Read())
                    {
                        s_email = rd["S_Email"].ToString();
                        studentname = rd["S_Name"].ToString();
                        S_dept = rd["S_Dept"].ToString();

                    }

                    LBL_StudentName.Text = studentname;
                    LBL_Email.Text = s_email;
                    LBL_Dept.Text = S_dept;



                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        protected void BTN_Logout_Click(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("Manage_Book.aspx");
        }
        protected void DDL_ISBN_SelectedIndexChanged(object sender, EventArgs e)
        {
            string noOFbook = "0";
            try
            {

                string ISBN = "", bookname = "", b_dept = "";
                ISBN = DDL_ISBN.SelectedItem.Text.ToString();
                con.Open();
                string qry = "select * from Book_Info_2 where ISBN='" + ISBN + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd != null)
                {

                    while (rd.Read())
                    {
                        bookname = rd["Book_Name"].ToString();
                        b_dept = rd["Book_Subject"].ToString();
                        noOFbook = rd["Number_of_Books"].ToString();

                    }

                    LBL_BookName.Text = bookname;
                    LBL_BookSubject.Text = b_dept;
                    LBL_TotalBook.Text = noOFbook;

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

            // Loading the remaining book
            try
            {
                string remainingBook = "";
                con.Open();
                string qry2 = "select count(ISBN) as CT from Book_RentInfo where ISBN='" + DDL_ISBN.SelectedItem.ToString() + "'";
                SqlCommand cmd = new SqlCommand(qry2, con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd != null)
                {
                    while (rd.Read())
                    {
                        remainingBook = rd["CT"].ToString();
                    }
                }

                LBL_ReaminingBook.Text = (Convert.ToInt32(noOFbook) - Convert.ToInt32(remainingBook)).ToString();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void BTN_Rentdate_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
            BTN_selectdateRent.Visible = true;
        }

        protected void BTN_selectdateRent_Click(object sender, EventArgs e)
        {
            BTN_Rentdate.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
            BTN_selectdateRent.Visible = false;
        }
        protected void BTN_ReturnDate_Click(object sender, EventArgs e)
        {
            BTN_SelectdateReturn.Visible = true;
            Calendar2.Visible = true;
        }
        protected void BTN_SelectdateReturn_Click(object sender, EventArgs e)
        {
            BTN_ReturnDate.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
            BTN_SelectdateReturn.Visible = false;

        }
        protected void BTN_Rent_Click(object sender, EventArgs e)
        {
            LBL_Message.Visible = true;
            LBL_Message.Text = "";
            try
            {
                if (BTN_Rentdate.Text != "Click to Select date" && BTN_ReturnDate.Text != "Click to Select Date")
                {
                    LBL_Message.Text = "";
                    if (Convert.ToDateTime(BTN_Rentdate.Text) < Convert.ToDateTime(BTN_ReturnDate.Text))
                    {
                        LBL_Message.Text = "";
                        if (Convert.ToInt32(LBL_ReaminingBook.Text) > 0)
                        {
                            LBL_Message.Text = "";
                            //insert data to the database
                            con.Open();
                            string qry3 = "insert into Book_RentInfo values ('" + DDL_TNo.SelectedItem.ToString() + "','" + DDL_ISBN.SelectedItem.ToString() + "','" + Convert.ToDateTime(BTN_Rentdate.Text) + "','" + Convert.ToDateTime(BTN_ReturnDate.Text) + "','0')";
                            SqlCommand cmd = new SqlCommand(qry3, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            LBL_Message.Text = "Book rented successfully.";
                            DDL_ISBN_SelectedIndexChanged(null, null);

                        }
                        else
                        {
                            LBL_Message.Text = "No Available book";
                        }
                    }
                    else
                    {
                        LBL_Message.Text = "Please correct the Return date";
                    }
                }
                else
                {

                    LBL_Message.Text = "Select Date";
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}