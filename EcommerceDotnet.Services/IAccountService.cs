using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDotnet.Services
{
    public interface IAccountService
    {
        List<UserModel> List();
        int Add(UserModel user);
        int Update(UserModel user);
        int Delete(int id);
        UserModel Find(int id);
    }
}
