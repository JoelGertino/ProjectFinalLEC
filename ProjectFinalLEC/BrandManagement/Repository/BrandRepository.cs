using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.BrandManagement.Factory;

namespace ProjectFinalLEC.BrandManagement.Repository
{
    public class BrandRepository
    {
        Database1Entities13 db = new Database1Entities13();

        public void AddBrand(string name, string image)
        {
            db.Brands.Add(BrandFactory.createBrand(1,name, image));
            db.SaveChanges();

        }

        public Brand getID(int id)
        {
            return db.Brands.Where(x => x.BrandID == id).FirstOrDefault();
        }

        public void deleteItem(int id)
        {
            db.Brands.Remove(db.Brands.Find(id));
            db.SaveChanges();
        }

        public void updateItem(int id, string name, string image)
        {
            Brand tempID = db.Brands.Find(id);
            tempID.BrandName = name;
            tempID.BrandImage = image;
            db.SaveChanges();

        }
        public List<Brand> getAllBrand()
        {
            return (from Brand in db.Brands select Brand).ToList();
        }
        public bool IsNameUnique(string name)
        {
            List<Brand> brands = getAllBrand();
            foreach (var brand in brands)
            {
                if (brand.BrandName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }

    }
}