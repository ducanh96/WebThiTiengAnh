namespace WebTiengAnhCode.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietChuDe")]
    public partial class ChiTietChuDe
    {
        public int ID { get; set; }

        [Column(TypeName = "text")]
        public string NoiDung { get; set; }

        public int? IDChuDe { get; set; }

        public virtual ChuDe ChuDe { get; set; }
    }
}
