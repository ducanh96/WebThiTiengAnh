using Shop.Models.Dao;
using Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult IndexI()
        {
            return View(new ImageDao().getAllData());
        }
        public ActionResult ViewADD()
        {
            ImageDao imd = new ImageDao();
            ViewBag.idPD = new SelectList((new MyDB()).Products.ToList().OrderBy(x => x.TenPD), "idPD", "TenPD");
                                                                           

            return View();
        }
        public ActionResult ViewEdit(int idImg)
        {
            Image mn = ImageDao.getSinglData(idImg);
            ViewBag.idPD = new SelectList((new MyDB()).Products.ToList().OrderBy(x => x.TenPD), "idPD", "TenPD");


            return View(mn);
        }
        public ActionResult Delete(int idPD)
        {
            bool check = ImageDao.deleteImage(idPD);
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
        public ActionResult Add(Image mn, HttpPostedFileBase fileUpLoad)
        {


            ViewBag.idPD = new SelectList(new MyDB().Products.ToList().OrderBy(x => x.TenPD), "idPD", "TenPD");


            var fileName = Path.GetFileName(fileUpLoad.FileName);
            var path = Path.Combine(Server.MapPath("~/Image"), fileName);
            if (System.IO.File.Exists(path))
            {
                ViewBag.msgImg = "Ảnh đã tồn tại";

            }
            else
            {
                fileUpLoad.SaveAs(path);
            }
            mn.linkImg = "~/Image/" + fileUpLoad.FileName.Trim();
            bool check = ImageDao.addImage(mn);
            if (check)
            {
                ViewBag.msgAdd = "Thêm mới thành công";
            }
            else
                ViewBag.msgAdd = "Thêm mới thất bại ";


            return View("ViewADD");
        }
        [HttpPost]
        public ActionResult Edit(Image mn)
        {


            ViewBag.idPD = new SelectList(new MyDB().Products.ToList().OrderBy(x => x.TenPD), "idPD", "TenPD");

            bool check = ImageDao.updateImage(mn);
            if (check)
            {
                ViewBag.msgEdit = "sửa thành công";
            }
            else
                ViewBag.msgEdit = "Sửa thất bại ";
            return Redirect("Index");
        }
    }
}