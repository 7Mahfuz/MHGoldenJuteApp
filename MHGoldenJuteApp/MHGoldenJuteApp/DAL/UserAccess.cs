using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MHGoldenJuteApp.Models;

namespace MHGoldenJuteApp.DAL
{
    public class UserAccess:SQL
    {
        public int UserLogin(LoginVM aLoginVM)
        {
            Connection.Open();
            Query = "select dbo.CheckUser('@Name','@PassWord')";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Name",aLoginVM.UserName);
            Command.Parameters.AddWithValue("PassWord", aLoginVM.Password);
            int result = (int)Command.ExecuteScalar();
            Connection.Close();
            return result;       

        }

        public int UserRegister(User aUser)
        {
            Connection.Open();
            try
            {
                Query = "insert into tblUser('@Name','@Password','@Email')";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Name", aUser.UserName);
                Command.Parameters.AddWithValue("Password", aUser.Password);
                Command.Parameters.AddWithValue("Email", aUser.Email);
                RowCount = Command.ExecuteNonQuery();
            }
            catch { RowCount = 2; }
            
            Connection.Close();
            return RowCount;
        }

        public bool isUserNameExist(string userName)
        {            
            Connection.Open();
            Query = "select count(UserName) from tblUser where UserName='@Name'";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Name", userName);           
            int result = (int)Command.ExecuteScalar();
            Connection.Close();
            if (result>0) return true;
            else return false;
        }

        public int UpdateUserName(string UserName,string OldName)
        {
            Connection.Open();
            try
            {
                Query = "Update set UserName='@NewName' where UserName='@OldName'";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("NewName",UserName);
                Command.Parameters.AddWithValue("OldName", OldName);
                RowCount= Command.ExecuteNonQuery();
            }
            catch { RowCount = 2; }
            
            Connection.Close();
            return RowCount;
        }

        public int UpdatePassword(string Password,string NewPassword)
        {
            Connection.Open();
            try
            {
                Query = "Update set UserName='@NewPassword' where UserName='@Password'";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("NewPassword", NewPassword);
                Command.Parameters.AddWithValue("Password", Password);
                RowCount = Command.ExecuteNonQuery();
            }
            catch { RowCount = 2; }

            Connection.Close();
            return RowCount;
        }
        
    }
}