using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models.DTO
{
    public class ItemCartDTO
    {
        public string linkImg { get; set; }
        public string namePD { get; set; }
        public decimal price { get; set; }
        public int? quantity { get; set; }
        public decimal? amount { get; set; }
      //  public decimal? total { get; set; }

    }
}