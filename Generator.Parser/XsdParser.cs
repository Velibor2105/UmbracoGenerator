using Generator.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Generator.Parser
{
    public static class XsdParser
    {
        public static IEnumerable<DocTypeModel> GetDocTypes(string xsdPath)
        {
            List<DocTypeModel> doctypes = new List<DocTypeModel>();

            var xDoc = XDocument.Load(xsdPath);
            var ns = XNamespace.Get(@"http://www.w3.org/2001/XMLSchema");

            var docTypes = from dType in xDoc.Element(ns + "schema").Elements(ns + "element")
                           select dType.Attribute("name").Value;

            foreach (var docType in docTypes)
            {
                DocTypeModel docTypeModel = new DocTypeModel();
                docTypeModel.Properties = new List<PropModel>();
                docTypeModel.Relations = new List<string>();
                docTypeModel.Name = docType;

                var docPropertiesNames = (from dType in xDoc.Element(ns + "schema").Elements(ns + "element")
                                          where dType.Attribute("name").Value == docType
                                          from d in dType.Elements(ns + "element")
                                          where !d.Attribute("name").Value.StartsWith("Association")
                                          select GetName(d.Attribute("name").Value)).ToList();

                 var docPropertiesTabs = (from dType in xDoc.Element(ns + "schema").Elements(ns + "element")
                                          where dType.Attribute("name").Value == docType
                                          from d in dType.Elements(ns + "element")
                                          where !d.Attribute("name").Value.StartsWith("Association")
                                          select GetTab(d.Attribute("name").Value)).ToList();

          var docPropertiesDescription = (from dType in xDoc.Element(ns + "schema").Elements(ns + "element")
                                         where dType.Attribute("name").Value == docType
                                         from d in dType.Elements(ns + "element")
                                         where !d.Attribute("name").Value.StartsWith("Association")
                                         select GetDescription(d.Attribute("name").Value)).ToList();


                var docPropertiesTypes = from dType in xDoc.Element(ns + "schema").Elements(ns + "element")
                                         where dType.Attribute("name").Value == docType
                                         from d in dType.Elements(ns + "element")
                                         where !d.Attribute("name").Value.StartsWith("Association")
                                         select d.Attribute("type").Value;

                docTypeModel.Relations = (from dType in xDoc.Element(ns + "schema").Elements(ns + "element")
                                          where dType.Attribute("name").Value == docType
                                          from d in dType.Elements(ns + "element")
                                          where d.Attribute("name").Value.StartsWith("Association")
                                          select d.Attribute("type").Value).ToList();

                for (int i = 0; i < docPropertiesNames.Count(); i++)
                {
                    PropModel propModel = new PropModel();
                    propModel.Name = docPropertiesNames.ElementAt(i);
                    propModel.Type = docPropertiesTypes.ElementAt(i);
                    propModel.Tab = docPropertiesTabs.ElementAt(i);
                    propModel.Description = docPropertiesDescription.ElementAt(i);
                    docTypeModel.Properties.Add(propModel);
                }

                doctypes.Add(docTypeModel);
            }
            return doctypes;
        }

        public static string GetTab(string text)
        {
            char[] delimiterChars = { '-' };
            string[] words = text.Split(delimiterChars);

            return words != null && words.Count() > 1 ? words[0] : "Default tab";
        }
        public static string GetName(string text)
        {
            char[] delimiterChars = { '-',':' };
            string[] words = text.Split(delimiterChars);

            return words != null && words.Count() > 1 ? words[1] : "Error";
        }
        public static string GetDescription(string text)
        {
            char[] delimiterChars = {':'};
            string[] words = text.Split(delimiterChars);

            return words != null && words.Count() > 1 ? words[1] : "Enter description";
        }

        public static string ReplaceFirstCharacterToUpperVariant(string name)
        {
            return name != null && name.Length > 1 ? Char.ToUpperInvariant(name[0]) + name.Substring(1) : string.Empty;
        }
        public static string ToLowercaseNamingConvention(this string s, bool toLowercase)
        {
            if (toLowercase)
            {
                var r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

                return s != null ? ReplaceFirstCharacterToUpperVariant(r.Replace(s, " ").ToLower()) : string.Empty;
            }
            else
                return s != null ? s : string.Empty;
        }
    }

   
}