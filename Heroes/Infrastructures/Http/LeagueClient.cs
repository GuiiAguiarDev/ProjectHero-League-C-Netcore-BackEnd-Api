using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;

namespace Infrastructure.Http
{
    public class LeagueClient : ILeague
    {

        private readonly HttpClient _httpClient;

        public LeagueClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LeagueDto> GetLeagueById(Guid LeagueId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/league/{LeagueId}");
                if (!response.IsSuccessStatusCode) return null;

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var league = await response.Content.ReadFromJsonAsync<LeagueDto>(options);
                return league;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao buscar");
                return null;
            }        }

    

        public async Task<bool> LeaguesExists(Guid LeagueID)
        {
            var response = await _httpClient.GetAsync($"api/league/{LeagueID}");
            return response.IsSuccessStatusCode;
        }
    }
}
