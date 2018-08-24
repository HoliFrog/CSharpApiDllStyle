using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagDlls
{
    public class DisplayDataInConsole
    {
        public void Display (Dictionary<string, List<string>> data)
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
    }
}
