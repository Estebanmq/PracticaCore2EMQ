using PracticaCore2EMQ.Data;
using PracticaCore2EMQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2EMQ.Repositories
{
    public class RepositoryLibros
    {

        private LibrosContext context;

        public RepositoryLibros(LibrosContext context)
        {
            this.context = context;
        }

        public List<Libro>GetLibros()
        {
            var consulta = from datos in this.context.Libros
                           select datos;
            return consulta.ToList();
        }

        public List<Genero>GetGeneros()
        {
            var consulta = from datos in this.context.Genero
                           select datos;
            return consulta.ToList();
        }

        public List<Libro>GetLibrosGenero(int idgenero)
        {
            var consulta = from datos in this.context.Libros
                           where datos.IdGenero == idgenero
                           select datos;

            return consulta.ToList();
        }

        public Libro FindLibro(int idlibro)
        {
            return this.context.Libros.FirstOrDefault(x => x.IdLibro == idlibro);
        }
    }
}
