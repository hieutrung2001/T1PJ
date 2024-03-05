using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Entity;

namespace T1PJ.DataLayer.Model.Classes
{
    public class CreateViewModel
    {
        [Required]
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<int> StudentSelectList { get; set; }
        public DateTime Created { get; set; }
    }
}
