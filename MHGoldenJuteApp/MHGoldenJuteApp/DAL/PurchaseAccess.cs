using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MHGoldenJuteApp.Models;
using System.Data.SqlClient;

namespace MHGoldenJuteApp.DAL
{
    public class PurchaseAccess:SQL
    {
        public Purchase SaveAPurchase(Purchase aPurchase)
        {
            Connection.Open();
            try
            {
                Query = "insert into Purchase values('@PurchaseInvNo','@PurDateTime',@SupplierId,@PurchaseByUserId,'@Remarks','@ChalanNo',"+
                      "'@MrNo',@IsApprove,@ApproveByUserId,@ApproveDateTime,@TotalAmount)";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("PurchaseInvNo", aPurchase.PurchaseInvoiceNo);
                Command.Parameters.AddWithValue("PurDateTime", aPurchase.PurcahseDateTime);
                Command.Parameters.AddWithValue("SupplierId", aPurchase.SupplierId);
                Command.Parameters.AddWithValue("PurchaseByUserId", aPurchase.PurchaseByUserId);
                Command.Parameters.AddWithValue("Remarks", aPurchase.Remarks);
                Command.Parameters.AddWithValue("ChalanNo", aPurchase.ChalanNo);
                Command.Parameters.AddWithValue("MrNo", aPurchase.MrNo);
                Command.Parameters.AddWithValue("IsApprove", aPurchase.IsApproved);
                Command.Parameters.AddWithValue("ApproveByUserId", aPurchase.PurchaseApproveUserId);
                Command.Parameters.AddWithValue("ApproveDateTime", aPurchase.PurchaseApproveDateTime);
                Command.Parameters.AddWithValue("TotalAmount", aPurchase.TotalAmount);
                RowCount = Command.ExecuteNonQuery();
            }
            catch { RowCount = 2; }

            Query = "Select Max(PurchaseId) from Purchase where PurchaseUserId=";
            Command = new SqlCommand(Query, Connection);
            Int64 purchaseId=(Int64)Command.ExecuteScalar();

            string PurchaseInvNo = "RC-" + DateTime.Today.Year.ToString() + "-" + purchaseId.ToString("00000");

            Query = "Update Purchase set PurchaseInvoiceNo='"+PurchaseInvNo+"' where PurchaseId="+purchaseId+"";
            Command = new SqlCommand(Query, Connection);
            Command.ExecuteNonQuery();

            aPurchase.PurchaseID = purchaseId;
            aPurchase.PurchaseInvoiceNo = PurchaseInvNo;

            Connection.Close();
            return aPurchase;
        }

        public void SavePurchaseDetail(PurchaseDetail aPurchaseDetail)
        {
            Connection.Open();
            try
            {
                Query = "insert into PurchaseDetail values(@PurchaseId,'@PurchaseInvNo',@ItemGroupId,@ItemId,'@ItemName',@GodownId,,'@ProductName'" +
                      "'@Quantity',@UnitPrice,@TotalAmount,@IsApporved,@ApprovedByUserId,@ApproveDateTime,'@Department','@Location')";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("PurchaseId", aPurchaseDetail.PurchaseId);
                Command.Parameters.AddWithValue("PurchaseInvNo", aPurchaseDetail.PurchaseInvoiceNo);
                Command.Parameters.AddWithValue("ItemGroupId", aPurchaseDetail.ItemGroupId);
                Command.Parameters.AddWithValue("ItemId", aPurchaseDetail.ItemId);
                Command.Parameters.AddWithValue("ItemName", aPurchaseDetail.ItemName);
                Command.Parameters.AddWithValue("GodownId", aPurchaseDetail.GodownId);
                Command.Parameters.AddWithValue("ProductName", aPurchaseDetail.ProductName);
                Command.Parameters.AddWithValue("Quantity", aPurchaseDetail.Quantity);
                Command.Parameters.AddWithValue("UnitPrice", aPurchaseDetail.UnitPrice);
                Command.Parameters.AddWithValue("TotalAmount", aPurchaseDetail.TotalAmount);
                Command.Parameters.AddWithValue("IsApporved", aPurchaseDetail.IsApproved);
                Command.Parameters.AddWithValue("ApprovedByUserId", aPurchaseDetail.ApproveByUserId);
                Command.Parameters.AddWithValue("ApproveDateTime", aPurchaseDetail.ApproveDateTime);
                Command.Parameters.AddWithValue("Department", aPurchaseDetail.Department);
                Command.Parameters.AddWithValue("Location", aPurchaseDetail.Location);
                RowCount = Command.ExecuteNonQuery();
            }
            catch { RowCount = 2; }
            Connection.Close();
        }


        public void UpdateApproval(List<PurchaseDetail> listOfPurchaseDetail)
        {
            Connection.Open();
            int approved = 0;
            foreach (PurchaseDetail aPurchaseDetail in listOfPurchaseDetail)
            {
                if (aPurchaseDetail.IsApproved == "Y") { 
                Query = "Update PurchaseDetail set IsApprove=1 where PurchaseDetailId="+aPurchaseDetail.PurchaseDetailId+"";
                Command = new SqlCommand(Query, Connection);
                Command.ExecuteNonQuery();
                approved++;
                }
            }
            if(approved>0)
            {
                Query = "Update Purchase set IsApprove=1 where PurchaseDetailId=" + listOfPurchaseDetail[0].PurchaseDetailId + "";
                Command = new SqlCommand(Query, Connection);
                Command.ExecuteNonQuery();
            }
            else
            {
                Query = "Update Purchase set IsApprove=0 where PurchaseDetailId=" + listOfPurchaseDetail[0].PurchaseDetailId + "";
                Command = new SqlCommand(Query, Connection);
                Command.ExecuteNonQuery();
            }


            Connection.Close();

        }
    }
}