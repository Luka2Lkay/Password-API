using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Password_API.services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const int MaxConcurrentRequest = 3;

    }
}
