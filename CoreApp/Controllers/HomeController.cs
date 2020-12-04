using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Entities;
using CoreApp.Interfaces;
using CoreApp.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NLog;

namespace CoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISepetRepository _sepetRepository;
      private readonly SignInManager<AppUser> _signInManager;
      private readonly  IUrunRepository _urunRepository;
        public HomeController(IUrunRepository urunRepository,SignInManager<AppUser> signInManager, ISepetRepository sepetRepository)
        {
            _sepetRepository = sepetRepository;
            _signInManager = signInManager;
            _urunRepository = urunRepository;

        }
        public IActionResult Index(int ? kategoriID)
        {
            ViewBag.Kategorid = kategoriID;

            //    SetCookie("kişi", "Merve");
            //SetSession("kisi", "Merve");
            return View( /*_urunRepository.GetirListe()*/);
        }


        public IActionResult UrunDetay(int id)
        {
            //ViewBag.Cookie=GetCookies("kişi");
            //ViewBag.Session = GetSession("kisi");
            return View(_urunRepository.GetirIdile(id));
        }

        [HttpGet]
        public IActionResult GirisYap()
        {

            return View(new KulllaniciGirisModel());
        }

        [HttpPost]
        public IActionResult GirisYap(KulllaniciGirisModel model)
        {
            if (ModelState.IsValid)
            {
              var signInResult=  _signInManager.PasswordSignInAsync(model.KullaniciAdi, model.Sifre, model.Benihatirla, false).Result;

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new {  Area = "Admin" });

                }

                ModelState.AddModelError("", "Kullanıcı adı veya Şifre yanlış");

            }

           

            return View( model);
        }

        public IActionResult Sepet()
        {

            //sepetteki ürünler listelenir

            return View(_sepetRepository.GetirSepetUrunler());
        }
        public IActionResult SepeteEkle(int id)
        {
            var urun = _urunRepository.GetirIdile(id);

            _sepetRepository.SepeteEkle(urun);

            TempData["Bildirim"] = "Ürün sepete eklendi...";
            return RedirectToAction("Index");
        }

      

        public IActionResult SepetBosalt(decimal fiyat)
        {

            //alışverişi tamamla diyince sepeti boşaltıcak


            _sepetRepository.SepetiBosalt();

            return RedirectToAction("Tesekkur",new { fiyat=fiyat});
        }

        public IActionResult Tesekkur(decimal fiyat)
        {
            ViewBag.Fiyat = fiyat;
            return View();
        }

        public IActionResult SepettenCıkar(int id)
        {

            //sepete eklenen ürünü çıkartmak iptal etmek için yapıyoruz
            var cikacakUrun = _urunRepository.GetirIdile(id);
            _sepetRepository.SepettenCıkar(cikacakUrun);

            return RedirectToAction("Sepet");
        }

        public IActionResult NotFound(int code)
        {
            ViewBag.Code = code;

            return View();
        }
        [Route("/Error")]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var logger = LogManager.GetLogger("FileLogger");
            logger.Log(LogLevel.Error, $"\nHatanın Gerçeklelştiği Yer:  { errorInfo.Path} \n Hata Mesajı: {errorInfo.Error.Message } \n Stack Trace:{ errorInfo.Error.StackTrace}");

            return View();
        }

        //public void SetSession(string key, string value)
        //{

        //    HttpContext.Session.SetString(key,value);



        //}

        //public string GetSession(string key)
        //{
        //    return HttpContext.Session.GetString(key);
        //}



        //public void SetCookie(string key,string value)
        //{

        //    HttpContext.Response.Cookies.Append(key,value);
        //}

        //public string GetCookies(string key)
        //{
        //    HttpContext.Request.Cookies.TryGetValue(key, out string value);
        //    return value;

        //}



    }
}
