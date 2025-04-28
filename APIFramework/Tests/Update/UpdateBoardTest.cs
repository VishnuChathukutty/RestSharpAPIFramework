using APIFramework.Consts;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace APIFramework.Tests.Update
{
    internal class UpdateBoardTest:SetupFixture
    {
        [Test]
        public void CheckUpdateBoard()
        {
            var updatedName = "Updated Name" + DateTime.Now.ToLongTimeString();
            var request = RequestWithAuth(BoardEndPoints.UpdateBoardUrl)
                .AddUrlSegment("id", UrlParamValues.BoardIdToUpdate)
                .AddJsonBody(new Dictionary<string, string> { { "name", updatedName } });
            var response = _client.Put(request);

            var responseContent = JToken.Parse(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(updatedName, responseContent.SelectToken("name").ToString());

            request = RequestWithAuth(BoardEndPoints.GetBoardUrl)
                .AddUrlSegment("id", UrlParamValues.BoardIdToUpdate);
            response = _client.Get(request);
            responseContent = JToken.Parse(response.Content);
            Assert.AreEqual(updatedName, responseContent.SelectToken("name").ToString());
        }
    }
}
