using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MvvmLightSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<object>(this, true, LogoffMessage);

        }
        public async void LogoffMessage(object param)
        {

            MessageDialog msg = new MessageDialog(param as string);
            UICommand yes = new UICommand("确定", (o) =>
            {
                var navigation = ServiceLocator.Current.GetInstance<INavigationService>();
                navigation.GoBack();
            });
            UICommand no = new UICommand("返回", (o) =>
            {
            });
            msg.Commands.Add(yes);
            msg.Commands.Add(no);

            var re = await msg.ShowAsync();
            if (re == yes)
            {
                GalaSoft.MvvmLight.Messaging.Messenger.Default.Unregister<object>(this, LogoffMessage);
            }
        }

    }
}
