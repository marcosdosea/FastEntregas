using System.Collections.Generic;
using Model;

namespace Services
{
    public interface IGerenciadorContaBancaria
    {
        void Editar(ContaBancaria contabancariaModel);
        int Inserir(ContaBancaria contabancariaModel);
        ContaBancaria Obter(int codConta);
        IEnumerable<ContaBancaria> ObterPorAgencia(int agencia);
        IEnumerable<ContaBancaria> ObterTodas();
        void Remover(int codVeiculo);


    }
}
