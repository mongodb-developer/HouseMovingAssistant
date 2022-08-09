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
		public async Task Login()
        {
			try
            {
                var user = await App.RealmApp.LogInAsync(Credentials.EmailPassword(EmailText, PasswordText));

                if(user != null)
                {
                    await AppShell.Current.GoToAsync("///Main");
                    EmailText = "";
                    PasswordText = "";                    
                }
                else
                {
                    throw new Exception();
                }   

            } catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error Logging In", ex.Message, "OK");
            }

        }

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
                await App.Current.MainPage.DisplayAlert("Error creating account!", "Error: " + ex.Message, "OK");
            }
        }

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

