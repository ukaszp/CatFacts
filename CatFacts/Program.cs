using CatFacts.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CatFacts
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddHttpClient() 
                .AddSingleton<ICatFactService, CatFactService>()
                .AddSingleton<IFileService, FileService>()
                .BuildServiceProvider();

            var catFactService = serviceProvider.GetRequiredService<ICatFactService>();
            var fileService = serviceProvider.GetRequiredService<IFileService>();

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Console.WriteLine("Press any key to fetch a random cat fact. Press 'Esc' to exit.");

            while (true)
            {

                var key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

                try
                {
                    var fact = await catFactService.GetFactAsync();
                    await fileService.AppendToFileAsync(filePath, fact, "catFacts.txt");
                    Console.WriteLine($"\nRandom Cat Fact: {fact}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError fetching cat fact: {ex.Message}\n");
                }
            }
        }
    }
}
