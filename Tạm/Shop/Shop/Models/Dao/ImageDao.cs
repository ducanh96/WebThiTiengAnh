using Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models.Dao
{
    public class ImageDao

    {
        static MyDB db = new MyDB();
        public ImageDao()
        {

        }
        public List<Image> getAllData()
        {

            List<Image> lstImage = db.Images.ToList();

            return lstImage;
        }
        public IQueryable<Image> getDataByIdPD(int idPD)
        {

            var pd = from s in db.Images
                  
                     where s.idPD == idPD
                     select s;
            return pd;
        }
        //public IQueryable<Image> getTopSeller()
        //{
        //    var pd = from s in db.Images
        //             orderby s.Statistics descending
        //             select s;

        //    return pd;
        //}
        //public IQueryable<Image> getTopNew()
        //{
        //    var pd = from s in db.Images
        //             orderby s.datePost descending
        //             select s;

        //    return pd;
        //}
        //public IQueryable<Image> getHotPd()
        //{
        //    var pd = from s in db.Images
        //             where s.HotPD == true
        //             select s;

        //    return pd;
        //}
        //public IQueryable<Image> getRelatedPD(int? idCon)
        //{
        //    var pd = from s in db.Images
        //             where s.idCon == idCon
        //             select s;

        //    return pd;
        //}
        public static bool addImage(Image pd)
        {
            try
            {
                db.Images.Add(pd);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static Image getSinglData(int idImg)
        {
            if (idImg > -1)
            {
                return db.Images.SingleOrDefault(x => x.idImg == idImg);
            }
            else
            {
                return db.Images.Find(0);
            }

        }
        public static bool updateImage(Image pd)
        {
            Image pdx = db.Images.Find(pd.idImg);
            try
            {
                pdx.active = pd.active;
                pdx.idPD = pd.idPD;
                pdx.linkImg = pd.linkImg;
               

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool deleteImage(int idImg)
        {
            Image pd = db.Images.Find(idImg);
            if (pd != null)
            {
                db.Images.Remove(pd);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}