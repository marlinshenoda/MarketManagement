using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MarketManagement.Core.Entities;

namespace MarketManagement.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MarketManagement.Core.Entities.Category> Category { get; set; } = default!;
        public DbSet<MarketManagement.Core.Entities.Product> Product { get; set; } = default!;
        public DbSet<MarketManagement.Core.Entities.Transaction> Transaction { get; set; } = default!;
    }
}
