using System.Net.Http.Json;
using Route2.Models;

namespace Route2.Services
{
    public class MapaService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://routeips.runasp.net/api/Mapa";

        public MapaService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<LocalItem>> GetLocalsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<LocalItem>>($"{BaseUrl}/locais");
            return response ?? new List<LocalItem>();
        }

        public async Task<List<SubLocalItem>> GetSubLocalsByLocalIdAsync(Guid localId)
        {
            var response = await _httpClient.GetFromJsonAsync<List<SubLocalItem>>($"{BaseUrl}/sublocais");
            if (response == null)
                return new List<SubLocalItem>();

            return response.Where(s => s.LocalID == localId).ToList();
        }
    }
}