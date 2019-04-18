using System.ComponentModel.DataAnnotations;

namespace Forma_Gym.Models
{
	public class Subscription
	{
		public byte Id { get; set; }

		[StringLength(255)]
		public string Name { get; set; }

		public byte Duration { get; set; }

		public short Fees { get; set; }

		public byte Discount { get; set; }


	}
}