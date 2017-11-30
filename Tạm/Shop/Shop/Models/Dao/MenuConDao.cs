using Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models.Dao
{
    public class MenuConDao

    {
        static MyDB db = new MyDB();
        public MenuConDao()
        {

        }
        public List<MenuCon> getAllData()
        {

            List<MenuCon> lstMenuCon = db.MenuCons.ToList();

            return lstMenuCon;
        }
        public static bool addMenuCon(MenuCon pd)
        {
            try
            {
                db.MenuCons.Add(pd);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static MenuCon getSinglData(int idCon)
        {
            return db.MenuCons.SingleOrDefault(x => x.idCon == idCon);
        }
        public static bool updateMenuCon(MenuCon pd)
        {
            MenuCon pdx = db.MenuCons.Find(pd.idCon);
            try
            {
                pdx.isShow = pd.isShow;
                pdx.idCha = pd.idCha;
                pdx.TenMenuCon = pd.TenMenuCon;
               

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool deleteMenuCon(int idCon)
        {
            MenuCon pd = db.MenuCons.Find(idCon);
            if (pd != null)
            {
                var x = from s in db.Products where s.idCon == idCon select s;
                db.Products.RemoveRange(x);
                db.MenuCons.Remove(pd);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}