using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Entity;

namespace T1PJ.DataLayer.Model.Paginations
{
    public class Pagination<T> where T : class
    {
        public int Page { get; set; }
        public int Total { get; set; }
        public int Size { get; set; }
        public string Search { get; set; }
        public string Order { get; set; }
        public List<T> Data { get; set; }    
    }
}
