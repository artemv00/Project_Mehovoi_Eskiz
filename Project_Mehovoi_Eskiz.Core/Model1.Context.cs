//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_Mehovoi_Eskiz.Core
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("name=DBConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<accessory> accessories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Cat_product> Cat_product { get; set; }
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<Custom> Customs { get; set; }
        public virtual DbSet<Default_Size> Default_Size { get; set; }
        public virtual DbSet<furriery_n_fabrics> furriery_n_fabrics { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Order_Position> Order_Position { get; set; }
        public virtual DbSet<Order_Status> Order_Status { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Polzovatel> Polzovatels { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Cart_pos> Cart_pos { get; set; }
        public virtual DbSet<Payed_Orders> Payed_Orders { get; set; }
    }
}
