using Model;
using Moq;
using System;
using Xunit;
using Services;
using FastEntregasWeb.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CartaoTests
{
    public class UnitTest1
    {
        /// <summary>
        /// Testnado o método Create da Controller Cartão de Crédito para cartão válido
        /// </summary>
        [Fact]
        public void InserirCartaoValido()
        {
            //Arrange
            var mockRepoCartao = new Mock<IGerenciadorCartao>();
            mockRepoCartao.Setup(repo => repo.Inserir(It.IsAny<Cartao>())).Verifiable();
            var mockRepoUsuario = new Mock<IGerenciadorUsuario>();
            var newCartao = GetTestCartao();
            var controller = new CartaoController(mockRepoCartao.Object, mockRepoUsuario.Object);

            //Act
            var result = controller.Create(newCartao);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepoCartao.Verify();
        }
        /// <summary>
        /// Testnado o método Create da Controller Cartão de Crédito para cartão inválido CVV
        /// </summary>
        [Fact]
        public void InserirCartaoInvalido_CVV()
        {
            //Arrange
            var mockRepoCartao = new Mock<IGerenciadorCartao>();

            var mockRepoUsuario = new Mock<IGerenciadorUsuario>();
            var controller = new CartaoController(mockRepoCartao.Object, mockRepoUsuario.Object);
            controller.ModelState.AddModelError("Cvv", "Required");
            var newCartao = GetTestCartao();

            //Act
            var result = controller.Create(newCartao);

            //Assert
            var view = Assert.IsType<ViewResult>(result);
            Assert.Null(view.ViewName);
        }

        /// <summary>
        /// Testnado o método Create da Controller Cartão de Crédito para cartão inválido Numero
        /// </summary>
        [Fact]
        public void InserirCartaoInvalido_Numero()
        {
            //Arrange
            var mockRepoCartao = new Mock<IGerenciadorCartao>();

            var mockRepoUsuario = new Mock<IGerenciadorUsuario>();
            var controller = new CartaoController(mockRepoCartao.Object, mockRepoUsuario.Object);
            controller.ModelState.AddModelError("Numero", "Required");
            var newCartao = GetTestCartao();

            //Act
            var result = controller.Create(newCartao);

            //Assert
            var view = Assert.IsType<ViewResult>(result);
            Assert.Null(view.ViewName);
        }

        /// <summary>
        /// Testnado o método Create da Controller Cartão de Crédito para cartão inválido Validade
        /// </summary>
        [Fact]
        public void InserirCartaoInvalido_Validade()
        {
            //Arrange
            var mockRepoCartao = new Mock<IGerenciadorCartao>();

            var mockRepoUsuario = new Mock<IGerenciadorUsuario>();
            var controller = new CartaoController(mockRepoCartao.Object, mockRepoUsuario.Object);
            controller.ModelState.AddModelError("DataValidade", "Required");
            var newCartao = GetTestCartao();

            //Act
            var result = controller.Create(newCartao);

            //Assert
            var view = Assert.IsType<ViewResult>(result);
            Assert.Null(view.ViewName);
        }
        /// <summary>
        /// Incompleta
        /// </summary>
        [Fact]
        public void BuscarCartões()
        {
            //Arrange
            var mockRepoCartao = new Mock<IGerenciadorCartao>();
            mockRepoCartao.Setup(repo => repo.ObterTodos())
                .Returns(GetTestCartoes());
            var mockRepoUsuario = new Mock<IGerenciadorUsuario>();
            var controller = new CartaoController(mockRepoCartao.Object, mockRepoUsuario.Object);

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Cartao>>(viewResult.ViewData.Model);
            Assert.Single(model);

        }

        [Fact]
        public void ExcluirCartao()
        {

        }

        private IEnumerable<Cartao> GetTestCartoes()
        {
            return new List<Cartao>()
            {
                new Cartao()
                {
                    Numero = "5592320009111522",
                    NomeDono = "FELIPE D M TELES",
                    DataValidade = "06/2020",
                    Cvv = 136
                }
            };
        }

        private Cartao GetTestCartao()
        {
            return new Cartao()
            {
                Numero = "5592320009111522",
                NomeDono = "FELIPE D M TELES",
                DataValidade = "06/2020",
                Cvv = 136
            };
        }
    }


}
