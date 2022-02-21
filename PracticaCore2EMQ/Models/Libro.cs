using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2EMQ.Models
{
    [Table("LIBROS")]
    public class Libro
    {

        [Key]
        [Column("IDLIBRO")]
        public int IdLibro { get; set; }

        [Column("TITULO")]
        public String NombreLibro { get; set; }

        [Column("AUTOR")]
        public String Author { get; set; }

        [Column("EDITORIAL")]
        public String Editorial { get; set; }

        [Column("PORTADA")]
        public String Portada { get; set; }

        [Column("RESUMEN")]
        public String Resumen { get; set; }

        [Column("PRECIO")]
        public int Precio { get; set; }

        [Column("IDGENERO")]
        public int IdGenero { get; set; }


    }
}
