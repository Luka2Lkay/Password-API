
using System.Text;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace Password_API.services
{
    public class AuthService
    {
        private static readonly HttpClient _http = new HttpClient();
        private readonly SemaphoreSlim _throttle;
        private readonly string? _authUrl;
        private readonly int? _maximumRetries;
        private readonly int _delays;
        private readonly Logger _logger = new Logger();
        
        public  AuthService(IConfiguration configuration)
        {
            _authUrl = configuration["Api:AuthUrl"];
            _maximumRetries = int.Parse(configuration["Api:MaximumRetries"]);
            _throttle = new SemaphoreSlim(int.Parse(configuration["Api:MaximumConcurrentRequest"]));
            _delays = int.Parse(configuration["Api:ThrottleDelaysMS"]);
        
        }

        public async Task<string?> Athenticate(string username, List<string> passwords)
        {
            foreach (string password in passwords)
            {
                await _throttle.WaitAsync();
                try
                {
                   string? result =  await TryPassword(username, password);

                    if(result != null) 
                    {
                        return result;
                    }


                }
                finally { 
                _throttle.Release();
                }


                await Task.Delay(_delays);
            }

            return null;
        }

        private async Task<string?> TryPassword(string username, string password)
        {

            if(_authUrl == null) return null;

            string? urlKey = Environment.GetEnvironmentVariable(_authUrl);

            if (string.IsNullOrEmpty(urlKey)) {

                _logger.Warn("The urlKey value is missing.");
                return null;
            }

            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, urlKey);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", auth);

            Console.WriteLine($"Basic: {username}:{password}");
           
            for (int i = 1; i <= _maximumRetries; i++)
            { 
                try
                {
                    HttpResponseMessage response = await _http.SendAsync(request);

                    Console.WriteLine($"Tried password: {password} - Status Code: {response.StatusCode}");

                    if (response.IsSuccessStatusCode)
                    {
                        _logger.Success($"Password found: {password}");
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Warn($"Retry {i}: {ex.Message}");
                    await Task.Delay(500 * i);
                }
            }
            return null;
        }
    }
}