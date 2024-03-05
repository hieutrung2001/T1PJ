using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Entity;

namespace T1PJ.DataLayer.Model.Classes
{
    public class IndexModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}
