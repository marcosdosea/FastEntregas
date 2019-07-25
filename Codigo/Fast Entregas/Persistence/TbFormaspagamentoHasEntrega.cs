using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbFormaspagamentoHasEntrega
    {
        public int FormasPagamentoCodFormaPagamento { get; set; }
        public int EntregaCodCorridaEntrega { get; set; }
        public float Valor { get; set; }

        public virtual TbEntrega EntregaCodCorridaEntregaNavigation { get; set; }
        public virtual TbFormaspagamento FormasPagamentoCodFormaPagamentoNavigation { get; set; }
    }
}
