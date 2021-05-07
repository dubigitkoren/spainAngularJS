using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("CREATE TABLE  details(ID int IDENTITY(1,1) NOT NULL, CreateDate DATETIME NOT NULL DEFAULT (GETDATE()),   " +
                    "                                   DateOfAuto   DATETIME, Tribunal char(100), TypeOfAuto  char(20), LocationOfAuto  char(200), Name char(200)," +
                    " Aliases  char(200), Gender char(10), DateOfBirth DATETIME, PersonalStatus char(20), " +
                    " Occupation  char(200), FamilyTies  char(300), LocationOfBirth  char(300), Residence  char(200), " +
                    " TypeOfCrime   char(200), Sentence  char(300), AdditionalInformation   char(300));"
                    );
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                int w = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO details (DateOfAuto, Tribunal, TypeOfAuto)  " +
                                                        "VALUES('02-03-2000', 'value2', 'value3'); "
                    );
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                int w = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("Select count(*) from  details ; "
                    );
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader["id"]));
                    }
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            lbl1.Text = txtTribunal.Text ;
        }
    }
}