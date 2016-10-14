using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MvvmLightSample.Model;
using MvvmLightSample.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MvvmLightSample.ViewModel
{
   public class LoginViewModel:ViewModelBase
    {
        private string _userName;
        private string _password;

        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                Set(ref _userName, value);
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
             {
                Set(ref _password, value);
            }
        }

        public ICommand LoginCommand { get; set; }

        private void Login()
        {
            User model = new User { Username = UserName, Password = Password };
            if (true == AuthenticateHelper.Authenticate(model))
            {
                var navigation = ServiceLocator.Current.GetInstance<INavigationService>();
                navigation.NavigateTo("Main", model);

                ViewModelLocator.Main.User = model;
            }
            else
            {
                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<string>("用户名或密码错误！！！");
            }
        }
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

    }
}
