using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.ModelTypeManagement.Repository;
namespace ProjectFinalLEC.ModelTypeManagement.Handler
{
    public class ModelTypeHandler
    {
        ModelTypeRepository MR = new ModelTypeRepository();

        public void AddModelTypeHand(string modeltypeName, string modeltypeDesc, int modeltypePrice, int modeltypeStock, string modeltypeImage, int brandId)
        {
            MR.AddModelType(modeltypeName, modeltypeDesc, modeltypePrice, modeltypeStock, modeltypeImage, brandId);
        }
        public void AddPrice(int price)
        {
            MR.AddPrice(price);
        }

        public Price getPrice(int price)
        {
            return MR.getPrice(price);
        }
        public Price getPricebyId(int id)
        {
            return MR.getPricebyId(id);
        }
        public List<ModelType> GetAllModelTypesHand(int brandID)
        {
            List<ModelType> modelTypes = MR.GetAllModelTypes(brandID);
            return modelTypes;

        }

        public void UpdateModelTypeHandler(int id, string name, string desc, int price, int stock, string image)
        {
            MR.updateModelType(id, name, desc, stock, price, image);
        }
        public void deleteModelTypeHand(int id)
        {
            MR.deleteModelType(id);
        }

        public ModelType getModelTypeID(int id)
        {
            return MR.getModelTypeID(id);
        }
    }
}