using FastEntregasWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestesControllers
{
    public class UnitTest1
    {
        [Fact]
        public void ContaBancaria_ObterTodas()
        {
            // Arrange
            var mockRepo = new Mock<IGerenciadorContaBancaria>();
            mockRepo.Setup(repo => repo.ObterTodas())
                .Returns(GetTestContaBancaria());
            var mockRe = new Mock<IGerenciadorBanco>();
            mockRe.Setup(repo => repo.ObterTodos())
                .Returns(GetTestBanco());

            var controller = new ContaBancariaController(mockRepo.Object, mockRe.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<ContaBancaria>>(
                viewResult.ViewData.Model);
            Assert.True(model.Count == 2);
        }

        private IEnumerable<ContaBancaria> GetTestContaBancaria()
        {
            return new List<ContaBancaria>()
            {
                new ContaBancaria()
                {
                    CodBanco = 1,
                    CodConta = 6757,
                    CodUsuario = 781,
                    Agencia = 123,
                    Numero = 2142,
                    Tipo = "Corrente"


                },
                new ContaBancaria()
                {
                    CodBanco = 2,
                    CodConta = 1982,
                    CodUsuario = 123,
                    Agencia = 12356,
                    Numero = 214212,
                    Tipo = "Corrente"
                }
            };
        }

        private IEnumerable<Banco> GetTestBanco()
        {
            return new List<Banco>()
            {
                new Banco()
                {
                    CodBanco = 1,
                    Nome = "Banco A"


                },
                new Banco()
                {
                    CodBanco = 2,
                    Nome = "Banco B"


                }
            };
        }

        [Fact]
        public void ContaBancaria_Obter()
        {
            // Arrange
            var mockRepo = new Mock<IGerenciadorContaBancaria>();
            mockRepo.Setup(repo => repo.Obter(5437))
                .Returns(GetTestContaBancaria().First());
            var mockRe = new Mock<IGerenciadorBanco>();
            mockRe.Setup(repo => repo.ObterTodos())
                .Returns(GetTestBanco());

            var controller = new ContaBancariaController(mockRepo.Object, mockRe.Object);

            // Act
            var result = controller.Details(5437);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ContaBancaria>(
                viewResult.ViewData.Model);
            Assert.NotNull(model);
            Assert.True(model.CodConta == 6757);
        }

        [Fact]
        public void ContaBancaria_CreateGet()
        {
            // Arrange
            var mockRepo = new Mock<IGerenciadorContaBancaria>();
            mockRepo.Setup(repo => repo.Obter(5437))
                .Returns(GetTestContaBancaria().First());
            var mockRe = new Mock<IGerenciadorBanco>();
            mockRe.Setup(repo => repo.ObterTodos())
                .Returns(GetTestBanco());

            var controller = new ContaBancariaController(mockRepo.Object, mockRe.Object);

            // Act
            var result = controller.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public void ContaBancaria_CreatePost()
        {
            // Arrange
            var mockRepo = new Mock<IGerenciadorContaBancaria>();
            mockRepo.Setup(repo => repo.Inserir(GetTestContaBancaria().First()))
                .Returns(GetTestContaBancaria().First().CodConta);
            var mockRe = new Mock<IGerenciadorBanco>();
            mockRe.Setup(repo => repo.ObterTodos())
                .Returns(GetTestBanco());
            mockRepo.Setup(repo => repo.ObterTodas())
                .Returns(GetTestContaBancaria());

            var controller = new ContaBancariaController(mockRepo.Object, mockRe.Object);

            // Act
            var result = controller.Create(GetTestContaBancaria().First());

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);


        }

        [Fact]
        public void ContaBancaria_EditGet()
        {
            // Arrange
            var mockRepo = new Mock<IGerenciadorContaBancaria>();
            mockRepo.Setup(repo => repo.Obter(5437))
                .Returns(GetTestContaBancaria().First());
            var mockRe = new Mock<IGerenciadorBanco>();
            mockRe.Setup(repo => repo.ObterTodos())
                .Returns(GetTestBanco());

            var controller = new ContaBancariaController(mockRepo.Object, mockRe.Object);

            // Act
            var result = controller.Edit(5437);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public void ContaBancaria_EditPost()
        {
            // Arrange
            var mockRepo = new Mock<IGerenciadorContaBancaria>();
            mockRepo.Setup(repo => repo.Editar(GetTestContaBancaria().First()))
                .Verifiable();
            var mockRe = new Mock<IGerenciadorBanco>();
            mockRe.Setup(repo => repo.ObterTodos())
                .Returns(GetTestBanco());
            mockRepo.Setup(repo => repo.ObterTodas())
                .Returns(GetTestContaBancaria());

            var controller = new ContaBancariaController(mockRepo.Object, mockRe.Object);

            // Act
            var result = controller.Edit(5437, GetTestContaBancaria().First());

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);


        }

        [Fact]
        public void ContaBancaria_DeleteGet()
        {
            // Arrange
            var mockRepo = new Mock<IGerenciadorContaBancaria>();
            mockRepo.Setup(repo => repo.Obter(5437))
                .Returns(GetTestContaBancaria().First());
            var mockRe = new Mock<IGerenciadorBanco>();
            mockRe.Setup(repo => repo.ObterTodos())
                .Returns(GetTestBanco());

            var controller = new ContaBancariaController(mockRepo.Object, mockRe.Object);

            // Act
            var result = controller.Delete(5437);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public void ContaBancaria_DeletePost()
        {
            // Arrange
            var mockRepo = new Mock<IGerenciadorContaBancaria>();
            mockRepo.Setup(repo => repo.Remover(5437))
                .Verifiable();
            var mockRe = new Mock<IGerenciadorBanco>();
            mockRe.Setup(repo => repo.ObterTodos())
                .Returns(GetTestBanco());
            mockRepo.Setup(repo => repo.ObterTodas())
                .Returns(GetTestContaBancaria());

            var controller = new ContaBancariaController(mockRepo.Object, mockRe.Object);

            // Act
            var result = controller.Delete(5437, null);

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);


        }

      
    }
}
