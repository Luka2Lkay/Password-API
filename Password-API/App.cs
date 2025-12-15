using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Password_API.services;

namespace Password_API
{
    public class App

    {
        private readonly Logger _logger = new Logger();
        private readonly DictionaryService _dictionaryService = new DictionaryService();
        public void SubmitCv ()
        {
            _logger.Info("Generating dictionary...");

            List<string> passwords = _dictionaryService.GeneratePassword("passwords");


            foreach (var password in passwords)
            {

            }


            passwords.ForEach(p => Console.WriteLine($"Generated Password: {p}"));

            
        }


    }
}
