using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;

namespace ProjectFinalLEC.Transaction.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader CreateTrHeader(int UserID, DateTime transactionDate)
        {
            return new TransactionHeader
            {
                CustomerID = UserID,
                TransactionDate = transactionDate
            };
        }

        public static TransactionDetail CreateTrDetail(int transactionID, int itemID, int quantity)
        {
            return new TransactionDetail
            {
                TransactionID = transactionID,
                ModelTypeID = itemID,
                Qty = quantity,
                OrderDate = 1
            };
        }
        public static OrderDateTransaction CreateOrderDate()
        {
            return new OrderDateTransaction
            {
                Date = 1,
                Time = 2
            };
        }
    }
}