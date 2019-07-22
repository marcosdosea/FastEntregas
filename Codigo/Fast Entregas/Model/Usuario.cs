using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence
{
    public partial class Usuario
    {
        [Required]
        [Key]
        public int CodUsuario { get; set; }
        [Required]
        [StringLength(45)]
        public string Nome { get; set; }
        [Required]
        [StringLength(15)]
        public string Cpf { get; set; }
        [Required]
        [StringLength(12)]
        public string Telefone { get; set; }
        [Required]
        [StringLength(45)]
        public string Email { get; set; }
        [Required]
        [StringLength(45)]
        public string Senha { get; set; }
        [Required]
        public string Tipo { get; set; }
        public string StatusCliente { get; set; }
        public string StatusEntregador { get; set; }
    }
}
