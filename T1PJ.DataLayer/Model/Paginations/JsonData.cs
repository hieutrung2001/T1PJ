using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.Domain.Model.Students;

namespace T1PJ.Domain.Model.Paginations
{
    public class JsonData<T> where T : class
    {
        public int Draw { get; set; }
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }
        public List<T> Data { get; set; }
    }
}
