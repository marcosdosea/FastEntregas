using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Services
{

    public class GerenciadorFormaPagamento : IGerenciadorFormaPagamento
    {
        private readonly fast_entregasContext _context;

        public GerenciadorFormaPagamento(fast_entregasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere uma nova forma de pagamento na base de dados
        /// </summary>
        /// <param name="formaPagamento">dados da forma de pagamento</param>
        /// <returns></returns>
        public int Inserir(Formaspagamento formaPagamento)
        {
            TbFormaspagamento _tbFormaPagamento = new TbFormaspagamento();

            _tbFormaPagamento.CodFormaPagamento = formaPagamento.CodFormaPagamento;
            _tbFormaPagamento.Descricao = formaPagamento.Descricao;

            _context.Add(_tbFormaPagamento);
            _context.SaveChanges();
            return _tbFormaPagamento.CodFormaPagamento;
        }

        /// <summary>
        /// Atualiza os dados da forma de pagamento na base de dados
        /// </summary>
        /// <param name="formaPagamento">dados da forma de pagamento</param>
        public void Editar(Formaspagamento formaPagamento)
        {
            TbFormaspagamento _tbFormaPagamento = new TbFormaspagamento();
            Atribuir(formaPagamento, _tbFormaPagamento);
            _context.Update(_tbFormaPagamento);
            _context.SaveChanges();
        }

        /// <summary>
        /// Remove uma forma de pagamento da base de dados
        /// </summary>
        /// <param name="codFormaPamento">identificador da forma de pagamento</param>
        public void Remover(int codFormaPamento)
        {
            var tbFormaPagamento = _context.TbFormaspagamento.Find(codFormaPamento);
            _context.TbFormaspagamento.Remove(tbFormaPagamento);
            _context.SaveChanges();
        }

        /// <summary>
        /// Consulta genérica aos dados da forma de pagamento
        /// </summary>
        /// <returns></returns>
        private IQueryable<Formaspagamento> GetQuery()
        {
            IQueryable<TbFormaspagamento> tb_formaPagamento = _context.TbFormaspagamento;
            var query = from formasPagamento in tb_formaPagamento
                        select new Formaspagamento
                        {
                            CodFormaPagamento = formasPagamento.CodFormaPagamento,
                            Descricao = formasPagamento.Descricao
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos as formas de pagamento
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Formaspagamento> ObterTodos()
        {
            return GetQuery();
        }

        /// <summary>
        /// Obtém pelo identificador da forma de pagamento
        /// </summary>
        /// <param name="codFormaPagamento"></param>
        /// <returns></returns>
        public Formaspagamento Obter(int codFormaPagamento)
        {
            IEnumerable<Formaspagamento> formaPagamento = GetQuery().Where(formaPagamentoModel => formaPagamentoModel.CodFormaPagamento.Equals(codFormaPagamento));

            return formaPagamento.ElementAtOrDefault(0);
        }

        /// <summary>
        /// Obtém formas de pagamento pela descrição
        /// </summary>
        /// <param name="placa">placa a ser buscada</param>
        /// <returns></returns>
        public Formaspagamento ObterPorDescricao(string descricao)
        {
            IEnumerable<Formaspagamento> formaPagamento = GetQuery().Where(formaPagamentoModel => formaPagamentoModel.Descricao.StartsWith(descricao));
            return formaPagamento.ElementAtOrDefault(0);
        }

        /// <summary>
        /// Atribui dados entre objetos do model e entity
        /// </summary>
        /// <param name="formaPagamentoModel">objeto model</param>
        /// <param name="tbFormaPagamento">objeto entity</param>
        private void Atribuir(Formaspagamento formaPagamentoModel, TbFormaspagamento tbFormaPagamento)
        {
            tbFormaPagamento.CodFormaPagamento = formaPagamentoModel.CodFormaPagamento;
            tbFormaPagamento.Descricao = formaPagamentoModel.Descricao;
        }

    }

}
