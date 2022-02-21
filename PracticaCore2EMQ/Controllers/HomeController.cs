    using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticaCore2EMQ.Models;
using PracticaCore2EMQ.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2EMQ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RepositoryLibros repo;

        public HomeController(ILogger<HomeController> logger, RepositoryLibros repo)
        {
            _logger = logger;
            this.repo = repo;
        }

        public IActionResult Index(int?idgenero)
        {
            List<Libro> libros = new List<Libro>();
            if(idgenero != null)
            {
                libros = this.repo.GetLibrosGenero(idgenero.Value);
            } else
            {
                libros = this.repo.GetLibros();
            }
            return View(libros);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
