using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace week4Crud
{
    public partial class AddStudentInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["New"] == null)
            {
                Response.Redirect("BookMnager2.aspx");
            }
        }

        protected void BTN_AddStudent_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string SName, SEmail, SDept;
                string Tno;
                Tno = TXTBox_TNumber.Text;
                SName = TXTBox_StudentName.Text;
                SEmail = TXTBox_Email.Text;
                SDept = DDL_Department.SelectedItem.Text;

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                string qry = "insert into Student_info (Tno,S_Name,S_Email,S_Dept) values ('" + Tno + "','" + SName + "','" + SEmail + "','" + SDept + "')";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();
                con.Close();

                LBL_SMessage.Text = "Data Added Successfully";
            }
            
        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string tNo;
            tNo = args.Value.ToString();
            args.IsValid = true;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            string qry = "Select * from Student_info";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                if (rd["TNo"].ToString() == tNo)
                {
                    args.IsValid = false;
                    break;
                }
            }
            con.Close();

        }

        protected void BTN_Logout_Click(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("BookMnagerLogin2.aspx");
        }

        protected void BTN_MNGBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manage_Book.aspx");
        }
    }
}