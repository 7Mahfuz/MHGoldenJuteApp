using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MHGoldenJuteApp.Models;
using System.Data.SqlClient;

namespace MHGoldenJuteApp.DAL
{
    public class ItemAccess:SQL
    {   
        public int Save(Item aItem)
        {
            Connection.Open();
            try
            {
                Query = "insert into Item values('@ItemGroupId','@ItemCode','@ItemName','@Department','@Unit','@SalesPrice','@ReOderlvl','@ReOrderQnt','@ItemType','@ImgUrl')";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("ItemName", aItem.ItemGroupId);
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
                aItem.ItemId = (Int64)Reader["ItemId"];
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

        public Item GetAItemById(Int64 itemId)
        {
            Connection.Open();
            Item aItem = new Item();
            Query = "Select * from Item where ItemId=@ItemId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("ItemId", itemId);

            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                aItem.ItemId = (Int64)Reader["ItemId"];
                aItem.ItemGroupId = (Int64)Reader["ItemGroupId"];
                aItem.ItemCode = Reader["ItemCode"].ToString();
                aItem.ItemName = Reader["ItemName"].ToString();
                aItem.Department = Reader["Department"].ToString();
                aItem.ItemType = (int)Reader["ItemType"];
                aItem.ReOrderLevel = (int)Reader["ReOrderLevel"];
                aItem.ReOrderQuantity = (double)Reader["ReOrderQuantity"];
                aItem.ImageUrl = Reader["ImageUrl"].ToString();
                aItem.SalesPrice = (double)Reader["SalesPrice"];
                aItem.Unit = Reader["Unit"].ToString();

            }
            Reader.Close();
            Connection.Close();

            return aItem;
        }

        public int UpdateAItemById(Item aItem)
        {
            Connection.Open();
            try
            {
                Query = "Update Item set ItemGroupId='@ItemGroupId',ItemCode='@ItemCode',ItemName='@ItemName',Department='@Department',Unit='@Unit',SalesPrice='@SalesPrice',ReOrderLevel='@ReOderlvl',ReOrderQuantity='@ReOrderQnt',ItemType='@ItemType',ImageUrl='@ImgUrl')";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("ItemName", aItem.ItemGroupId);
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

        public int DeleteById(int itemId)
        {
            Connection.Open();
            try
            {
                Query = "Delete from Item where ItemId=@ItemId";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("ItemId", itemId);
                RowCount = Command.ExecuteNonQuery();
            }
            catch { RowCount = 2; }

            Connection.Close();
            return RowCount;
        }


        public List<ItemGroup>GetAllItemGroup()
        {
            List<ItemGroup> listOfItemGroup = new List<ItemGroup>();
            Connection.Open();
            Query = "Select * from ItemGroup order by ItemGroupId";
            Command = new SqlCommand(Query, Connection);
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ItemGroup aItemGroup = new ItemGroup();
                aItemGroup.ItemGroupId = (Int64)Reader["ItemGroupId"];
                aItemGroup.ItemGroupName = Reader["ItemGroupName"].ToString();

                listOfItemGroup.Add(aItemGroup);

            }
            Reader.Close();
            Connection.Close();
            return listOfItemGroup;
        }
    }
}