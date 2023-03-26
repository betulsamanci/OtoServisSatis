using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Entities;

namespace OtoServisSatis.Data
{
    public class DatabaseContext:DbContext

    {
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Servis> Servisler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(LocalDB)\MSSQLLocalDB; database=OtoServisSatisNetCore; integrated security=True; MultipleActiveResultsSets=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   //FLUENT API 
            modelBuilder.Entity<Marka>().Property(m => m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().Property(m => m.Adi).IsRequired().HasColumnType("varchar(50)");

            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id= 1,
                Adi="Admin"
            });
            modelBuilder.Entity<Kullanici>().HasData(new Kullanici
            {
                Id= 1,
                Adi = "Admin",
                AktifMi=true,
                EklenmeTarihi=DateTime.Now,
                Email="betulsmncc@icloud.com",
                KullaniciAdi="admin",
                Sifre="123456",
               // Rol=new Rol { Id= 1},
                RolId=1,
                Soyadi="admin",
                Telefon="085055"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
