using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MFlorist.DataAccessLayer
{
    public partial class FlowersdbEntities : DbContext
    {
        public FlowersdbEntities()
            : base("name=ProductsDbEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    }
}
