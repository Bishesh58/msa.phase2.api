// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Net.Http.Json;
using msa.phase2.api.client;

HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:7180");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = await client.GetAsync("api/products");
response.EnsureSuccessStatusCode();

if (response.IsSuccessStatusCode)
{
    Console.WriteLine("Loading products...");
    var products = await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
    foreach (var product in products)
    {
       
        Console.WriteLine(product.Title);
    }
}

Console.ReadLine();
