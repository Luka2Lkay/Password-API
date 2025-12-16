using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_API.services
{
    public class ZipService
    {
        public string CreateZip() {

            const string directory = "submission";
            const string zipPath = "submission.zip";
            const string cvPath = "Lukhanyo_Matshebelele_Full_Stack_Developer_CV.pdf";
            const string dictionaryPath = "dict.txt";
            const string programPath = "Program.cs";

            Directory.CreateDirectory(directory);
            File.Copy(cvPath, Path.Combine(directory, cvPath), true);
            File.Copy(dictionaryPath, Path.Combine(directory, dictionaryPath), true);
            File.Copy(programPath, Path.Combine(directory, programPath), true);

            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

            ZipFile.CreateFromDirectory(directory, zipPath);

            return zipPath;

        }
    }
}
