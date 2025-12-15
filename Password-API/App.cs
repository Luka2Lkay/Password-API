using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Password_API.services;
using Microsoft.Extensions.Configuration;

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

        public void SubmitCv ()
        {
            _logger.Info("Generating dictionary...");
            List<string> passwords = _dictionaryService.GeneratePassword("passwords");
            File.WriteAllLines("dict.txt", passwords);

            _logger.Info("Authentication...");
            _authService.Athenticate();


        


            //passwords.ForEach(p => Console.WriteLine($"Generated Password: {p}"));

            
        }


    }
}
