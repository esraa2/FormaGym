using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forma_Gym.Models
{
	public class FormaActivity
	{
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[StringLength(255)]
		public string TrainerName { get; set; }

		public byte ClassDuration { get; set; }

		public Classes Class { get; set; }

		[Display(Name="Class Types")]
		public byte ClassId { get; set; }
	}
}