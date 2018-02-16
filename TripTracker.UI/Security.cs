using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripTracker.UI
{
	public class Security
	{

		public static void Configure(RazorPagesOptions options)
		{
			options.Conventions.AuthorizeFolder("/Account/Manage");
			options.Conventions.AuthorizePage("/Account/Logout");

		}

	}
}
