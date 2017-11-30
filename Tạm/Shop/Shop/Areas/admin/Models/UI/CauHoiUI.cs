using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTiengAnhCode.Areas.admin.Models.UI
{
    public class CauHoiUI
    {
        
        public static List<CauHoi> getDSCauHoiDocPart1()
        {   
            return CauHoi.LayDSCauHoi(1);
        }
        public static bool delete(int ID)
        {
            return CauHoi.deleteCauHoi(ID);
        }
    }
}