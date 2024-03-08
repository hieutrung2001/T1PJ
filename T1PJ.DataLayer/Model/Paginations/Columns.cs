using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1PJ.DataLayer.Model.Paginations
{
    public class Columns
    {
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public string Search {  get; set; }
        public string Value { get; set; }
        public bool Regex { get; set; }
        public string Data {  get; set; }

    }
}
