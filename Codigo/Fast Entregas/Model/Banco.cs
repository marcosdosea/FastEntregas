using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public partial class Banco
    {
        [Required]
        [Key]
        public int CodBanco { get; set; }
        [Required]
        public string Nome { get; set; }

    }
}
