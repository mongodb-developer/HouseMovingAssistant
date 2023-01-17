
using Realms;

namespace HouseMovingAssistant.Models
{
	public partial class User : IRealmObject
	{
        [PrimaryKey]
       
        [Required]
        [MapTo("_id")]
        public string Id { get; set; }

       
        [Required]
        [MapTo("_partition")]
        public string Partition { get; set; }

        
        [Required]
        [MapTo("name")]
        public string Name { get; set; }       
        
        [MapTo("email")]
        public string Email { get; set; }
    }
}

