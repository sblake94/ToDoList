using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Security;
using System.ServiceProcess;
using System.Windows;
using WpfUI.Common;
using WpfUI.Views;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        public App()
        {
            _serviceProvider = ServiceConfigurator.Configure();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DisplayMainWindow();
        }

        private void DisplayMainWindow()
        {
            MainWindow = _serviceProvider.GetRequiredService<MainView>();
            MainWindow.Show();
        }
    }
}
