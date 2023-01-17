using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Realms.Sync;
using System.Windows.Input;

namespace HouseMovingAssistant.ViewModels
{

    public partial class LoginPageViewModel : ObservableObject
    {

        public LoginPageViewModel()
        {
        }

        [ObservableProperty]
        private string emailText = "";

        [ObservableProperty]
        private string passwordText = "";

        [RelayCommand]
        public async Task CreateAccount()
        {
            try
            {
                await App.RealmApp.EmailPasswordAuth.RegisterUserAsync(EmailText, PasswordText);

                await Login();

            }
            catch (Exception ex)
            {
                //TODO A small thing, but in the template app I'm working on I've created a DialogService: https://github.com/papafe/realm-template-apps/blob/fp/update-dotnet-app/maui/RealmTodo/Services/DialogService.cs
                //I think it's a little more clean, but that's personal preference. I also think it's a pity they made so messy to call a dialog from a viewModel...
                await App.Current.MainPage.DisplayAlert("Error creating account!", "Error: " + ex.Message, "OK");
            }
        }

        [RelayCommand]
        public async Task Login()
        {
            try
            {
                //TODO Similar to the DialogService, I've also created a RealmService: https://github.com/papafe/realm-template-apps/blob/fp/update-dotnet-app/maui/RealmTodo/Services/RealmService.cs
                //This is also personal preference, but I thought it was a good idea to have all the realm related methods in one place (including the appId)
                //I suppose the disadvantage is that it could be slightly less clear which methods are called
                var user = await App.RealmApp.LogInAsync(Credentials.EmailPassword(EmailText, PasswordText));

                if (user != null)
                {
                    await AppShell.Current.GoToAsync("///Main");
                    EmailText = "";  //TODO Do you need to reset this because the page/viewModel is being reused?
                    PasswordText = "";
                }
                else
                {
                    //TODO I think it would make sense to add a message to this exception at least
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error Logging In", ex.Message, "OK");
            }

        }

        //TODO This seems not to be used
        public bool CheckIsLoggedIn()
        {
            if (App.RealmApp.CurrentUser != null)
            {
                var user = App.RealmApp.CurrentUser;

                if (user.State == UserState.LoggedIn)
                    return true;
            }

            return false;
        }
    }
}

