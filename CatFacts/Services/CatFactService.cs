using CatFacts.Data;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatFacts
{
    internal class CatFactService : ICatFactService
    {
        private readonly HttpClient httpClient;

        public CatFactService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<String> GetFactAsync()
        {
            var response = await httpClient.GetStringAsync("https://catfact.ninja/fact");
            var fact = JsonConvert.DeserializeObject<CatFact>(response);

            return fact?.Fact;
        }
    }
}
