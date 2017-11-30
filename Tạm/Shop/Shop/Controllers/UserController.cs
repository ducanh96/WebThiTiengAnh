using Shop.Models.Dao;
using Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class UserController : Controller
    {
        UserDao usd = new UserDao();
        // GET: User
        public ActionResult Index()
        {
           List<User> lst = usd.getAllData();
            return View(lst); //UserDao.getAllData())
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ViewADD()
        {
            
            return View();
        }
        public ActionResult MyAccount()
        {
            if (Session["userName"] == null)
            {
                return View("Login");
            }
            else
            {
                User us = usd.getSinglData(Session["userName"].ToString());
                return View(us);
            }
           
           
        }
        [HttpPost]
        public ActionResult LoginAction(User u)
        {

            int check = usd.LoginCheck(u.userName, u.password);
            if (check > 0)
            {
                Session["userName"] = u.userName;
                User us = usd.getSinglData(u.userName);
                if (us.Quyen == 1)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }        
            else
                return View("Login");
        }
        public ActionResult ViewEdit(string userName)
        {
            User mn = usd.getSinglData(userName);
            return View(mn);
        }
        //public ActionResult Delete(int idCha)
        //{
        //    bool check = UserDao.deleteUser(idCha);
        //    if (check)
        //    {
        //        ViewBag.msgDelete = "Xóa thành công";
        //    }
        //    else
        //    {
        //        ViewBag.msgDelete = "Xóa thất bại";
        //    }
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public ActionResult Add(User mn)
        {
            mn.Quyen = 0;
            if (ModelState.IsValid)
            {
                int check = usd.addUser(mn);
                if (check==1)
                {
                    ViewBag.msgAdd = "Thêm mới thành công";
                }
                else  if(check==-1)
                {
                    ViewBag.msgAdd = "Thêm mới thất bại ";
                }
                    
                else
                {
                    ViewBag.msgAdd = "user name is already exixs";
                }
            }


            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Edit(User mn,string userName1)
        {
            mn.Quyen = 0;
            bool check = usd.updateUser(mn);
            if (check)
            {
                ViewBag.msgEdit = "sửa thành công";
            }
            else
                ViewBag.msgEdit = "Sửa thất bại ";
            return RedirectToAction("Index", "Home");
        }
    }
}