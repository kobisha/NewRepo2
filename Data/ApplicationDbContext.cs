using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using marlin.Models;

namespace marlin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<marlin.Models.Accounts> Accounts { get; set; }
        public DbSet<marlin.Models.Catalogue> Catalogue { get; set; }
        public DbSet<marlin.Models.OrderHeader> OrderHeader { get; set; }
    }
}