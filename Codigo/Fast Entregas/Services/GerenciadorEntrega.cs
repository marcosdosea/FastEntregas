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
            tbEntrega.Distancia = entregaModel.Distancia;
            tbEntrega.Duracao = entregaModel.Duracao;
            tbEntrega.DescricaoOrigem = entregaModel.Descricao_origem;
            tbEntrega.DescricaoDestino = entregaModel.Descricao_destino;
            tbEntrega.CategoriaVeiculo = entregaModel.Categoria_veiculo;
            tbEntrega.CodUsuarioCliente = entregaModel.CodUsuarioCliente;
            tbEntrega.CodUsuarioEntregador = entregaModel.CodUsuarioEntregador;
            tbEntrega.CodVeiculo = entregaModel.CodVeiculo;

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
                            Distancia = entrega.Distancia,
                            Duracao = entrega.Duracao,
                            Descricao_origem = entrega.DescricaoOrigem,
                            Descricao_destino = entrega.DescricaoDestino,
                            Categoria_veiculo = entrega.CategoriaVeiculo,
                            CodUsuarioCliente = entrega.CodUsuarioCliente,
                            CodUsuarioEntregador = entrega.CodUsuarioEntregador
                        };
            return query;
        }

        public IEnumerable<Grafico> GetCorridasDia(int codUser)
        {
            IEnumerable<Grafico> query = GetQuery()
                .Where(entrega => entrega.CodUsuarioCliente == codUser)
                .GroupBy(entrega => entrega.Data)
                .Select(grafico => new Grafico
                {
                    Data = grafico.Key.ToString(),
                    Qtd = grafico.Count()
                });

            return query;
        }

        public IEnumerable<Grafico> GetGastoDia(int codUser)
        {
            IEnumerable<Grafico> query = GetQuery()
                .Where(entrega => entrega.CodUsuarioCliente == codUser)
                .GroupBy(entrega => entrega.Data)
                .Select(grafico => new Grafico
                {
                    Data = grafico.Key.ToString(),
                    Valor = grafico.Sum(entrega => entrega.Valor)
                });

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

        /// <summary>
        /// Obtém entregas que estão com status solicitada para uma cateoria de veiculo
        /// </summary>
        /// <param name="cateoriaVeiculo">cateoria de veiculos que está sendo requisitada</param>
        /// <returns></returns>
        public IEnumerable<Entrega> ObterPorTipoVeiculo(string cateoriaVeiculo)
        {
            IEnumerable<Entrega> entregas = GetQuery().Where(entregaModel => entregaModel.Status.Equals("solicitada") &&
                                                                             entregaModel.Categoria_veiculo.Equals(cateoriaVeiculo));
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
            tbEntrega.Duracao = entregaModel.Duracao;
            tbEntrega.Distancia = entregaModel.Distancia;
            tbEntrega.DescricaoOrigem = entregaModel.Descricao_origem;
            tbEntrega.DescricaoDestino = entregaModel.Descricao_destino;
            tbEntrega.CategoriaVeiculo = entregaModel.Categoria_veiculo;
            tbEntrega.CodUsuarioCliente = entregaModel.CodUsuarioCliente;
            tbEntrega.CodUsuarioEntregador = entregaModel.CodUsuarioEntregador;
            tbEntrega.CodVeiculo = entregaModel.CodVeiculo;
        }
    }
}
