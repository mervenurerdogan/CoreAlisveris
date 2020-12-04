using CoreApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Contexts
{
    public class CoreAppContext : IdentityDbContext <AppUser>
    {
        //on configure methodunu overide etttik
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer("server=DESKTOP-SDCUEKN; database=CoreAppDB;integrated security=true;"); //buraya yazdığımız sql adresi ile bağlantıyı sağlayabiliriz

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Urun>().HasMany(I => I.urunKategori).WithOne(I => I.Urun).HasForeignKey(I => I.UrunId);//Urun Kategoride tablosunda Urun tanımı
            modelBuilder.Entity<Kategori>().HasMany(I => I.urunKategori).WithOne(I => I.Kategori).HasForeignKey(I => I.Kategorid);//urunkategor tablosunda kategori tanımı

            //ındex ıd oluşturduk
            modelBuilder.Entity<UrunKategoriTBL>().HasIndex(I => new
            {

                I.Kategorid,
                I.UrunId
            }).IsUnique();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UrunKategoriTBL>().HasKey(I => I.UrunKategorID);
           }
        

        //tablolarımızı aldık
        public DbSet<UrunKategoriTBL> UrunKategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }

        public DbSet<Kategori> Kategoriler { get; set; }

    }
}
