using System.Data.Entity;
using OrderEF6.Models;

namespace OrderEF6.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("name=OrderContext") { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Details)
                .WithRequired(d => d.Order)
                .WillCascadeOnDelete(true);
        }
    }
}
