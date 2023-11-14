using HouseMovingAssistant.ViewModels;
using HouseMovingAssistant.Views;
using Realms.Sync;

namespace HouseMovingAssistant;

public partial class AppShell : Shell
{
	
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("edittaskpage", typeof(EditTaskPage));
        Routing.RegisterRoute("statspage", typeof(StatsPage));
    }
    
	protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        base.OnNavigated(args);

        if (App.RealmApp.CurrentUser != null)
        {
            var user = App.RealmApp.CurrentUser;

            if (user.State == UserState.LoggedIn)
                AppShell.Current.GoToAsync("///Main");
        }        
    }
}
