using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private string connectionString = "Server=CHRIS-PC\\SQLEXPRESS;Database=pru;User Id=sa;Password=sqlServerPassword;TrustServerCertificate=True;";

        public IActionResult Index(int? categoriaId)
        {
            var categorias = ObtenerCategoriasConVentas2019();
            ViewBag.Categorias = categorias;
            ViewBag.CategoriaSeleccionada = categoriaId;

            List<Producto> productos = new List<Producto>();
            if (categoriaId.HasValue)
            {
                productos = ObtenerProductosPorCategoria2019(categoriaId.Value);
            }

            return View(productos);
        }

        private List<Categoria> ObtenerCategoriasConVentas2019()
        {
            var lista = new List<Categoria>();
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT DISTINCT c.IdCategoria, c.NombreCategoria
                FROM Categorias c
                JOIN Productos p ON c.IdCategoria = p.IdCategoria
                JOIN Ventas v ON p.IdProducto = v.IdProducto
                WHERE YEAR(v.FechaVenta) = 2019";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Categoria
                    {
                        IdCategoria = (int)reader["IdCategoria"],
                        NombreCategoria = reader["NombreCategoria"].ToString()
                    });
                }
            }
            return lista;
        }

        private List<Producto> ObtenerProductosPorCategoria2019(int idCategoria)
        {
            var lista = new List<Producto>();
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT DISTINCT p.NombreProducto
                FROM Productos p
                JOIN Ventas v ON p.IdProducto = v.IdProducto
                WHERE p.IdCategoria = @IdCategoria AND YEAR(v.FechaVenta) = 2019";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Producto
                    {
                        NombreProducto = reader["NombreProducto"].ToString()
                    });
                }
            }
            return lista;
        }
    }
}
