using RestSharp;
using System.Collections.Generic;

namespace NbitcOinWagerrPlay2
{
    public class RestHelper
    {
        private IRestClient _client;
        private RestRequest _request;

        public RestHelper(string url, Method method)
        {
            _client = new RestClient(url);
            _request = new RestRequest(method);
        }

        public IRestResponse SendRequest(Dictionary<string, string> headers = null, Dictionary<string, string> parameters)
        {
            if (!headers.ContainsKey("content-type")) 
                headers.Add("content-type", "application/json");

            foreach (var header in headers) 
                _request.AddHeader(header.Key, header.Value);

            if (headers.ContainsValue("application/json") && _request.Method != Method.GET)
            {
                _request.RequestFormat = DataFormat.Json;
                _request.AddJsonBody(parameters);
            }

            if (parameters != null)
                foreach (var param in parameters)
                    _request.AddParameter(param.Key, param.Value);

            var response = _client.Execute(_request);
            return response;
        }
    }
}