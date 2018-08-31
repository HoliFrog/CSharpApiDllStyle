using System.Collections.Generic;
using System.ComponentModel;
using TagLibrary;

namespace TagApiWPFDisplayer.ViewModel
{
    internal class StationWithLinesAndDetails
    {
        public List<TransportLines> transportLines { get; set; }
        public string name { get; set; }
        
        public StationWithLinesAndDetails(string key, List<TransportLines> value)
        {
            this.name = key;
            this.transportLines = value;
        }
    }
}