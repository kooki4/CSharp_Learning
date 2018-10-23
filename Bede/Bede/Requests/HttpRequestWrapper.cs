﻿using System;
using System.Collections.Generic;
using RestSharp;

namespace Bede.Requests
{
    class HttpRequestWrapper
    {
        private RestRequest _restRequest;
        private RestClient _restClient;

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
            _restRequest.AddHeader("Content type", "application/json");
            _restRequest.AddBody(data);
            return this;
        }
        public HttpRequestWrapper AddParameter(string name, object value)
        {
            _restRequest.AddParameter(name, value);
            return this;
        }
        public HttpRequestWrapper AddParameters(IDictionary<string, object> parameters)
        {
            foreach (var item in parameters)
            {
                _restRequest.AddParameter(item.Key, item.Value);
            }
            return this;
        }
    }
}
