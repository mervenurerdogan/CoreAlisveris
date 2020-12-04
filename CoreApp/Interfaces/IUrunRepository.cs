using CoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Interfaces
{
    public interface IUrunRepository:IGenericRepository<Urun>
    {

        public List<Kategori> GetirKategoriler(int urunid);

        void EkleKategori(UrunKategoriTBL urunKategoriTBL);
        void SilKategori(UrunKategoriTBL urunKategoriTBL);

        List<Urun> GetirKategoriIdile(int kategoriId);
    }
}
