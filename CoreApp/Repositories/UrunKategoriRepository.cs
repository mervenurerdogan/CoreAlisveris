using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreApp.Entities;
using CoreApp.Contexts;
using CoreApp.Interfaces;
using System.Linq;

namespace CoreApp.Repositories
{
    public class UrunKategoriRepository : GenericRepository<UrunKategoriTBL>, IUrunKategoriRepository
    {
        public UrunKategoriTBL GetirFilteile(Expression<Func<UrunKategoriTBL, bool>> expression)
        {
            using var context = new CoreAppContext();

          return  context.UrunKategoriler.FirstOrDefault(expression);
        }
    }
}
