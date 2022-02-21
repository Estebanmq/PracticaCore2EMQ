using Microsoft.AspNetCore.Mvc;
using PracticaCore2EMQ.Models;
using PracticaCore2EMQ.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult DetallesLibro(int idlibro)
        {
            Libro libro = this.repo.FindLibro(idlibro);
            return View(libro);
        }

        [HttpPost]
        public IActionResult DetallesLibro(int idlibro, string nombre)
        {   
            

            ViewBag.Mensaje = "Añadido a la cesta";
            return View();
        }
    }
}
