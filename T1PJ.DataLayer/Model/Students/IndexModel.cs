﻿using T1PJ.Domain.Entity;

namespace T1PJ.Domain.Model.Students
{
    public class IndexModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateOnly Dob { get; set; }
        public int PhoneNumber { get; set; }
        public IList<StudentClass> StudentClasses { get; set; }
        public string Address { get; set; }
    }
}
