using System.Collections.Generic;
using Model;

namespace Services
{
    public interface IGerenciadorFormaPagamento
    {
        void Editar(Formaspagamento formaPagamento);
        int Inserir(Formaspagamento formaPagamento);
        Formaspagamento Obter(int codFormaPagamento);
        Formaspagamento ObterPorDescricao(string descricao);
        IEnumerable<Formaspagamento> ObterTodos();
        void Remover(int codFormaPamento);
    }
}