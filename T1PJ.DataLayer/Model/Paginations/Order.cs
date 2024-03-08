using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1PJ.DataLayer.Model.Paginations
{
    public class Order
    {
        public int Index { get; set; }
        public string Column { get; set; }
        public string Dir { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }

        public Order(int index, string column, string dir, bool searchable, bool orderable)
        {
            Index = index;
            Column = column;
            Dir = dir;
            Searchable = searchable;
            Orderable = orderable;
        }
    }
}
