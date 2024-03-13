using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.Domain.Entity;
using T1PJ.Domain.Entity.Identity;
using T1PJ.Domain.Model.Accounts;
using T1PJ.Domain.Model.Students;

namespace T1PJ.Core.Helpers.Students
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
