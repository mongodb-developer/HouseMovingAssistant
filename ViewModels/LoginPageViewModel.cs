using MvvmHelpers;
using MvvmHelpers.Commands;
using Realms.Sync;
using System.Windows.Input;

namespace HouseMovingAssistant.ViewModels
{

    public class LoginPageViewModel : BaseViewModel
	{

        public ICommand LoginCommand {get; set;}
        public ICommand CreateAccountCommand {get; set;}

        public LoginPageViewModel()
		{
            LoginCommand = new AsyncCommand(Login);
            CreateAccountCommand = new AsyncCommand(CreateAccount);
		}


        private string emailText = "";
        public string EmailText
        {
            get => emailText;
            set => SetProperty(ref emailText, value);
        }


        private string passwordText = "";
        public string PasswordText
        {
            get => passwordText;
            set => SetProperty(ref passwordText, value);
        }



       
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

