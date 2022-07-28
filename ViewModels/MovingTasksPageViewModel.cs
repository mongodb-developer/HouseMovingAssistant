using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using System.Windows.Input;
using MvvmHelpers.Commands;
using HouseMovingAssistant.Models;

namespace HouseMovingAssistant.ViewModels
{
   
    public class MovingTasksPageViewModel : BaseViewModel
    {
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

        private async Task AddMovingTask()
        {
            if(MovingTaskEntryText.Length > 0)
            {
                try
                {
                    MovingTasks.Add(
                        new MovingTask
                        {
                            Name = MovingTaskEntryText,
                            Partition = App.RealmApp.CurrentUser.Id,
                            Status = "Open"                            
                        }
                    );

                    MovingTaskEntryText = "";

                } catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayPromptAsync("Error", ex.Message);

                }
            }
        }
        
    }
}
