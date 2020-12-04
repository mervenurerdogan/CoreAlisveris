using System;
using System.Linq.Expressions;

using CoreApp.Entities;


namespace CoreApp.Interfaces
{
   public  interface IUrunKategoriRepository:IGenericRepository<UrunKategoriTBL>
    {
        UrunKategoriTBL GetirFilteile(Expression<Func<UrunKategoriTBL, bool>> expression);
      
    }
}
