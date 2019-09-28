using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Autothon.Core.RestSharp
{
    public class RestSharpManager
    {
        public void SendAPIRequest(HttpRequest httpRequest)
        {
            IRestClient restClient = new RestClient(httpRequest.Url);

        }
    }
}
