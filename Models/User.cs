﻿
using Realms;

namespace HouseMovingAssistant.Models
{
	public partial class User : IRealmObject
	{
        [PrimaryKey]
        [MapTo("_id")]
        [Required]
        public string Id { get; set; }

        [MapTo("_partition")]
        [Required]
        public string Partition { get; set; }

        [MapTo("name")]
        [Required]
        public string Name { get; set; }

        [MapTo("email")]
        [Required]
        public string Email { get; set; }
    }
}

