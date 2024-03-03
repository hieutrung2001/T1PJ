using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Entity.Identity;
using T1PJ.DataLayer.Model.Accounts;

namespace T1PJ.Repository.Helpers.Accounts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginViewModel, User>();
            CreateMap<RegisterViewModel, User>();
        }
    }
}
