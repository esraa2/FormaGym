using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forma_Gym.Models
{
	public class Rental
	{
		public int Id { get; set; }

		[Required]
		public Subscriber Subscriber { get; set; }

		[Required]
		public FormaActivity Activity { get; set; }

		public DateTime DateRented { get; set; }

		public DateTime? DateReturned { get; set; }
	}
}