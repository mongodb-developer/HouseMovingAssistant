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

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        switch (((Picker)sender).SelectedIndex)
        {
            case 0:
                viewModel.NewStatus = MovingTask.TaskStatus.Open.ToString();
                break;
            case 1:
                viewModel.NewStatus = MovingTask.TaskStatus.InProgress.ToString();
                break;
            case 2:
                viewModel.NewStatus = MovingTask.TaskStatus.Complete.ToString();
                break;
        }

    }

}