using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTiengAnhCode.Models
{
    public class Admin
    {
        public string tendangnhap { get; set; }
        public string matkhau { set; get; }
        public bool KiemTraTaiKhoan(string username, string password)
        {
            return false;
        }
        public void SetSession(Admin admin)
        {
            
        }
    }
}