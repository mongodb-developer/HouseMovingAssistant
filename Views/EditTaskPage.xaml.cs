using HouseMovingAssistant.Models;
using HouseMovingAssistant.ViewModels;

namespace HouseMovingAssistant.Views;

public partial class EditTaskPage : ContentPage
{
	
	public EditTaskPage(EditMovingTaskPageViewModel viewModel)
	{
		InitializeComponent();			
		BindingContext = viewModel;
	}
}