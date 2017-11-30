
using Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models.Dao
{
    public class MenuChaDao
    {
        public MyDB db = new MyDB();
        public MenuChaDao()
        {
           
        }
        public  List<MenuCha> getAllData()
        {
          
            List<MenuCha> lstMenuCha = db.MenuChas.ToList();
            return lstMenuCha;
        }
        public IQueryable<MenuCha> getAllData1()
        {
            var rs = (from s in db.MenuChas select s);
            return rs;
        }
        public  bool addMenuCha(MenuCha mn)
        {
            try
            {
                db.MenuChas.Add(mn);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public  MenuCha getSinglData(int idCha)
        {
            return db.MenuChas.SingleOrDefault(x => x.idCha == idCha);
        }
        public  bool updateMenuCha(MenuCha mn)
        {
            MenuCha mnx = db.MenuChas.Find(mn.idCha);
            try
            {
                mnx.TenMenuCha = mn.TenMenuCha;
                mnx.isShow = mn.isShow;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public  bool deleteMenuCha(int idCha)
        {
            MenuCha mn = db.MenuChas.Find(idCha);
            if (mn != null)
            {
                var x = from s in db.MenuCons where s.idCha == idCha select s;
                db.MenuCons.RemoveRange(x);
                db.MenuChas.Remove(mn);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}