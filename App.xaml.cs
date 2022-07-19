using HouseMovingAssistant.Helpers;

namespace HouseMovingAssistant;

public partial class App : Application
{
	public static Realms.Sync.App RealmApp;
	public App()
	{
		InitializeComponent();
        RealmApp = Realms.Sync.App.Create(AppConfig.RealmAppId);
        MainPage = new AppShell();
	}

	protected override void OnStart()
    {
		
    }
}
