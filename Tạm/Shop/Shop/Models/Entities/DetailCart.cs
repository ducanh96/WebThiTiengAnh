namespace Shop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetailCart")]
    public partial class DetailCart
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long idCart { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPD { get; set; }

        public int? quantity { get; set; }

        public decimal? amount { get; set; }

        public int? status { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Product Product { get; set; }
    }
}
