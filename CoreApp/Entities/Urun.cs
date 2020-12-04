using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Entities
{

    [Dapper.Contrib.Extensions.Table("Urunler")]
    public class Urun : IEquatable<Urun>
    {

        public int UrunID { get; set; }
        [MaxLength(100)]
        public string UrunAd { get; set; }
        [MaxLength(250)]
        public string Resim { get; set; }

        public decimal Fiyat { get; set; }

        public List<UrunKategoriTBL> urunKategori { get; set; }

        public bool Equals([AllowNull] Urun other)
        {
            return UrunID == other.UrunID && UrunAd == other.UrunAd && Resim == other.Resim && Fiyat == other.Fiyat;
        }
    }
}
