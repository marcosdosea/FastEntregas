using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Services
{

    public class GerenciadorCartao : IGerenciadorCartao
    {
        private readonly fast_entregasContext _context;

        public GerenciadorCartao(fast_entregasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere um novo cartao na base de dados
        /// </summary>
        /// <param name="cartaoModel">dados do cartao</param>
        /// <returns></returns>
        public int Inserir(Cartao cartaoModel)
        {
            TbCartao _tbCartao = new TbCartao();
            _tbCartao.CodCartao = cartaoModel.CodCartao;
            _tbCartao.Numero = cartaoModel.Numero;
            _tbCartao.NomeDono = cartaoModel.NomeDono;
            _tbCartao.DataValidade = cartaoModel.DataValidade;
            _tbCartao.Cvv = cartaoModel.Cvv;
            _tbCartao.CodUsuario = cartaoModel.CodUsuario;


            _context.Add(_tbCartao);
            _context.SaveChanges();
            return _tbCartao.CodCartao;
        }

        /// <summary>
        /// Atualiza os dados do cartao na base de dados
        /// </summary>
        /// <param name="cartao">dados do cartao</param>
        public void Editar(Cartao cartaoModel)
        {
            TbCartao tbCartao = new TbCartao();
            Atribuir(cartaoModel, tbCartao);
            _context.Update(tbCartao);
            _context.SaveChanges();

        }

        /// <summary>
        /// Remove um cartao da base de dados
        /// </summary>
        /// <param name="codCartao">identificador do cartao</param>
        public void Remover(int codCartao)
        {
            var tbCartao = _context.TbCartao.Find(codCartao);
            _context.TbCartao.Remove(tbCartao);
            _context.SaveChanges();

        }

        /// <summary>
        /// Consulta genérica aos dados do cartao
        /// </summary>
        /// <returns></returns>
        private IQueryable<Cartao> GetQuery()
        {
            IQueryable<TbCartao> tb_cartao = _context.TbCartao;
            var query = from cartao in tb_cartao
                        select new Cartao
                        {
                            CodCartao = cartao.CodCartao,
                            Numero = cartao.Numero,
                            NomeDono = cartao.NomeDono,
                            DataValidade = cartao.DataValidade,
                            Cvv = cartao.Cvv,
                            CodUsuario = cartao.CodUsuario,
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos os cartões
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cartao> ObterTodos()
        {
            return GetQuery();
        }

        /// <summary>
        /// Obtém pelo identificador do Cartao
        /// </summary>
        /// <param name="codCartao"></param>
        /// <returns></returns>
        public Cartao Obter(int codCartao)
        {
            IEnumerable<Cartao> cartao = GetQuery().Where(cartaoModel => cartaoModel.CodCartao.Equals(codCartao));

            return cartao.ElementAtOrDefault(0);
        }

        /// <summary>
        /// Obtém cartao que iniciam com o numero
        /// </summary>
        /// <param name="numero">numero a ser buscado</param>
        /// <returns></returns>
        public IEnumerable<Cartao> ObterPorNumero(int numero)
        {
            IEnumerable<Cartao> cartao = GetQuery().Where(cartaoModel => cartaoModel.Numero.Equals(numero));
            return cartao;
        }

        /// <summary>
        /// Atribui dados entre objetos do model e entity
        /// </summary>
        /// <param name="cartaoModel">objeto model</param>
        /// <param name="tbCartao">objeto entity</param>
        private void Atribuir(Cartao cartaoModel, TbCartao tbCartao)
        {
            tbCartao.CodCartao = cartaoModel.CodCartao;
            tbCartao.NomeDono = cartaoModel.NomeDono;
            tbCartao.Numero = cartaoModel.Numero;
            tbCartao.DataValidade = cartaoModel.DataValidade;
            tbCartao.Cvv = cartaoModel.Cvv;
            tbCartao.CodUsuario = cartaoModel.CodUsuario;

        }

    }

}
