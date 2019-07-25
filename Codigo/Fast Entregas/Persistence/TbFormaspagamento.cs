using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbFormaspagamento
    {
        public TbFormaspagamento()
        {
            FormaspagamentoHasEntrega = new HashSet<TbFormaspagamentoHasEntrega>();
        }

        public int CodFormaPagamento { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<TbFormaspagamentoHasEntrega> FormaspagamentoHasEntrega { get; set; }
    }
}
