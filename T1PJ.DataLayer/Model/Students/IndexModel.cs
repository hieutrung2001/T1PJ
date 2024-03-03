using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Entity;

namespace T1PJ.DataLayer.Model.Students
{
    public class IndexModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateOnly Dob { get; set; }
        public int PhoneNumber { get; set; }
        public List<Class>? Classes { get; set; }
        public string Address { get; set; }
    }
}
