using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Model.Students;

namespace T1PJ.Domain.Model.Students
{
    public class JsonData
    {
        public int Draw { get; set; }
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }
        public List<IndexModel> Data { get; set; }
    }
}
