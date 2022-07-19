using HouseMovingAssistant.ViewModels;

namespace HouseMovingAssistant.Views;

public partial class LoginPage : ContentPage
{

	LoginPageViewModel vm;
	public LoginPage()
	{
		InitializeComponent();
		vm = new LoginPageViewModel();
		BindingContext = vm;
	}
}
