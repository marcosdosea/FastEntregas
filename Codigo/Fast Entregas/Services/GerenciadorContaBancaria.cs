using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{

    public class GerenciadorContaBancaria : IGerenciadorContaBancaria
    {
        private readonly fast_entregasContext _context;

        public GerenciadorContaBancaria(fast_entregasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere uma nova conta bancaria na base de dados
        /// </summary>
        /// <param name="contabancariaModel"></param>
        /// <returns></returns>
        public int Inserir(ContaBancaria contabancariaModel)
        {

            TbContaBancaria _tbContaBancaria = new TbContaBancaria();
            _tbContaBancaria.CodConta = contabancariaModel.CodConta;
            _tbContaBancaria.Numero = contabancariaModel.Numero;
            _tbContaBancaria.Agencia = contabancariaModel.Agencia;
            _tbContaBancaria.Tipo = contabancariaModel.Tipo;
            _tbContaBancaria.CodUsuario = contabancariaModel.CodUsuario;
            _tbContaBancaria.CodBanco = contabancariaModel.CodBanco;

            _context.Add(_tbContaBancaria);
            _context.SaveChanges();
            return _tbContaBancaria.CodConta;
        }

        /// <summary>
        /// Atualizar os dados da conta bancaria na base de dados
        /// </summary>
        /// <param name="contabancariaModel"></param>
        public void Editar(ContaBancaria contabancariaModel)
        {
            if (contabancariaModel == null)
            {
                throw new Exception("Dados Invalidos");
            }

            TbContaBancaria tbContaBancaria = _context.TbContaBancaria.Find(contabancariaModel.CodConta);

            if (tbContaBancaria == null)
            {
                throw new Exception("Conta não encontrada");
            }

            Atribuir(contabancariaModel, tbContaBancaria);
            _context.Update(tbContaBancaria);
            _context.SaveChanges();
        }

        /// <summary>
        /// Remove uma conta bancaria da base de dados
        /// </summary>
        /// <param name="codConta">identificador da conta bancaria</param>
        public void Remover(int codConta)
        {
            var tbContaBancaria = _context.TbContaBancaria.Find(codConta);
            _context.TbContaBancaria.Remove(tbContaBancaria);
            _context.SaveChanges();
        }

        /// <summary>
        /// Consulta generica aos dados da conta
        /// </summary>
        /// <returns></returns>
        private IQueryable<ContaBancaria> GetQuery()
        {
            IQueryable<TbContaBancaria> tb_contabancaria = _context.TbContaBancaria;
            var query = from contabancaria in tb_contabancaria
                        select new ContaBancaria
                        {
                            CodConta = contabancaria.CodConta,
                            Numero = contabancaria.Numero,
                            Agencia = contabancaria.Agencia,
                            Tipo = contabancaria.Tipo,
                            CodUsuario = contabancaria.CodUsuario,
                            CodBanco = contabancaria.CodBanco,
                        };
            return query;
        }

        /// <summary>
        /// Obtém todas as contas bancarias
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContaBancaria> ObterTodas()
        {
            return GetQuery();
        }

        /// <summary>
        /// Obtém pelo identificador da Bonta
        /// </summary>
        /// <param name="codConta"></param>
        /// <returns></returns>
        public ContaBancaria Obter(int codConta)
        {
            IEnumerable<ContaBancaria> contabancaria = GetQuery().Where(contabancariaModel => contabancariaModel.CodConta.Equals(codConta));

            return contabancaria.ElementAtOrDefault(0);
        }

        /// <summary>
        /// Obter conta bancaria pelo número da conta
        /// </summary>
        /// <param name="conta"></param>
        /// <returns></returns>
        public IEnumerable<ContaBancaria> ObterPorConta(int conta)
        {
            IEnumerable<ContaBancaria> contabancaria = GetQuery().Where(contabancariaModel => contabancariaModel.Numero == conta);
            return contabancaria;
        }

        /// <summary>
        /// Atribui dados entre objetos do model e entity
        /// </summary>
        /// <param name="contabancariaModel">objeto model</param>
        /// <param name="tbContaBancaria">objeto entity</param>
        private void Atribuir(ContaBancaria contabancariaModel, TbContaBancaria tbContaBancaria)
        {
            //tbContaBancaria.CodConta = contabancariaModel.CodConta; 
            tbContaBancaria.Numero = contabancariaModel.Numero;
            tbContaBancaria.Agencia = contabancariaModel.Agencia;
            tbContaBancaria.Tipo = contabancariaModel.Tipo;
            tbContaBancaria.CodUsuario = contabancariaModel.CodUsuario;
            tbContaBancaria.CodBanco = contabancariaModel.CodBanco;

        }

    }

}
