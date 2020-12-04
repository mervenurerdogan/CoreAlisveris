using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class UrunGuncelleModel
    {

        public int Urunid { get; set; }
        [Required(ErrorMessage = "Ürün Adı boş bırakılmaz")]
        public string UrunAdi { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Fiyat sıfırdan yüksek olmalıdır.")]
        public decimal UrunFiyat { get; set; }

        public IFormFile Resim { get; set; }
    }
}
