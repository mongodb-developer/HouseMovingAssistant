using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HouseMovingAssistant.Models;
using HouseMovingAssistant.Services;
using HouseMovingAssistant.Views;
using Realms;
using Realms.Sync;
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
            ButtonEnabled = true;
        }

        [ObservableProperty]
        string welcomeMessage;

        [ObservableProperty]
        string movingTaskEntryText;
       
        [ObservableProperty]
        IEnumerable<MovingTask> movingTasks;

        [ObservableProperty]
        bool buttonEnabled;

        
       
        public void InitialiseRealm()
        {
            realm = RealmDatabaseService.GetRealm();           
        
            MovingTasks = realm.All<MovingTask>().OrderBy(task => task.CreatedAt);                
         
        }

        [RelayCommand]
        async Task AddMovingTask()
        {

            if (string.IsNullOrWhiteSpace(MovingTaskEntryText))
                return;            

            try
            {
                ButtonEnabled = false;
                var task =
                    new MovingTask
                    {
                        Name = MovingTaskEntryText,
                        Partition = App.RealmApp.CurrentUser.Id,
                        Status = MovingTask.TaskStatus.Open.ToString(),
                        Owner = App.RealmApp.CurrentUser.Profile.Email,
                        CreatedAt = DateTimeOffset.UtcNow
                    };

                MovingTasks.Append(task);

                realm.Write(() =>
                {
                    realm.Add(task);
                });

                MovingTaskEntryText = "";
                ButtonEnabled = true;
               
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayPromptAsync("Error", ex.Message);
                ButtonEnabled = true;
            }
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

              
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayPromptAsync("Error", ex.Message);
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
        async Task ViewStats()
        {
            //await Shell.Current.GoToAsync($"{nameof(TaskStatsPage)}");
            await Shell.Current.GoToAsync($"{nameof(StatsPage)}");
        }

        [RelayCommand]
        async Task Logout()
        {
            await Shell.Current.GoToAsync("/Login");
        }
    }
}
