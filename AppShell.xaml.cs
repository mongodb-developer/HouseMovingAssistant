using HouseMovingAssistant.ViewModels;
using HouseMovingAssistant.Views;
using Realms.Sync;

namespace HouseMovingAssistant;

public partial class AppShell : Shell
{
	LoginPageViewModel viewModel;
	public AppShell()
	{
		InitializeComponent();
		viewModel = new LoginPageViewModel();

		Routing.RegisterRoute("edittaskpage", typeof(EditTaskPage));
	}

	protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        base.OnNavigated(args);

        if (App.RealmApp.CurrentUser != null)
        {
            var user = App.RealmApp.CurrentUser;

            if (user.State == UserState.LoggedIn)
                AppShell.Current.GoToAsync("/Main");
        }        
    }
}
