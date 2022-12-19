using HouseMovingAssistant.Models;
using HouseMovingAssistant.ViewModels;

namespace HouseMovingAssistant.Views;

public partial class EditTaskPage : ContentPage
{
	EditMovingTaskPageViewModel viewModel;  //TODO Is this used?
	public EditTaskPage(EditMovingTaskPageViewModel viewModel)
	{
		//TODO If you want you can automate the viewModel setting by specifying the bindingcontext directly in the xaml file , like here: https://github.com/papafe/realm-template-apps/tree/fp/update-dotnet-app/maui/RealmTodo/Views
		//(check ContentPage.BindingContext)
		//If you go this way, you can use EventToCommandBehavior to call methods like "InitialiseRealm" when the view appears or it's loaded
		InitializeComponent();		
		this.viewModel = viewModel;
		BindingContext = viewModel;
	}
}