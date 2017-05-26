using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Entity
{
    public class DocTypeModel
    {
        public string Name { get; set; }
        public List<PropModel> Properties { get; set; }
        public List<string> Relations { get; set; }
    }
}
