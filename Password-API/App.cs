using Microsoft.Extensions.Configuration;
using Password_API.services;

namespace Password_API
{
    public class App

    {
        private readonly Logger _logger = new Logger();
        private readonly DictionaryService _dictionaryService = new DictionaryService();
        private readonly AuthService _authService;

        public App (IConfiguration configuration)
        {
          _authService = new AuthService(configuration);
        }

        public async Task SubmitCv ()
        {
            _logger.Info("Generating dictionary...");
            List<string> passwords = _dictionaryService.GeneratePassword("password");
            File.WriteAllLines("dict.txt", passwords);

            _logger.Info("Authentication...");
            string? uploadUrl = await _authService.Athenticate("John", passwords);

            if (uploadUrl == null) {
                _logger.Error("Authentication failed!");
                return;
            }

            _logger.Success("Authentication successful!");
        }
    }
}
