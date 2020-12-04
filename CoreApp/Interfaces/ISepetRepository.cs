using CoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Interfaces
{
    public interface ISepetRepository
    {
        void SepeteEkle(Urun urun);
        void SepettenCıkar(Urun urun);

        List<Urun> GetirSepetUrunler();

        void SepetiBosalt();
    }
}
