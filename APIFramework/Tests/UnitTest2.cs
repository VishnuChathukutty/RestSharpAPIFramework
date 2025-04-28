using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Tests
{
    internal class UnitTest2
    {
        private static IRestClient _client;

        [OneTimeSetUp]
        public static void IntializeRestClient() =>
            _client = new RestClient("https://api.trello.com");

        [Test]
        public void Test2()
        {
            var request = new RestRequest();
            var response = _client.Get(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [OneTimeTearDown]
        public static void ClinetCleanUp() => _client.Dispose();
    }
}
