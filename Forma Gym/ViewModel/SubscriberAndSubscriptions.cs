using Forma_Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forma_Gym.ViewModel
{
	public class SubscriberAndSubscriptions
	{
		public Subscriber Subscriber { get; set; }
		public IEnumerable<Subscription> Subscriptions { get; set; }
	}
}