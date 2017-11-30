namespace Shop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cart()
        {
            DetailCarts = new HashSet<DetailCart>();
        }

        [Key]
        public long idCart { get; set; }

        public int? status { get; set; }

        [StringLength(50)]
        public string userName { get; set; }

        [StringLength(50)]
        public string userEmail { get; set; }

        [StringLength(20)]
        public string userPhone { get; set; }

        public decimal? amount { get; set; }

        [StringLength(20)]
        public string payment { get; set; }

        [StringLength(250)]
        public string paymentInfor { get; set; }

        [StringLength(250)]
        public string message { get; set; }

        public DateTime? timeCreated { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailCart> DetailCarts { get; set; }
    }
}
