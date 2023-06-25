using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.BrandManagement.Repository;

namespace ProjectFinalLEC.BrandManagement.Handler
{
    public class BrandHandler
    {
        BrandRepository BR = new BrandRepository();
        public void AddBrand(string name, string image)
        {
            BR.AddBrand(name, image);
        }
        public bool IsNameUnique(string name)
        {
            return BR.IsNameUnique(name);
        }
        public Brand getID(int id)
        {
            return BR.getID(id);
        }
        public List<Brand> getAllBrand()
        {
            return BR.getAllBrand();
        }
    }
}