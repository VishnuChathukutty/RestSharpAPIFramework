using RestSharp;
using System.Net;

namespace APIFramework.Tests
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            var request = new RestRequest();
            var client = new RestClient("https://api.trello.com");
            var response = client.Get(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }
    }
}