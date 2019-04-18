using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forma_Gym.Models
{
	public class Subscriber
	{
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime? BirthDate { get; set; }

		public Subscription Subscription { get; set; }

		[Display(Name = "Subscription")]
		public byte SubscriptionId { get; set; }
	}
}