﻿using Bupa.MotExpiry.App.Extensions;
using Bupa.MotExpiry.App.Models;
using Microsoft.AspNetCore.WebUtilities;

namespace Bupa.MotExpiry.App.Clients;

public class MotApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<MotApiClient> _logger;

    private const string Endpoint = "/trade/vehicles/mot-tests";

    public MotApiClient(HttpClient httpClient, ILogger<MotApiClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<CarDetails> GetCarDetailsAsync(string registration)
    {
        var queryParams = new Dictionary<string, string>()
        {
           [nameof(registration)] = registration,
        };

        var uri = QueryHelpers.AddQueryString(Endpoint, queryParams!);

        var response = await _httpClient.GetAsync(uri);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogWarning($"Error on registration search. Unsuccessful response from API. StatusCode: {response.StatusCode}.");
            return null;
        }

        // using List<> because array is the base object of the json response :(
        var responseObject = await response.Content.ReadFromJsonAsync<List<MotServiceResponse>>();
        return responseObject.First().ToCarDetails();
    }
}
