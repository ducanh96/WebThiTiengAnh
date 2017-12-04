namespace WebTiengAnhCode.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CauHoi")]
    public partial class CauHoi
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TieuDe { get; set; }

        [StringLength(50)]
        public string DapAnA { get; set; }

        [StringLength(50)]
        public string DapAnB { get; set; }

        [StringLength(50)]
        public string DapAnC { get; set; }

        [StringLength(50)]
        public string DapAnD { get; set; }

        [Required]
        [StringLength(50)]
        public string DapAn { get; set; }

        public int IDChiTietChuDe { get; set; }

        public virtual ChiTietChuDe ChiTietChuDe { get; set; }
    }
}
