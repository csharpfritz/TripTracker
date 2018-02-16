using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripTracker.BackService.Models
{
	public class Trip
	{

		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

	}
}
