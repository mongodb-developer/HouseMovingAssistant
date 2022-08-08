using HouseMovingAssistant.ViewModels;
using HouseMovingAssistant.Views;
using CommunityToolkit.Maui;


namespace HouseMovingAssistant;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


        builder.UseMauiApp<App>().UseMauiCommunityToolkit();
        builder.Services.AddSingleton<MovingTasksPage>();
		builder.Services.AddSingleton<MovingTasksPageViewModel>();

		builder.Services.AddTransient<EditTaskPage>();
		builder.Services.AddTransient<EditMovingTaskPageViewModel>();

		return builder.Build();
	}
}
