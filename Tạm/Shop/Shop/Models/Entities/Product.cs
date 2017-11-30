namespace Shop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            DetailCarts = new HashSet<DetailCart>();
            Images = new HashSet<Image>();
        }

        [Key]
        public int idPD { get; set; }

        [Required]
        [StringLength(100)]
        public string TenPD { get; set; }

        public string Information { get; set; }

        public decimal? oldPrice { get; set; }

        public decimal newPrice { get; set; }

        [StringLength(150)]
        public string linkImage { get; set; }

        public bool? PromotionPD { get; set; }

        public bool? HotPD { get; set; }

        public bool active { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datePost { get; set; }

        public int? idCon { get; set; }

        public long? Statistics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailCart> DetailCarts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Images { get; set; }

        public virtual MenuCon MenuCon { get; set; }
    }
}
