using Shop.Models;
using Shop.Models.Dao;
using Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class MenuChaController : Controller
    {
        MenuChaDao mnd = new MenuChaDao();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult MenuCha()
        {       
            return View(mnd.getAllData());
        }
        public ActionResult ViewADD()
        {
            return View();
        }
        public ActionResult ViewEdit(int idCha)
        {
            MenuCha mn = mnd.getSinglData(idCha);
            return View(mn);
        }
        public ActionResult Delete(int idCha)
        {
            bool check= mnd.deleteMenuCha(idCha);
            if (check)
            {
                ViewBag.msgDelete = "Xóa thành công";
            }
            else
            {
                ViewBag.msgDelete = "Xóa thất bại";
            }
            return RedirectToAction("MenuCha");
        }
        [HttpPost]
        public ActionResult Add(MenuCha mn)
        {
           
            if (ModelState.IsValid)
            {
                bool check = mnd.addMenuCha(mn);
                if (check)
                {
                    ViewBag.msgAdd = "Thêm mới thành công";
                }
                else
                    ViewBag.msgAdd = "Thêm mới thất bại ";
            }


            return View("ViewADD");
        }
        [HttpPost]
        public ActionResult Edit(MenuCha mn)
        {
            bool check= mnd.updateMenuCha(mn);
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