using System;
using MongoDB.Bson;
using Realms;

namespace HouseMovingAssistant.Models
{
    public partial class MovingTask : IRealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("owner")]
        public string Owner { get; set; }

        [Required]
        [MapTo("name")]
        public string Name { get; set; }

       
        [Required]
        [MapTo("_partition")]
        public string Partition { get; set; }

        [Required]
        [MapTo("status")]
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

   

