using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTiengAnhCode.Areas.admin.Models
{
    public class CauHoi
    {
        public int ID { get; set; }
        public string TieuDe { get; set; }
        public string DapAnA { get; set; }
        public string DapAnB { get; set; }
        public string DapAnC { get; set; }
        public string DapAnD { get; set; }
        public string DapAn { get; set; }
        private static List<CauHoi> lst = new List<CauHoi>()
        { new CauHoi()
                {
                    ID = 1,
                    TieuDe = "Tiêu đề câu hỏi " + 1,
                    DapAnA = "Đáp án A câu số " + 1,
                    DapAnB = "Đáp án B câu số " + 1,
                    DapAnC = "Đáp án C câu số " + 1,
                    DapAnD = "Đáp án D câu số " + 1,
                    DapAn = "Đáp án câu " + 1
                },
             new CauHoi()
                {
                    ID = 2,
                    TieuDe = "Tiêu đề câu hỏi " + 2,
                    DapAnA = "Đáp án A câu số " + 2,
                    DapAnB = "Đáp án B câu số " + 2,
                    DapAnC = "Đáp án C câu số " + 2,
                    DapAnD = "Đáp án D câu số " + 2,
                    DapAn = "Đáp án câu " + 2
                },
              new CauHoi()
                {
                    ID = 3,
                    TieuDe = "Tiêu đề câu hỏi " + 3,
                    DapAnA = "Đáp án A câu số " + 3,
                    DapAnB = "Đáp án B câu số " + 3,
                    DapAnC = "Đáp án C câu số " + 3,
                    DapAnD = "Đáp án D câu số " + 3,
                    DapAn = "Đáp án câu " + 3
                },
               new CauHoi()
                {
                    ID = 4,
                    TieuDe = "Tiêu đề câu hỏi " + 4,
                    DapAnA = "Đáp án A câu số " + 4,
                    DapAnB = "Đáp án B câu số " + 4,
                    DapAnC = "Đáp án C câu số " + 4,
                    DapAnD = "Đáp án D câu số " + 4,
                    DapAn = "Đáp án câu " + 4
                },
                 new CauHoi()
                {
                    ID = 5,
                    TieuDe = "Tiêu đề câu hỏi " + 5,
                    DapAnA = "Đáp án A câu số " + 5,
                    DapAnB = "Đáp án B câu số " + 5,
                    DapAnC = "Đáp án C câu số " + 5,
                    DapAnD = "Đáp án D câu số " + 5,
                    DapAn = "Đáp án câu " + 5
                },
                };

        public static  List<CauHoi> LayDSCauHoi(int MaTopic)
        {
            return lst;
        }
        public static bool deleteCauHoi(int ID)
        {
            int i = CauHoi.lst.FindIndex(x => x.ID == ID);
            if (i > -1)
            {
                CauHoi.lst.RemoveAt(i);
                return true;
            }
            else return false;
        }
    }
  

}