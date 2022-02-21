using Microsoft.AspNetCore.Mvc;
using PracticaCore2EMQ.Extensions;
using PracticaCore2EMQ.Models;
using PracticaCore2EMQ.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PracticaCore2EMQ.Controllers
{
    public class LibrosController : Controller
    {

        private RepositoryLibros repo;

        public LibrosController(RepositoryLibros repo)
        {
            this.repo = repo;
        }
        public IActionResult DetallesLibro(int idlibro, bool? cesta)
        {
            Libro libro = this.repo.FindLibro(idlibro);
            if(cesta != null && cesta == true)
            {
                List<int> libroscomprados = HttpContext.Session.GetObject<List<int>>("libroscesta");
                if (libroscomprados == null)
                {
                    libroscomprados = new List<int>();
                }
                libroscomprados.Add(idlibro);
                HttpContext.Session.SetObject("libroscesta",libroscomprados);
                ViewBag.Mensaje = "Añadido a la cesta";

            }
            return View(libro);
        }

        public IActionResult Cesta(int?idlibro)
        {
            List<int> libroscesta = HttpContext.Session.GetObject<List<int>>("libroscesta");
            if (idlibro != null)
            {
                libroscesta.Remove(idlibro.Value);
                HttpContext.Session.SetObject("libroscesta",libroscesta);
            }

            List<Libro> libros = new List<Libro>();
            foreach(int id in libroscesta)
            {
                Libro libro = this.repo.FindLibro(id);
                libros.Add(libro);
            }

            

            return View(libros);
        }

        [HttpPost]
        public IActionResult Cesta(List<int>idlibro)
        {
            foreach(int id in idlibro)
            {
                this.repo.InsertPedido(this.repo.GetIdFactura() + 1, id, int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            }
            return RedirectToAction("Index", "Home");
        }

      
    }
}
