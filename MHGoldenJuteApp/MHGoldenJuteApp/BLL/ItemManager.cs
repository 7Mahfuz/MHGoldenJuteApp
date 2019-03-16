using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MHGoldenJuteApp.DAL;
using MHGoldenJuteApp.Models;

namespace MHGoldenJuteApp.BLL
{
    public class ItemManager
    {
        ItemAccess aItemAccess = new ItemAccess();

        public int Save(Item aItem)
        {
           // if (aItemAccess.IsItemNameExist(aItem.ItemName, aItem.ItemType)) return 3;
           // else
                return aItemAccess.Save(aItem);
        }

        public Item GetAItemById(int ItemID)
        {
            return aItemAccess.GetAItemById(ItemID);
        }

        public List<Item> GetAllItem()
        {
            return aItemAccess.GetAllItem();
        }

        public int Update(Item aItem)
        {
            return aItemAccess.UpdateAItemById(aItem);
        }

        public int DeleteById(int ItemId)
        {
            return aItemAccess.DeleteById(ItemId);
        }

        public List<ItemGroup>GetAllItemGroup()
        {
            return aItemAccess.GetAllItemGroup();
        }
    }
}