using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Entities;
using CoreApp.Interfaces;
using CoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Areas.Admin.Controllers
{
   //home controller karışmasın diye buranın admin olduğunu belirtiyoeuz
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {

       private readonly IUrunRepository _urunRepository;
       private readonly  IKategoriRepository _kategoriRepository;

        public HomeController(IUrunRepository urunRepository, IKategoriRepository kategoriRepository)
        {
            _urunRepository = urunRepository;
            _kategoriRepository = kategoriRepository;
        }
        public IActionResult Index()
        {//bu indexte yapmak istediğimiz sayfa açılır açılmaz ürünü listelmeek 
            return View(_urunRepository.GetirListe());
        }

        public IActionResult Ekle()
        {


            return View(new UrunEkleModel());
        }

       [HttpPost]
        public IActionResult Ekle(UrunEkleModel model)
        {
            if (ModelState.IsValid)
            {

                //kontrol ediyoruz doğru giriş yapıldı mı diye
                Urun urun = new Urun();
                if (model.Resim != null)
                {
                    //benzersiz resim yüklemek istiyorum
                    var path = Path.GetExtension(model.Resim.FileName);
                    var yeniResimAd = Guid.NewGuid() + path;
                    var resimYuklenecekYer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + yeniResimAd);
                    //resim null değilse resim yükle

                    var stream = new FileStream(resimYuklenecekYer, FileMode.Create);
                    model.Resim.CopyTo(stream);

                    urun.Resim = yeniResimAd;

                }

                
                urun.UrunAd = model.UrunAdi;
                urun.Fiyat = model.UrunFiyat;
             
                _urunRepository.Ekle(urun);


                return RedirectToAction("Index", "Home", new { area = "Admin" });

            }

            return View(new UrunEkleModel());
        }

    
        public IActionResult Guncelle(int id)
        {

            var gelenUrun = _urunRepository.GetirIdile(id);

            UrunGuncelleModel model = new UrunGuncelleModel
            {

                Urunid = gelenUrun.UrunID,
                UrunAdi = gelenUrun.UrunAd,
                UrunFiyat = gelenUrun.Fiyat
            };
       
            return View(model);
        }

        [HttpPost]
        public IActionResult Guncelle(UrunGuncelleModel model)
        {

            if (ModelState.IsValid)
            {//kontrol ediyoruz doğru giriş yapıldı mı diye


                var guncellnecekurun = _urunRepository.GetirIdile(model.Urunid);
                if (model.Resim != null)
                {
                    //benzersiz resim yüklemek istiyorum
                    var path = Path.GetExtension(model.Resim.FileName);
                    var yeniResimAd = Guid.NewGuid() + path;
                    var resimYuklenecekYer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + yeniResimAd);
                    //resim null değilse resim yükle

                    var stream = new FileStream(resimYuklenecekYer, FileMode.Create);
                    model.Resim.CopyTo(stream);

                    guncellnecekurun.Resim = yeniResimAd;

                }

                guncellnecekurun.UrunID = model.Urunid;
                guncellnecekurun.UrunAd = model.UrunAdi;
                guncellnecekurun.Fiyat = model.UrunFiyat;

                _urunRepository.Guncelle(guncellnecekurun);


                return RedirectToAction("Index", "Home", new { area = "Admin" });

            }

            return View(model);
        }


        public IActionResult Sil(int id)
        {

            _urunRepository.Sil(new Urun
            {

                UrunID = id

            });

            return RedirectToAction("Index");

        }

        //katagori ekleme işlemi için checkboxlar için 

        public IActionResult AtaKategori(int id)
        {
            var urunAitKategoriler = _urunRepository.GetirKategoriler(id).Select(I=>I.KategoriAD);
            var kategoriler = _kategoriRepository.GetirListe();//bütün katagoriler gelecek

            TempData["UrunId"] = id;

            List<KategoriAtaModel> list = new List<KategoriAtaModel>();

            foreach (var item in kategoriler)
                //bütün katageoriler gelecek ürüne ait olanları seçecek
            {
                KategoriAtaModel model = new KategoriAtaModel();

                model.KategoriID = item.KategoriID;
                model.KategoriAd = item.KategoriAD;
                model.Varmi = urunAitKategoriler.Contains(item.KategoriAD);

                list.Add(model);
            }

            return View(list);
        }

        [HttpPost]
        public IActionResult AtaKategori(List<KategoriAtaModel> list)
        {
            int UrunID = (int)TempData["UrunId"];
            foreach (var item in list)
            {
                if (item.Varmi)
                {//chechbox alanı click edilmiş mi kontrol edecek eğer click edildi ise ekle


                    _urunRepository.EkleKategori(new UrunKategoriTBL
                    {
                        Kategorid = item.KategoriID,
                        UrunId = UrunID

                    });

                }

                else
                {

                    //eğer alan zaten click edildi ise ikinci clikde silinmiş olacak
                    _urunRepository.SilKategori(new UrunKategoriTBL
                    {
                        Kategorid = item.KategoriID,
                        UrunId = UrunID

                    });
                }

            }

            return RedirectToAction("Index");


        }



    }
}
