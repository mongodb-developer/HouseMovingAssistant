namespace HouseMovingAssistant.Views;

public partial class TaskStatsPage : ContentPage
{
	public TaskStatsPage()
	{
		//TODO I didn't try to run the code, but I suppose this page is showing a web view with the charts related to the task stats
		//To make it slightly more general, would it be possible to create a view model and bind the web view source html?
		//This way we can build the html in code and it's more evident that the chart url needs to be changed
		InitializeComponent();		
    }
}