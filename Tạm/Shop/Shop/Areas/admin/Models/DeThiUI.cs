using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTiengAnhCode.Models
{
    public class DeThiUI
    {
        public DeThi dethi { get; set; }
        public User user { get; set; }
        public LoginUI loginUI{get;set;}

        public void TaoDeThi(int maTopic)
        {
            
        }
        public void SuaDeThi(DeThi dethi)
        {

        }
        public void ViewResult(int maDeThi)
        {

        }
        public int Thi(string tenthisinh, int madethi)
        {
            return 0;
        }
    }
}