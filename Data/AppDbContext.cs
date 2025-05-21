using Microsoft.EntityFrameworkCore;
using Target.Config;
using Target.Models;

namespace Target.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<DiaValorModel> DiaValores { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DiaValorConfig());
        }
    }
}
