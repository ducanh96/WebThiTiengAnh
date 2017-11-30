namespace Shop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuCon")]
    public partial class MenuCon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MenuCon()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int idCon { get; set; }

        [StringLength(100)]
        public string TenMenuCon { get; set; }

        public int? idCha { get; set; }

        public bool isShow { get; set; }

        public virtual MenuCha MenuCha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
