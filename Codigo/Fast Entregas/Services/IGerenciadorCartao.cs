using System.Collections.Generic;
using Model;

namespace Services
{
    public interface IGerenciadorCartao
    {
        void Editar(Cartao cartaoModel);
        int Inserir(Cartao cartaoModel);
        Cartao Obter(int codCartao);
        IEnumerable<Cartao> ObterPorNumero(int numero);
        IEnumerable<Cartao> ObterTodos();
        void Remover(int codCartao);
    }
}