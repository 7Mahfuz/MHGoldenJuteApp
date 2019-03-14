using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MHGoldenJuteApp.Models;
using MHGoldenJuteApp.DAL;

namespace MHGoldenJuteApp.BLL
{
    public class UserHandler
    {
        UserAccess aUserAccess = new UserAccess();

        public int Login(LoginVM aLoginVM)
        {
            aLoginVM.Password = EncryptDecrypt.Decrypt(aLoginVM.Password);
            return aUserAccess.UserLogin(aLoginVM); 
        }

        public bool IsUserNameExist(string userName)
        {
            return aUserAccess.isUserNameExist(userName);
        }

        public int UserRegister(User aUser)
        {
            if (IsUserNameExist(aUser.UserName)) return 0;
            aUser.Password = EncryptDecrypt.Encrypt(aUser.Password);
             return aUserAccess.UserRegister(aUser);
        }

        public int UpdateUserName(string newName,string oldName)
        {
            return aUserAccess.UpdateUserName(newName, oldName);
        }
        public int UpdatePassword(string newPassword,string oldPassword)
        {
            newPassword = EncryptDecrypt.Encrypt(newPassword);
            oldPassword = EncryptDecrypt.Encrypt(oldPassword);
            return aUserAccess.UpdatePassword(oldPassword,newPassword);
        }
    }
}