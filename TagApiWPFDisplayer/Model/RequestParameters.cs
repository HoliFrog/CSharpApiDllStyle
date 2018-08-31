using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagApiWPFDisplayer.Model
{
    public class RequestParameters
    {
      

        public RequestParameters()
        {
            Long = "5.728221";
            Lat = "45.185692";
            Dist = "550";
        }

        public string Long
        
            { get; set; }
        

        public string Lat
    
           { get; set; }
        
        public string Dist
        
            { get; set; }
        
    }
}
