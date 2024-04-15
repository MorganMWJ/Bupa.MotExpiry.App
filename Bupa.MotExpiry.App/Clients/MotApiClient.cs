using Bupa.MotExpiry.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace Bupa.MotExpiry.App.Clients;

public class MotApiClient
{
    private readonly HttpClient _httpClient;

    private const string Endpoint = "/trade/vehicles/mot-tests";

    public MotApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CarDetails> GetCarDetailsAsync(string registration)
    {
        var queryParams = new Dictionary<string, string>()
        {
           [nameof(registration)] = registration,
        };

        var uri = QueryHelpers.AddQueryString(Endpoint, queryParams!);

        var response = await _httpClient.GetAsync(uri);


    }
}
