using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagLibrary
{
    public static class UrlBuilder
    {
        public static string StopUrlBuilder(string lon, string lat, string dist)
        {
            string BaseUrl = "http://data.metromobilite.fr/api/linesNear/";
            string finalUrl = String.Format("{0}json?x={1}&y={2}&dist={3}&details=true", BaseUrl, lon, lat, dist);
            return finalUrl;
        }
        public static string LinesUrlBuilder(string linesDetails)
        {
            string BaseUrl = "http://data.metromobilite.fr/api/routers/default/index/routes?codes=";
               string finalUrl = String.Format("{0}{1}", BaseUrl, linesDetails);
            return finalUrl;
        }
    }
}
