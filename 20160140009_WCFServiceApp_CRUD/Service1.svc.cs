using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _20160140009_WCFServiceApp_CRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered : {0}", value);
        }

        public string Insert(InsertUser user)
        {
            string message;
            SqlConnection con = new SqlConnection("Data Source=RASY;Initial Catalog=WCFServiceApp;Persist Security Info=True;User ID=sa;Password=bibimbap2326");
            con.Open();

            SqlCommand cmd = new SqlCommand("Insert into dbo.UserTable (Name, Email) values (@Name, @Email)", con);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);

            int g = cmd.ExecuteNonQuery();
            if (g == 1)
            {
                message = "Successfully Inserted";
            }

            else
            {
                message = "Failed to Insert";
            }

            return message;
        }

        public GetTestData GetInfo()
        {
            GetTestData g = new GetTestData();
            SqlConnection con = new SqlConnection("Data Source=RASY;Initial Catalog=WCFServiceApp;Persist Security Info=True;User ID=sa;Password=bibimbap2326");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from UserTable", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("mytab");
            da.Fill(dt);
            g.userTable = dt;
            return g;
        }

        public string Update(UpdateUser u)
        {
            string Message = "";
            SqlConnection con = new SqlConnection("Data Source=RASY;Initial Catalog=WCFServiceApp;Persist Security Info=True;User ID=sa;Password=bibimbap2326");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update UserTable set Name = @Name, Email = @Email where UserID=@UserID", con);
            cmd.Parameters.AddWithValue("@UserID", u.UID);
            cmd.Parameters.AddWithValue("@Name", u.Name);
            cmd.Parameters.AddWithValue("@Email", u.Email);
            int res = cmd.ExecuteNonQuery();
            if (res == 1)
            {
                Message = "Successfully Updated";
            }

            else
            {
                Message = "Failed to Update";
            }

            return Message;
        }

        public string Delete(DeleteUser d)
        {
            string msg = "";
            SqlConnection con = new SqlConnection("Data Source=RASY;Initial Catalog=WCFServiceApp;Persist Security Info=True;User ID=sa;Password=bibimbap2326");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete UserTable where UserID = @UserID", con);
            cmd.Parameters.AddWithValue("@UserID", d.UID);
            int res = cmd.ExecuteNonQuery();
            if (res == 1)
            {
                msg = "Successfully Deleted";
            }

            else
            {
                msg = "Failed to Delete";
            }

            return msg;
        }
    }
}