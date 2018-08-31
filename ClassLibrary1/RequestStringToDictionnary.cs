using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagLibrary
{
    internal class RequestStringToDictionnary
    {
        private IApiRequest _request;

        public RequestStringToDictionnary(IApiRequest request)
        {
            _request = request;
        }

        public string allLinesUrl(string responseFromServer)
        {
            List<TagCloserToYou> linesAround = JsonConvert.DeserializeObject<List<TagCloserToYou>>(responseFromServer);
           string ListLinesWithOutDuplicates = String.Empty;
            foreach (TagCloserToYou item in linesAround)
            {
                foreach (var line in item.lines)
                {
                    if (!ListLinesWithOutDuplicates.Contains(line))
                    {
                        ListLinesWithOutDuplicates += line+ ",";
                    }
                }
            }
            return ListLinesWithOutDuplicates.TrimEnd(new char[] { ',' });
        }




        public Dictionary<string, List<TransportLines>> StringToDictionnary(string responseFromServer)
        {
            string urlEnd = allLinesUrl(responseFromServer);
            List<TransportLines> transportLines = GetRoutesDetails(urlEnd);
            List<TagCloserToYou> linesAround = JsonConvert.DeserializeObject<List<TagCloserToYou>>(responseFromServer);
            Dictionary<string, List<TransportLines>> ListWithOutDuplicatesNames = new Dictionary<string, List<TransportLines>>();
            foreach (TagCloserToYou item in linesAround)
            {
                if (!ListWithOutDuplicatesNames.ContainsKey(item.name))
                {
                    ListWithOutDuplicatesNames.Add(item.name, new List<TransportLines>());
                    
                }
                foreach (var line in item.lines)
                {
                    foreach (var lineDetail in transportLines)
                    {
                        if (lineDetail.id == line && !ListWithOutDuplicatesNames[item.name].Contains(lineDetail))
                        {
                            ListWithOutDuplicatesNames[item.name].Add(lineDetail);
                        }
                    }
                }



                // ListWithOutDuplicatesNames[item.name].AddRange(item.lines.Where(_ => !ListWithOutDuplicatesNames[item.name].Contains(_)));

                //string linesForRoutesUrl = "";
                //foreach (var line in item.lines)
                //{
                //    if (!linesForRoutesUrl.Contains(line) && !ListWithOutDuplicatesNames[item.name].Any(_ => _.id == line))
                //    {
                //        linesForRoutesUrl += line + ",";
                //    }
                //}

                //if (!string.IsNullOrEmpty(linesForRoutesUrl))
                //{
                //    List<TransportLines> details = GetRoutesDetails(linesForRoutesUrl.TrimEnd(new char[] { ',' }));
                //    ListWithOutDuplicatesNames[item.name].AddRange(details);
                //}
            }

            return ListWithOutDuplicatesNames;
        }

        public List<TransportLines> GetRoutesDetails(string urlEnd)
        {
            if (!string.IsNullOrEmpty(urlEnd))
            {
            string url = UrlBuilder.LinesUrlBuilder(urlEnd);
            string detailFromServer = _request.DoRequest(url);
            return JsonConvert.DeserializeObject<List<TransportLines>>(detailFromServer);
            }
            else
            {
                return new List<TransportLines>();
            }
        }
    }
}
