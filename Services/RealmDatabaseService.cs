using Realms.Sync;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseMovingAssistant.Models;

namespace HouseMovingAssistant.Services
{
    public static class RealmDatabaseService
    {
        public static Realm GetRealm()
        {
            PartitionSyncConfiguration config = new PartitionSyncConfiguration($"{App.RealmApp.CurrentUser.Id}", App.RealmApp.CurrentUser);
            return Realm.GetInstance(config);
        }
    }
}
