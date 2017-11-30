using Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models.Dao
{
    public class BrandDao

    {
        public MyDB db = new MyDB();
        public BrandDao()
        {

        }
        public List<Brand> getAllData()
        {

            List<Brand> lstBrand = db.Brands.ToList();

            return lstBrand;
        }
     
     
     
     
        public bool addBrand(Brand pd)
        {
            try
            {
                db.Brands.Add(pd);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //public Brand getSinglData(int idPD)
        //{
        //    if (idPD > -1)
        //    {
        //        return db.Brands.SingleOrDefault(x => x.idPD == idPD);
        //    }
        //    else
        //    {
        //        return db.Brands.Find(0);
        //    }

        //}
        //public bool updateBrand(Brand pd)
        //{
        //    Brand pdx = db.Brands.Find(pd.idPD);
        //    try
        //    {
        //        pdx.TenPD = pd.TenPD;
        //        pdx.PromotionPD = pd.PromotionPD;
        //        pdx.oldPrice = pd.oldPrice;
        //        pdx.newPrice = pd.newPrice;
        //        pdx.MenuCon = pd.MenuCon;
        //        pdx.linkImage = pd.linkImage;
        //        pdx.Information = pd.Information;
        //        pdx.idCon = pd.idCon;
        //        pdx.HotPD = pd.HotPD;

        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool deleteBrand(int idPD)
        //{
        //    Brand pd = db.Brands.Find(idPD);
        //    if (pd != null)
        //    {
        //        var x = from s in db.Images where s.idPD == idPD select s;
        //        db.Images.RemoveRange(x);
        //        db.Brands.Remove(pd);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    else return false;
        //}
    }
}