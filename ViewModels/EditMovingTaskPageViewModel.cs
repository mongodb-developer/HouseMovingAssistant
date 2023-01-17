using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HouseMovingAssistant.Models;
using HouseMovingAssistant.Services;
using Realms;
using Realms.Sync;

namespace HouseMovingAssistant.ViewModels
{
    [QueryProperty(nameof(MovingTask), nameof(MovingTask))]
    public partial class EditMovingTaskPageViewModel : ObservableObject
    {   
        private Realm realm; 

        [ObservableProperty]
        MovingTask movingTask;

        [ObservableProperty]
        int index;

        [RelayCommand]
        async Task PickerSelectedItemChanged(int selectedItemIndex)
        {          
            realm = RealmDatabaseService.GetRealm();

            try
            {
                var task = realm.Find<MovingTask>(MovingTask.Id);

                realm.Write(() =>
                {
                    switch (selectedItemIndex)
                    {
                        case 0:
                            task.Status = MovingTask.TaskStatus.Open.ToString();
                            break;
                        case 1:
                            task.Status = MovingTask.TaskStatus.InProgress.ToString();
                            break;
                        case 2:
                            task.Status = MovingTask.TaskStatus.Complete.ToString();
                            break;
                    }
                });               
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayPromptAsync("Error", ex.Message);
            }            
        }
    }
}
