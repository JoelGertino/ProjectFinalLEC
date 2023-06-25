using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFinalLEC.Model;

namespace ProjectFinalLEC.ModelTypeManagement.Factory
{
    public class ModelTypeFactory
    {
        public static ModelType CreateModelType(string modelTypeName, string modelTypeDesc, int modelTypePrice, int modelTypeStock, string modelTypeImage, int brandId)
        {
            return new ModelType
            {
                ModelTypeName = modelTypeName,
                ModelTypeDescription = modelTypeDesc,
                ModelTypeStock = modelTypeStock,
                ModelTypeImage = modelTypeImage,
                ModelTypePrice = modelTypePrice,
                BrandID = brandId
            };
        }
        public static Price CreatePrice(int nominal)
        {
            return new Price
            {
                Currency = "Rp.",
                Nominal = nominal
            };
        }

    }
}