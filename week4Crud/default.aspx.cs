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

        }

        protected void BTN_AddStudent_Click(object sender, EventArgs e)
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
}