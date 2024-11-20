using System.IO;
using System.Threading.Tasks;

namespace CatFacts.Services
{
    internal class FileService : IFileService
    {
        public async Task AppendToFileAsync(string filePath, string content, string fileName)
        {
            string fullPath = Path.Combine(filePath, fileName);

            using (StreamWriter outputFile = new StreamWriter(fullPath, append: true))
            {
                await outputFile.WriteLineAsync($"{content}\n");
            }
        }
    }
}
