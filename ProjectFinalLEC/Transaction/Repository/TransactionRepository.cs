using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.Transaction.Factory;

namespace ProjectFinalLEC.Transaction.Repository
{
    public class TransactionRepository
    {
        public static Database1Entities13 db = new Database1Entities13();
        public static TransactionHeader CreateTrHeader(int UserID, DateTime transactionDate)
        {
            TransactionHeader data = db.TransactionHeaders.Add(TransactionFactory.CreateTrHeader(UserID, transactionDate));
            db.SaveChanges();
            return data;
        }

        public static TransactionDetail CreateTrDetail(int transactionID, int ItemID, int quantity)
        {
            TransactionDetail data = db.TransactionDetails.Add(TransactionFactory.CreateTrDetail(transactionID, ItemID, quantity));
            db.SaveChanges();
            return data;
        }
        public void CreateTransactionDetail(int transactionID, int ItemID, int quantity)
        {
            db.TransactionDetails.Add(TransactionFactory.CreateTrDetail(transactionID, ItemID, quantity));
            db.SaveChanges();
        }

        public List<object> GetAllTransactionHeader(int customerID)
        {
            var transactionDetails = (from TransactionHeader in db.TransactionHeaders
                                      join customer in db.Customers on TransactionHeader.CustomerID equals customer.CustomerID
                                      join transactionDetail in db.TransactionDetails on TransactionHeader.TransactionID equals transactionDetail.TransactionID
                                      join modeltype in db.ModelTypes on transactionDetail.ModelTypeID equals modeltype.ModelTypeID
                                      where TransactionHeader.CustomerID == customerID
                                      select new
                                      {
                                          TransactionHeader.TransactionID,
                                          TransactionHeader.TransactionDate,
                                          customer.CustomerName,
                                          modeltype.ModelTypeImage,
                                          modeltype.ModelTypeName,
                                          transactionDetail.Qty,
                                          modeltype.ModelTypePrice
                                      }).ToList<object>();
            return transactionDetails;
        }

        public static List<TransactionDetail> GetAllTrDetail(int transactionId)
        {
            return db.TransactionDetails.Where(x => x.TransactionID == transactionId).ToList();
        }
        public static List<TransactionHeader> GetAllTrHeader()
        {
            return db.TransactionHeaders.ToList();
        }

        public static List<object> GetReport(int TransactionID)
        {
            var getDetail = (from transactionDetail in db.TransactionDetails
                             join modeltype in db.ModelTypes on transactionDetail.ModelTypeID equals modeltype.ModelTypeID
                             where transactionDetail.TransactionID == TransactionID
                             select new
                             {
                                 TransactionID = transactionDetail.TransactionID,
                                 ModelTypeName = modeltype.ModelTypeName,
                                 Quantity = transactionDetail.Qty,
                                 ModelTypePrice = modeltype.ModelTypePrice,

                             }).ToList<object>();
            return getDetail;
        }
    }
}
