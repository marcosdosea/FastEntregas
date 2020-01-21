using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Services;
using Moq;
using Model;
using FastEntregasWeb.Controllers;
using Microsoft.AspNetCore.Mvc;

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
        public void IndexVeiculo()
        {

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
    }
}
