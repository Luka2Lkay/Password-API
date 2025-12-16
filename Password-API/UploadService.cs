using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_API
{
    public class UploadService
    {
        private readonly static HttpClient _httpClient = new HttpClient();
        private readonly IConfiguration _config;

        public UploadService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task Submission(string zipPath, string temporaryUrl)
        {
            byte[] bytes = await File.ReadAllBytesAsync(zipPath);
            string base64Content = Convert.ToBase64String(bytes);

            var payload = new
            {
               data = base64Content,

                

            };  
        }
    }
}
