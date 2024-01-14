using ClinicService.Controllers;
using ClinicService.Services.ClientServices;
using ClinicService.Shared;
using ClinicService.Shared.Entity;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ClinicService.Test
{
    public class ClientControllerTests
    {
        private readonly Mock<IClientRepository> _clientRepositoryMock;
        private readonly ClientController _clientController;

        public ClientControllerTests()
        {
            _clientRepositoryMock = new Mock<IClientRepository>();
            _clientController = new ClientController(_clientRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            // Arrange
            var clients = new List<Client> {  };
            var expectedResult = new ServiceResponse<IList<Client>> { Data = clients };

            _clientRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(expectedResult);

            // Act
            var result = await _clientController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var serviceResponse = Assert.IsType<ServiceResponse<IList<Client>>>(okResult.Value);
            Assert.Equal(clients, serviceResponse.Data);
        }

        [Fact]
        public async Task Create_ReturnsOkResult()
        {
            // Arrange
            var client = new Client {  };
            var expectedResult = new ServiceResponse<Client> { Data = client };

            _clientRepositoryMock.Setup(x => x.Create(It.IsAny<Client>())).ReturnsAsync(expectedResult);

            // Act
            var result = await _clientController.Create(client);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var serviceResponse = Assert.IsType<ServiceResponse<Client>>(okResult.Value);
            Assert.Equal(client, serviceResponse.Data);
        }

        [Fact]
        public async Task Update_WithExistingClient_ReturnsOkResult()
        {
            // Arrange
            var updatedClient = new Client { };
            var existingClient = new Client {  };
            var expectedResult = new ServiceResponse<Client> { Data = updatedClient };

            _clientRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new ServiceResponse<Client> { Data = existingClient });
            _clientRepositoryMock.Setup(x => x.Update(It.IsAny<Client>())).ReturnsAsync(expectedResult);

            // Act
            var result = await _clientController.Update(updatedClient);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var serviceResponse = Assert.IsType<ServiceResponse<Client>>(okResult.Value);
            Assert.Equal(updatedClient, serviceResponse.Data);
        }

        [Fact]
        public async Task Update_WithNonExistingClient_ReturnsBadRequest()
        {
            // Arrange
            var updatedClient = new Client { };

            _clientRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new ServiceResponse<Client> { Data = null });

            // Act
            var result = await _clientController.Update(updatedClient);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Необходимо зарегистрировать Владельца животного", badRequestResult.Value);
        }

        [Fact]
        public async Task Delete_WithExistingClient_ReturnsOkResult()
        {
            // Arrange
            var clientId = 1;
            var expectedResult = new ServiceResponse<int> { Data = clientId };

            _clientRepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(expectedResult);

            // Act
            var result = await _clientController.Delete(clientId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var serviceResponse = Assert.IsType<ServiceResponse<int>>(okResult.Value);
            Assert.Equal(clientId, serviceResponse.Data);
        }
   
        [Fact]
        public async Task GetById_WithExistingClient_ReturnsOkResult()
        {
            // Arrange
            var clientId = 1;
            var client = new Client {  };
            var expectedResult = new ServiceResponse<Client> { Data = client };

            _clientRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(expectedResult);

            // Act
            var result = await _clientController.GetById(clientId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var serviceResponse = Assert.IsType<ServiceResponse<Client>>(okResult.Value);
            Assert.Equal(client, serviceResponse.Data);
        }
    }
}
