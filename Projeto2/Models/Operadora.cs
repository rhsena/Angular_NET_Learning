using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projeto2.Models
{
    [Table("Operadora")]
    public class Operadora
    {
        [Key]
        public int OperadoraID { get; set; }

        [Required]
        public string NomeOperadora { get; set; }

        [Required]
        public string CodigoOperadora { get; set; }

        public string Tipo { get; set; }

        //public Contato Contato { get; set; }
    }
}