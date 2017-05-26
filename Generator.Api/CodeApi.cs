using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generator.Entity;
using Generator.Parser;
using System.Text.RegularExpressions;
using System.Globalization;
using Generator.DataType;
namespace Generator.Api
{
    public static class CodeApi
    {
       

        public static string GetApiCode(IEnumerable<DocTypeModel> docTypes, string conncetionString)
        {

            CustomDataType cdp = new CustomDataType(conncetionString);
           
            string propString = null;
            StringBuilder docTypeBuilder = new StringBuilder();
            StringBuilder properties = new StringBuilder();
            docTypeBuilder.Append("umbraco.BusinessLogic.User user = new umbraco.BusinessLogic.User(" + QuoteWrapper("admin") + ");\n");

            foreach (DocTypeModel docTpye in docTypes)
            {
                docTypeBuilder.Append("DocumentType dt" + docTpye.Name + " = DocumentType.MakeNew(user," + QuoteWrapper(docTpye.Name) + ");\n");
                foreach (var prop in docTpye.Properties)
                {

                    if (prop.Type.StartsWith("MNTP") || prop.Type.StartsWith("MUP") || prop.Type.StartsWith("NC") || prop.Type.StartsWith("AT"))
                    {
                        properties.Append(" new Tuple<umbraco.cms.businesslogic.datatype.DataTypeDefinition, string, string, string, string>(new umbraco.cms.businesslogic.datatype.DataTypeDefinition(" + cdp.AddCustomDataType(prop) + "), " + QuoteWrapper(ReplaceFirstCharacterToLowerVariant(prop.Name)) + ", " + QuoteWrapper(prop.Name.ToLowercaseNamingConvention(true)) + "," + QuoteWrapper(prop.Description) + "," + QuoteWrapper(prop.Tab) + "),\n");
                    }
                    if (prop.Type == "TextString")
                    {
                        properties.Append(" new Tuple<umbraco.cms.businesslogic.datatype.DataTypeDefinition, string, string, string, string>(new umbraco.cms.businesslogic.datatype.DataTypeDefinition(-88), " + QuoteWrapper(ReplaceFirstCharacterToLowerVariant(prop.Name)) + ", " + QuoteWrapper(prop.Name.ToLowercaseNamingConvention(true)) + "," + QuoteWrapper(prop.Description) + "," + QuoteWrapper(prop.Tab) + "),\n");
                    }
                    if (prop.Type == "ContentPicker")
                    {
                        properties.Append(" new Tuple<umbraco.cms.businesslogic.datatype.DataTypeDefinition, string, string, string, string>(new umbraco.cms.businesslogic.datatype.DataTypeDefinition(1034), " + QuoteWrapper(ReplaceFirstCharacterToLowerVariant(prop.Name)) + ", " + QuoteWrapper(prop.Name.ToLowercaseNamingConvention(true)) + "," + QuoteWrapper(prop.Description) + "," + QuoteWrapper(prop.Tab) + "),\n");
                    }
                    if (prop.Type == "TextArea")
                    {
                        properties.Append(" new Tuple<umbraco.cms.businesslogic.datatype.DataTypeDefinition, string, string, string, string>(new umbraco.cms.businesslogic.datatype.DataTypeDefinition(-89), " + QuoteWrapper(ReplaceFirstCharacterToLowerVariant(prop.Name)) + ", " + QuoteWrapper(prop.Name.ToLowercaseNamingConvention(true)) + "," + QuoteWrapper(prop.Description) + "," + QuoteWrapper(prop.Tab) + "),\n");
                    }
                    if (prop.Type == "MediaPicker")
                    {
                        properties.Append(" new Tuple<umbraco.cms.businesslogic.datatype.DataTypeDefinition, string, string, string, string>(new umbraco.cms.businesslogic.datatype.DataTypeDefinition(1035), " + QuoteWrapper(ReplaceFirstCharacterToLowerVariant(prop.Name)) + ", " + QuoteWrapper(prop.Name.ToLowercaseNamingConvention(true)) + "," + QuoteWrapper(prop.Description) + "," + QuoteWrapper(prop.Tab) + "),\n");
                    }
                    if (prop.Type == "ImageCropper")
                    {
                        properties.Append(" new Tuple<umbraco.cms.businesslogic.datatype.DataTypeDefinition, string, string, string, string>(new umbraco.cms.businesslogic.datatype.DataTypeDefinition(1043), " + QuoteWrapper(ReplaceFirstCharacterToLowerVariant(prop.Name)) + ", " + QuoteWrapper(prop.Name.ToLowercaseNamingConvention(true)) + "," + QuoteWrapper(prop.Description) + "," + QuoteWrapper(prop.Tab) + "),\n");
                    }
                    if (prop.Type == "True/False")
                    {
                        properties.Append(" new Tuple<umbraco.cms.businesslogic.datatype.DataTypeDefinition, string, string, string, string>(new umbraco.cms.businesslogic.datatype.DataTypeDefinition(-49), " + QuoteWrapper(ReplaceFirstCharacterToLowerVariant(prop.Name)) + ", " + QuoteWrapper(prop.Name.ToLowercaseNamingConvention(true)) + "," + QuoteWrapper(prop.Description) + "," + QuoteWrapper(prop.Tab) + "),\n");
                    }
                    if (prop.Type == "Numeric")
                    {
                        properties.Append(" new Tuple<umbraco.cms.businesslogic.datatype.DataTypeDefinition, string, string, string, string>(new umbraco.cms.businesslogic.datatype.DataTypeDefinition(-51), " + QuoteWrapper(ReplaceFirstCharacterToLowerVariant(prop.Name)) + ", " + QuoteWrapper(prop.Name.ToLowercaseNamingConvention(true)) + "," + QuoteWrapper(prop.Description) + "," + QuoteWrapper(prop.Tab) + "),\n");
                    }
                    if (prop.Type == "DateTime")
                    {
                        properties.Append(" new Tuple<umbraco.cms.businesslogic.datatype.DataTypeDefinition, string, string, string, string>(new umbraco.cms.businesslogic.datatype.DataTypeDefinition(-36), " + QuoteWrapper(ReplaceFirstCharacterToLowerVariant(prop.Name)) + ", " + QuoteWrapper(prop.Name.ToLowercaseNamingConvention(true)) + "," + QuoteWrapper(prop.Description) + "," + QuoteWrapper(prop.Tab) + "),\n");
                    }
                    if (prop.Type == "UploadField")
                    {
                        properties.Append(" new Tuple<umbraco.cms.businesslogic.datatype.DataTypeDefinition, string, string, string, string>(new umbraco.cms.businesslogic.datatype.DataTypeDefinition(-90), " + QuoteWrapper(ReplaceFirstCharacterToLowerVariant(prop.Name)) + ", " + QuoteWrapper(prop.Name.ToLowercaseNamingConvention(true)) + "," + QuoteWrapper(prop.Description) + "," + QuoteWrapper(prop.Tab) + "),\n");
                    }
                    if (prop.Type == "DropDown")
                    {
                        properties.Append(" new Tuple<umbraco.cms.businesslogic.datatype.DataTypeDefinition, string, string, string, string>(new umbraco.cms.businesslogic.datatype.DataTypeDefinition(-42), " + QuoteWrapper(ReplaceFirstCharacterToLowerVariant(prop.Name)) + ", " + QuoteWrapper(prop.Name.ToLowercaseNamingConvention(true)) + "," + QuoteWrapper(prop.Description) + "," + QuoteWrapper(prop.Tab) + "),\n");
                    }
                    if (prop.Type == "RTE")
                    {
                        properties.Append(" new Tuple<umbraco.cms.businesslogic.datatype.DataTypeDefinition, string, string, string, string>(new umbraco.cms.businesslogic.datatype.DataTypeDefinition(-87), " + QuoteWrapper(ReplaceFirstCharacterToLowerVariant(prop.Name)) + ", " + QuoteWrapper(prop.Name.ToLowercaseNamingConvention(true)) + "," + QuoteWrapper(prop.Description) + "," + QuoteWrapper(prop.Tab) + "),\n");
                    }
                    propString = properties.ToString();
                    propString = propString.Length > 2 ? propString.Remove(propString.Length - 2) : string.Empty;
                }
                docTypeBuilder.Append(ListPropertiWraper(propString, docTpye.Name).ToString());
                docTypeBuilder.Append(AddProperty(docTpye.Name));
                properties.Clear();
            }
            cdp.GetConncetion().Close();
            return docTypeBuilder.ToString();
        }

        public static string ListPropertiWraper(string properties, string docTypeName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("var list" + docTypeName + " = new List<Tuple<umbraco.cms.businesslogic.datatype.DataTypeDefinition, string, string, string, string>>\n");
            sb.Append("{\n");
            sb.Append("  " + properties + "\n");
            sb.Append("};\n");
            return sb.ToString();
        }
        public static string AddProperty(string docTypeName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("var distinctTabList" + docTypeName + " = list" + docTypeName + ".Select(x => x.Item5).Distinct();\n");
            sb.Append("Dictionary<string, int> tabIdDic" + docTypeName + " = new Dictionary<string, int>();\n");
            sb.Append("foreach (var item in distinctTabList" + docTypeName + ")\n");
            sb.Append("{\n");
            sb.Append("int tabId" + docTypeName + " = dt" + docTypeName + ".AddVirtualTab(item);\n");
            sb.Append("tabIdDic" + docTypeName + ".Add(item,tabId" + docTypeName + ");");
            sb.Append("}\n\n\n");

            sb.Append("foreach (var item in list" + docTypeName + ")\n");
            sb.Append("{\n");
            sb.Append("dt" + docTypeName + ".AddPropertyType(item.Item1, item.Item2, item.Item3);\n");
            sb.Append("dt" + docTypeName + ".SetTabOnPropertyType(dt" + docTypeName + ".getPropertyType(item.Item2), tabIdDic" + docTypeName + "[item.Item5]);\n");
            sb.Append("var n" + docTypeName + " = dt" + docTypeName + ".getPropertyType(item.Item2);\n");
            sb.Append("n" + docTypeName + ".Description = item.Item4;\n");
            sb.Append("}\n");
            sb.Append("dt" + docTypeName + ".Save();\n");
            return sb.ToString();
        }

        public static string QuoteWrapper(string word)
        {
            string quote = "\"";
            return quote + word + quote;
        }

        public static string ReplaceFirstCharacterToLowerVariant(string name)
        {
            return  name != null && name.Length > 1 ?  Char.ToLowerInvariant(name[0]) + name.Substring(1) : string.Empty;
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
                return s!= null ? s : string.Empty;
        }

        public static string SeparateStringByUpperCase(string text)
        {
            StringBuilder sBuilder = new StringBuilder();
            List<char> tempList = text.ToList<char>();
            for (int i = 0; i < tempList.Count; i++)
			{
                if (Char.IsUpper(tempList[i]) && i > 0)
                {
                    sBuilder.Append(' ');
                    sBuilder.Append(Char.ToLower(tempList[i]));
                }
                else
                {
                    sBuilder.Append(tempList[i]);
                }
                
			}

            return sBuilder.ToString();
        }
    }
}
