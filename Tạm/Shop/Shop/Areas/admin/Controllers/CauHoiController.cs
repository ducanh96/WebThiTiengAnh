using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTiengAnhCode.Areas.admin.Models.UI;

namespace WebTiengAnhCode.Areas.admin.Controllers
{
    public class CauHoiController : Controller
    {
       // CauHoiUI UI = new CauHoiUI();
        // GET: admin/CauHoi
        public ActionResult Index()
        {
            ViewData["lstDocPart1"] = CauHoiUI.getDSCauHoiDocPart1();
            return View();
        }
        public ActionResult Delete(int ID)
        {
            bool check = CauHoiUI.delete(ID);
            if (check)
            {
                ViewBag.msgDelete = 1;
            }
            else
            {
                ViewBag.msgDelete = 0;
            }
            
            return RedirectToAction("Index");
        }
    }
}