namespace WebTiengAnhCode.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChuDe")]
    public partial class ChuDe
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TenChuDe { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        public int? SoCauHoi { get; set; }
    }
}
