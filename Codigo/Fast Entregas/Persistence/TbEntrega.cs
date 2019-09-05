using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbEntrega
    {
        public TbEntrega()
        {
            FormaspagamentoHasEntrega = new HashSet<TbFormaspagamentoHasEntrega>();
        }

        public int CodEntrega { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public float Valor { get; set; }
        public string Duracao { get; set;}
        public string Distancia { get; set; }
        public string Descricao_origem { get; set; }
        public string Descricao_destino { get; set; }
        public int CodUsuarioCliente { get; set; }
        public int? CodUsuarioEntregador { get; set; }

        public virtual TbUsuario CodUsuarioClienteNavigation { get; set; }
        public virtual TbUsuario CodUsuarioEntregadorNavigation { get; set; }
        public virtual ICollection<TbFormaspagamentoHasEntrega> FormaspagamentoHasEntrega { get; set; }
    }
}
