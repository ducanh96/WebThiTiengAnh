using Shop.Models._Cart;
using Shop.Models.Dao;
using Shop.Models.DTO;
using Shop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Menu()
        {

            ViewData["lstMenu"] = new MenuChaDao().getAllData();
            return View();
        }
        public ActionResult Index()
        {
            ProductDao pdd = new ProductDao();
            ViewBag.index = "class=active";
            ViewData["lst"] = pdd.getAllData();
            ViewData["lstTopSeller"] = pdd.getTopSeller();
            ViewData["lstTopNew"] = pdd.getTopNew();
            ViewData["lstHotPD"] = pdd.getHotPd();
            ViewData["lstBrand"] = new BrandDao().getAllData();

            //ViewData["lst1"] = Product.getAllseller();
            return View();
        }
        public ActionResult Shop(int id)
        {
            ViewBag.shop = "class=active";
            ProductDao pdd = new ProductDao();
            if (id == 0)
            {
                ViewData["lst"] = pdd.getAllData();
            }
            else if (id == 1)
            {
                ViewData["lst"] = pdd.getTopSeller();
            }
            else if (id == 3)
            {
                ViewData["lst"] = pdd.getTopNew();
            }
            else if (id == 2)
            {
                ViewData["lst"] = pdd.getHotPd();
            }

            return View();
        }
        public ActionResult SingleProduct(int idPD)
        {

            ProductDao pdd = new ProductDao();
            Product pd = new ProductDao().getSinglData(idPD);
            if (pd == null) pd = new ProductDao().getSinglData(10);
            ViewBag.single = "class=active";
            ViewData["lst"] = pdd.getAllData();

            ViewData["lstTopNew"] = pdd.getTopNew();
            ViewData["lstRelatedPD"] = pdd.getRelatedPD(pd.idCon);
            return View(pd);
        }
        public ActionResult CheckOut()
        {
            ViewBag.checkOut = "class=active";
            ProductDao pdd = new ProductDao();
            ViewData["lst"] = pdd.getAllData();

            ViewData["lstTopNew"] = pdd.getTopNew();
            return View();
        }



        /// <summary>
        /// phần CART
        /// </summary>
        [HttpPost]
        public ActionResult incQuantity(FormCollection collection)
        {
            //DetailCartDao dtc = new DetailCartDao();
            //dtc.updateDetailCart()
            //ViewBag.cart = "class=active";


            //// GET: Cart

            //CartDTO lst = cd.listCartDTO(idCart);
            int dem = 0;
            SCart cart = (SCart)Session["cart"];
            if (cart == null)
                cart = new SCart();
            foreach (ItemCart c in cart.ListItem)
            {
                int x = int.Parse(collection[dem].ToString());
                dem++;
                cart.updateQuantity(c.ID, x);
            }

            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        //   form add cart
        [HttpPost]
        public ActionResult addItemCart_form(int idPD,int quantity)
        {
            SCart cart = (SCart)Session["cart"];
            if (cart == null)
                cart = new SCart();

            ProductDao dao = new ProductDao();
            Product pro = new ProductDao().getSinglData(idPD);
            cart.AddItem(pro.idPD, pro.TenPD, quantity, (double)pro.newPrice);

            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Cart()
        {
            ProductDao pdd = new ProductDao();
            int? idCon = 1;

            ViewBag.cart = "class=active";
            SCart cart = (SCart)Session["cart"];
            //List<ItemCart> lst = new List<ItemCart>();
            if (cart == null)
            {
                cart = new SCart();

            }
            else
            {
                Product pd = new ProductDao().getSinglData(cart.ListItem[0].ID);
                idCon = pd.idCon;
            }

            Session["cart"] = cart;
            ViewData["lst"] = pdd.getAllData();

            ViewData["lstTopNew"] = pdd.getTopNew();

            ViewData["lstRelatedPD"] = pdd.getRelatedPD(idCon);
            return View(cart);
        }
        public ActionResult addItemCart(int idPD)
        {
            SCart cart = (SCart)Session["cart"];
            if (cart == null)
                cart = new SCart();

            ProductDao dao = new ProductDao();
            Product pro = new ProductDao().getSinglData(idPD);
            cart.AddItem(pro.idPD, pro.TenPD, 1, (double)pro.newPrice);

            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult deleteItemCart(int idPD)
        {
            SCart cart = (SCart)Session["cart"];
            if (cart == null)
                cart = new SCart();
            Product pro = new ProductDao().getSinglData(idPD);
            cart.Delete(pro.idPD);

            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Category(int idCha)
        {
            ProductDao dao = new ProductDao();
            ViewBag.category = "class=active";
            ViewData["lstNhom"] = dao.getDataByIdCha(idCha);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}