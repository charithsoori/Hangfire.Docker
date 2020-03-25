using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Hangfire.Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("Server=db;Database=master;User=sa;Password=Your_password123;");

            var hostBuilder = new HostBuilder()
                // Add configuration, logging, ...
                .ConfigureServices((hostContext, services) =>
                {
                    // Add your services for depedency injection.
                });

            using (var server = new BackgroundJobServer(new BackgroundJobServerOptions()
            {
                Queues = new[] { "alpha", "default" },
                WorkerCount = 2
            }))
            {
                await hostBuilder.RunConsoleAsync();
            }
        }
    }
}
