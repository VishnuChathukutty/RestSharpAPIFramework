using APIFramework.Arguments.Holders;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Arguments.Providers
{
    public class BoardIdArgumentValidationProvider : IEnumerable
    {
        public IEnumerator GetEnumerator() //implement missing members
        {
            yield return new object[]
            {
                        new BoardIdArgumentValidationHolder
                        {
                            ErrorMessage = "invalid id",
                            StatusCode = HttpStatusCode.BadRequest,
                            PathParams = new[] { new UrlSegmentParameter("id", "invalid") }
                        }
            };
            yield return new object[] {
                    new BoardIdArgumentValidationHolder
                        {
                            ErrorMessage = "The requested resource was not found.",
                            StatusCode = HttpStatusCode.NotFound,
                            PathParams = new[] { new UrlSegmentParameter("id", "67f4349ba322325795e05b94") }
                        }
                };
        }
    }

    public class BoardMemberArgumentValidationProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new BoardMemberArgumentValidationHolder
                {
                    QueryParams = new[] { new QueryParameter("key", "") },
                    PathParams = new[] { new UrlSegmentParameter("member", "vishnuchathukutty") },
                    StatusCode = HttpStatusCode.OK
                }
            };
        }
    }
}
