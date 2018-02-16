using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TripTracker.BackService.Models;
using TripTracker.UI.Data;
using TripTracker.UI.Services;

namespace TripTracker.UI.Pages.Trips
{
    public class DetailsModel : PageModel
    {
        private readonly IApiClient _Client;

        public DetailsModel(IApiClient client)
        {
            _Client = client;
        }

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
    }
}
