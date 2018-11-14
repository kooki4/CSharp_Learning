using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Bede.Requests
{
    class HttpRequestWrapper
    {
        private RestRequest _restRequest;
        private RestClient _restClient;
        private string _server = ConfigurationManager.AppSettings["server"];

        public HttpRequestWrapper()
        {
            _restRequest = new RestRequest();
        }

        public HttpRequestWrapper SetResource(string resource)
        {
            _restRequest.Resource = resource;
            return this;
        }
        public HttpRequestWrapper SetMethod(Method method)
        {
            _restRequest.Method = method;
            return this;
        }
        public HttpRequestWrapper AddHeaders(IDictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                _restRequest.AddParameter(header.Key, header.Value, ParameterType.HttpHeader);
            }
            return this;
        }
        public HttpRequestWrapper AddJsonContent(object data)
        {
            _restRequest.RequestFormat = DataFormat.Json;
            _restRequest.AddHeader("Content-Type", "application/json");
            _restRequest.AddBody(data);
            return this;
        }
        public HttpRequestWrapper AddParameter(string name, object value)
        {
            _restRequest.AddParameter(name, value);
            return this;
        }
        public IRestResponse Execute()
        {
            try
            {
                _restClient = new RestClient(_server);
                var response = _restClient.Execute(_restRequest);
                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
