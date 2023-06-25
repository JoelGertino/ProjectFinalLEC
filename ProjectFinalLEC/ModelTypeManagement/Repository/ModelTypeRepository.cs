using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;
using ProjectFinalLEC.ModelTypeManagement.Factory;

namespace ProjectFinalLEC.ModelTypeManagement.Repository
{
    public class ModelTypeRepository
    {
        Database1Entities13 db = new Database1Entities13();
        public void AddModelType(string modeltypeName, string modeltypeDesc, int modeltypePrice, int modeltypeStock, string modeltypeImage, int brandID)
        {
            db.ModelTypes.Add(ModelTypeFactory.CreateModelType(modeltypeName, modeltypeDesc, modeltypePrice, modeltypeStock, modeltypeImage, brandID));
            db.SaveChanges();
        }
        public void AddPrice(int price)
        {
            db.Prices.Add(ModelTypeFactory.CreatePrice(price));
            db.SaveChanges();
        }

        public Price getPrice(int price)
        {
            Price nominal = db.Prices.Where(x => x.Nominal == price ).FirstOrDefault();
            return nominal;
        }
        public Price getPricebyId(int id)
        {
            Price nominal = db.Prices.Find(id);
            return nominal;
        }
        public List<ModelType> GetAllModelTypes(int brandId)
        {
            List<ModelType> modelTypes = (from ModelType in db.ModelTypes where ModelType.BrandID == brandId select ModelType).ToList();
            return modelTypes;

        }

        public ModelType getModelTypeID(int id)
        {
            return db.ModelTypes.Where(x => x.ModelTypeID == id).FirstOrDefault();
        }
        public void updateModelType(int id, string name, string Desc, int stock, int price, string image)
        {
            ModelType tempID = db.ModelTypes.Find(id);
            tempID.ModelTypeName = name;
            tempID.ModelTypeDescription = Desc;
            tempID.ModelTypeStock = stock;
            tempID.ModelTypePrice = price;
            tempID.ModelTypeImage = image;
            db.SaveChanges();

        }
        public void deleteModelType(int id)
        {
            db.ModelTypes.Remove(db.ModelTypes.Find(id));
            db.SaveChanges();
        }
    }
}