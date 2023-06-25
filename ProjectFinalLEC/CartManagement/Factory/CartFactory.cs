using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
namespace ProjectFinalLEC.CartManagement.Factory
{
    public class CartFactory
    {
        public static Cart CreateCartItem(int customerID, int modeltypeID, int quantity)
        {
            return new Cart
            {
                CustomerID = customerID,
                ModelTypeID = modeltypeID,
                Qty = quantity,
                OrderDate = 1
            };
        }
        public static OrderDate CreateOrderDate()
        {
            return new OrderDate
            {
                Date = "25",
                Time = "10"
            };
        }

    }
    
}