using Shop.Models.Dao;
using Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class MenuConController : Controller
    {
        // GET: MenuCon
        public ActionResult Index()
        {
            return View(new MenuConDao().getAllData());
        }
        public ActionResult ViewADD()
        {
            ViewBag.idCha = new SelectList((new MyDB()).MenuChas.ToList().OrderBy(x => x.TenMenuCha), "idCha", "TenMenuCha");

            return View();
        }
        public ActionResult ViewEdit(int idCon)
        {
            MenuCon mn = MenuConDao.getSinglData(idCon);
            ViewBag.idCha = new SelectList((new MyDB()).MenuChas.ToList().OrderBy(x => x.TenMenuCha), "idCha", "TenMenuCha");

            return View(mn);
        }
        public ActionResult Delete(int idCon)
        {
            bool check = MenuConDao.deleteMenuCon(idCon);
            if (check)
            {
                ViewBag.msgDelete = "Xóa thành công";
            }
            else
            {
                ViewBag.msgDelete = "Xóa thất bại";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(MenuCon mn, HttpPostedFileBase fileUpLoad)
        {
            ViewBag.idCha = new SelectList((new MyDB()).MenuChas.ToList().OrderBy(x => x.TenMenuCha), "idCha", "TenMenuCha");


            bool check = MenuConDao.addMenuCon(mn);
            if (check)
            {
                ViewBag.msgAdd = "Thêm mới thành công";
            }
            else
                ViewBag.msgAdd = "Thêm mới thất bại ";


            return View("ViewADD");
        }
        [HttpPost]
        public ActionResult Edit(MenuCon mn, HttpPostedFileBase fileUpLoad)
        {

            ViewBag.idCha = new SelectList((new MyDB()).MenuChas.ToList().OrderBy(x => x.TenMenuCha), "idCha", "TenMenuCha");

            bool check = MenuConDao.updateMenuCon(mn);
            if (check)
            {
                ViewBag.msgEdit = "sửa thành công";
            }
            else
                ViewBag.msgEdit = "Sửa thất bại ";
            return View("ViewEdit");
        }
    }
}