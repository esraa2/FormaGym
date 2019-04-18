using Forma_Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forma_Gym.ViewModel
{
	public class FormaActivityAndClasses
	{
		public FormaActivity FormaActivity { get; set; }
		public IEnumerable<Classes> Classes { get; set; }
	}
}