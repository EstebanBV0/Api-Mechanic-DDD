using Mechanic.DDD.api.Queries;
using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Mechanic.DDD.Infrastructure;
using System.Text.Json;


using Microsoft.AspNetCore.Mvc;
using Mechanic.DDD.api.Utilidades;
using System.Net.Http;

namespace Mechanic.DDD.api.AplicationServices
{
    public class DuenoServices
    {
        private readonly DuenoQueries duenoQueries;
        private readonly IDuenoRepository duenoRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        


        public DuenoServices(DuenoQueries duenoQueries, IDuenoRepository duenoRepository, IHttpClientFactory httpClientFactory)
        {
            this.duenoQueries = duenoQueries;
            this.duenoRepository = duenoRepository;
            _httpClientFactory = httpClientFactory;
        }
        //public async Task<bool> UpdateStatusShoppingCart()
        //{

        //    //Console.WriteLine('shoppingCartUrl: ', json)
        //    var httpClient = _httpClientFactory.CreateClient("vistaspokemon");
        //    Console.WriteLine("shoppingCartUrl");
        //    StringContent data = new StringContent("https://pokeapi.co/api/v2/type/3");
        //    var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/type/3");
        //    var responseData = string.Empty;
        //    //if (response.IsSuccessStatusCode && response.Content != null)
        //      responseData = await response.Content.ReadAsStringAsync();
        //    Console.WriteLine(responseData);
        //    return bool.Parse(responseData);
        //    //return response;


        //}












        // normal queries and services
        public async Task HandleCommands(Dueno dueno)
        {
            await duenoRepository.AddDueno(dueno);

        }
        public async Task<Dueno> GetDueno(int id)

        {
            return await duenoQueries.GetDuenoIdAsync(id);


        }
        public async Task<List<Dueno>> GetDuenosAsyc()
        {
            return await duenoQueries.GetDuenos();
        }
        public async Task<ActionResult> UpdateDueno(int id, Dueno dueno)
        {
            return await duenoQueries.UpdateDueno(id, dueno);
        }
        public async Task<ActionResult<Dueno>> DeleteDueno(int id)
        {
            return await duenoQueries.DeleteDueno(id);
        }
    }
}
