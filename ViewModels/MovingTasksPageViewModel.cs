using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Realms;
using Realms.Sync;
using MvvmHelpers;
using System.Windows.Input;
using MvvmHelpers.Commands;
using HouseMovingAssistant.Models;

using User = HouseMovingAssistant.Models.User;

namespace HouseMovingAssistant.ViewModels
{
   
    public class MovingTasksPageViewModel : BaseViewModel
    {

        private User user;
        private Realm realm;
        private PartitionSyncConfiguration config;

        public ICommand AddTaskCommand { get; set; }  
        

        public MovingTasksPageViewModel()
        {
            WelcomeMessage = $"Welcome in {App.RealmApp.CurrentUser.Profile.Email}!";

            AddTaskCommand = new AsyncCommand(() => AddMovingTask());
           

            movingTasks = new ObservableCollection<MovingTask>();
        }

        private string welcomeMessage = "Welcome in!";
        public string WelcomeMessage
        {
            get => welcomeMessage;
            set => SetProperty(ref welcomeMessage, value);
        }

        private string movingTaskEntryText = "";
        public string MovingTaskEntryText
        {
            get => movingTaskEntryText;
            set => SetProperty(ref movingTaskEntryText, value);
        }

        private ObservableCollection<MovingTask> movingTasks;
        public ObservableCollection<MovingTask> MovingTasks
        {
            get => movingTasks;
            set => SetProperty(ref movingTasks, value);
            
        }

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

        public async Task ChangeTaskStatus(string status)
        {
            
        }

        private async Task AddMovingTask()
        {
            if(MovingTaskEntryText.Length > 0)
            {
                try
                {
                    var task =
                        new MovingTask
                        {
                            Name = MovingTaskEntryText,
                            Partition = App.RealmApp.CurrentUser.Id,
                            Status = "Open"
                        };

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
        }       
    }
}
