using CoreApp.Contexts;
using CoreApp.Entities;
using CoreApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Repositories
{
    public class KategoriRepository : GenericRepository<Kategori>,IKategoriRepository
    //kalıtım ile Generic repositoryden geçicek Generic design pattern kullandık
    {

    }
}
