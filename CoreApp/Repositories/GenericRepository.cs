using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Contexts;


namespace CoreApp.Repositories
{
    public class GenericRepository<Tablo> where Tablo:class,new()
    {
        public void Ekle(Tablo tablo)
        {
            using var context = new CoreAppContext();
            context.Set<Tablo>().Add(tablo);
            context.SaveChanges();

        }

        public void Guncelle(Tablo tablo)
        {
            using var context = new CoreAppContext();
            context.Set<Tablo>().Update(tablo);
            context.SaveChanges();


        }

        public void Sil(Tablo tablo)
        {
            using var context = new CoreAppContext();
            context.Set<Tablo>().Remove(tablo);
            context.SaveChanges();


        }

        public List<Tablo> GetirListe()
        {
            using var context = new CoreAppContext();
            return context.Set<Tablo>().ToList();


        }

        public Tablo GetirIdile(int id)
        {
            using var context = new CoreAppContext();
            return context.Set<Tablo>().Find(id);


        }



    }
}
