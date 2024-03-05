using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Entity;
using T1PJ.DataLayer.Model.Classes;

namespace T1PJ.Repository.Helpers.Classes
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Class, IndexModel>();
            CreateMap<CreateViewModel, Class>();
            CreateMap<Class, EditViewModel>();
        }
    }
}
