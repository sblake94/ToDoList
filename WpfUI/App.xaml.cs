using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Security;
using System.ServiceProcess;
using System.Windows;
using PresentationLayer_WPF.Common;
using PresentationLayer_WPF.Views;

namespace PresentationLayer_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IServiceProvider serviceProvider;
        public App()
        {
            serviceProvider = ServiceConfigurator.Configure();
            Ioc.Default.ConfigureServices(serviceProvider);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow = new MainView();
            MainWindow.Show();
        }
    }
}
