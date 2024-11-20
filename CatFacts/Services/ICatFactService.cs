using System.Threading.Tasks;

namespace CatFacts
{
    internal interface ICatFactService
    {
        Task<string> GetFactAsync();
    }
}