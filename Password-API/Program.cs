using Password_API;
using Microsoft.Extensions.Configuration;
public class Program
{
    public static async Task Main(string[] arg)
    {

        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        App app = new App(configuration);

        await app.SubmitCv();

    }
}