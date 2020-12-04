using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.CustomExtension
{
    public static class CustomSessionExtension
    {

        // burda getObject ve SetObject methodları ile açılan session içnde liste olmasını sağlıycaz

        public static void SetObject <T>(this ISession session,string key,T value) where T:class,new()
        {
            var stringData = JsonConvert.SerializeObject(value);
            session.SetString(key,stringData);
        }

        public static T GetObject<T>(this ISession session,string key) where T : class, new()
        {
            var jsonData = session.GetString(key);
            if (!string.IsNullOrWhiteSpace(jsonData))//jsonData null yada boş değilse 
            {
                return JsonConvert.DeserializeObject<T>(jsonData);

            }


            return null;
        }
    }
}
