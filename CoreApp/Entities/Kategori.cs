using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Entities
{
    public class Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAD { get; set; }

        public List<UrunKategoriTBL> urunKategori { get; set; }

        
    }
}
