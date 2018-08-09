using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatCustomDisign.Models.Autho;
using ChatCustomDisign.Models.DTO;
using ChatCustomDisign.Models.Template;

namespace ChatCustomDisign.Models.Interfaces.Services
{
    public interface ILoginService
    {
        bool LoginUser(LoginRequest login);
        UserResponce GetUserInfo();
    }
}
