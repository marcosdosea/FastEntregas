using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbFormaspagamento
    {
        public TbFormaspagamento()
        {
            TbformaspagamentoHasEntrega = new HashSet<TbFormaspagamentoHasEntrega>();
        }

        public int CodFormaPagamento { get; set; }
        public string Descricao { get; set; }

        public ICollection<TbFormaspagamentoHasEntrega> TbformaspagamentoHasEntrega { get; set; }
    }
}
