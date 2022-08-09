using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HouseMovingAssistant.Models;
using HouseMovingAssistant.Views;
using Realms;
using Realms.Sync;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using User = HouseMovingAssistant.Models.User;

namespace HouseMovingAssistant.ViewModels
{

    public partial class MovingTasksPageViewModel : ObservableObject
    {

        private User user;
        private Realm realm;
        private PartitionSyncConfiguration config;

        public MovingTasksPageViewModel()
        {
            WelcomeMessage = $"Welcome in {App.RealmApp.CurrentUser.Profile.Email}!";
            movingTasks = new ObservableCollection<MovingTask>();
        }


        [ObservableProperty]
        string welcomeMessage;

        [ObservableProperty]
        string movingTaskEntryText;

        [ObservableProperty]
        ObservableCollection<MovingTask> movingTasks;
       

        public async Task InitialiseRealm()
        {
            config = new PartitionSyncConfiguration($"{App.RealmApp.CurrentUser.Id}", App.RealmApp.CurrentUser);
            realm = await Realm.GetInstanceAsync(config);
            Console.WriteLine(realm.All<User>());
            user = realm.Find<User>(App.RealmApp.CurrentUser.Id);

            if(user == null)
            {
                await Task.Delay(5000);
                user = realm.Find<User>(App.RealmApp.CurrentUser.Id);

                if(user == null)
                {
                    Console.WriteLine("NO USER OBJECT: This error occurs if " +
                           "you do not have the trigger configured on the backend " +
                           "or when there is a network connectivity issue. See " +
                           "https://docs.mongodb.com/realm/tutorial/realm-app/#triggers");

                    await App.Current.MainPage.DisplayAlert("No User object",
                        "The User object for this user was not found on the server. " +
                        "If this is a new user acocunt, the backend trigger may not have completed, " +
                        "or the tirgger doesn't exist. Check your backend set up and logs.", "OK");
                }

            }

            if(user != null)
            {
                MovingTasks = new ObservableCollection<MovingTask>(realm.All<MovingTask>().ToList().Reverse<MovingTask>());
            }
            
        }

        [RelayCommand]
        async Task EditTask(MovingTask task)
        {

            await Shell.Current.GoToAsync($"{nameof(EditTaskPage)}", new Dictionary<string, object>
            {
                ["MovingTask"] = task
            }) ;
        }

        [RelayCommand]
        async Task DeleteTask(MovingTask task)
        {
            try
            {
                realm.Write(() =>
                {
                    realm.Remove(task);
                });

                MovingTasks.Remove(task);
            } catch (Exception ex)
            {
                await App.Current.MainPage.DisplayPromptAsync("Error", ex.Message);
            }
        }

        [RelayCommand]
       async Task AddMovingTask()
        {

            if (string.IsNullOrWhiteSpace(MovingTaskEntryText))
                return;

                try
                {
                    var task =
                        new MovingTask
                        {
                            Name = MovingTaskEntryText,
                            Partition = App.RealmApp.CurrentUser.Id,
                            Status = "Open",
                            Owner = App.RealmApp.CurrentUser.Profile.Email
                        };

                MovingTasks.Add(task);

                    realm.Write(() =>
                    {
                        realm.Add(task);
                    });

                    MovingTaskEntryText = "";

                } catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayPromptAsync("Error", ex.Message);

                }
        }


        [RelayCommand]
        async Task ViewStats()
        {
            await Shell.Current.GoToAsync("TaskStatsPage");
        }
    }
}
