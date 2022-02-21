using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2EMQ.Models
{

   [Table("GENEROS")]
    public class Genero
    {
        [Key]
        [Column("IDGENERO")]
        public int IdGenero { get; set; }

        [Column("NOMBRE")]
        public String Nombre { get; set; }
    }
}
