using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Interfaces
{
   public interface IGenericRepository<Tablo> where Tablo:class,new()
    {
        //generic repository clasındaki methodları alıp buraya yapıştırıyoruz
        void Ekle(Tablo tablo);
        void Sil(Tablo tablo);

        void Guncelle(Tablo tablo);

         List<Tablo> GetirListe();

        Tablo GetirIdile(int id);


    }
}
