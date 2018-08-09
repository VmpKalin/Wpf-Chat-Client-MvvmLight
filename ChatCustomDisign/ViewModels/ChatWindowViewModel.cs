using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ChatCustomDisign.Models.Template;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ChatCustomDisign.ViewModels
{
    public class ChatWindowViewModel : ViewModelBase
    {
        //private  UserInfo;
        private ObservableCollection<Person> _people;

        public ObservableCollection<Person> People
        {
            get
            {
                if (_people == null)
                    _people = PersonRepository.AllClients;
                return _people;
            }
        }

        public RelayCommand ChatView
        {
            get
            {
                return new RelayCommand(() => ShowPage(null));
            }
        }

        public RelayCommand SettingView
        {
            get
            {
                return new RelayCommand(() => ShowPage(null));
            }
        }

        private void ShowPage(Page page)
        {
        }
    }
}
