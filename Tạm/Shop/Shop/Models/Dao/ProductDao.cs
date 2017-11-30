using Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models.Dao
{
    public class ProductDao
    {
        public MyDB db = new MyDB();
        public ProductDao()
        {
           
        }
        public  List<Product> getAllData()
        {
        
            List<Product> lstProduct = db.Products.ToList();
          
            return lstProduct;
        }
        public IQueryable<Product> getDataByIdCha(int idCha)
        {

            var pd = from s in db.Products
                     join m in db.MenuCons on s.idCon equals m.idCon
                     where m.idCha==idCha
                     select s;
            return pd;
        }
        public IQueryable<Product> getTopSeller()
        {
               var pd = from s in db.Products
                                   orderby s.Statistics descending
                        select s; 

            return pd;
        }
        public IQueryable<Product> getTopNew()
        {
            var pd = from s in db.Products
                     orderby s.datePost descending
                     select s;

            return pd;
        }
        public IQueryable<Product> getHotPd()
        {
            var pd = from s in db.Products
                     where s.HotPD==true
                     select s;

            return pd;
        }
        public IQueryable<Product> getRelatedPD(int? idCon)
        {
            var pd = from s in db.Products
                     where s.idCon==idCon 
                     select s;

            return pd;
        }
        public  bool addProduct(Product pd)
        {
            try
            {
                db.Products.Add(pd);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public  Product getSinglData(int idPD)
        {
            if (idPD > -1)
            {
                return db.Products.SingleOrDefault(x => x.idPD == idPD);
            }
            else
            {
                return db.Products.Find(0);
            }
           
        }
        public  bool updateProduct(Product pd)
        {
            Product pdx = db.Products.Find(pd.idPD);
            try
            {
                pdx.TenPD = pd.TenPD;
                pdx.PromotionPD = pd.PromotionPD;
                pdx.oldPrice = pd.oldPrice;
                pdx.newPrice = pd.newPrice;
                pdx.MenuCon = pd.MenuCon;
                pdx.linkImage = pd.linkImage;
                pdx.Information = pd.Information;
                pdx.idCon = pd.idCon;
                pdx.HotPD = pd.HotPD;
              
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public  bool deleteProduct(int idPD)
        {
            Product pd = db.Products.Find(idPD);
            if (pd != null)
            {
                var x = from s in db.Images where s.idPD == idPD select s;
                var y = from s in db.DetailCarts where s.idPD == idPD select s;
                if (x!=null){
                    db.Images.RemoveRange(x);
                    db.DetailCarts.RemoveRange(y);
                }
                
                db.Products.Remove(pd);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}