using HouseMovingAssistant.ViewModels;

namespace HouseMovingAssistant.Views;

public partial class EditTaskPage : ContentPage
{
	EditMovingTaskPageViewModel viewModel;
	public EditTaskPage()
	{
		InitializeComponent();
		viewModel = new EditMovingTaskPageViewModel();
		BindingContext = viewModel;
	}
}