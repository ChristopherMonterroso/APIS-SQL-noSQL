
using Microsoft.AspNetCore.Mvc;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            var productos = _context.Productos.ToList();
            return Ok(productos);
        }

        [HttpPost]
        public IActionResult AgregarProducto([FromBody] Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return Ok(producto);
        }
    }
}
