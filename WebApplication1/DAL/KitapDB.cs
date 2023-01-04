global using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.DAL
{
    public class KitapDB:DbContext
    {
       
        public KitapDB(DbContextOptions<KitapDB> options):base(options)
        {

        }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           
            //Birinci yontem...
           // optionsBuilder.UseSqlServer("Data source=.;initial catalog=BookDB;integrated security=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Kategori>().HasData(
                new Kategori { KategoriID = 1, KategoriAdi = "Roman" },
                new Kategori { KategoriID = 2, KategoriAdi = "Deneme" },
                new Kategori { KategoriID = 3, KategoriAdi = "Programlama" });
            modelBuilder.Entity<Kitap>().HasData(
                new Kitap { KitapID = 101, KitapAdi = "Denemeler", KategoriID = 2, Fiyat = 33 },
                new Kitap { KitapID = 105, KitapAdi = "Martin EDEN", KategoriID = 1, Fiyat = 66 },
                new Kitap { KitapID = 108, KitapAdi = "C# Baslangic", KategoriID = 3, Fiyat = 33 },
                new Kitap { KitapID = 109, KitapAdi = "Baslangic", KategoriID = 1, Fiyat = 55 }
                );
        }
    }
}
