using CoreApp.Entities;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Repositories
{
    public class DpUrunRepository
    {
        //kodun hızlı çalışmasını istiyorsak Dapper ORM ile bunu sağlayabiliriz

        public List<Urun> GetirHepsi()
        {

            using var connection = new SqlConnection("server=DESKTOP-SDCUEKN; database=CoreAppDB;integrated security=true;");
            return connection.GetAll<Urun>().ToList();


        }

    }
}
