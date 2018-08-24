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
        public Dictionary<string, List<string>> StringToDictionnary(string responseFromServer)
        {
            List<TagCloserToYou> linesAround = JsonConvert.DeserializeObject<List<TagCloserToYou>>(responseFromServer);
            Dictionary<string, List<string>> ListWithOutDuplicatesNames = new Dictionary<string, List<string>>();

            foreach (TagCloserToYou item in linesAround)
            {
                if (!ListWithOutDuplicatesNames.ContainsKey(item.name))
                {
                    ListWithOutDuplicatesNames.Add(item.name, new List<string>());
                }

                // ListWithOutDuplicatesNames[item.name].AddRange(item.lines.Where(_ => !ListWithOutDuplicatesNames[item.name].Contains(_)));

                foreach (var line in item.lines)
                {
                    if (!ListWithOutDuplicatesNames[item.name].Contains(line))
                    {
                        ListWithOutDuplicatesNames[item.name].Add(line);
                    }
                }
            }

            return ListWithOutDuplicatesNames;
        }
    }
}
