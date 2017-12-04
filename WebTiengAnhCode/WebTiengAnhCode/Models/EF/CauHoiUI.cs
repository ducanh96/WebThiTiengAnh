using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTiengAnhCode.Models.Entities;

namespace WebTiengAnhCode.Models.EF
{
    public class CauHoiUI
    {
        public CauHoiUI cauhoi { get; set; }
        public LoginUI loginUI { get; set; }
        public List<CauHoi> dsCauHoi { get; set; }

        public void ThemCauHoi(CauHoi cauhoi)
        {

        }
        public void SuaCauHoi(CauHoi cauhoi)
        {

        }
        public void XoaCauHoi(int maCauhoi)
        {

        }
        public List<CauHoi> HienThiDSCauHoi(int macd)
        {
            return null;
        }
    }
}