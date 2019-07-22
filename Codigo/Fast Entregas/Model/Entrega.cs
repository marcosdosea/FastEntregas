using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public partial class Entrega
    {
        [Required]
        [Key]
        public int CodEntrega { get; set; }
        [Required]
        [Display(Name ="Endereço de Origem")]
        [StringLength(100)]
        public string Origem { get; set; }
        [Required]
        [Display(Name = "Endereço de Destino")]
        [StringLength(100)]
        public string Destino { get; set; }
        [Required]
        [Display(Name ="Data da Corrida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/mm/yyyy}", ApplyFormatInEditMode =true)]
        public DateTime Data { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public float Valor { get; set; }
        [Required]
        [Display(Name ="Descrição")]
        [StringLength(300)]
        public string Descricao { get; set; }
        [Required]
        public int CodUsuarioCliente { get; set; }
        public int CodUsuarioEntregador { get; set; }
    }
}
