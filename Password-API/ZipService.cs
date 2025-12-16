using System.IO.Compression;

namespace Password_API.services
{
    public class ZipService
    {
        public string CreateZip(string sourceDirectory) {

            string zipPath = Path.Combine(AppContext.BaseDirectory, "submission.zip");

            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

            ZipFile.CreateFromDirectory(sourceDirectory, zipPath);

            return zipPath;

        }
    }
}
