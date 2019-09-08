using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Services
{

    public class GerenciadorFormaPagamentoHasEntrega : IGerenciadorFormaPagamentoHasEntrega
    {
        private readonly fast_entregasContext _context;

        public GerenciadorFormaPagamentoHasEntrega(fast_entregasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere um nov pagamento na base de dados
        /// </summary>
        /// <param name="pagamento">dados do pagamento</param>
        /// <returns></returns>
        public void Inserir(FormaspagamentoHasEntrega pagamento)
        {
            TbFormaspagamentoHasEntrega _tbFormaPagamentoHasEntrega = new TbFormaspagamentoHasEntrega();

            _tbFormaPagamentoHasEntrega.FormasPagamentoCodFormaPagamento = pagamento.CodFormaPagamento;
            _tbFormaPagamentoHasEntrega.EntregaCodCorridaEntrega = pagamento.CodEntrega;

            _context.Add(_tbFormaPagamentoHasEntrega);
            _context.SaveChanges();
        }

        /// <summary>
        /// Atualiza o pagamento na base de dados
        /// </summary>
        /// <param name="pagamento">dados do pagamento</param>
        public void Editar(FormaspagamentoHasEntrega pagamento)
        {
            TbFormaspagamentoHasEntrega _tbFormaPagamentoHasEntrega = new TbFormaspagamentoHasEntrega();
            Atribuir(pagamento, _tbFormaPagamentoHasEntrega);
            _context.Update(_tbFormaPagamentoHasEntrega);
            _context.SaveChanges();
        }

        /// <summary>
        /// Remove um pagamento do banco de dados
        /// </summary>
        /// <param name="codFormaPagamento">identificador da forma de pagamento</param>
        /// <param name="codEntrega">identificador da entrega</param>
        public void Remover(int codFormaPagamento, int codEntrega)
        {
            var tbFormaPagamentoHasEntrega = _context.TbFormaspagamentoHasEntrega
                .Where(pagamentoModel =>
                pagamentoModel.FormasPagamentoCodFormaPagamento
                .Equals(codFormaPagamento)
                && pagamentoModel.EntregaCodCorridaEntrega
                .Equals(codEntrega));

            _context.TbFormaspagamentoHasEntrega.Remove(tbFormaPagamentoHasEntrega.ElementAtOrDefault(0));
            _context.SaveChanges();
        }

        /// <summary>
        /// Consulta genérica aos dados do pagamento
        /// </summary>
        /// <returns></returns>
        private IQueryable<FormaspagamentoHasEntrega> GetQuery()
        {
            IQueryable<TbFormaspagamentoHasEntrega> tb_formaPagamentoHasEntrega = _context.TbFormaspagamentoHasEntrega;
            var query = from pagamento in tb_formaPagamentoHasEntrega
                        select new FormaspagamentoHasEntrega
                        {
                            CodFormaPagamento = pagamento.FormasPagamentoCodFormaPagamento,
                            CodEntrega = pagamento.EntregaCodCorridaEntrega
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos os pagamentos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FormaspagamentoHasEntrega> ObterTodos()
        {
            return GetQuery();
        }

        /// <summary>
        /// Obtém pelos identificadores do pagamento
        /// </summary>
        /// <param name="codFormaPagamento">identificador da forma de pagamento</param>
        /// <param name="codEntrega">identificador da entrega</param>
        /// <returns></returns>
        public FormaspagamentoHasEntrega Obter(int codFormaPagamento, int codEntrega)
        {
            IEnumerable<FormaspagamentoHasEntrega> pagamento = GetQuery()
                .Where(pagamentoModel => pagamentoModel.CodFormaPagamento
                .Equals(codFormaPagamento) && pagamentoModel.CodEntrega
                .Equals(codEntrega));

            return pagamento.ElementAtOrDefault(0);
        }


        /// <summary>
        /// Atribui dados entre objetos do model e entity
        /// </summary>
        /// <param name="pagamentoModel">objeto model</param>
        /// <param name="tbpagamento">objeto entity</param>
        private void Atribuir(FormaspagamentoHasEntrega pagamentoModel, TbFormaspagamentoHasEntrega tbpagamento)
        {
            tbpagamento.FormasPagamentoCodFormaPagamento = pagamentoModel.CodFormaPagamento;
            tbpagamento.EntregaCodCorridaEntrega = pagamentoModel.CodEntrega;
            tbpagamento.Valor = pagamentoModel.Valor;
        }

    }

}
