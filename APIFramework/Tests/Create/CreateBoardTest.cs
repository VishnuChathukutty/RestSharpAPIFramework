using APIFramework.Consts;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace APIFramework.Tests.Create
{
    public class CreateBoardTest : SetupFixture
    {
        private string _createdBoardId;

        [Test]
        public void CheckCreateBoard()
        {
            var boardName = "New Board" + DateTime.Now.ToLongTimeString();
            var request = RequestWithAuth(BoardEndPoints.CreateBoardUrl)
                .AddJsonBody(new Dictionary<string, string> { { "name", boardName } });
            var response = _client.Post(request);
            var responseContent = JToken.Parse(response.Content!);

            _createdBoardId = responseContent.SelectToken("id")?.ToString() ?? string.Empty;

            Assert.That(HttpStatusCode.OK, Is.EqualTo(response.StatusCode));
            Assert.That(boardName, Is.EqualTo(responseContent.SelectToken("name")?.ToString()), "Board name does not match");

            request = RequestWithAuth(BoardEndPoints.GetAllBoardsUrl)
                .AddQueryParameter("field", "id,name")
                .AddUrlSegment("member", UrlParamValues.UserName);
            response = _client.Get(request);
            responseContent = JToken.Parse(response.Content!);

            Assert.That(responseContent.Children().Select(token => token.SelectToken("name")).Contains(boardName), Is.True, "Board name matches in the list of boards");
        }

        [TearDown]
        public void DeleteCreatedBoard()
        {
            var request = RequestWithAuth(BoardEndPoints.DeleteBoardUrl)
                .AddUrlSegment("id", _createdBoardId);
            var response = _client.Delete(request);
            Assert.That(HttpStatusCode.OK, Is.EqualTo(response.StatusCode));
        }
    }
}
