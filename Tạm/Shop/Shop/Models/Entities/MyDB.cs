namespace Shop.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDB : DbContext
    {
        public MyDB()
            : base("name=MyDB")
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<DetailCart> DetailCarts { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<MenuCha> MenuChas { get; set; }
        public virtual DbSet<MenuCon> MenuCons { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Quyền> Quyền { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.userEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.userPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.amount)
                .HasPrecision(15, 4);

            modelBuilder.Entity<Cart>()
                .Property(e => e.payment)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .HasMany(e => e.DetailCarts)
                .WithRequired(e => e.Cart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DetailCart>()
                .Property(e => e.amount)
                .HasPrecision(15, 4);

            modelBuilder.Entity<Image>()
                .Property(e => e.linkImg)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.oldPrice)
                .HasPrecision(15, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.newPrice)
                .HasPrecision(15, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.linkImage)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.DetailCarts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.linkImg)
                .IsUnicode(false);
        }
    }
}
