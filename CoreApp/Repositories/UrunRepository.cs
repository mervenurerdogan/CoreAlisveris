using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreApp.Entities;
using CoreApp.Contexts;
using CoreApp.Interfaces;

namespace CoreApp.Repositories
{
    public class UrunRepository : GenericRepository<Urun>, IUrunRepository
    {
        private readonly IUrunKategoriRepository _urunkategoriRepository;
        public UrunRepository(IUrunKategoriRepository urunkategoriRepository)
        {
            _urunkategoriRepository = urunkategoriRepository;
        }
        public void EkleKategori(UrunKategoriTBL urunKategoriTBL)
        {
            var kontolKayit = _urunkategoriRepository.GetirFilteile(I => I.Kategorid == urunKategoriTBL.Kategorid && I.UrunId == urunKategoriTBL.UrunId);

            if (kontolKayit == null)
            {//eğer boşsa ekle

                _urunkategoriRepository.Ekle(urunKategoriTBL);
            }
        }

        public List<Urun> GetirKategoriIdile(int kategoriId)
        {
            //join sorgusu yazıyoruz
            //Urunler ile UrunKategori Tablosunu join etcez


            using var context = new CoreAppContext();
          return  context.Urunler.Join(context.UrunKategoriler, u => u.UrunID, uc => uc.UrunId, (urun, urunKategori) => new
            {
                Urun = urun,
                UrunKategori = urunKategori

            }).Where(I => I.UrunKategori.Kategorid == kategoriId).Select(
                I => new Urun
                {
                    UrunID = I.Urun.UrunID,
                    UrunAd = I.Urun.UrunAd,
                    Fiyat=I.Urun.Fiyat,
                    Resim=I.Urun.Resim

                }



                ).ToList();
        }

        public void SilKategori(UrunKategoriTBL urunKategoriTBL)
        {
            var kontolKayit = _urunkategoriRepository.GetirFilteile(I => I.Kategorid == urunKategoriTBL.Kategorid && I.UrunId == urunKategoriTBL.UrunId);

                if (kontolKayit != null)
            {//eğer boş değilse sil

                _urunkategoriRepository.Sil(kontolKayit);
            }

        }


        //ürünün kategorisini göstermek için inner join yazacağız

        //geri dönüş değeri olarak list aldık
        public List<Kategori> GetirKategoriler(int urunid)
        {
            //join sorgumuzu yazıyoruz

            using var context = new CoreAppContext();
            //önce ürünlerden gidip ara tablo ile birleştirme yapacağız
            //daha sonra kategori tablosuna gideceğiz
            return context.Urunler.Join(context.UrunKategoriler, urun => urun.UrunID, urunKategori => urunKategori.UrunId,
                 //ürün ile ürünkategoriler arasında bir ilişki oluştu
                 (u, uc) => new
                 {

                     urun = u,//urun için u 
                    urunKategori = uc//urun kategori için uc
                                     //şimdi de ürünkategorilerden kategorilerle join yapcaz
                }).Join(context.Kategoriler, iki => iki.urunKategori.Kategorid, kategori => kategori.KategoriID,

                 (uc, k) => new
                 {
                     urun = uc.urun,
                     kategori = k,
                     urunKategori = uc.urunKategori

                    //3 tablo birleşmşi oldu

                }

                 ).Where(I => I.urun.UrunID == urunid).Select(I => new Kategori
                 {

                     KategoriAD = I.kategori.KategoriAD,
                     KategoriID = I.kategori.KategoriID,


                 }).ToList();




        }

       
    }

}
