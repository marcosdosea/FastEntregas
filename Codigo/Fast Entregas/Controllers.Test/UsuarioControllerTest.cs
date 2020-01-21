using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using FastEntregasWeb.Controllers;
using Services;
using Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Controllers.Test
{
    public class UsuarioControllerTest
    {
        
        [Fact]
        public void SolicitarCadastroTeste()
        {
            // Arrange
            var mockGerenciadorUsuario = new Mock<IGerenciadorUsuario>();
            var mockGerenciadorSolicitacao = new Mock<IGerenciadorSolicitacaoDeCadastro>();

            mockGerenciadorSolicitacao.Setup(repo => repo.ObterTodos()).Returns(GetTestSolicitacaoDeCadastro());
            var controller = new UsuarioController(mockGerenciadorUsuario.Object, mockGerenciadorSolicitacao.Object);

            // Act
            var usuario = new Usuario();
            usuario.UserName = "natan";
            var result = controller.SolicitarCadastro(usuario.UserName);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<SolicitacaoDeCadastro>>(
                viewResult.ViewData.Model);
            Assert.Single(model);
        }

        private IEnumerable<SolicitacaoDeCadastro> GetTestSolicitacaoDeCadastro()
        {
            return new List<SolicitacaoDeCadastro>()
            {

                new SolicitacaoDeCadastro()
                {
                    CodSolicitacao = 1,
                    NumRegistro = "123456879123456",
                    NumCnh = "789456123789456",
                    DataNascimento = new DateTime(),
                    CodUsuarioEntregador = 3
                }
            };
        }
    }
}
