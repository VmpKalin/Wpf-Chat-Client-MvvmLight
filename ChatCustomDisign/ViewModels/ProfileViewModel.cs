using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatCustomDisign.Models.Interfaces.Services;
using GalaSoft.MvvmLight;

namespace ChatCustomDisign.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly ILoginService _loginService;
        private string userName;

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                RaisePropertyChanged(nameof(UserName));
            }
        }

        public ProfileViewModel(ILoginService loginService)
        {
            _loginService = loginService;

            GetUserInfo();
        }

        private void GetUserInfo()
        {
            var info = _loginService.GetUserInfo();
            UserName = info.FName + " " + info.LName;
        }
    }
}
