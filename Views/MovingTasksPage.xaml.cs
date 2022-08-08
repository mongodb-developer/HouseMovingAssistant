using HouseMovingAssistant.ViewModels;

namespace HouseMovingAssistant.Views;

public partial class MovingTasksPage : ContentPage
{
	MovingTasksPageViewModel viewModel;
	public MovingTasksPage()
	{
		InitializeComponent();
		viewModel = new MovingTasksPageViewModel();
		BindingContext = viewModel;
	}

	protected override async void OnAppearing()
	{
		await viewModel.InitialiseRealm();
		
	}
}



