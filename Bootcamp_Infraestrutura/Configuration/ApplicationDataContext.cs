using Microsoft.EntityFrameworkCore;
using Bootcamp_Domain.Models;
using System.Reflection;


namespace ProductAPI.Context
{
    public class ApplicationDataContext: DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        // public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
