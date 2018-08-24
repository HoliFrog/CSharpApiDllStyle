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
            mRequestStringToDictionnary = new RequestStringToDictionnary();
            mDisplayDataInConsole = new DisplayDataInConsole();
        }
        
        public DataCallToDll()
            : this(new ApiRequest())
        {
        }

        string url = "http://data.metromobilite.fr/api/linesNear/json?x=5.728221&y=45.185692&dist=550&details=true";


        public Dictionary<string, List<string>> CallToDll()
        {
            string rawString = _apiRequest.DoRequest(url);
            Dictionary<string, List<string>> data = mRequestStringToDictionnary.StringToDictionnary(rawString);

            return data;
        }

        public void DisplayDataCalled()
        {
            mDisplayDataInConsole.Display(CallToDll());
        }
    }
}
