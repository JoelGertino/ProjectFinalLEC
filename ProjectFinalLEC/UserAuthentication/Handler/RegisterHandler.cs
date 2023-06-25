using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.UserAuthentication.Repository;
namespace ProjectFinalLEC.UserAuthentication.Handler
{
    public class RegisterHandler
    {
        RegisterRepository RR = new RegisterRepository();

        public void RegisterHand(string name, string password, int address, string email, string gender)
        {
            RR.addCustomer(name, password, email, address, gender);
        }

        public void addAdress(string address, string country)
        {
            RR.addAdress(address, country);
        }

        public Address getAddress(string address, string country)
        {
            return RR.getAddress(address, country);

        }
        public Address getAddressById(int id)
        {
            return RR.getAddressById(id);
        }

        public bool EmailHand(string email)
        {
            return RR.findEmail(email);
        }

        public Customer getCustomer(int id)
        {
            return RR.getCustomer(id);
        }

        public void updateName(int id, string name)
        {
            RR.updateName(id, name);
        }

        public void updateEmail(int id, string email)
        {
            RR.updateEmail(id, email);
        }

        public void UpdateGender(int id, string gender)
        {
            RR.UpdateGender(id, gender);
        }

        public void updateAddress(int id, string address)
        {
            RR.updateAddress(id, address);
        }

        public void updatePassword(int id, string password)
        {
            RR.updatePassword(id, password);
        }
    }
}