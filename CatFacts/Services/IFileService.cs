using System.Threading.Tasks;

namespace CatFacts.Services
{
    internal interface IFileService
    {
        Task AppendToFileAsync(string filePath, string content, string fileName);
    }
}