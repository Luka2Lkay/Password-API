using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace Password_API
{
    public class UploadService
    {
        private readonly static HttpClient _http = new HttpClient();
        private readonly IConfiguration _config;

        public UploadService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task UploadSubmission(string zipPath, string temporaryUrl)
        {
            byte[] bytes = await File.ReadAllBytesAsync(zipPath);
            string base64Content = Convert.ToBase64String(bytes);

            string payload = JsonSerializer.Serialize(new
            {
                data = base64Content,
                name = _config["Upload:Name"],
                surname = _config["Upload:Surname"],
                email = _config["Upload:Email"]
            });

            HttpResponseMessage response = await _http.PostAsync(temporaryUrl, new StringContent(payload, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }
    }
}
