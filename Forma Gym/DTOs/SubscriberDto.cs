using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forma_Gym.DTOs
{
	public class SubscriberDto
	{
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime? BirthDate { get; set; }

		public SubscriptionDto Subscription { get; set; }

		[Display(Name = "Subscription types")]
		public byte SubscriptionId { get; set; }
	}
}