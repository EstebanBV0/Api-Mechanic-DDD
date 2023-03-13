using Mechanic.DDD.api.Utilidades;
using Mechanic.DDD.Domain.Entities;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http;
using System.Text;

namespace Mechanic.DDD.api.AplicationServices
{
    public class ServicioExterno

    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ServicioExterno(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory; 
        }
        public async Task<string> UpdateStatusShoppingCart(string uri,StatusCarrito status)
        {
            StatusCarrito ob = new StatusCarrito()
            {
                Status = "Finalized"
            };
            string uris = "https://dev-lpg-njs-back-abandonedshopcart.luegopago.com/abandoned-shoppingcart/60a1a247-95a8-4b08-a6f9-d1ba1fed4330";

            string json = JsonConvert.SerializeObject(status); 
            Console.WriteLine("-----------------------this response " + json);

            var httpClient = _httpClientFactory.CreateClient("PruebaMate");

            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            Console.WriteLine("-----------------------this response " + data+"-------------");
            var response = await httpClient.PatchAsync(uri, data);
            Console.WriteLine($"this response {response}");
            return "esta hecho";


        }

    }
}
