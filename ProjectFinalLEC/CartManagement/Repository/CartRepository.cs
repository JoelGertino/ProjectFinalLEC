using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.CartManagement.Factory;

namespace ProjectFinalLEC.CartManagement.Repository
{
    public class CartRepository
    {
        Database1Entities13 db = new Database1Entities13();

        public void createCartItem(int customerID, int ModelTypeID, int quantity)
        {
            db.Carts.Add(CartFactory.CreateCartItem(customerID, ModelTypeID, quantity));
            db.SaveChanges();
        }
        public void createOrderDate()
        {
            db.OrderDates.Add(CartFactory.CreateOrderDate());
            db.SaveChanges();
        }


        public int getStock(int id)
        {
            ModelType tempModelType = db.ModelTypes.Find(id);
            int stock = tempModelType.ModelTypeStock;
            return stock;

        }
        public List<object> GetModelTypeDetailsByCustomerId(int custId)
        {
            var modeltypeDetails = (from modeltype in db.ModelTypes
                                    join cart in db.Carts on modeltype.ModelTypeID equals cart.ModelTypeID
                                    where cart.CustomerID == custId
                                    select new
                                    {
                                        modeltype.ModelTypeName,
                                        ModelTypeImage = modeltype.ModelTypeImage,
                                        Quantity = cart.Qty,
                                        modeltype.ModelTypePrice
                                    }).ToList<object>();
            return modeltypeDetails;
        }
        public List<Cart> Carts(int userid)
        {
            return db.Carts.Where(x => x.CustomerID == userid).ToList();
        }
        public void DeleteCart(int userid)
        {
            db.Carts.RemoveRange(db.Carts.Where(x => x.CustomerID == userid));
            db.SaveChanges();
        }

        public void UpdateCart(int customerID, int modeltypeId, int quantity)
        {
            Cart tempCart = db.Carts.Where(x => x.ModelTypeID == modeltypeId).FirstOrDefault();
            if (tempCart != null)
            {
                tempCart.Qty = tempCart.Qty + quantity;
                db.SaveChanges();
            }
            else
            {
                createCartItem(customerID, modeltypeId, quantity);
            }

        }
        public void updateStock(int modeltypeId, int quantity)
        {
            ModelType tempModelType = db.ModelTypes.Where(x => x.ModelTypeID == modeltypeId).FirstOrDefault();
            tempModelType.ModelTypeStock = tempModelType.ModelTypeStock - quantity;
        }
    }
}