using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTiengAnhCode.Models.Entities;

namespace WebTiengAnhCode.Models.EF
{
    public class LoginUI
    {
        public Admin admin { get; set; }

        public void DangNhap(Admin admin)
        {

        }
        public bool KiemTraDangNhap(Admin admin)
        {
            return false;
        }
    }
}