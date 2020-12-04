using CoreApp.CustomExtension;
using CoreApp.Entities;
using CoreApp.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Repositories
{
    public class SepetRepository : ISepetRepository
    {
        // 1.httpcontext e ulşamak  istiyoruz ve bunu startup.cs de yapmaya başlıyoruz

        private readonly IHttpContextAccessor _httpContextAccessor;
        public SepetRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //ürürü sepete eklemek içn method yazıyoruz 

        public void SepeteEkle(Urun urun)
        {
            var gelenUrun = _httpContextAccessor.HttpContext.Session.GetObject<List<Urun>>("sepet");

            if (gelenUrun==null)//gelen liste boşsa ekle
            {
                gelenUrun = new List<Urun>();//önce bir örnek oluşturduk
                gelenUrun.Add(urun);

            }

            else
            {
                //doluysa da ekle
                gelenUrun.Add(urun);
            }

            _httpContextAccessor.HttpContext.Session.SetObject("sepet", gelenUrun);

        }

        public void SepettenCıkar(Urun urun)
        {
            var gelenUrun = _httpContextAccessor.HttpContext.Session.GetObject<List<Urun>>("sepet");
            gelenUrun.Remove(urun);
            _httpContextAccessor.HttpContext.Session.SetObject("sepet", gelenUrun);//çıkardıktan sonra listeyi set ediyoz

        }

        //sepete için liste almamız gerekitor 

        public List<Urun> GetirSepetUrunler()
        {

            return _httpContextAccessor.HttpContext.Session.GetObject<List<Urun>>("sepet");
        }


        public void SepetiBosalt()
        {

            _httpContextAccessor.HttpContext.Session.Remove("sepet");
        }

    }
}
