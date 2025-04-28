using APIFramework.Arguments.Holders;
using RestSharp;
using System.Collections;

namespace APIFramework.Arguments.Providers
{
    public class AuthValidationArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new AuthValidationArgumentHolder
                {
                    AuthParams= ArraySegment<Parameter>.Empty,
                    ErrorMessage = "invalid key"
                }
            };
            yield return new object[]
           {
                new AuthValidationArgumentHolder
                {
                    AuthParams= new Parameter[] 
                    {
                        new QueryParameter("key", ""),
                        
                    },ErrorMessage= "unauthorized permission requested"
                }
           };
            yield return new object[]
           {
                new AuthValidationArgumentHolder
                {
                    AuthParams= new []
                    {
                        new QueryParameter()//tok
                    },ErrorMessage = "invalid key"
                }
           };
        }
    }
}
