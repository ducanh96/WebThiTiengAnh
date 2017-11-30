using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models._Cart
{
    public class SCart

    {
        public List<ItemCart> ListItem = new List<ItemCart>();

        public void AddItem(int ID, string Name, int Amount, double Price)
        {  
            int pos = ListItem.FindIndex(x => x.ID == ID);
            if (pos > -1)
            {
                ListItem[pos].Quantity++;
            }
            else
            {
                ItemCart item = new ItemCart();
                item.ID = ID;
                item.Name = Name;
                item.Price = Price;
                item.Quantity = Amount;
                ListItem.Add(item);
            }
        }

        public void IncQuantity(int ID,int quan)
        {
            ListItem.Find(x => x.ID == ID).Quantity+=quan;
        }
        public void updateQuantity(int ID, int quan)
        {
            ListItem.Find(x => x.ID == ID).Quantity = quan;
        }
        public void Delete(int ID)
        {
            int pos = ListItem.FindIndex(x => x.ID == ID);
            ListItem.RemoveAt(pos);
        }
        public double GetTotalCart()
        {
            double Total = 0;
            foreach (var itemTmp in ListItem)
            {
                Total += itemTmp.GetTotal();
            }
            return Total;
        }
        public int GetAmount()
        {
            int Amount = 0;
            foreach (var itemTmp in ListItem)
            {
                Amount += itemTmp.Quantity;
            }
            return Amount;
        }
        public List<ItemCart> GetAllData()
        {
            return ListItem;
        }
        public ItemCart GetDataById(int id)
        {
            return ListItem.Find(x => x.ID == id);
        }
    }
}