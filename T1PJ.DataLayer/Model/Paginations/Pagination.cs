using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Entity;
using T1PJ.DataLayer.Model.Students;

namespace T1PJ.DataLayer.Model.Paginations
{
    public class Pagination<T> where T : class
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public Search Search { get; set; }
        public List<Order> Order { get; set; }
        public List<Columns> Columns { get; set; }

    }

    public class Order
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }

    public class Search {
        public string Value {  get; set; }
    }
}
