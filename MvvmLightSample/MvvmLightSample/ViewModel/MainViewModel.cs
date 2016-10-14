using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmLightSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmLightSample.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                Set(ref _username, value);
            }
        }

        private Model.User _user;
        public User User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
                Username = value.Username;
            }
        }

        public MainViewModel()
        {
            Username = "CQ";
            LogoffCommand = new RelayCommand(Logoff);

        }
        public ICommand LogoffCommand { get; set; }

        private void Logoff()
        {
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<object>("确认注销吗？");
        }
    }

}
