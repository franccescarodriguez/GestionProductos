using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text;
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

        // =======================
        // LISTADO
        // =======================
        public async Task<IActionResult> Index(bool soloActivos = false)
        {
            var client = _httpClientFactory.CreateClient("API");
            var url = soloActivos ? "api/productos?soloActivos=true" : "api/productos";

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View(new List<ProductoViewModel>());

            var json = await response.Content.ReadAsStringAsync();
            var productos = JsonSerializer.Deserialize<List<ProductoViewModel>>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            ViewBag.SoloActivos = soloActivos;

            return View(productos);
        }


        // =======================
        // CREATE
        // =======================

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoViewModel producto)
        {
            // ✅ Validación
            if (!ModelState.IsValid)
                return View(producto);

            var client = _httpClientFactory.CreateClient("API");
            var json = JsonSerializer.Serialize(producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/productos", content);

            if (!response.IsSuccessStatusCode)
                return View(producto);

            // ✅ Mensaje de éxito
            TempData["Success"] = "Producto creado correctamente";

            return RedirectToAction(nameof(Index));
        }

        // =======================
        // EDIT
        // =======================

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("API");
            var response = await client.GetAsync($"api/productos/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var producto = JsonSerializer.Deserialize<ProductoViewModel>(
                json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductoViewModel producto)
        {
            // ✅ Validar Id
            if (id != producto.IdProducto)
                return BadRequest();

            // ✅ Validación de modelo
            if (!ModelState.IsValid)
                return View(producto);

            var client = _httpClientFactory.CreateClient("API");
            var json = JsonSerializer.Serialize(producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"api/productos/{id}", content);

            if (!response.IsSuccessStatusCode)
                return View(producto);

            // ✅ Mensaje de éxito
            TempData["Success"] = "Producto actualizado correctamente";

            return RedirectToAction(nameof(Index));
        }

        // =======================
        // DELETE
        // =======================

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int id, bool soloActivos = false)
        {
            var client = _httpClientFactory.CreateClient("API");
            await client.DeleteAsync($"api/productos/{id}");

            return RedirectToAction(nameof(Index), new { soloActivos });
        }



        public async Task<IActionResult> Reactivar(int id, bool soloActivos = false)
        {
            var client = _httpClientFactory.CreateClient("API");
            await client.PutAsync($"api/productos/reactivar/{id}", null);

            return RedirectToAction(nameof(Index), new { soloActivos });
        }



    }
}
