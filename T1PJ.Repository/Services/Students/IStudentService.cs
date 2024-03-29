﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Entity;

namespace T1PJ.Repository.Services.Students
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();
        Task<List<Student>> GetStudentsOfClass(int classId);
        Task<Student> GetStudentById(int id);
        Task<Student> Create(Student student);
        Task<Student> Update(Student student);
        Task Delete(int id);
    }
}
