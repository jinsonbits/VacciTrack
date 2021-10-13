using VacciTrack.Views;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VacciTrack.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            OpenWebCommand = new Command(OnRegisterNowClicked);
        }
        private async void OnRegisterNowClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
        }

        public ICommand OpenWebCommand { get; }
    }
}