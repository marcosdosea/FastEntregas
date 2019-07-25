using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Services
{

    public class GerenciadorVeiculo : IGerenciadorVeiculo
    {
        private readonly fast_entregasContext _context;

        public GerenciadorVeiculo(fast_entregasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere um novo veiculo na base de dados
        /// </summary>
        /// <param name="veiculoModel">dados do veiculo</param>
        /// <returns></returns>
        public int Inserir(Veiculo veiculoModel)
        {
            TbVeiculo _tbVeiculo = new TbVeiculo();
            _tbVeiculo.CodVeiculo = veiculoModel.CodVeiculo;
            _tbVeiculo.Categoria = veiculoModel.Categoria;
            _tbVeiculo.Placa = veiculoModel.Placa;
            _tbVeiculo.Renavam = veiculoModel.Renavam;
            _tbVeiculo.Ano = veiculoModel.Ano;
            _tbVeiculo.Status = veiculoModel.Status;
            _tbVeiculo.EmUso = veiculoModel.EmUso;
            _tbVeiculo.CodDono = veiculoModel.CodDono;

            _context.Add(_tbVeiculo);
            _context.SaveChanges();
            return _tbVeiculo.CodVeiculo;
        }

        /// <summary>
        /// Atualiza os dados do veiculo na base de dados
        /// </summary>
        /// <param name="veiculo">dados do veiculo</param>
        public void Editar(Veiculo veiculoModel)
        {
            //if (autorModel.AnoNascimento.Year < 1000)
            //throw new ServiceException("O ano de nascimento de autor deve ser maior do que 1000. Favor informar nova data.");

            TbVeiculo tbVeiculo = new TbVeiculo();
            Atribuir(veiculoModel, tbVeiculo);
            _context.Update(tbVeiculo);
            _context.SaveChanges();
        }

        /// <summary>
        /// Remove um veiculo da base de dados
        /// </summary>
        /// <param name="codVeiculo">identificador do veiculo</param>
        public void Remover(int codVeiculo)
        {
            var tbVeiculo = _context.TbVeiculo.Find(codVeiculo);
            _context.TbVeiculo.Remove(tbVeiculo);
            _context.SaveChanges();
        }

        /// <summary>
        /// Consulta genérica aos dados do veiculo
        /// </summary>
        /// <returns></returns>
        private IQueryable<Veiculo> GetQuery()
        {
            IQueryable<TbVeiculo> tb_veiculo = _context.TbVeiculo;
            var query = from veiculo in tb_veiculo
                        select new Veiculo
                        {
                            CodVeiculo = veiculo.CodVeiculo,
                            Categoria = veiculo.Categoria,
                            Placa = veiculo.Placa,
                            Renavam = veiculo.Renavam,
                            Ano = veiculo.Ano,
                            Status = veiculo.Status,
                            EmUso = veiculo.EmUso,
                            CodDono = veiculo.CodDono
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos os veiculos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Veiculo> ObterTodos()
        {
            return GetQuery();
        }

        /// <summary>
        /// Obtém pelo identificador do Veiculo
        /// </summary>
        /// <param name="codVeiculo"></param>
        /// <returns></returns>
        public Veiculo Obter(int codVeiculo)
        {
            IEnumerable<Veiculo> veiculos = GetQuery().Where(veiculoModel => veiculoModel.CodVeiculo.Equals(codVeiculo));

            return veiculos.ElementAtOrDefault(0);
        }

        /// <summary>
        /// Obtém veiculos que iniciam com a placa
        /// </summary>
        /// <param name="placa">placa a ser buscada</param>
        /// <returns></returns>
        public IEnumerable<Veiculo> ObterPorPlaca(string placa)
        {
            IEnumerable<Veiculo> veiculos = GetQuery().Where(veiculoModel => veiculoModel.Placa.StartsWith(placa));
            return veiculos;
        }

        /// <summary>
        /// Atribui dados entre objetos do model e entity
        /// </summary>
        /// <param name="veiculoModel">objeto model</param>
        /// <param name="tbVeiculo">objeto entity</param>
        private void Atribuir(Veiculo veiculoModel, TbVeiculo tbVeiculo)
        {
            tbVeiculo.CodVeiculo = veiculoModel.CodVeiculo;
            tbVeiculo.Categoria = veiculoModel.Categoria;
            tbVeiculo.Placa = veiculoModel.Placa;
            tbVeiculo.Renavam = veiculoModel.Renavam;
            tbVeiculo.Ano = veiculoModel.Ano;
            tbVeiculo.Status = veiculoModel.Status;
            tbVeiculo.EmUso = veiculoModel.EmUso;
            tbVeiculo.CodDono = veiculoModel.CodDono;
        }

    }

}
