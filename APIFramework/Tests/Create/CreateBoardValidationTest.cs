using APIFramework.Arguments.Holders;
using APIFramework.Arguments.Providers;
using APIFramework.Consts;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Tests.Create
{
    public class CreateBoardValidationTest:SetupFixture
    {
        [Test, TestCaseSource(typeof(BoardNameValidationArgumentProvider))]
        public void CheckCreateBoardWithInvalidName(Dictionary<string, object> bodyParams)
        {
            try
            {
                var request = RequestWithAuth(BoardEndPoints.CreateBoardUrl)
                .AddJsonBody(bodyParams);
                var response = _client.Post(request);
            }
            catch (Exception error)
            {

               Assert.That(error.Message, Is.EqualTo("400 Bad Request"));
            }
            
        }
        [Test,TestCaseSource(typeof(AuthValidationArgumentProvider))]
        public void CheckCreateBoardWithInvalidAuth(AuthValidationArgumentHolder argumentParam)
        {
            try
            {
                var boardName = "New Board" ;
                var request = RequestWithAuth(BoardEndPoints.CreateBoardUrl)
                    .AddOrUpdateParameters(argumentParam.AuthParams)
                    .AddJsonBody(new Dictionary<string, string> { { "name",boardName} });
                var response = _client.Post(request);

                Assert.That(HttpStatusCode.Unauthorized, Is.EqualTo(response.StatusCode));
                Assert.That(argumentParam.ErrorMessage, Is.EqualTo(response.Content));
            }
            catch (Exception error)
            {

                Assert.That(error.Message.Contains("Unauthorized"));
            }

        }

    }
}
