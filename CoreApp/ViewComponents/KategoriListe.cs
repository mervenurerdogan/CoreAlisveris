using CoreApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.ViewComponents
{
    public class KategoriListe : ViewComponent
    {
       private readonly IKategoriRepository _kategoriRepository;
        public KategoriListe(IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }

        public IViewComponentResult Invoke()
        {

            return View(_kategoriRepository.GetirListe());
        }
    }
}
