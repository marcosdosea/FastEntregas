using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class UsuarioVeiculo
    {
        public int CodUsuario { get; set; }
        public int CodVeiculo { get; set; }

        public virtual Usuario CodUsuarioNavigation { get; set; }
        public virtual Veiculo CodVeiculoNavigation { get; set; }
    }
}
