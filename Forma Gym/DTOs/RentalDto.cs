using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forma_Gym.DTOs
{
	public class RentalDto
	{
		public int SubscriberId { get; set; }
		public List<int> ActivityIds { get; set; }
	}
}