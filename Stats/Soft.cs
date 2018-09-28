using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Soft
    {
        static string url;

        public static string GetURL(string user, string platform)
        {
            url = "https://api./api/v1/players/" + user + "/?platform=" + platform;
            return url;
        }
    }
}
