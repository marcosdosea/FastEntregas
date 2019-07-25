using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbSolicitacaoDeCadastro
    {
        public int CodSolicitacao { get; set; }
        public string NumRegistro { get; set; }
        public string NumCnh { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Status { get; set; }
        public int CodUsuarioEntregador { get; set; }
        public int? CodUsuarioFuncionario { get; set; }

        public virtual TbUsuario CodUsuarioEntregadorNavigation { get; set; }
        public virtual TbUsuario CodUsuarioFuncionarioNavigation { get; set; }
    }
}
