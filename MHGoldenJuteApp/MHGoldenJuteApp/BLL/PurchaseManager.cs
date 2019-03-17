using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MHGoldenJuteApp.DAL;
using MHGoldenJuteApp.Models;

namespace MHGoldenJuteApp.BLL
{
    public class PurchaseManager:SessionKeeper
    {
        PurchaseAccess aPurchaseAccess = new PurchaseAccess();
        ItemAccess aItemAccess = new ItemAccess();

        public void Save(Purchase aPurchase,List<PurchaseDetail> fullProductDetail) 
        {
            //Purchase aPurchase = new Purchase();
            aPurchase.PurchaseInvoiceNo = "";
            aPurchase.PurchaseByUserId = UserId;// USER ID from Seesion
            aPurchase.PurcahseDateTime = DateTime.Now;
            aPurchase.IsApproved = "N";
            aPurchase.MrNo = "";
            aPurchase.PurchaseApproveDateTime =DateTime.Parse("1800-5-5");
            aPurchase.PurchaseApproveUserId = 0;
            aPurchase.Remarks = "";
            aPurchase.TotalAmount = 0;
            
            foreach (PurchaseDetail aPurchaseDetail in fullProductDetail)
            {
                aPurchase.TotalAmount += aPurchaseDetail.TotalAmount;
            }

            aPurchase=aPurchaseAccess.SaveAPurchase(aPurchase);// First Phase

          // List<PurchaseDetail> fullProductDetail = new List<PurchaseDetail>();

            foreach (PurchaseDetail aPurchaseDetail in fullProductDetail)
            {
                Item aItem = aItemAccess.GetAItemById(aPurchaseDetail.ItemId);
                aPurchaseDetail.PurchaseId = aPurchase.PurchaseID;
                aPurchaseDetail.PurchaseInvoiceNo = aPurchase.PurchaseInvoiceNo;
                aPurchaseDetail.IsApproved = "N";
                aPurchaseDetail.ApproveByUserId = 0;
                aPurchaseDetail.ApproveDateTime = DateTime.Parse("1800-5-5");
                aPurchaseDetail.Department = aItem.Department;
                aPurchaseDetail.Location = "Jani Na";
                aPurchaseDetail.ItemGroupId = aItem.ItemGroupId;
                aPurchaseDetail.ItemName = aItem.ItemName;
                aPurchaseAccess.SavePurchaseDetail(aPurchaseDetail);
            }
           
            
        }

        public void UpdateApproval(List<PurchaseDetail>listOfPurchaseDetail)
        {
            int a = listOfPurchaseDetail.Count(x => x.IsApproved == "Y");
            if(a>0)
            {
                aPurchaseAccess.UpdateApproval(listOfPurchaseDetail);
            }
        }
        
    }
}