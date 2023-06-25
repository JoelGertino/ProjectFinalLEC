using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.BrandManagement.Handler;

namespace ProjectFinalLEC.BrandManagement.Controller
{
    public class UpdateController
    {
        UpdateHandler UH = new UpdateHandler();
        BrandHandler BH = new BrandHandler();

        public int UpdateBrandController(int id, string name, string image)
        {
            if (BH.getID(id) != null)
            {
                if (name.Length != 0 && image.Length != 0)
                {
                    if (BH.IsNameUnique(name) && BH.IsNameUnique(image))
                    {
                        UH.UpdateBrandHandler(id, name, image);
                        return 1;
                    }
                }
            }
            return 0;
        }
        public void DeleteBrandController(int id)
        {
            UH.DeleteBrandHandler(id);
        }
    }
}