using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class FormaspagamentoHasEntrega
    {
        public int FormasPagamentoCodFormaPagamento { get; set; }
        public int EntregaCodCorridaEntrega { get; set; }
        public float Valor { get; set; }

        public virtual Entrega EntregaCodCorridaEntregaNavigation { get; set; }
        public virtual Formaspagamento FormasPagamentoCodFormaPagamentoNavigation { get; set; }
    }
}
