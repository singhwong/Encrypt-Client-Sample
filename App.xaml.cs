using System;
using EncryptKeyClient.Services;
using EncryptKeyClient.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EncryptKeyClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeServices();
            MainPage = new NavigationPage(new EncryptPage());
        }
        void InitializeServices()
        {
            IServiceCollection collection = new ServiceCollection();
            collection.AddSingleton<IEncryptService, EncryptService>();
            collection.AddSingleton<EnctyptVM>();
            ServiceProvider = collection.BuildServiceProvider();
        }
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
