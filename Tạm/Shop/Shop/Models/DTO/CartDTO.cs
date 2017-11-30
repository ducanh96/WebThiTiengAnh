using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models.DTO
{
    public class CartDTO
    {
        public long idCart { get; set; }
        public List<ItemCartDTO> lstItem = new List<ItemCartDTO>();
        public decimal? total { get; set; }
    }
}