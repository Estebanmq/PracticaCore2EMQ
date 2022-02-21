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
        
        private int MaxIdPedidos()
        {
            var consulta = (from datos in this.context.Pedidos
                            select datos).Max(x => x.IdPedido);
            return consulta;
        }

        public int GetIdFactura()
        {
            var consulta = (from datos in this.context.Pedidos
                            select datos).Max(x => x.IdFactura);
            return consulta;
        }

        public List<VistaPedidos> GetPedidosUsuario(int idusuario)
        {
            var consulta = from datos in this.context.VistaPedidos
                           where datos.IdUsuario == idusuario
                           select datos;

            return consulta.ToList();
        }

        public void InsertPedido(int idfactura, int idlibro, int idusuario)
        {
            Pedido pedido = new Pedido();
            pedido.IdPedido = this.MaxIdPedidos() + 1;
            pedido.IdFactura = idfactura;
            pedido.Fecha = DateTime.Now;
            pedido.IdLibro = idlibro;
            pedido.IdUsuario = idusuario;
            pedido.Cantidad = 1;

            this.context.Pedidos.Add(pedido);
            this.context.SaveChanges();
        }

        public Usuario FindUsuario(int idusuario)
        {
            return this.context.Usuarios.SingleOrDefault(x => x.IdUsuario == idusuario);
        }

        public Usuario LogIn(string email, string password)
        {
            var consulta = from datos in this.context.Usuarios
                           where datos.Email == email && datos.Password == password
                           select datos;

            return consulta.FirstOrDefault();
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
