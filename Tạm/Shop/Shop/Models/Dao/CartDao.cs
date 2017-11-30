using Shop.Models.DTO;
using Shop.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Models.Dao
{
    public class CartDao

    {
         MyDB db = new MyDB();
        public CartDao()
        {

        }
        public List<Cart> getAllData()
        {

            List<Cart> lstCart = db.Carts.ToList();

            return lstCart;
        }
        public  long addCart(Cart pd)
        {
            try
            {
                db.Carts.Add(pd);
                db.SaveChanges();
                return pd.idCart;
            }
            catch
            {
                return 0;
            }
        }
        public  Cart getSinglData(long idCart)
        {
            return db.Carts.SingleOrDefault(x => x.idCart == idCart);
        }
        public  bool updateCart(Cart pd)
        {
            Cart pdx = db.Carts.Find(pd.idCart);
            try
            {
                pdx.amount = pd.amount;
                pdx.message = pd.message;
                pdx.payment = pd.payment;
                pdx.paymentInfor = pd.paymentInfor;
                pdx.status = pd.status;
                pdx.timeCreated = pd.timeCreated;
                pdx.userEmail = pd.userEmail;
               // pdx.userID = pd.userID;
                pdx.userName = pd.userName;
                pdx.userPhone = pd.userPhone;
                


                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public  bool deleteCart(long idCart)
        {
            Cart pd = db.Carts.Find(idCart);
            if (pd != null)
            {
                db.Carts.Remove(pd);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
        public CartDTO listCartDTO(long idcart)
        {
            var lst = (from pd in db.Products
                       join dc in db.DetailCarts on pd.idPD equals dc.idPD
                      where dc.idCart==idcart

                       select new ItemCartDTO
                       {
                           amount = dc.amount,
                           linkImg = pd.linkImage,
                           namePD = pd.TenPD,
                           price = pd.newPrice,
                           quantity=dc.quantity,
                          
                         
                      });
            decimal? tong = db.Carts.Find(idcart).amount;
            CartDTO crt = new CartDTO();
            crt.idCart = idcart;
            crt.total = tong;
            crt.lstItem = lst.ToList<ItemCartDTO>();
            return crt;
        }
}
}