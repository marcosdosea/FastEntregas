using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public partial class Veiculo
    {
        [Required]
        [Key]
        public int CodVeiculo { get; set; }
        [Required]
        [StringLength(20)]
        public string Categoria { get; set; }
        [Required]
        [StringLength(10)]
        public string Placa { get; set; }
        [Required]
        [StringLength(20)]
        public string Renavam { get; set; }
        [Required]
        public int Ano { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string EmUso { get; set; }
        [Required]
        public int CodDono { get; set; }
    }
}
