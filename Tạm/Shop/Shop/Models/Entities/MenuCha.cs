namespace Shop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuCha")]
    public partial class MenuCha
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MenuCha()
        {
            MenuCons = new HashSet<MenuCon>();
        }

        [Key]
        public int idCha { get; set; }

        [StringLength(100)]
        public string TenMenuCha { get; set; }

        public bool isShow { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MenuCon> MenuCons { get; set; }
    }
}
