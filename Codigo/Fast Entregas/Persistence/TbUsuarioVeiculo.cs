using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbUsuarioVeiculo
    {
        public int CodUsuario { get; set; }
        public int CodVeiculo { get; set; }

        public virtual TbUsuario CodUsuarioNavigation { get; set; }
        public virtual TbVeiculo CodVeiculoNavigation { get; set; }
    }
}
