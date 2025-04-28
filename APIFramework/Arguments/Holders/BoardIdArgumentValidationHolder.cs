
using RestSharp;
using System.Net;

namespace APIFramework.Arguments.Holders
{
    public class BoardIdArgumentValidationHolder
    {
        public IEnumerable<Parameter> PathParams { get; set; }
        public string ErrorMessage { get; set; }    
        public HttpStatusCode StatusCode    { get; set; }
    }
    public class BoardMemberArgumentValidationHolder
    {
        public IEnumerable<Parameter> PathParams { get; set; }
        public IEnumerable<Parameter> QueryParams { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
