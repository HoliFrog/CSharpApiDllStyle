using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagDlls;

namespace TagLibrary
{
    
    public class DataCallToDll
    {
        private IApiRequest _apiRequest;
        private RequestStringToDictionnary mRequestStringToDictionnary;
        private DisplayDataInConsole mDisplayDataInConsole;
       

        internal DataCallToDll(IApiRequest apiRequest)
        {
            this._apiRequest = apiRequest;
            mRequestStringToDictionnary = new RequestStringToDictionnary(_apiRequest);
            mDisplayDataInConsole = new DisplayDataInConsole();
        }
        
        public DataCallToDll()
            : this(new ApiRequest())
        {
        }
 

        public Dictionary<string, List<TransportLines>> CallToDll(string lonX, string latY, string distance)
        { 
            return mRequestStringToDictionnary.StringToDictionnary(rawStringResponse(lonX, latY, distance));
        }
        public string rawStringResponse(string lonX, string latY, string distance)
        {
            string Url = UrlBuilder.StopUrlBuilder(lonX, latY, distance);
            string rawString = _apiRequest.DoRequest(Url);
            return rawString;
        }

        public void DisplayDataCalled(string lonX, string latY, string distance)
        {
            mDisplayDataInConsole.DisplayLinesDetails(CallToDll(lonX, latY, distance));
        }
    }
}
