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

namespace ControllerTests
{
    public class CartaoTestes
    {
        /// <summary>
        /// Testando o método Create da Controller Cartão de Crédito para cartão válido
        /// </summary>
        [Fact]
        public void CreateCartaoSucess()
        {
            //Arrange
            var mockCartao = new Mock<IGerenciadorCartao>();
            mockCartao.Setup(repo => repo.Inserir(It.IsAny<Cartao>())).Verifiable();
            var mockUsuario = new Mock<IGerenciadorUsuario>();
            var newCartao = GetTestCartao();
            var controller = new CartaoController(mockCartao.Object, mockUsuario.Object);

            //Act
            var result = controller.Create(newCartao);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockCartao.Verify();
        }
        /// <summary>
        /// Testando o método Create da Controller Cartão de Crédito para cartão inválido CVV
        /// </summary>
        [Fact]
        public void CreateCartaoFail()
        {
            //Arrange
            var mockCartao = new Mock<IGerenciadorCartao>();
            var mockUsuario = new Mock<IGerenciadorUsuario>();
            var controller = new CartaoController(mockCartao.Object, mockUsuario.Object);
            controller.ModelState.AddModelError("Numero", "Required");
            var newCartao = GetTestCartao();

            //Act
            var result = controller.Create(newCartao);

            //Assert
            var view = Assert.IsType<ViewResult>(result);
            Assert.Null(view.ViewName);
        }

        /*/// <summary>
        /// Testando o método Create da Controller Cartão de Crédito para cartão inválido Numero
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
        /// Testando o método Create da Controller Cartão de Crédito para cartão inválido Validade
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
        */

        /// <summary>
        /// Incompleta
        /// </summary>
        [Fact]
        public void IndexCartoes()
        {
            //Arrange
            var mockCartao = new Mock<IGerenciadorCartao>();
            mockCartao.Setup(repo => repo.ObterTodos())
                .Returns(GetTestCartoes());

            var mockUsuario = new Mock<IGerenciadorUsuario>();
            mockUsuario.Setup(repo => repo.ObterPorUserName(It.IsAny<String>()))
                .Returns(GetUsuario());

            var usuario = GetUsuario();
            var controller = new CartaoController(mockCartao.Object, mockUsuario.Object);
            
            //Act
            var result = controller.Index(usuario.UserName);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Cartao>>(viewResult.ViewData.Model);
            Assert.Single(model);

        }

        /// <summary>
        /// Testando o método Delete da Controller Cartão de Crédito
        /// </summary>
        [Fact]
        public void DeleteCartao()
        {
            //Arrange
            var mockRepoCartao = new Mock<IGerenciadorCartao>();
            mockRepoCartao.Setup(repo => repo.Remover(It.IsAny<int>())).Verifiable();

            var mockRepoUsuario = new Mock<IGerenciadorUsuario>();
            var newCartao = GetTestCartaoCompleto();
            var controller = new CartaoController(mockRepoCartao.Object, mockRepoUsuario.Object);
            
            //Act
            var result = controller.Delete(newCartao.CodCartao, null);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepoCartao.Verify();
        }       

        private IEnumerable<Cartao> GetTestCartoes()
        {          
            return new List<Cartao>()
            {
                new Cartao()
                {
                    CodCartao = 1,
                    Numero = "5592320009111522",
                    NomeDono = "FELIPE D M TELES",
                    DataValidade = "06/2020",
                    Cvv = 136,
                    CodUsuario = 1
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
                Cvv = 136,
                CodUsuario = 1
            };
        }

        private Cartao GetTestCartaoCompleto()
        {
            return new Cartao()
            {
                CodCartao = 1,
                Numero = "5592320009111522",
                NomeDono = "FELIPE D M TELES",
                DataValidade = "06/2020",
                Cvv = 136,
                CodUsuario = 1
            };
        }

        private Usuario GetUsuario()
        {
            return new Usuario()
            {
                CodUsuario = 1,
                UserName = "lipe9119"
            };
        }
    }


}
