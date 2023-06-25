using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.CartManagement.Repository;
using ProjectFinalLEC.Model;

namespace ProjectFinalLEC.CartManagement.Handler
{
    public class CartHandler
    {
        CartRepository CR = new CartRepository();

        public void CartHand(int customerID, int modeltypeID, int quantity)
        {
            CR.UpdateCart(customerID, modeltypeID, quantity);
        }
        public void createOrderDate()
        {
           CR.createOrderDate();
        }

        public int stockHand(int id)
        {
            return CR.getStock(id);
        }
        public List<Cart> Carts(int userid)
        {
            return CR.Carts(userid);
        }
        public void DeleteCart(int userid)
        {
            CR.DeleteCart(userid);
        }
        public void updateStock(int modeltypeId, int quantity)
        {
            CR.updateStock(modeltypeId, quantity);
        }

        public List<object> GetModelTypeDetailsByCustomerId(int custId)
        {
            return CR.GetModelTypeDetailsByCustomerId(custId);
        }
    }
}