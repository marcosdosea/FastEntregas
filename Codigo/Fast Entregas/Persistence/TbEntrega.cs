using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbEntrega
    {
        public TbEntrega()
        {
            TbformaspagamentoHasEntrega = new HashSet<TbFormaspagamentoHasEntrega>();
        }

        public int CodEntrega { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public float Valor { get; set; }
        public string DescricaoOrigem { get; set; }
        public string DescricaoDestino { get; set; }
        public int CodUsuarioCliente { get; set; }
        public int? CodUsuarioEntregador { get; set; }
        public string Duracao { get; set; }
        public string Distancia { get; set; }
        public int? CodVeiculo { get; set; }
        public string CategoriaVeiculo { get; set; }

        public TbUsuario CodUsuarioClienteNavigation { get; set; }
        public TbUsuario CodUsuarioEntregadorNavigation { get; set; }
        public TbVeiculo CodVeiculoNavigation { get; set; }
        public ICollection<TbFormaspagamentoHasEntrega> TbformaspagamentoHasEntrega { get; set; }
    }
}
