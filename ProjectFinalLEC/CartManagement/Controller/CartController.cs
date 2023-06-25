using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.CartManagement.Handler;
using ProjectFinalLEC.Model;

namespace ProjectFinalLEC.CartManagement.Controller
{
    public class CartController
    {
        CartHandler CH = new CartHandler();

        public bool CartControllerAdd(int customerID, int modeltypeID, int quantity)
        {
            int stock = CH.stockHand(modeltypeID);
            if (stock >= quantity)
            {
                CH.CartHand(customerID, modeltypeID, quantity);
                return true;
            }
            else
            {
                return false;
            }

        }
        public void createOrderDate()
        {
            CH.createOrderDate();
        }
        public List<Cart> Carts(int userid)
        {
            return CH.Carts(userid);
        }
        public void DeleteCart(int userid)
        {
            CH.DeleteCart(userid);
        }
        public void updateStock(int modeltypeId, int quantity)
        {
            CH.updateStock(modeltypeId, quantity);
        }

        public List<object> GetModelTypeDetailsByCustomerId(int custId)
        {
            return CH.GetModelTypeDetailsByCustomerId(custId);
        }
    }
}