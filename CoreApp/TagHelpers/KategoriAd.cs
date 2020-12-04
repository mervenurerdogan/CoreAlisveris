using CoreApp.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.TagHelpers
{
    [HtmlTargetElement("getirKategoriAd")]
    public class KategoriAd :TagHelper
    {

      private readonly  IUrunRepository _urunRepository;
        public KategoriAd(IUrunRepository urunRepository)
        {//yapılandırıcı method ile reposityorden kaltım aldık
            _urunRepository = urunRepository;
        }

        public int UrunId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {//taghelper in process methodunu override  ettik

           string data = "";//geriye döneceğim veri 
           var gelenkategoriler= _urunRepository.GetirKategoriler(UrunId).Select(I => I.KategoriAD);//urun ıd ye göre kategor isimlerini getirdik
            foreach (var item in gelenkategoriler)
            {
                data += item + "";//döngü ile birden fazla kategori varsa aldık

            }

            output.Content.SetContent(data);
        }
    }
}
