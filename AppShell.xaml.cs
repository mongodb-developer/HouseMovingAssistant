using HouseMovingAssistant.ViewModels;
using HouseMovingAssistant.Views;
using Realms.Sync;

namespace HouseMovingAssistant;

public partial class AppShell : Shell
{
    //TODO This seems not to be used 
	LoginPageViewModel viewModel;
	public AppShell()
	{
		InitializeComponent();
		viewModel = new LoginPageViewModel();

        //TODO You're registering routes both here and in App.xaml.cs
		Routing.RegisterRoute("edittaskpage", typeof(EditTaskPage));
	}

    //TODO Is this used to have a login flow?
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
