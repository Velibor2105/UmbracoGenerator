using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Model
{
    public static class ModelGenerator
    {
        public static  void GenerateCsFiles()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("nestiiiiooo\n");
            strBuilder.Append("nestiiihdiooo\n");
            strBuilder.Append("nestiiidghiooo\n");
            strBuilder.Append("nestiiiidgjooo\n");
            strBuilder.Append("nestiiiiooo\n");
            strBuilder.Append("nestiiiiooo\n");

            using (StreamWriter outputFile = new StreamWriter(@"C:\MyFile.cs"))
            {
                foreach (string line in strBuilder.ToString().Split('\n'))
                    outputFile.WriteLine(line);
            }
        }
    }
}
