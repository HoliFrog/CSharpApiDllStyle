using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLibrary;

namespace TagDlls
{
    public class DisplayDataInConsole
    {
        public void DisplayLinesNearYou (Dictionary<string, List<string>> data)
        {
            foreach (var item in data)
            {
                string s = "name :" + item.Key + "\n \nLignes disponibles : \n";
                foreach (string line in item.Value)
                {
                    s += line + "\n";
                }
                Console.WriteLine(s);
            }
        }

        public void DisplayLinesDetails (Dictionary<string, List<TransportLines>> details)
        {
            foreach (var item in details)
            {
                Console.WriteLine("name :" + item.Key + "\n details de la Ligne : ");
                foreach (TransportLines line in details[item.Key])
                {
                    Console.WriteLine("Type : "+line.type+ " => "+"Ligne : "+ line.shortName+"(" +line.id+")");
                }

                Console.WriteLine();
            }
        }
        public void DisplayLinesUrl (List<string> url)
        {
            foreach (var item in url)
            {
                Console.WriteLine(item);
               
            }
        }

    }
}
