using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.Core.Services.Accounts;
using T1PJ.Core.Services.Classes;
using T1PJ.Core.Services.Students;

namespace T1PJ.Core.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IStudentService, StudentService>();
            //services.AddScoped<IClassService, ClassService>();
            return services;
        }
    }
}
