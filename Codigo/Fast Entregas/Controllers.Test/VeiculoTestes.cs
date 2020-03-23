using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Services;
using Moq;
using Model;
using FastEntregasWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ControllerTestes
{
    public class VeiculoTestes
    {
        [Fact]
        public void CreateVeiculoSucess()
        {
            //Arrange
            var mockRepo = new Mock<IGerenciadorVeiculo>();
            mockRepo.Setup(repo => repo.Inserir(It.IsAny<Veiculo>())).Verifiable();

            var mockRepoUsuario = new Mock<IGerenciadorUsuario>();

            var newVeiculo = GetTestVeiculo();
            var controller = new VeiculoController(mockRepo.Object, mockRepoUsuario.Object);

            //Act
            var result = controller.Create(newVeiculo);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();
        }

        [Fact]
        public void CreateVeiculoFail()
        {
            //Arrange
            var mockRepoVeiculo = new Mock<IGerenciadorVeiculo>();

            var mockRepoUsuario = new Mock<IGerenciadorUsuario>();
            var controller = new VeiculoController(mockRepoVeiculo.Object, mockRepoUsuario.Object);
            controller.ModelState.AddModelError("Placa", "Required");
            var newVeiculo = GetTestVeiculo();

            //Act
            var result = controller.Create(newVeiculo);

            //Assert
            var view = Assert.IsType<ViewResult>(result);
            Assert.Null(view.ViewName);
        }

        [Fact]
        public void CreateVeiculoView()
        {
            //Arrange
            var mockVeiculo = new Mock<IGerenciadorVeiculo>();

            var mockUsuario = new Mock<IGerenciadorUsuario>();
            mockUsuario.Setup(repo => repo.ObterPorUserName(It.IsAny<String>()))
                .Returns(GetUsuario());
            var usuario = GetUsuario();

            var controller = new VeiculoController(mockVeiculo.Object, mockUsuario.Object);

            //Act
            var result = controller.Create(usuario.UserName);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DeleteVeiculo()
        {
            // Arrange
            var mockRepo = new Mock<IGerenciadorVeiculo>();
            mockRepo.Setup(repo => repo.Remover(It.IsAny<int>())).Verifiable();

            var mockRepoUsuario = new Mock<IGerenciadorUsuario>();

            var Veiculo = GetTestVeiculoCompleto();

            var controller = new VeiculoController(mockRepo.Object, mockRepoUsuario.Object);

            //Act
            var result = controller.Delete(Veiculo.CodVeiculo, null);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();
        }

        [Fact]
        public void DeleteVeiculoView()
        {
            //Arrange
            var mockVeiculo = new Mock<IGerenciadorVeiculo>();
            var mockUsuario = new Mock<IGerenciadorUsuario>();
            var veiculo = GetTestVeiculoCompleto();
            var controller = new VeiculoController(mockVeiculo.Object, mockUsuario.Object);

            //Act
            var result = controller.Delete(veiculo.CodVeiculo);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void IndexVeiculo()
        {
            //Arrange
            var usuario = GetUsuario();

            var mockVeiculo = new Mock<IGerenciadorVeiculo>();
            mockVeiculo.Setup(repo => repo.ObterTodos())
                .Returns(GetTestVeiculos()
                .Where(veiculo => veiculo.CodDono.Equals(usuario.CodUsuario)).ToList());

            var mockUsuario = new Mock<IGerenciadorUsuario>();
            mockUsuario.Setup(repo => repo.ObterPorUserName(It.IsAny<String>()))
                .Returns(GetUsuario());

            var controller = new VeiculoController(mockVeiculo.Object, mockUsuario.Object);

            //Act
            var result = controller.Index(usuario.UserName);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Veiculo>>(viewResult.ViewData.Model);
            Assert.Single(model);
        }

        private IEnumerable<Veiculo> GetTestVeiculos()
        {
            return new List<Veiculo>()
            {
                new Veiculo()
                {
                    Categoria = "carro",
                    Placa = "iae-8730",
                    Renavam = "789546463",
                    Ano = 2010,
                    Status = "bloqueado",
                    EmUso = "Nao",
                    CodDono = 1
                },
                new Veiculo()
                {
                    Categoria = "carro",
                    Placa = "qkt-3000",
                    Renavam = "78954218768",
                    Ano = 2018,
                    Status = "disponivel",
                    EmUso = "Nao",
                    CodDono = 2
                }
            };
        }

        private Veiculo GetTestVeiculo()
        {
            return new Veiculo
            {
                Categoria = "carro",
                Placa = "iae-8730",
                Renavam = "789546463",
                Ano = 2010,
                Status = "bloqueado",
                EmUso = "Nao",
                CodDono = 1
            };
        }

        private Veiculo GetTestVeiculoCompleto()
        {
            return new Veiculo
            {
                CodVeiculo = 1,
                Categoria = "carro",
                Placa = "iae-8730",
                Renavam = "789546463",
                Ano = 2010,
                Status = "bloqueado",
                EmUso = "Nao",
                CodDono = 1
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
