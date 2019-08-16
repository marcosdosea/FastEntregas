using System.Collections.Generic;
using Model;

namespace Services
{
    public interface IGerenciadorBanco
    {
        void Editar(Banco bancoModel);
        int Inserir(Banco bancoModel);
        Banco Obter(int codBanco);
        IEnumerable<Banco> ObterPorNome(string nome);
        IEnumerable<Banco> ObterTodos();
        void Remover(int codBanco);
    }
}