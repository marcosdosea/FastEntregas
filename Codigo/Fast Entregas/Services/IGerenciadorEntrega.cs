using System.Collections.Generic;
using Model;

namespace Services
{
    public interface IGerenciadorEntrega
    {
        void Editar(Entrega entregaModel);
        int Inserir(Entrega entregaModel);
        Entrega Obter(int codEntrega);
        IEnumerable<Entrega> ObterPorCliente(int codUsuarioCliente);
        IEnumerable<Entrega> ObterPorEntregador(int codUsuarioEntregador);
        IEnumerable<Grafico> GetGastoDia(int codUser);
        IEnumerable<Grafico> GetCorridasDia(int codUser);
        IEnumerable<Entrega> ObterTodos();
        void Remover(int codEntrega);
    }
}