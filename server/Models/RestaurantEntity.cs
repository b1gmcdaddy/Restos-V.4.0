using System.ComponentModel.DataAnnotations;

namespace server.Models
{
	public class RestaurantEntity
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Resto { get; set; } = "";
		[Required]
		public string Type { get; set; } = "";

		public int Rating { get; set; }
		public bool IsVisited { get; set; }
		public string Description { get; set; } = "";
	}
}
