using System.Collections.Generic;
using Model;

namespace Services
{
    public interface IGerenciadorUsuario
    {
        void Editar(Usuario usuarioModel);
        int Inserir(Usuario usuarioModel);
        Usuario Obter(int codUsuario);
        IEnumerable<Usuario> ObterPorCpf(string cpf);
        IEnumerable<Usuario> ObterTodos();
        void Remover(int codUsuario);
    }
}