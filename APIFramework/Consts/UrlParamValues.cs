using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Consts
{
    public class UrlParamValues
    {
        public const string ExistingBoardId = "67f4349ba322325795e05b93";
        public const string UserName = "vishnuchathukutty";

        public static readonly IEnumerable<Parameter> AuthQueryParams = new[]
        {
            new QueryParameter("key",""),
            new QueryParameter()//tok
        };
        public static readonly IEnumerable<Parameter> AnotherUserAuthQueryParams = new[]
        {
            new QueryParameter("key",""),
            new QueryParameter()//tok
        };

        public const string BoardIdToUpdate = "60d84769c4ce7a09f9140220";
    }
}
