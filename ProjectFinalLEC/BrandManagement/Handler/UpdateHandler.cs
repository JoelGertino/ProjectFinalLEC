using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.BrandManagement.Repository;

namespace ProjectFinalLEC.BrandManagement.Handler
{
    public class UpdateHandler
    {
        BrandRepository BR = new BrandRepository();

        public void UpdateBrandHandler(int id, string name, string image)
        {
            BR.updateItem(id, name, image);
        }
        public void DeleteBrandHandler(int id)
        {
            BR.deleteItem(id);
        }
    }
}