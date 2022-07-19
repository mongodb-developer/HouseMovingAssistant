using HouseMovingAssistant.ViewModels;

namespace HouseMovingAssistant;

public partial class AppShell : Shell
{
	LoginPageViewModel viewModel;
	public AppShell()
	{
		InitializeComponent();
		viewModel = new LoginPageViewModel();
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
