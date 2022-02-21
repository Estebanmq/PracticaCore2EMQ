using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2EMQ.Models
{

    [Table("VISTAPEDIDOS")]
    public class VistaPedidos
    {
        [Key]
        [Column("IDVISTAPEDIDOS")]
        public long IdPedido { get; set; }

        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }

        [Column("NOMBRE")]
        public String NombreUsuario { get; set; }

        [Column("APELLIDOS")]
        public String ApellidoUsuario { get; set; }


        [Column("TITULO")]
        public String Titulo { get; set; }

        [Column("PRECIO")]
        public int Precio { get; set; }

        [Column("PORTADA")]
        public String Portada { get; set; }

        [Column("FECHA")]
        public DateTime FechaPedido { get; set; }

        [Column("PRECIOFINAL")]
        public int PrecioFinal { get; set; }


    }
}
