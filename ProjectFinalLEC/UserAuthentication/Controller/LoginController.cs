using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.UserAuthentication.Handler;
namespace ProjectFinalLEC.UserAuthentication.Controller
{
    public class LoginController
    {
        LoginHandler LH = new LoginHandler();
        public Customer LoginValidation(string email, string password)
        {
            Customer CustomerValid = LH.loginHand(email, password);
            return CustomerValid;
        }
        public int roleValidation(Customer CustomerValid)
        {
            if (CustomerValid.CustomerRole.Equals("Admin"))
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public Customer findCustomer(int id)
        {
            return LH.findCustomer(id);
        }
    }
}