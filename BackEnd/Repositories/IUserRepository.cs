using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Repositories
{
    public interface IUserRepository
    {
        bool Register(t_user data);
        bool Login (vm_login data);
        bool DeleteProfile(int id);

        t_user GetProfile(int id);
        bool ChangeProfile(t_user data);

        int ChangePassword(ChangePassword data);

        bool forget(string email,string pass);
    }
}