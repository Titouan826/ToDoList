using ApiTest.ApiKey;
using Microsoft.Extensions.Configuration;

Console.WriteLine($"{IConfiguration.GetValue<string>(Constants.ApiKeyName)}");