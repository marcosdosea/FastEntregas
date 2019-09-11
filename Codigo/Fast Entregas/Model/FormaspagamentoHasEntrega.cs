using System;
using System.Collections.Generic;
using Model.Resources;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public partial class FormaspagamentoHasEntrega
    {
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "campo_requerido")]
        [Key]
        public int CodFormaPagamento { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "campo_requerido")]
        [Key]
        public int CodEntrega { get; set; }
        public float Valor { get; set; }
    }
}
