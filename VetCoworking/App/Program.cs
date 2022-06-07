using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace VetCoworking.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Builder(args).Run();
        }

        public static IHost Builder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(cfg =>
            {
                cfg.UseStartup<Startup>();
            })
            .Build();
    }
}
