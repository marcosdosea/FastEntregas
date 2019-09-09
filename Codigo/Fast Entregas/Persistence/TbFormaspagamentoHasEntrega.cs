using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbFormaspagamentoHasEntrega
    {
        public int FormasPagamentoCodFormaPagamento { get; set; }
        public int EntregaCodCorridaEntrega { get; set; }
        public float Valor { get; set; }

        public TbEntrega EntregaCodCorridaEntregaNavigation { get; set; }
        public TbFormaspagamento FormasPagamentoCodFormaPagamentoNavigation { get; set; }
    }
}
