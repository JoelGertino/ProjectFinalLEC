using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
namespace ProjectFinalLEC.UserAuthentication.Repository
{
    public class LoginRepository
    {
        Database1Entities13 db = new Database1Entities13();
        public Customer getUser(string email, string password)
        {
            Customer accTemp = db.Customers.Where(x => x.CustomerEmail == email && x.CustomerPassword == password).FirstOrDefault();
            return accTemp;
        }
        public Customer findCustomer(int id)
        {
            Customer User = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            return User;
        }
    }
}