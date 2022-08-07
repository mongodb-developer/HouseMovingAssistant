using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HouseMovingAssistant.Models;
using Realms;
using Realms.Sync;

namespace HouseMovingAssistant.ViewModels
{
    [QueryProperty(nameof(MovingTask), nameof(MovingTask))]
    public partial class EditMovingTaskPageViewModel : ObservableObject
    {
        private string newName;
        private string newStatus;
        public EditMovingTaskPageViewModel()
        {
        }

        private Realm realm;
        private PartitionSyncConfiguration config;

        public string NewStatus { get; set; }

        public string NewName { get; set; }

        [ObservableProperty]
        MovingTask movingTask;

        [ObservableProperty]
        int index;

        [RelayCommand]
        async Task SaveMovingTask()
        {
            config = new PartitionSyncConfiguration($"{App.RealmApp.CurrentUser.Id}", App.RealmApp.CurrentUser);
            realm = await Realm.GetInstanceAsync(config);

            

            try
            {
                realm.Write(() =>
                {
                    var task = realm.Find<MovingTask>(MovingTask.Id);

                    task.Name = newName;
                    task.Status = newStatus;

                });

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayPromptAsync("Error", ex.Message);
            }

        }

        [RelayCommand]
         void PickerSelectedItemChanged(int selectedItemIndex)
        {
            newName = MovingTask.Name;
            newStatus = MovingTask.Status;

            switch(selectedItemIndex)
            {
                case 0:
                    newStatus = MovingTask.TaskStatus.Open.ToString();
                    break;
                case 1:
                    newStatus = MovingTask.TaskStatus.InProgress.ToString();
                    break;
                case 2:
                    newStatus = MovingTask.TaskStatus.Complete.ToString();
                    break;
            }
        }

        [RelayCommand]
        async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
