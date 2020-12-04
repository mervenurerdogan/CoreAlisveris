using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Entities
{
    public class UrunKategoriTBL
    {
        public int UrunKategorID { get; set; }
        public int UrunId { get; set; }
        public Urun Urun { get; set; }

        public int Kategorid { get; set; }

        public Kategori Kategori { get; set; }
    }
}
