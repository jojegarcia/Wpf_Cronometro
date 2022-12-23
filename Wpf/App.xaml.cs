using Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using Wpf.ViewModels;
using Wpf.Views;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            //Set required dependency injections
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<ITimeable>(new TimeableFactory().GetInstance());
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
