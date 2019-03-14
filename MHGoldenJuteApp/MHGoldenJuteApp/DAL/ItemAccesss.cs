﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MHGoldenJuteApp.Models;
using System.Data.SqlClient;

namespace MHGoldenJuteApp.DAL
{
    public class ItemAccesss:SQL
    {
        
        public int Save(Item aItem)
        {
            Connection.Open();
            try
            {
                Query = "insert into Party values('@ItemGroupId','@ItemCode','@ItemName','@Department','@Unit','@SalesPrice','@ReOderlvl','@ReOrderQnt','@ItemType','@ImgUrl')";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("PartyName", aItem.ItemGroupId);
                Command.Parameters.AddWithValue("ItemCode", aItem.ItemCode);
                Command.Parameters.AddWithValue("ItemName", aItem.ItemName);
                Command.Parameters.AddWithValue("Department", aItem.Department);
                Command.Parameters.AddWithValue("Unit", aItem.Unit);
                Command.Parameters.AddWithValue("SalesPrice", aItem.SalesPrice);
                Command.Parameters.AddWithValue("ReOderlvl", aItem.ReOrderLevel);
                Command.Parameters.AddWithValue("ReOrderQnt", aItem.ReOrderQuantity);
                Command.Parameters.AddWithValue("ItemType", aItem.ItemType);
                Command.Parameters.AddWithValue("ImgUrl", aItem.ImageUrl);
               
                RowCount = Command.ExecuteNonQuery();
            }
            catch { RowCount = 2; }

            Connection.Close();
            return RowCount;
        }

        public List<Item> GetAllItem()
        {
            List<Item> listOfItem = new List<Item>();
            Connection.Open();
            Query = "Select * from Item order by ItemId";
            Command = new SqlCommand(Query, Connection);
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Item aItem=new Item();
                aItem.ItemId = (int)Reader["PartyId"];
                aItem.ItemGroupId = (int)Reader["ItemGroupId"];
                aItem.ItemCode = Reader["ItemCode"].ToString();
                aItem.ItemName = Reader["ItemName"].ToString();
                aItem.Department = Reader["Department"].ToString();
                aItem.ItemType = (int)Reader["ItemType"];
                aItem.ReOrderLevel = (int)Reader["ReOrderLevel"];
                aItem.ReOrderQuantity = (double)Reader["ReOrderQuantity"];
                aItem.ImageUrl = Reader["ImageUrl"].ToString();
                aItem.SalesPrice = (double)Reader["SalesPrice"];
                aItem.Unit = Reader["Unit"].ToString();
                listOfItem.Add(aItem);

            }
            Reader.Close();
            Connection.Close();
            return listOfItem;
        }
    }
}