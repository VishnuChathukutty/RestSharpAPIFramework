using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace APIFramework.Arguments.Providers
{
    public class BoardNameValidationArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new Dictionary<string,object> {{ "name","1234"} },

            };
            yield return new object[]
            {
               ImmutableDictionary<string, object>.Empty
            };
        }
    }
}
