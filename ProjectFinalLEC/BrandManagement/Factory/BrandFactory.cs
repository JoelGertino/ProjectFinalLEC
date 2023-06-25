using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;

namespace ProjectFinalLEC.BrandManagement.Factory
{
    public class BrandFactory
    {
        public static Brand createBrand(int hist,string name, string image)
        {
            return new Brand
            {
                HistoryID = 1,
                BrandName = name,
                BrandImage = image
            };
        }
    }
}