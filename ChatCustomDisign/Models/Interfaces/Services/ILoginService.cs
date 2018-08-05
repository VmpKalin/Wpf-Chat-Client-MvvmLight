using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatCustomDisign.Models.Interfaces.Services
{
    public interface ILoginService
    {
        Task LoginUser(string login, string password);
    }
}
