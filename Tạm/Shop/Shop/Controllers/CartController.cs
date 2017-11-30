using Shop.Models.Dao;
using Shop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        CartDao cd = new CartDao();
        // GET: Cart
        public ActionResult ViewCart(long idCart)
        {
            CartDTO crt= cd.listCartDTO(idCart);
            return View();
        }
    }
}