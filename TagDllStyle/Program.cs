using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagDlls;
using TagLibrary;

namespace TagDllStyle
{
    class Program
    {

        static void Main(string[] args)
        {
            DataCallToDll call = new DataCallToDll();
            call.DisplayDataCalled();
        }
    }
}
