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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View(new ProductDao().getAllData());
        }
        public ActionResult ViewADD()
        {
            ViewBag.idCon = new SelectList((new MyDB()).MenuCons.ToList().OrderBy(x => x.TenMenuCon), "idCon", "TenMenuCon");

            return View();
        }
        public ActionResult ViewEdit(int idPD)
        {
            Product mn = new ProductDao().getSinglData(idPD);

            ViewBag.idCon = new SelectList(new MyDB().MenuCons.ToList().OrderBy(x => x.TenMenuCon), "idCon", "TenMenuCon");
            ViewData["lstImg"] = new ImageDao().getDataByIdPD(idPD);
            return View(mn);
        }
        public ActionResult Delete(int idPD)
        {
            bool check = new ProductDao().deleteProduct(idPD);
            if (check)
            {
                ViewBag.msgDelete = "Xóa thành công";
            }
            else
            {
                ViewBag.msgDelete = "Xóa thất bại";
            }
            return Redirect("Index");
        }
        [HttpPost]
        public ActionResult Add(Product mn,HttpPostedFileBase fileUpLoad)
        {

         
            ViewBag.idCon = new SelectList(new MyDB().MenuCons.ToList().OrderBy(x => x.TenMenuCon), "idCon", "TenMenuCon");

            if (fileUpLoad == null)
            {
                ViewBag.msgFile = "choose the file!";
            }
            else
            {
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
                mn.linkImage = "~/Image/" + fileUpLoad.FileName.Trim();
            }
            
                bool check = new ProductDao().addProduct(mn);
                if (check)
                {
                    ViewBag.msgAdd = "Thêm mới thành công";
                }
                else
                    ViewBag.msgAdd = "Thêm mới thất bại ";
           

            return View("ViewADD");
        }
        [HttpPost]
        public ActionResult Edit(Product mn, HttpPostedFileBase fileUpLoad)
        {

            ViewBag.idCon = new SelectList(new MyDB().MenuCons.ToList().OrderBy(x => x.TenMenuCon), "idCon", "TenMenuCon");


           
            if(fileUpLoad!=null)
            {
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
                mn.linkImage = "~/Image/" + fileUpLoad.FileName.Trim();
            }
          
            
           
          
            bool check = new ProductDao().updateProduct(mn);
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
