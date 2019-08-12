using System.Collections.Generic;
using Model;

namespace Services
{
    public interface IGerenciadorSolicitacaoDeCadastro
    {
        void Editar(SolicitacaoDeCadastro solicitacaoModel);
        int Inserir(SolicitacaoDeCadastro solicitacaoModel);
        SolicitacaoDeCadastro Obter(int codSolicitacao);
        IEnumerable<SolicitacaoDeCadastro> ObterPorCnh(int cnh);
        IEnumerable<SolicitacaoDeCadastro> ObterTodos();
        void Remover(int codSolicitacao);
    }
}