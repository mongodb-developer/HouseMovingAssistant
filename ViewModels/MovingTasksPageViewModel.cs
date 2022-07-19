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

namespace HouseMovingAssistant.ViewModels
{
   
    public partial class MovingTasksPageViewModel : BaseViewModel
    {
        public MovingTasksPageViewModel()
        {
            WelcomeMessage = $"Welcome in {App.RealmApp.CurrentUser.Profile.Email}!";
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

    }
}
