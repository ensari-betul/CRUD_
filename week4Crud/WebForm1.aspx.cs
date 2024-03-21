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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTN_AddBook_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string BookISBN, BookName, Subject;
                    int SN;
                    SN = int.Parse(TXTBox_SN.Text);
                    BookName = TXTBox_BookName.Text;
                    BookISBN = TXTBox_BookISBN.Text;
                    Subject = Subject_Item.SelectedItem.Text;

                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    string qry = "insert into Book_info (SN,Book_ISBN,Book_Name,Subject) values ('" + SN + "','" + BookISBN + "','" + BookName + "','" + Subject + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex) { Console.WriteLine("Hata oluştu: " + ex.Message); }
                LBL_SMessage2.Text = "Data Added Successfully";
            }

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string tNo;
            tNo = args.Value.ToString();
            args.IsValid = true;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            string qry = "Select * from Book_info";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                if (rd["Book_ISBN"].ToString() == tNo)
                {
                    args.IsValid = false;
                    break;
                }
            }
            con.Close();

        }
    }
}