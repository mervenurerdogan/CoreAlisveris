using CoreApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoreApp.ViewComponents
{
    public class UrunList : ViewComponent
    {
       private readonly IUrunRepository _urunRepository;
        public UrunList(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }

        public IViewComponentResult Invoke(int? katagoriId)
        {

            if (katagoriId.HasValue)//değer var mı kontrol ediyoruz
            {

                return View(_urunRepository.GetirKategoriIdile((int)katagoriId));
            }

            return View(_urunRepository.GetirListe());
        }

    }
}
