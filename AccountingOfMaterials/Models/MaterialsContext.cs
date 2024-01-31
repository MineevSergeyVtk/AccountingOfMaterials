using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace AccountingOfMaterials.Models
{
    public class MaterialsContext : DbContext
    {
        public DbSet<Material> Materials { get; set; } = null!;
        public DbSet<GroupOfMaterial> GroupOfMaterials { get; set; } = null!;
        public MaterialsContext(DbContextOptions<MaterialsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().HasKey(u => u.Name);
            modelBuilder.Entity<GroupOfMaterial>().HasKey(u => u.Name);
            modelBuilder.Entity<Material>().Property(u => u.Name).ValueGeneratedNever();
            modelBuilder.Entity<GroupOfMaterial>().Property(u => u.Name).ValueGeneratedNever();

        }
    }
}
