using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public partial class Formaspagamento
    {
        [Required]
        [Key]
        public int CodFormaPagamento { get; set; }
        [Required]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }
}
}
