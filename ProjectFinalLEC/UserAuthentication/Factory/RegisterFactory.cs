using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;

namespace ProjectFinalLEC.UserAuthentication.Factory
{
    public class RegisterFactory
    {
        public Customer createUser(string name, string password, string email, int custAddress, string gender, string role)
        {
            return new Customer
            {
                CustomerName = name,
                CustomerPassword = password,
                CustomerEmail = email,
                CustomerAddress = custAddress,
                CustomerGender = gender,
                CustomerRole = role
            };
        }
        public Address createAddress(string address, string country)
        {
            return new Address
            {
                Address1 = address,
                Country = country
            };
        }

    }
}