using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2EMQ.Models
{

    [Table("VISTA_PEDIDOS")]
    public class VistaPedidos
    {
        [Key]
        [Column("IDPEDIDO")]
        public int IdPedido { get; set; }

        [Column("NOMBRE")]
        public String NombreUsuario { get; set; }

        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }

        [Column("IDLIBRO")]
        public int IdLibro { get; set; }

        [Column("TITULO")]
        public String Titulo { get; set; }
    }
}
