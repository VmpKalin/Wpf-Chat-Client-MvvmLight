using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ChatCustomDisign.Views.Login;
using ChatCustomDisign.Views.Profile;

namespace ChatCustomDisign
{
    /// <summary>
    /// Interaction logic for MainWindowContainer.xaml
    /// </summary>
    public partial class MainWindowContainer : Window
    {
        public MainWindowContainer(UserControl userControl)
        {
            InitializeComponent();

            this.UserMainControl = userControl;
        }

        public MainWindowContainer()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default["Token"].ToString()))
            {
                this.Hide();
                var login = new LoginWindow();
                login.Show();
            }

            this.UserMainControl  = new UserPage();
            InitializeComponent();
        }
    }
}
