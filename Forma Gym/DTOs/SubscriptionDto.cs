using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forma_Gym.DTOs
{
	public class SubscriptionDto
	{
		public byte Id { get; set; }

		[StringLength(255)]
		public string Name { get; set; }

		public byte Duration { get; set; }

		public short Fees { get; set; }

		public byte Discount { get; set; }
	}
}