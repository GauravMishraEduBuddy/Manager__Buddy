using EduBuddyApp.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FacilityService : IFacilityService
{
    private readonly HttpClient _httpClient;

    public FacilityService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<FacilityStatusDto>> GetFacilitiesStatusAsync(int schoolId)
    {
        var response = await _httpClient.GetFromJsonAsync<List<FacilityStatusDto>>(
            $"api/EduBuddyFacility/facilities-status?schoolId={schoolId}");
        return response ?? new List<FacilityStatusDto>();
    }
}