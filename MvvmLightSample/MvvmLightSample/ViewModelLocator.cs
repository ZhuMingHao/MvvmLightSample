using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MvvmLightSample.View;
using MvvmLightSample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLightSample
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();

            var navigationService = this.InitNavigationService();
            SimpleIoc.Default.Register(() => navigationService);


        }
        public INavigationService InitNavigationService()
        {
            NavigationService navigationService = new NavigationService();
            navigationService.Configure("Login", typeof(LoginView));
            navigationService.Configure("Main", typeof(MainPage));
            return navigationService;
        }

        public static LoginViewModel _login;
        public static LoginViewModel Login
        {
            get
            {
                if (_login == null)
                    _login = ServiceLocator.Current.GetInstance<LoginViewModel>();
                return _login;
            }
        }

        private static MainViewModel _main;
        public static MainViewModel Main
        {
            get
            {
                if (_main == null)
                    _main = ServiceLocator.Current.GetInstance<MainViewModel>();
                return _main;
            }
        }
    }
}
