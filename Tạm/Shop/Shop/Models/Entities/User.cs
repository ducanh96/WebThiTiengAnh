namespace Shop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Carts = new HashSet<Cart>();
        }

        [Key]
        [StringLength(50)]
        public string userName { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [StringLength(250)]
        public string fullName { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(250)]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthDay { get; set; }

        public byte? Quyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual Quyền Quyền { get; set; }
    }
}
