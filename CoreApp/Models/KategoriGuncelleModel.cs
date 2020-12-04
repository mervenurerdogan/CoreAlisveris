using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class KategoriGuncelleModel
    {

        public int KategoriId { get; set; }

        [Required(ErrorMessage ="Bu alan boş bırakılmaz")]
        public string KategoriAd { get; set; }
    }
}
