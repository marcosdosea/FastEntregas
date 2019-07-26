using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbCartao
    {
        public int CodCartao { get; set; }
        public string Numero { get; set; }
        public string NomeDono { get; set; }
        public string DataValidade { get; set; }
        public int Cvv { get; set; }
        public int CodUsuario { get; set; }

        public virtual TbUsuario CodUsuarioNavigation { get; set; }
    }
}
