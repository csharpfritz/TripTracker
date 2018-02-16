using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TripTracker.BackService.Models;
using TripTracker.UI.Data;
using TripTracker.UI.Services;


namespace TripTracker.UI.Pages.Trips
{

	[Authorize]
	public class DeleteModel : PageModel
	{
		private readonly IApiClient _Client;

		public DeleteModel(IApiClient client)
		{
			_Client = client;
		}

		[BindProperty]
		public Trip Trip { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Trip = await _Client.GetTripAsync(id.Value);

			if (Trip == null)
			{
				return NotFound();
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Trip = await _Client.GetTripAsync(id.Value);

			if (Trip != null)
			{
				await _Client.RemoveTripAsync(id.Value);
			}

			return RedirectToPage("./Index");
		}
	}
}
