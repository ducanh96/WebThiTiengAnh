namespace Shop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        [Key]
        public int idImg { get; set; }

        [Required]
        [StringLength(50)]
        public string linkImg { get; set; }

        public bool? active { get; set; }

        public int? idPD { get; set; }

        public virtual Product Product { get; set; }
    }
}
