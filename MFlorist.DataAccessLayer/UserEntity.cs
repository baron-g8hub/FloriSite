using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MFlorist.DataAccessLayer
{
    public partial class UserEntity : DbContext
    {
        public UserEntity()
            : base("name=UserEntity")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<User> Users { get; set; }
    }

}