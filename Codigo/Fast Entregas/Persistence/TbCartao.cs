using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Cartao
    {
        public int CodCartao { get; set; }
        public int Numero { get; set; }
        public string NomeDono { get; set; }
        public string DataValidade { get; set; }
        public int Cvv { get; set; }
        public int CodUsuario { get; set; }

        public virtual Usuario CodUsuarioNavigation { get; set; }
    }
}
