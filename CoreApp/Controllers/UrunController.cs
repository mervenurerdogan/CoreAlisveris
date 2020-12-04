using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using CoreApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            ITest test = new Test();

            ViewBag.Ad = test.GetirAd("merve");

            DpUrunRepository urunRepository = new DpUrunRepository();
            return View(urunRepository.GetirHepsi());
        }

        public IActionResult Index1()
        {

            DpUrunRepository urunRepository = new DpUrunRepository();
            return View(urunRepository.GetirHepsi());
        }

        public IActionResult Yeni()
        {

            ITest test = new Test();

            ViewBag.Ad = test.GetirAd("merve");

            return View();
        }

        public interface ITest{

            //interface oluşturduk
            //hiçbir intaerface örneklendirilemez 
            //yani bir clasta new yapamayız
            //ama bir nesne örneği ilgili interface implement ise o nesne den özellik alabilir.

            string GetirAd(string ad);

            }

        public  class Test : ITest
        {

            public string GetirAd(string ad)
            {
                return ad;
            }
            
        }

    }
}
