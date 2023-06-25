using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.ModelTypeManagement.Handler;
using System.IO;
namespace ProjectFinalLEC.ModelTypeManagement.Controller
{
    public class ModelTypeController
    {
        ModelTypeHandler MH = new ModelTypeHandler();

        public List<ModelType> GetAllModelTypesController(int brandID)
        {
            List<ModelType> modelTypes = MH.GetAllModelTypesHand(brandID);
            return modelTypes;

        }
        public void AddPrice(int price)
        {
            MH.AddPrice(price);
        }
        public Price getPrice(int price)
        {
            return MH.getPrice(price);
        }
        public Price getPricebyId(int id)
        {
            return MH.getPricebyId(id);
        }
        public bool AddModelTypeControl(string modeltypeName, string modeltypeDesc, int modeltypePrice, int modeltypeStock, string modeltypeImage, int brandId, double fileSize)
        {
            if (modeltypeName.Length > 0 && modeltypeName.Length < 50)
            {
                if (modeltypeDesc.Length > 0 && modeltypeDesc.Length < 255)
                {
                   
                        if (modeltypeStock > 0)
                        {
                            if (validateImage(modeltypeImage) && fileSize <= 2)
                            {
                                MH.AddModelTypeHand(modeltypeName, modeltypeDesc, modeltypePrice, modeltypeStock, modeltypeImage, brandId);
                                return true;
                            }

                        }
                    
                }
            }
            return false;
        }

        public bool UpdateModelTypeController(int id, string modeltypeName, string modeltypeDesc, int modeltypePrice, int modeltypeStock, string modeltypeImage, double fileSize)
        {
            if (modeltypeName.Length > 0 && modeltypeName.Length < 50)
            {
                if (modeltypeDesc.Length > 0 && modeltypeDesc.Length < 255)
                {
                    if (modeltypePrice > 100000 && modeltypePrice < 1000000)
                    {
                        if (modeltypeStock > 0)
                        {
                            if (validateImage(modeltypeImage) && fileSize <= 2)
                            {
                                MH.UpdateModelTypeHandler(id, modeltypeName, modeltypeDesc, modeltypePrice, modeltypeStock, modeltypeImage);
                                return true;
                            }

                        }
                    }
                }
            }
            return false;
        }
        public void deleteModelTypeController(int id)
        {
            MH.deleteModelTypeHand(id);
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

        public ModelType getModelTypeID(int id)
        {
            return MH.getModelTypeID(id);
        }
    }
}