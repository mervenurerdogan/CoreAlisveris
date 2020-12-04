using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Entities;
using CoreApp.Interfaces;
using CoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KategoriController : Controller
    {
       private readonly IKategoriRepository _kategoriRepository;
        public KategoriController(IKategoriRepository kategoriRepository)
        {
                _kategoriRepository=kategoriRepository;
        }
        public IActionResult Index()
        {//listelenemsi
            return View(_kategoriRepository.GetirListe());
        }

        public IActionResult Ekle()
        {

            return View(new KategoriEkleModel());
        }

        [HttpPost]
        public IActionResult Ekle(KategoriEkleModel model)
        {

            if (ModelState.IsValid)
            {

                _kategoriRepository.Ekle(new Kategori
                {

                    KategoriAD = model.KategoriAd

                });

                return RedirectToAction("Index");

            }


            return View(model);
        }

        public IActionResult Guncelle(int id)
        {
            var gelenktg = _kategoriRepository.GetirIdile(id);
            KategoriGuncelleModel model = new KategoriGuncelleModel
            {

                KategoriId = gelenktg.KategoriID,
                KategoriAd = gelenktg.KategoriAD
            };


            return View(model);
        }

        [HttpPost]
        public IActionResult Guncelle(KategoriGuncelleModel model)
        {

            if (ModelState.IsValid)
            {
                var guncelleneckKategori = _kategoriRepository.GetirIdile(model.KategoriId);

                guncelleneckKategori.KategoriAD = model.KategoriAd;

                _kategoriRepository.Guncelle(guncelleneckKategori);

                return RedirectToAction("Index");

            }

            return View(model);


        }


        public IActionResult Sil(int id)
        {
            _kategoriRepository.Sil(new Kategori
            {

                KategoriID = id

            });

            return RedirectToAction("Index");
        }

    }
}
