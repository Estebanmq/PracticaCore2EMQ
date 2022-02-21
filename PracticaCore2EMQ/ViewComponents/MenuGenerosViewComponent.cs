using Microsoft.AspNetCore.Mvc;
using PracticaCore2EMQ.Models;
using PracticaCore2EMQ.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2EMQ.ViewComponents
{
    public class MenuGenerosViewComponent : ViewComponent
    {

        private RepositoryLibros repo;

        public MenuGenerosViewComponent(RepositoryLibros repo)
        {
            this.repo = repo;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Genero> generos = this.repo.GetGeneros();
            return View(generos);
        }

    }
}
