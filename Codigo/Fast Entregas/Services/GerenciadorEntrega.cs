using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class GerenciadorEntrega : IGerenciadorEntrega
    {
        private readonly fast_entregasContext _context;

        public GerenciadorEntrega(fast_entregasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere uma nova entrega na base de dados
        /// </summary>
        /// <param name="entregaModel">dados da entrega</param>
        /// <returns></returns>
        public int Inserir(Entrega entregaModel)
        {
            TbEntrega tbEntrega = new TbEntrega();

            tbEntrega.CodEntrega = entregaModel.CodEntrega;
            tbEntrega.Origem = entregaModel.Origem;
            tbEntrega.Destino = entregaModel.Destino;
            tbEntrega.Data = entregaModel.Data;
            tbEntrega.Status = entregaModel.Status;
            tbEntrega.Valor = entregaModel.Valor;
            tbEntrega.Descricao_origem = entregaModel.Descricao_origem;
            tbEntrega.Descricao_destino = entregaModel.Descricao_destino;
            tbEntrega.CodUsuarioCliente = entregaModel.CodUsuarioCliente;
            tbEntrega.CodUsuarioEntregador = entregaModel.CodUsuarioEntregador;

            _context.Add(tbEntrega);
            _context.SaveChanges();
            return tbEntrega.CodEntrega;
        }

        /// <summary>
        /// Atualiza os dados da entrega na base de dados
        /// </summary>
        /// <param name="entregaModel">dados da entrega</param>
        public void Editar(Entrega entregaModel)
        {
            TbEntrega tbEntrega = new TbEntrega();
            Atribuir(entregaModel, tbEntrega);
            _context.Update(tbEntrega);
            _context.SaveChanges();
        }

        /// <summary>
        /// Remove uma entrega da base de dados
        /// </summary>
        /// <param name="codEntrega">identificador da Entrega</param>
        public void Remover(int codEntrega)
        {
            var tbEntrega = _context.TbEntrega.Find(codEntrega);
            _context.TbEntrega.Remove(tbEntrega);
            _context.SaveChanges();
        }

        /// <summary>
        /// Consulta genérica aos dados da entrega
        /// </summary>
        /// <returns></returns>
        private IQueryable<Entrega> GetQuery()
        {
            IQueryable<TbEntrega> tbEntrega = _context.TbEntrega;
            var query = from entrega in tbEntrega
                        select new Entrega
                        {
                            CodEntrega = entrega.CodEntrega,
                            Origem = entrega.Origem,
                            Destino = entrega.Destino,
                            Data = entrega.Data,
                            Status = entrega.Status,
                            Valor = entrega.Valor,
                            Descricao_origem = entrega.Descricao_origem,
                            Descricao_destino = entrega.Descricao_destino,
                            CodUsuarioCliente = entrega.CodUsuarioCliente,
                            CodUsuarioEntregador = entrega.CodUsuarioEntregador
                        };
            return query;
        }

        /// <summary>
        /// Obtém todas as entregas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Entrega> ObterTodos()
        {
            return GetQuery();
        }

        /// <summary>
        /// Obtém pelo identificador da entrega
        /// </summary>
        /// <param name="codEntrega"></param>
        /// <returns></returns>
        public Entrega Obter(int codEntrega)
        {
            IEnumerable<Entrega> entrega = GetQuery().Where(entregaModel => entregaModel.CodEntrega.Equals(codEntrega));

            return entrega.ElementAtOrDefault(0);
        }

        /// <summary>
        /// Obtém entregas que foram feitas por um cliente
        /// </summary>
        /// <param name="codUsuarioCliente">Codigo do cliente a ser buscado</param>
        /// <returns></returns>
        public IEnumerable<Entrega> ObterPorCliente(int codUsuarioCliente)
        {
            IEnumerable<Entrega> entregas = GetQuery().Where(entregaModel => entregaModel.CodUsuarioCliente.Equals(codUsuarioCliente));
            return entregas;
        }

        /// <summary>
        /// Obtém entregas que foram feitas por um entregador
        /// </summary>
        /// <param name="codUsuarioEntregador">Codigo do entregador a ser buscado</param>
        /// <returns></returns>
        public IEnumerable<Entrega> ObterPorEntregador(int codUsuarioEntregador)
        {
            IEnumerable<Entrega> entregas = GetQuery().Where(entregaModel => entregaModel.CodUsuarioEntregador.Equals(codUsuarioEntregador));
            return entregas;
        }

        private void Atribuir(Entrega entregaModel, TbEntrega tbEntrega)
        {
            tbEntrega.CodEntrega = entregaModel.CodEntrega;
            tbEntrega.Origem = entregaModel.Origem;
            tbEntrega.Destino = entregaModel.Destino;
            tbEntrega.Data = entregaModel.Data;
            tbEntrega.Status = entregaModel.Status;
            tbEntrega.Valor = entregaModel.Valor;
            tbEntrega.Descricao_origem = entregaModel.Descricao_origem;
            tbEntrega.Descricao_destino = entregaModel.Descricao_destino;
            tbEntrega.CodUsuarioCliente = entregaModel.CodUsuarioCliente;
            tbEntrega.CodUsuarioEntregador = entregaModel.CodUsuarioEntregador;
        }
    }
}
