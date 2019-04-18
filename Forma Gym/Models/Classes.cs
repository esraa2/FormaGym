using System.ComponentModel.DataAnnotations;

namespace Forma_Gym.Models
{
	public class Classes
	{
		public byte Id { get; set; }

		[StringLength(255)]
		public string Type { get; set; }
	}
}