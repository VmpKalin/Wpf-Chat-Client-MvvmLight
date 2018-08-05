using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ChatCustomDisign.Models.DTO;
using ChatCustomDisign.Models.Interfaces.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;

namespace ChatCustomDisign.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private LoginRequest _login;
        private ILoginService _loginService;

        public LoginViewModel(ILoginService service)
        {
            _loginService = service;
            _login = new LoginRequest();
        }

        public string Login
        {
            get => _login.Login;
            set
            {
                _login.Login = value;
                RaisePropertyChanged("Login");
            }
        }

        public string Password
        {
            get => _login.Password;
            set
            {
                _login.Password = value;
                RaisePropertyChanged("Password");
            }
        }

        public RelayCommand SingUp
        {
            get
            {
                return new RelayCommand(() => SingUpToProfile().GetAwaiter().GetResult(), null);

            }
        }

        private async Task SingUpToProfile()
        {
            await _loginService.LoginUser(Login, Password);
        }

        private bool CanExecuteSingUp()
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                return false;
            }

            return true;
        }
    }
}
