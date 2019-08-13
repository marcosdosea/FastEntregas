using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class GerenciadorSolicitacaoDeCadastro : IGerenciadorSolicitacaoDeCadastro
    {
        private readonly fast_entregasContext _context;

        public GerenciadorSolicitacaoDeCadastro(fast_entregasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere uma nova solicitaçao de cadastro na base de dados
        /// </summary>
        /// <param name="solicitacaoModel">dados do banco</param>
        /// <returns>retorna o codigo do banco inserido</returns>
        public int Inserir(SolicitacaoDeCadastro solicitacaoModel)
        {
            TbSolicitacaoDeCadastro _tbSolicitacaoDeCadastro = new TbSolicitacaoDeCadastro();
            _tbSolicitacaoDeCadastro.CodSolicitacao = solicitacaoModel.CodSolicitacao;
            _tbSolicitacaoDeCadastro.NumRegistro = solicitacaoModel.NumRegistro;
            _tbSolicitacaoDeCadastro.NumCnh = solicitacaoModel.NumCnh;
            _tbSolicitacaoDeCadastro.DataNascimento = solicitacaoModel.DataNascimento;
            _tbSolicitacaoDeCadastro.Status = solicitacaoModel.Status;
            _tbSolicitacaoDeCadastro.CodUsuarioEntregador = solicitacaoModel.CodUsuarioEntregador;
            _tbSolicitacaoDeCadastro.CodUsuarioFuncionario = solicitacaoModel.CodUsuarioFuncionario;

            _context.Add(_tbSolicitacaoDeCadastro);
            _context.SaveChanges();
            return _tbSolicitacaoDeCadastro.CodSolicitacao;
        }

        /// <summary>
        /// Atualiza os dados das solicitações de cadastro na base de dados
        /// </summary>
        /// <param name="solicitacaoModel">dados do banco</param>
        public void Editar(SolicitacaoDeCadastro solicitacaoModel)
        {
            TbSolicitacaoDeCadastro tbSolicitacaoDeCadastro = new TbSolicitacaoDeCadastro();
            Atribuir(solicitacaoModel, tbSolicitacaoDeCadastro);
            _context.Update(tbSolicitacaoDeCadastro);
            _context.SaveChanges();

        }

        /// <summary>
        /// Remove uma solicitacao da base de dados
        /// </summary>
        /// <param name="codSolicitacao">identificador da solicitacao</param>
        public void Remover(int codSolicitacao)
        {
            var tbSolicitacaoDeCadastro = _context.TbSolicitacaoDeCadastro.Find(codSolicitacao);
            _context.TbSolicitacaoDeCadastro.Remove(tbSolicitacaoDeCadastro);
            _context.SaveChanges();

        }

        /// <summary>
        /// Consulta genérica aos dados da solicitacao
        /// </summary>
        /// <returns></returns>
        private IQueryable<SolicitacaoDeCadastro> GetQuery()
        {
            IQueryable<TbSolicitacaoDeCadastro> tb_SolicitacaoDeCadastro = _context.TbSolicitacaoDeCadastro;
            var query = from solicitacao in tb_SolicitacaoDeCadastro
                        select new SolicitacaoDeCadastro
                        {
                            CodSolicitacao = solicitacao.CodSolicitacao,
                            NumRegistro = solicitacao.NumRegistro,
                            NumCnh = solicitacao.NumCnh,
                            DataNascimento = solicitacao.DataNascimento,
                            Status = solicitacao.Status,
                            CodUsuarioEntregador = solicitacao.CodUsuarioEntregador,
                            CodUsuarioFuncionario = solicitacao.CodUsuarioFuncionario,
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos as solicitacoes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SolicitacaoDeCadastro> ObterTodos()
        {
            return GetQuery();
        }

        /// <summary>
        /// Obtém pelo identificador da solicitacao
        /// </summary>
        /// <param name="codSolicitacao"></param>
        /// <returns></returns>
        public SolicitacaoDeCadastro Obter(int codSolicitacao)
        {
            IEnumerable<SolicitacaoDeCadastro> solicitacao = GetQuery().Where(solicitacaoModel => solicitacaoModel.CodSolicitacao.Equals(codSolicitacao));

            return solicitacao.ElementAtOrDefault(0);
        }

        /// <summary>
        /// Obtém solicitacoes com o cnh
        /// </summary>
        /// <param name="cnh">nome a ser buscado</param>
        /// <returns></returns>
        public IEnumerable<SolicitacaoDeCadastro> ObterPorCnh(string cnh)
        {
            IEnumerable<SolicitacaoDeCadastro> solicitacao = GetQuery().Where(solicitacaoModel => solicitacaoModel.NumCnh.Equals(cnh));
            return solicitacao;
        }


        /// <summary>
        /// Atribui dados entre objetos do model e entity
        /// </summary>
        /// <param name="solicitacaoModel">objeto model</param>
        /// <param name="tbSolicitacao">objeto entity</param>
        private void Atribuir(SolicitacaoDeCadastro solicitacaoModel, TbSolicitacaoDeCadastro tbSolicitacaoDeCadastro)
        {
            tbSolicitacaoDeCadastro.CodSolicitacao = solicitacaoModel.CodSolicitacao;
            tbSolicitacaoDeCadastro.NumCnh = solicitacaoModel.NumCnh;
            tbSolicitacaoDeCadastro.NumRegistro = solicitacaoModel.NumRegistro;
            tbSolicitacaoDeCadastro.DataNascimento = solicitacaoModel.DataNascimento;
            tbSolicitacaoDeCadastro.Status = solicitacaoModel.Status;
            tbSolicitacaoDeCadastro.CodUsuarioEntregador = solicitacaoModel.CodUsuarioEntregador;
            tbSolicitacaoDeCadastro.CodUsuarioFuncionario = solicitacaoModel.CodUsuarioFuncionario;
        }

    }
}
