using Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models.Dao
{
    public class DetailCartDao


    {
       public MyDB db = new MyDB();
        public DetailCartDao()
        {

        }
        public List<DetailCart> getAllData()
        {

            List<DetailCart> lstCart = db.DetailCarts.ToList();

            return lstCart;
        }
        public long addDetailCart(DetailCart pd)
        {
            try
            {
                db.DetailCarts.Add(pd);
                db.SaveChanges();
                return pd.idCart;
            }
            catch
            {
                return 0;
            }
        }
        public DetailCart getSinglData(long idCart,int idPD)
        {
            return db.DetailCarts.SingleOrDefault(x => x.idCart == idCart &&x.idPD==idPD);
        }
        public bool updateDetailCart(DetailCart pd)
        {
            DetailCart pdx = db.DetailCarts.Find(pd.idCart,pd.idPD);
            try
            {
                pdx.amount = pd.amount;
                pdx.idCart = pd.idCart;
                pdx.idPD = pd.idPD;
                pdx.quantity = pd.quantity;
                pdx.status = pd.status;
                


                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteDetailCart(long idCart,int idPD)
        {
            DetailCart pd = db.DetailCarts.Find(idCart,idPD);
            if (pd != null)
            {
                db.DetailCarts.Remove(pd);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}