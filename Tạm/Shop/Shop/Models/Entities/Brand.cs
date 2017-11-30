namespace Shop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Brand")]
    public partial class Brand
    {
        [Key]
        public int idBrand { get; set; }

        [StringLength(50)]
        public string linkImg { get; set; }
    }
}
