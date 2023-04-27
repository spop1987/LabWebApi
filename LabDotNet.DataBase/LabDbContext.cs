using LabDotNet.Models.Entities;
using LabDotNet.Models.Entities.TypeConfig;
using Microsoft.EntityFrameworkCore;

namespace LabDotNet.DataBase
{
    public class LabDbContext : DbContext
    {
        public LabDbContext(DbContextOptions<LabDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ConfigureAllTypeConfig();
    }
}