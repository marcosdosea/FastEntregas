using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public partial class ContaBancaria
    {
        [Required]
        [Key]
        public int CodConta { get; set; }
        [Required]
        [Display(Name ="Número da Conta")]
        public int Numero { get; set; }
        [Required]
        [Display(Name ="Agência")]
        public int Agencia { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public int CodUsuario { get; set; }
        [Required]
        public int CodBanco { get; set; }
    }
}
