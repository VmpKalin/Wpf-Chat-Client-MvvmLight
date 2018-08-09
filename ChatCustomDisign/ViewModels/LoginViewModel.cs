using System.Windows;
using System.Windows.Input;
using ChatCustomDisign.Models.DTO;
using ChatCustomDisign.Models.Interfaces.Services;
using ChatCustomDisign.Views.Chat;
using ChatCustomDisign.Views.Profile;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ChatCustomDisign.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private LoginRequest _login;
        private readonly ILoginService _loginService;

        public LoginViewModel(ILoginService service)
        {
            _loginService = service;
            _login = new LoginRequest();
        }



        public LoginRequest Login
        {
            get => _login;
            set
            {
                _login = value;
                RaisePropertyChanged("Login");  
            }
        }

        RelayCommand<Window> _singUp;

        public RelayCommand<Window> SingUp
        {
            get
            {
                if (_singUp == null)
                    _singUp = new RelayCommand<Window>(SingUpToProfile);
                return _singUp;
            }
        }

        RelayCommand<Window> _exit;

        public RelayCommand<Window> Exit
        {
            get
            {
                if(_exit==null)
                    _exit = new RelayCommand<Window>(CloseWindow);
                return _exit;
            }
        }

        public void CloseWindow(Window window)
        {
            window.Close();
        }

        private void SingUpToProfile(Window window)
        {
            if (string.IsNullOrEmpty(_login.Login) || string.IsNullOrEmpty(_login.Password))
            {
                return;
            }
         
            var isAuthorized = _loginService.LoginUser(_login);

            if (isAuthorized)
            {
                window.Hide();
                window = new MainWindowContainer(new UserPage());
                window.Show();
            }
        }

        public bool CanExecuteSingUp()
        {
            if (string.IsNullOrEmpty(_login.Login) || string.IsNullOrEmpty(_login.Password))
            {
                return false;
            }

            return true;
        }
    }
}
