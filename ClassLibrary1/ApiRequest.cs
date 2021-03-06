﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TagLibrary
{
    internal class ApiRequest : IApiRequest
    {       
        public string DoRequest(string uri)
        {
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create(uri);
            // Get the response.
            WebResponse response = request.GetResponse();
            // DisplayLinesNearYou the status.
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
           
            return responseFromServer;
        }
    }
}
