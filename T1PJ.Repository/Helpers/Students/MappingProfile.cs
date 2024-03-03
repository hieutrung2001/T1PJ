using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Entity;
using T1PJ.DataLayer.Entity.Identity;
using T1PJ.DataLayer.Model.Accounts;
using T1PJ.DataLayer.Model.Students;

namespace T1PJ.Repository.Helpers.Students
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, IndexModel>();
            CreateMap<CreateViewModel, Student>();
            CreateMap<EditViewModel, Student>();
            CreateMap<Student, EditViewModel>();
        }
    }
}
