using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TripTracker.BackService.Models;

namespace TripTracker.UI.Services
{
	public interface IApiClient
	{

		Task<List<BackService.Models.Trip>> GetTripsAsync();
		Task<BackService.Models.Trip> GetTripAsync(int id);
		Task PutTripAsync(Trip tripToUpdate);
		Task AddTripAsync(Trip tripToAdd);
		Task RemoveTripAsync(int id);

	}

	public class ApiClient : IApiClient
	{

		private readonly HttpClient _HttpClient;

		public ApiClient(HttpClient httpClient)
		{
			_HttpClient = httpClient;
		}

		public async Task AddTripAsync(Trip tripToAdd)
		{

			var response = await _HttpClient.PostJsonAsync("/api/Trips", tripToAdd);

			response.EnsureSuccessStatusCode();


		}

		public async Task<Trip> GetTripAsync(int id)
		{
			var response = await _HttpClient.GetAsync($"/api/Trips/{id}");

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsJsonAsync<Trip>();

		}

		public async Task<List<Trip>> GetTripsAsync()
		{

			var response = await _HttpClient.GetAsync("/api/Trips");

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsJsonAsync<List<Trip>>();

		}

		public async Task PutTripAsync(Trip tripToUpdate)
		{

			var response = await _HttpClient.PutJsonAsync($"/api/Trips/{tripToUpdate.Id}", tripToUpdate);

			response.EnsureSuccessStatusCode();

		}

		public async Task RemoveTripAsync(int id)
		{

			var response = await _HttpClient.DeleteAsync($"/api/Trips/{id}");

			response.EnsureSuccessStatusCode();

		}
	}


}
