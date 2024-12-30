using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OgrenciBilgilendirmeApp.Model;

namespace OgrenciBilgilendirmeApp.Context
{
    internal class ObsDbContext : DbContext
    {

        public DbSet<Ogrenciler>? Ogrencilers { get; set; }
        public DbSet<Siniflar>? Siniflars { get; set; }
        public DbSet<OgrenciDersler>? OgrenciDerslers { get; set; }
        public DbSet<Dersler>? Derslers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=ObsDb;Integrated Security=true;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OgrenciDersler>()
       .HasKey(od => new { od.OgrenciId, od.DersId });

            modelBuilder.Entity<OgrenciDersler>()
                .HasOne(od => od.Dersler)
                .WithMany(d => d.derslers)
                .HasForeignKey(od => od.DersId);

            modelBuilder.Entity<OgrenciDersler>()
                .HasOne(od => od.Ogrenciler)
                .WithMany(o => o.ogrenciDerslers)
                .HasForeignKey(od => od.OgrenciId);

            modelBuilder.Entity<Ogrenciler>()
                .HasOne(o => o.Siniflar)
                .WithMany(s => s.ogrencilers)
                .HasForeignKey(o => o.SinifId);
        }
    }
}
