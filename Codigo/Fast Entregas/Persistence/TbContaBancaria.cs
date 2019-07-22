using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class ContaBancaria
    {
        public int CodConta { get; set; }
        public int Numero { get; set; }
        public int Agencia { get; set; }
        public string Tipo { get; set; }
        public int CodUsuario { get; set; }
        public int CodBanco { get; set; }

        public virtual Banco CodBancoNavigation { get; set; }
        public virtual Usuario CodUsuarioNavigation { get; set; }
    }
}
