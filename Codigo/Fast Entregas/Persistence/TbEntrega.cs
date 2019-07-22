using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Entrega
    {
        public Entrega()
        {
            FormaspagamentoHasEntrega = new HashSet<FormaspagamentoHasEntrega>();
        }

        public int CodEntrega { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public float Valor { get; set; }
        public string Descricao { get; set; }
        public int CodUsuarioCliente { get; set; }
        public int? CodUsuarioEntregador { get; set; }

        public virtual Usuario CodUsuarioClienteNavigation { get; set; }
        public virtual Usuario CodUsuarioEntregadorNavigation { get; set; }
        public virtual ICollection<FormaspagamentoHasEntrega> FormaspagamentoHasEntrega { get; set; }
    }
}
