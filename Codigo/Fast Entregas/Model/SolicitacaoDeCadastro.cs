using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public partial class SolicitacaoDeCadastro
    {
        [Required]
        [Key]
        public int CodSolicitacao { get; set; }
        [Required]
        [Display(Name ="Número do Registro")]
        [StringLength(15)]
        public string NumRegistro { get; set; }
        [Required]
        [Display(Name ="Número da CNH")]
        [StringLength(15)]
        public string NumCnh { get; set; }
        [Required]
        [Display(Name = "Data de Validade")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int CodUsuarioEntregador { get; set; }
        public int CodUsuarioFuncionario { get; set; }
}
}
