using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Entity;
using T1PJ.DataLayer.Model.Students;

namespace T1PJ.DataLayer.Model.Paginations
{
    public class Pagination<T> where T : class 
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public string Search { get; set; }
        public List<Order> Order { get; set; }
        public int Draw {  get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public List<T> Data { get; set; }

        public Pagination() { }

        public Pagination(int start, int length, string search, List<Order> order, int draw, int recordsTotal, int recordsFiltered, List<T> data)
        {
            Start = start;
            Length = length;
            Search = search;
            Order = order;
            Draw = draw;
            RecordsTotal = recordsTotal;
            RecordsFiltered = recordsFiltered;
            Data = data;
        }
    }
}
