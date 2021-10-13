using System;
using VacciTrack.Services;
using VacciTrack.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VacciTrack
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

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
