using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ChatCustomDisign.Views.AddintionViews;
using ChatCustomDisign.Views.Login;
using ChatCustomDisign.Views.Profile;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ChatCustomDisign.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private UserControl _currentView;

        public UserControl CurrentView => _currentView;
         
        public MainWindowViewModel()
        {
            _currentView = new UserPage();
        }

        RelayCommand<Window> _exit;

        public RelayCommand<Window> Exit
        {
            get
            {
                if (_exit == null)
                    _exit = new RelayCommand<Window>(CloseWindow);
                return _exit;
            }
        }

        public void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}
