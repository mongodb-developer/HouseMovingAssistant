using HouseMovingAssistant.ViewModels;
using HouseMovingAssistant.Views;

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

		var isLoggedIn = viewModel.CheckIsLoggedIn();

		if(isLoggedIn)
        {
			AppShell.Current.GoToAsync("/Main");
        }
    }
}
