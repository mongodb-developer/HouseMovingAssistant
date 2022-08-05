using System;
using MongoDB.Bson;
using Realms;

namespace HouseMovingAssistant.Models
{
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

        [MapTo("_partition")]
        [Required]
        public string Partition { get; set; }

        [MapTo("status")]
        [Required]
        public string Status { get; set; }        
    }
}

