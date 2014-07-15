using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace FVTest
{
    public class JsonContentNegotiator : IContentNegotiator
    {
        private readonly JsonMediaTypeFormatter _jsonFormatter;

        public JsonContentNegotiator(JsonMediaTypeFormatter formatter)
        {
            _jsonFormatter = formatter;
        }

        public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {
            var result = new ContentNegotiationResult(_jsonFormatter, null); // , new MediaTypeHeaderValue("application/json"));
            return result;
        }
    }
}