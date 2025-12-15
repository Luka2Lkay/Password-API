using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Password_API.services
{
    public class AuthService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly SemaphoreSlim _throttle;
        private readonly string _authUrl;
        private readonly int _maximumRetries;
        private readonly int _delays;
        

        public AuthService(IConfiguration configuration)
        {
            _authUrl = configuration["Api:AuthUrl"];
            _maximumRetries = int.Parse(configuration["Api:MaximumRetries"]);
            _throttle = new SemaphoreSlim(int.Parse(configuration["Api:MaximumConcurrentRequest"]));
            _delays = int.Parse(configuration["Api:ThrottleDelaysMS"]);
           
        }

        public async Task<string> Athenticate(string username, List<string> passwords)
        {
            foreach (string password in passwords)
            {
                await _throttle.WaitAsync();
                await TryPassword(username, password).ContinueWith(throttle => _throttle.Release());
            }

            return null;
        }

        private async Task<string> TryPassword(string username, string password)
        {
           string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _authUrl);

        }

    }
}
