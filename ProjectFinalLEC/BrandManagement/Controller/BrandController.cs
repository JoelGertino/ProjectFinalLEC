using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.BrandManagement.Handler;
using System.IO;
namespace ProjectFinalLEC.BrandManagement.Controller
{
    public class BrandController
    {
        BrandHandler BH = new BrandHandler();
        public bool AddBrand(string name, string image, double fileSize)
        {
            if (BH.IsNameUnique(name) && validateImage(image) && fileSize <= 2)
            {
                BH.AddBrand(name, image);
                return true;
            }
            return false;

        }
        public bool validateImage(string imageFile)
        {

            string fileExtension = Path.GetExtension(imageFile).ToLower();
            string[] extension = { ".png", ".jpg", ".jpeg", ".jfif" };

            if (!extension.Contains(fileExtension))
            {
                return false;
            }
            return true;
        }
        public List<Brand> getAllBrand()
        {
            return BH.getAllBrand();
        }

        public Brand getID(int id)
        {
            return BH.getID(id);
        }
    }
}