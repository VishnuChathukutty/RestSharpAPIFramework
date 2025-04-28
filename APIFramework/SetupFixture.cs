using APIFramework.Consts;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework
{
    public class SetupFixture
    {
        public static IRestClient _client;

        [OneTimeSetUp]

        public static void IntializeRestClient()
        {
            var options= new RestClientOptions("https://api.trello.com")
            {
                ThrowOnAnyError = false,
              
            };
            _client = new RestClient(options);
        }

        protected RestRequest RequestWithAuth(string url) =>
           RequestWithoutAuth(url).AddOrUpdateParameters(UrlParamValues.AuthQueryParams);
           //    .AddQueryParameter("key", "")
           //.AddQueryParameter("", "");

        protected RestRequest RequestWithoutAuth(string url) =>
          new RestRequest(url);



        [OneTimeTearDown]
        public static void ClinetCleanUp() => _client.Dispose();

        public RestClientOptions Options()=>
             new RestClientOptions("https://api.trello.com")
            {
                ThrowOnAnyError = false,
                
            };

    }
}
