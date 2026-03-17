using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain.Entities;

namespace VehicleInventory.InfrastructureNS.Persistence
{
    public class NS_InventoryDbContext : DbContext
    {
        public NS_InventoryDbContext   (DbContextOptions<NS_InventoryDbContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleLocation> VehicleLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.LocationId).IsRequired();
                entity.Property(v => v.Status).IsRequired();
                
                entity.OwnsOne(v => v.VehicleCode, code =>
                {
                    code.Property(c => c.Value)
                        .HasColumnName("VehicleCode")
                        .IsRequired()
                        .HasMaxLength(50);
                });

                entity.OwnsOne(v => v.VehicleType, type =>
                {
                    type.Property(t => t.Value)
                        .HasColumnName("VehicleType")
                        .IsRequired()
                        .HasMaxLength(50);
                });

            });
     
            modelBuilder.Entity<VehicleLocation>(entity =>
            {
                entity.HasKey(l => l.Id);
                entity.Property(l => l.Name).IsRequired().HasMaxLength(100);
                entity.Property(l => l.City).IsRequired().HasMaxLength(100);
                entity.Property(l => l.Country).IsRequired().HasMaxLength(100);
            });
        }

    }
}
