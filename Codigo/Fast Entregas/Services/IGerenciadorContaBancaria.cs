using System.Collections.Generic;
using Model;

namespace Services
{
    public interface IGerenciadorContaBancaria
    {
        void Editar(ContaBancaria contabancariaModel);
        int Inserir(ContaBancaria contabancariaModel);
        ContaBancaria Obter(int codConta);
        IEnumerable<ContaBancaria> ObterPorConta(int conta);
        IEnumerable<ContaBancaria> ObterTodas();
        void Remover(int codConta);


    }
}
