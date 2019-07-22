using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public partial class Cartao
    {
        [Required]
        [Key]
        public int CodCartao { get; set; }
        [Required]
        [Display(Name ="Número do Cartão")]
        public int Numero { get; set; }
        [Required]
        [Display(Name ="Nome do Dono")]
        [StringLength(50)]
        public string NomeDono { get; set; }
        [Required]
        [Display(Name ="Data de Validade")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/mm/yyyy}", ApplyFormatInEditMode =true)]
        public string DataValidade { get; set; }
        [Required]
        [Display(Name ="Código de Segurança")]
        public int Cvv { get; set; }
        [Required]
        public int CodUsuario { get; set; }

    }
}
