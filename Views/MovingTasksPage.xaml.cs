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

	private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;

		if(selectedIndex != -1)
		{
			switch(picker.SelectedItem.ToString())
			{
				case "Open":
					await viewModel.ChangeTaskStatus("Open");
					break;
				case "InProgress":
					await viewModel.ChangeTaskStatus("InProgress");
					break;
				case "Completed":
					await viewModel.ChangeTaskStatus("Completed");
                    break;
				default:
                    await viewModel.ChangeTaskStatus("Open");
					break;
            } 
		}
	}
}



