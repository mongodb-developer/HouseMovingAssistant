
using Realms;

namespace HouseMovingAssistant.Models
{
	public class User : RealmObject
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
    }
}

