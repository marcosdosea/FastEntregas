using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Formaspagamento
    {
        public Formaspagamento()
        {
            FormaspagamentoHasEntrega = new HashSet<FormaspagamentoHasEntrega>();
        }

        public int CodFormaPagamento { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<FormaspagamentoHasEntrega> FormaspagamentoHasEntrega { get; set; }
    }
}
