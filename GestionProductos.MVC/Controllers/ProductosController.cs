using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using GestionProductos.MVC.Models;

namespace GestionProductos.MVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductosController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("API");
            var response = await client.GetAsync("api/productos");

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<ProductoViewModel>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var productos = JsonSerializer.Deserialize<List<ProductoViewModel>>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(productos);
        }
    }
}

