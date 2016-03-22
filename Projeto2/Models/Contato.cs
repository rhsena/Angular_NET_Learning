
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projeto2.Models
{
    [Table("Contato")]
    public class Contato
    {
        [Key]
        public long ContatoID { get; set; }

        [Required]
        public string NomeContato { get; set; }

        [Required]
        public string TelefoneContato { get; set; }

        [ForeignKey("Operadora")]
        public int OperadoraIDContato { get; set; }

        public virtual Operadora Operadora { get; set; }
    }
}