using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbVeiculo
    {
        public TbVeiculo()
        {
            UsuarioVeiculo = new HashSet<TbUsuarioVeiculo>();
        }

        public int CodVeiculo { get; set; }
        public string Categoria { get; set; }
        public string Placa { get; set; }
        public string Renavam { get; set; }
        public int Ano { get; set; }
        public string Status { get; set; }
        public string EmUso { get; set; }
        public int CodDono { get; set; }

        public virtual TbUsuario CodDonoNavigation { get; set; }
        public virtual ICollection<TbUsuarioVeiculo> UsuarioVeiculo { get; set; }
    }
}
