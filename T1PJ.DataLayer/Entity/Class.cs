using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1PJ.DataLayer.Entity
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        
        public List<Student> Students { get; set; }
    }
}
