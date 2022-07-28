using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Framework.Utilities
{
    internal class JsonReader
    {
        public String  extractdata(String tokenname)
        {
           var  myJson= File.ReadAllText("C:/Users/pc/source/repos/Udemy/Framework/Utilities/testData.json");
            var jsonObject=JToken. Parse(myJson);
             return jsonObject.SelectToken(tokenname).Value<String>();
        }
        public String[] extractdataArray(String tokenname)
        {
            var myJson = File.ReadAllText("C:/Users/pc/source/repos/Udemy/Framework/Utilities/testData.json");
            var jsonObject = JToken.Parse(myJson);
            List<String> list= jsonObject.SelectTokens(tokenname).Values<String>().ToList();
            return list.ToArray();
        }
    }
}
