using Microsoft.Extensions.Configuration;
using Password_API.services;

namespace Password_API
{
    public class App

    {
        private readonly Logger _logger = new Logger();
        private readonly DictionaryService _dictionaryService = new DictionaryService();
        private readonly AuthService _authService;
        private readonly ZipService _zipService = new ZipService();
        private readonly string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string _submissionDirectory;

        public App(IConfiguration configuration)
        {
            _authService = new AuthService(configuration);
            _submissionDirectory = Path.Combine(baseDirectory, "submission");
        }

        public async Task SubmitCv()
        {
            _logger.Info("Generating dictionary...");
            List<string> passwords = _dictionaryService.GeneratePassword("password");
            Directory.CreateDirectory(_submissionDirectory);
            string directoryPath = Path.Combine(_submissionDirectory, "dict.txt");
            File.WriteAllLines(directoryPath, passwords);
            _logger.Success("Dictionary generated!");   

            //_logger.Info("Authentication...");
            //string? uploadUrl = await _authService.Athenticate("John", passwords);

            //if (uploadUrl == null)
            //{
            //    _logger.Error("Authentication failed!");
            //    return;
            //}

            //_logger.Success("Authentication successful!");

            CopyRequiredFiles(_submissionDirectory);
          
            _logger.Info("Creating zip file...");
            string zipPath = _zipService.CreateZip(_submissionDirectory);
            _logger.Success("Zip file created!");

            _logger.Info("Submitting CV...");
        }

        private void CopyRequiredFiles(string directoryPath)
        {
            string cvSourcePath = Path.Combine(Directory.GetCurrentDirectory(), "Lukhanyo_Matshebelele_Full_Stack_Developer_CV.pdf");
            string cvDestinationPath = Path.Combine(directoryPath, "Lukhanyo_Matshebelele_Full_Stack_Developer_CV.pdf");

            File.Copy(cvSourcePath, cvDestinationPath, true);
            File.Copy("appsettings.json", Path.Combine(directoryPath, "appsettings.json"), true);

            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.cs");

            foreach (string file in files)
            {

                string destinationPath = Path.Combine(directoryPath, Path.GetFileName(file));
                File.Copy(file, destinationPath, true);

            }
        }
    }
}
