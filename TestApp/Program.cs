using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generator.Parser;
using Generator.Entity;
using Generator.Api;
using Generator.DataType;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var parsedCode = XsdParser.GetDocTypes("C://Users//v.stancic//Desktop//Apax.xsd");
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;
            CodeApi.GetApiCode(parsedCode, connection);
      
            CustomDataType sdp = new CustomDataType(connection);
            PropModel p = new PropModel()
            {
                Type = "NC:WeliborCarr:getContent"
            };
            
             int n = sdp.AddCustomDataType(p);
            sdp.GetConncetion().Close();
        }
    }
}
