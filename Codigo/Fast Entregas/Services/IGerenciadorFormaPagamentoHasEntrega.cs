using System.Collections.Generic;
using Persistence;
using Model;

namespace Services
{
    public interface IGerenciadorFormaPagamentoHasEntrega
    {
        void Editar(FormaspagamentoHasEntrega pagamento);
        void Inserir(FormaspagamentoHasEntrega pagamento);
        FormaspagamentoHasEntrega Obter(int codFormaPagamento, int codEntrega);
        IEnumerable<FormaspagamentoHasEntrega> ObterTodos();
        void Remover(int codFormaPagamento, int codEntrega);
    }
}