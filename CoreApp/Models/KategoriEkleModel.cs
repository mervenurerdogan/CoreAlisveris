using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CoreApp.Models
{
    public class KategoriEkleModel
    {
        [Required(ErrorMessage ="Kategori Ad Alanı Boş Bırakılamaz")]
        public string KategoriAd { get; set; }
    }
}
