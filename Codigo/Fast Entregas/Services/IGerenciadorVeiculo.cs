using System.Collections.Generic;
using Model;

namespace Services
{
    public interface IGerenciadorVeiculo
    {
        void Editar(Veiculo veiculoModel);
        int Inserir(Veiculo veiculoModel);
        Veiculo Obter(int codVeiculo);
        IEnumerable<Veiculo> ObterPorPlaca(string placa);
        IEnumerable<Veiculo> ObterTodos();
        void Remover(int codVeiculo);
    }
}