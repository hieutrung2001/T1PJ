using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1PJ.DataLayer.Model.Students
{
    public class CreateViewModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly Dob { get; set;}
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
