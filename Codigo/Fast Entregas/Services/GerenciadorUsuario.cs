using Persistence;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Services
{
    public class GerenciadorUsuario : IGerenciadorUsuario
    {
        private readonly fast_entregasContext _context;

        public GerenciadorUsuario(fast_entregasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere um novo usuario na base de dados
        /// </summary>
        /// <param name="usuarioModel">Dados do usuario</param>
        /// <returns>Código do usuário inserido</returns>
        public int Inserir(Usuario usuarioModel)
        {
            TbUsuario tb_usuario = new TbUsuario();

            tb_usuario.CodUsuario = usuarioModel.CodUsuario;
            tb_usuario.Nome = usuarioModel.Nome;
            tb_usuario.Cpf = usuarioModel.Cpf;
            tb_usuario.Telefone = usuarioModel.Telefone;
            tb_usuario.Email = usuarioModel.Email;
            tb_usuario.Senha = usuarioModel.Senha;
            tb_usuario.Tipo = usuarioModel.Tipo;
            tb_usuario.StatusCliente = usuarioModel.StatusCliente;
            tb_usuario.StatusEntregador = usuarioModel.StatusEntregador;

            _context.Add(tb_usuario);
            _context.SaveChanges();

            return tb_usuario.CodUsuario;
        }

        /// <summary>
        /// Atualiza os dados do usuario na base de dados
        /// </summary>
        /// <param name="usuarioModel">dados do usuario</param>
        public void Editar(Usuario usuarioModel)
        {
            TbUsuario tb_usuario = new TbUsuario();
            Atribuir(usuarioModel, tb_usuario);
            _context.Update(tb_usuario);
            _context.SaveChanges();
        }

        /// <summary>
        /// Remove um usuario da base de dados
        /// </summary>
        /// <param name="codUsuario">código do usuario</param>
        public void Remover(int codUsuario)
        {
            var tbUsuario = _context.TbUsuario.Find(codUsuario);
            _context.TbUsuario.Remove(tbUsuario);
            _context.SaveChanges();
        }

        /// <summary>
        /// Consulta genérica aos dados do usuario
        /// </summary>
        /// <returns></returns>
        private IQueryable<Usuario> GetQuery()
        {
            IQueryable<TbUsuario> tb_usuario = _context.TbUsuario;
            var query = from usuario in tb_usuario
                        select new Usuario
                        {
                            CodUsuario = usuario.CodUsuario,
                            Nome = usuario.Nome,
                            Cpf = usuario.Cpf,
                            Telefone = usuario.Telefone,
                            Email = usuario.Email,
                            Senha = usuario.Senha,
                            Tipo = usuario.Tipo,
                            StatusCliente = usuario.StatusCliente,
                            StatusEntregador = usuario.StatusEntregador
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos os usuarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> ObterTodos()
        {
            return GetQuery();
        }

        /// <summary>
        /// Obtém pelo identificador do Usuario
        /// </summary>
        /// <param name="codUsuario"></param>
        /// <returns></returns>
        public Usuario Obter(int codUsuario)
        {
            IEnumerable<Usuario> usuarios = GetQuery().Where(usuarioModel => usuarioModel.CodUsuario.Equals(codUsuario));

            return usuarios.ElementAtOrDefault(0);
        }

        /// <summary>
        /// Obtém usuarios que iniciam com o cpf
        /// </summary>
        /// <param name="cpf">cpf a ser buscado</param>
        /// <returns></returns>
        public IEnumerable<Usuario> ObterPorCpf(string cpf)
        {
            IEnumerable<Usuario> usuarios = GetQuery().Where(usuarioModel => usuarioModel.Cpf.StartsWith(cpf));
            return usuarios;
        }

        /// <summary>
        /// Atribui dados entre objetos do model e entity
        /// </summary>
        /// <param name="usuarioModel">objeto model</param>
        /// <param name="tb_usuario">objeto entity</param>
        private void Atribuir(Usuario usuarioModel, TbUsuario tb_usuario)
        {
            tb_usuario.CodUsuario = usuarioModel.CodUsuario;
            tb_usuario.Nome = usuarioModel.Nome;
            tb_usuario.Cpf = usuarioModel.Cpf;
            tb_usuario.Telefone = usuarioModel.Telefone;
            tb_usuario.Email = usuarioModel.Email;
            tb_usuario.Senha = usuarioModel.Senha;
            tb_usuario.Tipo = usuarioModel.Tipo;
            tb_usuario.StatusCliente = usuarioModel.StatusCliente;
            tb_usuario.StatusEntregador = usuarioModel.StatusEntregador;
        }
    }
}
