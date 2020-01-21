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
        /// Testando o método Create da Controller Cartão de Crédito para cartão inválido
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

        /// <summary>
        /// Testando o método Create da Controller Cartão de Crédito formulário
        /// </summary>
        [Fact]
        public void CreateCartaoView()
        {
            //Arrange
            var mockCartao = new Mock<IGerenciadorCartao>();
            
            var mockUsuario = new Mock<IGerenciadorUsuario>();
            mockUsuario.Setup(repo => repo.ObterPorUserName(It.IsAny<String>()))
                .Returns(GetUsuario());
            var usuario = GetUsuario();
            var controller = new CartaoController(mockCartao.Object, mockUsuario.Object);

            //Act
            var result = controller.Create(usuario.UserName);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            
        }

        /// <summary>
        /// Testando o método Index da controller Cartão de Crédito
        /// </summary>
        [Fact]
        public void IndexCartoes()
        {
            //Arrange
            var usuario = GetUsuario();

            var mockCartao = new Mock<IGerenciadorCartao>();
            mockCartao.Setup(repo => repo.ObterTodos())
                .Returns(GetTestCartoes().
                Where(cartao => cartao.CodUsuario.Equals(usuario.CodUsuario)).ToList());

            var mockUsuario = new Mock<IGerenciadorUsuario>();
            mockUsuario.Setup(repo => repo.ObterPorUserName(It.IsAny<String>()))
                .Returns(GetUsuario());
            
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

        /// <summary>
        /// Testando o método Delete da Controller Cartão de Crédito exibisão de dados
        /// </summary>
        [Fact]
        public void DeleteCartaoView()
        {
            //Arrange
            var mockCartao = new Mock<IGerenciadorCartao>();
            var mockUsuario = new Mock<IGerenciadorUsuario>();
            var cartao = GetTestCartaoCompleto();
            var controller = new CartaoController(mockCartao.Object, mockUsuario.Object);

            //Act
            var result = controller.Delete(cartao.CodCartao);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);

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
                },
                new Cartao()
                {
                    CodCartao = 2,
                    Numero = "30277670609054",
                    NomeDono = "FELIPE D M TELES",
                    DataValidade = "12/2020",
                    Cvv = 184,
                    CodUsuario = 2
                }
            }.ToList();
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
