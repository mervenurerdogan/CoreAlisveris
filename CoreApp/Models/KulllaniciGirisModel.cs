using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class KulllaniciGirisModel
    {

        [Required(ErrorMessage ="Kullanıcı Adı Gerekli")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Şifre Gerekli")]
        public string Sifre { get; set; }
  
        public bool Benihatirla { get; set; }//buna cilick eden kullanıcı cookide belirledmiz süre boyunca hatırlanır
        //tıklamazsa hatırlanmaz

    }
}
