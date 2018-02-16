using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTracker.BackService.Models;

namespace TripTracker.UI.ViewComponents
{
	public class EditTripViewComponent : ViewComponent
	{

		public async Task<IViewComponentResult> InvokeAsync(Trip trip)
		{

			
			await Task.Delay(0);
			return View("Edit", trip);

		}

	}
}
