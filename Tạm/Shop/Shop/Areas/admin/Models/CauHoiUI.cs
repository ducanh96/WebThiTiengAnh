using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTiengAnhCode.Areas.admin.Models.UI
{
    public class CauHoiUI
    {
        
        public static List<CauHoi> HienThiDSCauHoi(int maTopic) //1 la chu de doc tu vung
        {
            return CauHoi.LayDSCauHoi(maTopic);
        }
        public static bool delete(int ID)
        {
            return CauHoi.deleteCauHoi(ID);
        }
    }
}