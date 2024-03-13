using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.Domain.Entity;

namespace T1PJ.Domain.Model.Classes
{
    public class CreateViewModel
    {
        [Required]
        public string Name { get; set; }
        public List<StudentClass> StudentClasses { get; set; }
        public List<int> StudentSelectList { get; set; }
        public DateTime Created { get; set; }
    }
}
