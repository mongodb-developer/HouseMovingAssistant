using HouseMovingAssistant.Models;
using MvvmHelpers;
using Realms.Sync;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using User = HouseMovingAssistant.Models.User;

namespace HouseMovingAssistant.ViewModels
{
    
    public class EditMovingTaskPageViewModel : BaseViewModel
    {
        public EditMovingTaskPageViewModel()
        {

        }

        private User user;
        private Realm realm;
        private PartitionSyncConfiguration config;

        private MovingTask taskToEdit;
        public MovingTask MovingTask
        {
            get => taskToEdit;
            set => SetProperty(ref taskToEdit, value);
        }
    }
}
