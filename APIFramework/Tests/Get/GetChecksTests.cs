using APIFramework.Arguments.Holders;
using APIFramework.Arguments.Providers;
using APIFramework.Consts;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Tests.Get
{
    internal class GetChecksTests : SetupFixture
    {



        [Test]
        public void TestGetApiCheckBoards()
        {
            var request = RequestWithoutAuth("/1/members/{member}/boards")
                .AddQueryParameter("key", "")
            .AddQueryParameter("", "")//tok
              .AddUrlSegment("member", "vishnuchathukutty");//path parameter
            var response = _client.Get(request);
        }
        [Test]
        public void TestBoardName()
        {
            var request = RequestWithAuth("/1/boards/{id}")
                .AddUrlSegment("id", "67f4349ba322325795e05b93");
            var response = _client.Get(request);
            var content = response.Content;
            var boardName = JToken.Parse(response.Content!).SelectToken("name")?.ToString();
            Assert.That("TestBoard", Is.EqualTo(boardName), "Board name does not match");
        }

        [Test]
        public void CheckBoardsJsonSchemaValidation()//jsonSchema validation
        {
            var request = RequestWithAuth("/1/members/{member}/boards").
                AddQueryParameter("field", "id").
                AddUrlSegment("member", "vishnuchathukutty");
            var response = _client.Get(request);

            Assert.That(HttpStatusCode.OK, Is.EqualTo(response.StatusCode));
            var responseContent = JToken.Parse(response.Content!);
            string workingDirectory = Directory.GetCurrentDirectory();
            string parentDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName ?? "";

            var jsonSchema = JSchema.Parse(File.ReadAllText(parentDirectory + "\\JsonSchemas\\get_boards.json"));
            Assert.That(responseContent.IsValid(jsonSchema), Is.True, "Response does not match the schema");


        }

        [Test]
        [TestCaseSource(typeof(BoardIdArgumentValidationProvider))]
        public void CheckBoardWithInvalidId(BoardIdArgumentValidationHolder validationaArguments) //paramterized testid
        {

            var request = RequestWithAuth("/1/boards/{id}")
                .AddOrUpdateParameters(validationaArguments.PathParams);
            var response = _client.Get(request);
            Assert.That(response.StatusCode, Is.EqualTo(validationaArguments.StatusCode));
            Assert.That(response.Content, Is.EqualTo(validationaArguments.ErrorMessage));
        }

        [Test]
        [TestCaseSource(typeof(BoardMemberArgumentValidationProvider))]
        public void CheckBoardsWithParams(BoardMemberArgumentValidationHolder validationArgument)
        {
            var request = RequestWithAuth(BoardEndPoints.GetAllBoardsUrl).
                AddOrUpdateParameters(validationArgument.PathParams).
                AddOrUpdateParameters(validationArgument.QueryParams);
            var response = _client.Get(request);
            Assert.That(response.StatusCode, Is.EqualTo(validationArgument.StatusCode));

        }

        [Test, TestCaseSource(typeof(AuthValidationArgumentProvider))]
        public void AuthParameterInvalidScenario(AuthValidationArgumentHolder validationArgument)
        {
            var request = RequestWithAuth(BoardEndPoints.GetBoardUrl)
                .AddOrUpdateParameters(validationArgument.AuthParams);
            var response = _client.Get(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Content, Is.EqualTo("unauthorized permission requested"));
        }
        [Test]
        public void TestBoardNameConstTest()
        {
            var request = RequestWithAuth(BoardEndPoints.GetBoardUrl)
                .AddUrlSegment("id", UrlParamValues.ExistingBoardId);
            var response = _client.Get(request);
            var content = response.Content;
            var boardName = JToken.Parse(response.Content!).SelectToken("name")?.ToString();
            Assert.That("TestBoard", Is.EqualTo(boardName), "Board name does not match");
        }





    }
}
