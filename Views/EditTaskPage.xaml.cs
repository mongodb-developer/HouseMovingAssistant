using HouseMovingAssistant.Models;
using HouseMovingAssistant.ViewModels;

namespace HouseMovingAssistant.Views;

public partial class EditTaskPage : ContentPage
{
	EditMovingTaskPageViewModel viewModel;
	public EditTaskPage(EditMovingTaskPageViewModel viewModel)
	{
		InitializeComponent();		
		this.viewModel = viewModel;
		BindingContext = viewModel;
	}
}