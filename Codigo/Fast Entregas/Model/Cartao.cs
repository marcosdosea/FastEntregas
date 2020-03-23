﻿using Model.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public partial class Cartao
    {
        [Key]
        public int CodCartao { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "campo_requerido")]
        [Display(Name = "numCartao", ResourceType = typeof(Mensagem))]
        [StringLength(16)]
        [MinLength(16)]
        public string Numero { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "campo_requerido")]
        [Display(Name = "nmDono", ResourceType = typeof(Mensagem))]
        [StringLength(50)]
        public string NomeDono { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "campo_requerido")]
        [Display(Name = "dtValidade", ResourceType = typeof(Mensagem))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:mm/yyyy}", ApplyFormatInEditMode =true)]
        public string DataValidade { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "campo_requerido")]
        [Display(Name = "cdSegurança", ResourceType = typeof(Mensagem))]
        public int Cvv { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "campo_requerido")]
        public int CodUsuario { get; set; }

    }
}
