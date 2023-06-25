using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.UserAuthentication.Factory;

namespace ProjectFinalLEC.UserAuthentication.Repository
{
    public class RegisterRepository
    {
        RegisterFactory RF = new RegisterFactory();
        Database1Entities13 db = new Database1Entities13();

        public void addCustomer(string name, string password, string email, int address, string gender)
        {
            Customer newUser = RF.createUser(name, password, email, address, gender, "Cust");
            db.Customers.Add(newUser);
            db.SaveChanges();
        }
        public void addAdress(string address, string country)
        {
            Address newAddress = RF.createAddress(address,country);
            db.Addresses.Add(newAddress);
            db.SaveChanges();
        }
        public Address getAddressById(int id)
        {
            Address add = db.Addresses.Find(id);
            return add;
        }

        public Address getAddress(string address, string country)
        {
            Address user = db.Addresses.Where(x => x.Address1 == address && x.Country == country).FirstOrDefault();
            return user;
        }

        public bool findEmail(string email)
        {
            Customer emailtemp = db.Customers.Where(x => x.CustomerEmail == email).FirstOrDefault();
            if (emailtemp != null)
            {
                return false;
            }
            return true;
        }

        public Customer getCustomer(int id)
        {
            Customer user = db.Customers.Find(id);
            return user;
        }

        public void updateName(int id, string name)
        {
            Customer user = db.Customers.Find(id);
            user.CustomerName = name;
            db.SaveChanges();
        }

        public void updateEmail(int id, string email)
        {
            Customer user = db.Customers.Find(id);
            user.CustomerEmail = email;
            db.SaveChanges();
        }

        public void UpdateGender(int id, string gender)
        {
            Customer user = db.Customers.Find(id);
            user.CustomerGender = gender;
            db.SaveChanges();
        }

        public void updateAddress(int id, string address)
        {
            Customer user = db.Customers.Find(id);
            int addId = user.CustomerAddress;
            Address findAdd = db.Addresses.Find(addId);
            findAdd.Address1 = address;
            db.SaveChanges();
        }

        public void updatePassword(int id, string password)
        {
            Customer user = db.Customers.Find(id);
            user.CustomerPassword = password;
            db.SaveChanges();
        }
    }
}