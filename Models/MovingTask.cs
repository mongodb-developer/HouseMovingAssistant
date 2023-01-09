using System;
using MongoDB.Bson;
using Realms;

namespace HouseMovingAssistant.Models
{
    //TODO You could consider using the new source generated classes if you're using version >= 10.18.0
    //Only thing you need to do is to make the class partial, and use IRealmObject instead of RealmObject
    public class MovingTask : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("owner")]
        public string Owner { get; set; }

        [MapTo("name")]
        [Required]
        public string Name { get; set; }

        //TODO I think it would make sense to always have MapTo as the attribute "closest" to the property definition, so it's slightly easier to read 
        [MapTo("_partition")]
        [Required]
        public string Partition { get; set; }

        //TODO You could consider creating making this private and creating another public variable of type TaskStatus and then convert between them
        //like it's suggested in https://www.mongodb.com/developer/products/realm/advanced-modeling-realm-dotnet/ (Using Unpersistable Data Types)
        //Also a matter of preference, but it helps to avoid writing wrong status strings for instance
        [MapTo("status")]
        [Required]
        public string Status { get; set; }

        [MapTo("createdAt")]        
        public DateTimeOffset CreatedAt { get; set; }

        public enum TaskStatus
        {
            Open,
            InProgress,
            Complete
        }
    }
}

   

