using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Model.Accounts;

namespace T1PJ.Repository.Services.Accounts
{
    public interface IAccountService
    {
        Task<bool> Login(LoginViewModel model);
        Task<bool> Register(RegisterViewModel model);
        Task Logout();
    }
}
