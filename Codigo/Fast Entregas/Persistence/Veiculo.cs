using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            UsuarioVeiculo = new HashSet<UsuarioVeiculo>();
        }

        public int CodVeiculo { get; set; }
        public string Categoria { get; set; }
        public string Placa { get; set; }
        public string Renavam { get; set; }
        public int Ano { get; set; }
        public string Status { get; set; }
        public byte EmUso { get; set; }
        public int CodDono { get; set; }

        public virtual Usuario CodDonoNavigation { get; set; }
        public virtual ICollection<UsuarioVeiculo> UsuarioVeiculo { get; set; }
    }
}
