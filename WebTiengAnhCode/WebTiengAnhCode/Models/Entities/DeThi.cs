namespace WebTiengAnhCode.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeThi")]
    public partial class DeThi
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string MaDe { get; set; }

        public int? IDChuDe { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }

        public virtual ChuDe ChuDe { get; set; }
    }
}
