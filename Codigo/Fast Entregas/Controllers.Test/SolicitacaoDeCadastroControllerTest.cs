using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;

namespace Controllers.Test
{
    public class SolicitacaoDeCadastroControllerTest
    {
        /*[Fact]
        public void Index_ReturnsAViewResult_WithAListOfEmployees()
        {
            // Arrange
            var mockRepo = new Mock<IDataRepository<Employee>>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(GetTestEmployees());
            var controller = new EmployeeController(mockRepo.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Employee>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        private IEnumerable<Employee> GetTestEmployees()
        {
            return new List<Employee>()
            {
        
                new Employee()
                {
                    Id = 1,
                    Name = "John"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Doe"
                }
            };
        }*/
    }
}
