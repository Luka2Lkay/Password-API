using Password_API;
using Microsoft.Extensions.Configuration;
public class Program
{
    public static void Main(string[] arg)
    {

        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        var app = new App(configuration);

        app.SubmitCv();

    }
}