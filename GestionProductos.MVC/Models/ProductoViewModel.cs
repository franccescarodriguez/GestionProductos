using System.ComponentModel.DataAnnotations;

namespace GestionProductos.MVC.Models
{
    public class ProductoViewModel
    {
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 99999)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, 10000)]
        public int Stock { get; set; }

        public bool Estado { get; set; }
    }
}
