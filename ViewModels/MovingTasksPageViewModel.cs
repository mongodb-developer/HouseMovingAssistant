using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HouseMovingAssistant.Models;
using HouseMovingAssistant.Services;
using HouseMovingAssistant.Views;
using Realms;
using Realms.Sync;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;  //TODO Is this used?
using User = HouseMovingAssistant.Models.User;

namespace HouseMovingAssistant.ViewModels
{

    public partial class MovingTasksPageViewModel : ObservableObject
    {

        private User user;
        private Realm realm;
        private PartitionSyncConfiguration config;

        //TODO Personally I would put the constructor after all the fields and properties deifnition
        public MovingTasksPageViewModel()
        {
            WelcomeMessage = $"Welcome in {App.RealmApp.CurrentUser.Profile.Email}!";           
        }

        [ObservableProperty]
        string welcomeMessage;

        [ObservableProperty]
        string movingTaskEntryText;

        //TODO It's needed if initialized after the constructor (and so it needs to raise "OnPropertyChanged")
        //In general I think it's a good idea to have it, it doesn't hurt

        // Is this needed to be an observable property?
        [ObservableProperty]
        IEnumerable<MovingTask> movingTasks;

        [ObservableProperty]
        bool buttonEnabled;

        //TODO A question ... I can see that you leave empty lines in various parts of the code. Is this done for a particular reason?
       
        public void InitialiseRealm()
        {
            realm = RealmDatabaseService.GetRealm();
            Console.WriteLine(realm.All<User>());
            user = realm.Find<User>(App.RealmApp.CurrentUser.Id);

            if(user != null)
            {               
                MovingTasks = realm.All<MovingTask>().OrderBy(task => task.CreatedAt);                
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
                        Owner = App.RealmApp.CurrentUser.Profile.Email,
                        CreatedAt = DateTimeOffset.UtcNow
                    };                

                realm.Write(() =>
                {
                    realm.Add(task);
                });

                MovingTaskEntryText = "";

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayPromptAsync("Error", ex.Message);
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
            await Shell.Current.GoToAsync("TaskStatsPage");
        }        
    }
}
