﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1PJ.Domain.Entity
{
    public class Student : BaseEntity
    {
        public string FullName { get; set; }
        public DateOnly Dob { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }

        public IList<StudentClass> StudentClasses { get; set; }
    }
}
