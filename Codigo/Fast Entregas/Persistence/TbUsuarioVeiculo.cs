using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbUsuarioVeiculo
    {
        public int CodUsuario { get; set; }
        public int CodVeiculo { get; set; }

        public TbUsuario CodUsuarioNavigation { get; set; }
        public TbVeiculo CodVeiculoNavigation { get; set; }
    }
}
