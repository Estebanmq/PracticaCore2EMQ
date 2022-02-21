using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2EMQ.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }

        [Column("NOMBRE")]
        public String Nombre { get; set; }

        [Column("APELLIDOS")]
        public String Apellidos { get; set; }

        [Column("EMAIL")]
        public String Email { get; set; }

        [Column("PASS")]
        public String Password { get; set; }

        [Column("FOTO")]
        public String Foto { get; set; }
    }
}
