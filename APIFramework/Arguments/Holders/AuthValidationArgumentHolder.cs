using RestSharp;
using System.Globalization;

namespace APIFramework.Arguments.Holders
{
    public class AuthValidationArgumentHolder
    {
        public IEnumerable<Parameter> AuthParams { get; set; }
        public string ErrorMessage { get; set; }
    }
}
