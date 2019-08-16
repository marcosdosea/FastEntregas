using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class GerenciadorBanco : IGerenciadorBanco
    {
        private readonly fast_entregasContext _context;

        public GerenciadorBanco(fast_entregasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere um novo banco na base de dados
        /// </summary>
        /// <param name="bancoModel">dados do banco</param>
        /// <returns>retorna o codigo do banco inserido</returns>
        public int Inserir(Banco bancoModel)
        {
            TbBanco _tbBanco = new TbBanco();
            _tbBanco.CodBanco = bancoModel.CodBanco;
            _tbBanco.Nome = bancoModel.Nome;

            _context.Add(_tbBanco);
            _context.SaveChanges();
            return _tbBanco.CodBanco;
        }

        /// <summary>
        /// Atualiza os dados do banco na base de dados
        /// </summary>
        /// <param name="bancoModel">dados do banco</param>
        public void Editar(Banco bancoModel)
        {
            TbBanco tbBanco = new TbBanco();
            Atribuir(bancoModel, tbBanco);
            _context.Update(tbBanco);
            _context.SaveChanges();

        }

        /// <summary>
        /// Remove um banco da base de dados
        /// </summary>
        /// <param name="codBanco">identificador do banco</param>
        public void Remover(int codBanco)
        {
            var tbBanco = _context.TbBanco.Find(codBanco);
            _context.TbBanco.Remove(tbBanco);
            _context.SaveChanges();

        }

        /// <summary>
        /// Consulta genérica aos dados do banco
        /// </summary>
        /// <returns></returns>
        private IQueryable<Banco> GetQuery()
        {
            IQueryable<TbBanco> tb_banco = _context.TbBanco;
            var query = from banco in tb_banco
                        select new Banco
                        {
                            CodBanco = banco.CodBanco,
                            Nome = banco.Nome,
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos os bancos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Banco> ObterTodos()
        {
            return GetQuery();
        }

        /// <summary>
        /// Obtém pelo identificador do banco
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public Banco Obter(int codBanco)
        {
            IEnumerable<Banco> banco = GetQuery().Where(bancoModel => bancoModel.CodBanco.Equals(codBanco));

            return banco.ElementAtOrDefault(0);
        }

        /// <summary>
        /// Obtém bancos com o nome
        /// </summary>
        /// <param name="nome">nome a ser buscado</param>
        /// <returns></returns>
        public IEnumerable<Banco> ObterPorNome(string nome)
        {
            IEnumerable<Banco> banco = GetQuery().Where(bancoModel => bancoModel.Nome.StartsWith(nome));
            return banco;
        }


        /// <summary>
        /// Atribui dados entre objetos do model e entity
        /// </summary>
        /// <param name="bancoModel">objeto model</param>
        /// <param name="tbBanco">objeto entity</param>
        private void Atribuir(Banco bancoModel, TbBanco tbBanco)
        {
            tbBanco.CodBanco = bancoModel.CodBanco;
            tbBanco.Nome = bancoModel.Nome;
        }

    }
}