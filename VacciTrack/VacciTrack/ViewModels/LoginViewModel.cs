using VacciTrack.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using VacciTrack.Services;
using Xamarin.Essentials;

namespace VacciTrack.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private string _Username;
        public string Username
        {
            set 
            { 
                this._Username = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Username;
            }
        }
        private string _Password;
        public string Password
        {
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Password;
            }
        }

        private bool _Result;
        public bool Result
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Result;
            }
        }
        public Command LoginCommand { get; }

        public Command RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);

            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Password);
                if (Result)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "User Registered", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "User Already exists with this credentials", "OK");
                }

            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoginCommandAsync()
        {
            IsBusy = true;
            var userService = new UserService();
            Result = await userService.LoginUser(Username, Password);
            if (Result)
            {
                Preferences.Set("Username", Username);
                //await Application.Current.MainPage.Navigation.PushModalAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "OK");
            }
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
