using Model.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public partial class SolicitacaoDeCadastro
    {
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "campo_requerido")]
        [Key]
        public int CodSolicitacao { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "campo_requerido")]
        [Display(Name = "numRegistro", ResourceType = typeof(Mensagem))]
        [StringLength(15)]
        public string NumRegistro { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "campo_requerido")]
        [Display(Name = "numCNH", ResourceType = typeof(Mensagem))]
        [StringLength(15)]
        public string NumCnh { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "campo_requerido")]
        [Display(Name = "dtNascimento", ResourceType = typeof(Mensagem))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        public string Status { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "campo_requerido")]
        [Display(Name = "cdUsuario", ResourceType = typeof(Mensagem))]
        public int CodUsuarioEntregador { get; set; }

        public int? CodUsuarioFuncionario { get; set; }
}
}
