using FixxoApi2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FixxoApi2.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
    }
}
