using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTiengAnhCode.Areas.admin.Models;

namespace WebTiengAnhCode.Models
{
    public class Topic
    {
        public string tenTopic { get; set; }
        public int soCauHoi { get; set; }
        public List<CauHoi> dsCauHoi { get; set; }
        public List<Topic> dsTopic { get; set; }
        public int maTopic { get; set; }
        public void XemDSCauHoiTrongTopic(int maTopic)
        {

        }
        public bool ThemTopic(Topic topic)
        {
            return false;
        }
        public bool SuaTopic(Topic topic)
        {
            return false;
        }
        public bool XoaTopic(int maTopic)
        {
            return false;
        }
    }
}