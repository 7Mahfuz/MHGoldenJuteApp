using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MHGoldenJuteApp.Models;
using System.Data.SqlClient;

namespace MHGoldenJuteApp.DAL
{
    public class PartyAccess:SQL
    {
        public int Save(Party aParty)
        {
             Connection.Open();
            try
            {
                Query = "insert into Party('@PartyType','@PartyName','@Person','@Address','@PhoneNo','@MobileNo','@Email','@OpenBalance','@ImgUrl')";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("PartyName", aParty.PartyName);
                Command.Parameters.AddWithValue("PartyTyp", aParty.PartyType);
                Command.Parameters.AddWithValue("Email", aParty.Email);
                Command.Parameters.AddWithValue("Person", aParty.ContactPerson);
                Command.Parameters.AddWithValue("Address", aParty.Address);
                Command.Parameters.AddWithValue("PhoneNo", aParty.PhoneNo);
                Command.Parameters.AddWithValue("MobileNo", aParty.MobileNo);
                Command.Parameters.AddWithValue("OpenBalance", aParty.OpeningBalance);
                Command.Parameters.AddWithValue("ImgUrl", aParty.ImageUrl);
                RowCount = Command.ExecuteNonQuery();
            }
            catch { RowCount = 2; }
            
            Connection.Close();
            return RowCount;
        }

        public Party GetAPartyById(int partyId)
        {
            Connection.Open();
            Party aParty=new Party();
            Query="Select * from Party where PartyId=@partyId";
            Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("PartyId", partyId);
            
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {                
                aParty.PartyId= (int)Reader["PartyId"];
                aParty.PartyName = Reader["PartyName"].ToString();
                aParty.PartyType = Reader["PartyType"].ToString();
                aParty.ContactPerson = Reader["ContactPerson"].ToString();
                aParty.Address = Reader["Address"].ToString();
                aParty.PhoneNo = Reader["PhoneNo"].ToString();
                aParty.MobileNo = Reader["MobileNo"].ToString();
                aParty.OpeningBalance =(double)Reader["OpeningBalance"];
                aParty.ImageUrl = Reader["ImageUrl"].ToString();
                aParty.Email = Reader["Email"].ToString();
                
            }
            Reader.Close();
            Connection.Close();

            return aParty;
        }

        public List<Party> GetAllParty()
        {
            List<Party> listOfParty = new List<Party>();
            Connection.Open();
            Query = "Select * from Party order by PartyId";
            Command = new SqlCommand(Query, Connection);
                        Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Party aParty = new Party();
                aParty.PartyId = (int)Reader["PartyId"];
                aParty.PartyName = Reader["PartyName"].ToString();
                aParty.PartyType = Reader["PartyType"].ToString();
                aParty.ContactPerson = Reader["ContactPerson"].ToString();
                aParty.Address = Reader["Address"].ToString();
                aParty.PhoneNo = Reader["PhoneNo"].ToString();
                aParty.MobileNo = Reader["MobileNo"].ToString();
                aParty.OpeningBalance = (double)Reader["OpeningBalance"];
                aParty.ImageUrl = Reader["ImageUrl"].ToString();
                aParty.Email = Reader["Email"].ToString();
                listOfParty.Add(aParty);

            }
            Reader.Close();
            Connection.Close();
            return listOfParty;
        }

        public bool IsPartyNameExist(string partyName,string partyType)
        {
            Connection.Open();
            Query = "select count(PartyName) from tblUser where PartyName='@PartyName' and PartyType='@PartyType'";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("PartyName",partyName);
            Command.Parameters.AddWithValue("PartyType", partyType);
            int result = (int)Command.ExecuteScalar();
            Connection.Close();
            if (result > 0) return true;
            else return false;
        }
    }
}