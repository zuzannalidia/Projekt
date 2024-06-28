using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Projekt.Data;
using Projekt.Models;
using Projekt.Repositories;
using Projekt.Services;
using Xunit;

public class ClientServiceTests
{
    private readonly IClientService _clientService;
    private readonly Mock<IClientRepository> _mockClientRepository;

    public ClientServiceTests()
    {
        _mockClientRepository = new Mock<IClientRepository>();
        _clientService = new ClientService(_mockClientRepository.Object);
    }

    [Fact]
    public async Task GetAllClientsAsync_ReturnsAllClients()
    {
        // Arrange
        var clients = new List<Client>
        {
            new Client { Id = 1, FirstName = "John", LastName = "Doe" },
            new Client { Id = 2, FirstName = "Jane", LastName = "Doe" }
        };

        _mockClientRepository.Setup(repo => repo.GetAllClientsAsync()).ReturnsAsync(clients);

        // Act
        var result = await _clientService.GetAllClientsAsync();

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetClientByIdAsync_ReturnsClient()
    {
        // Arrange
        var client = new Client { Id = 1, FirstName = "John", LastName = "Doe" };
        _mockClientRepository.Setup(repo => repo.GetClientByIdAsync(1)).ReturnsAsync(client);

        // Act
        var result = await _clientService.GetClientByIdAsync(1);

        // Assert
        Assert.Equal("John", result.FirstName);
        Assert.Equal("Doe", result.LastName);
    }

    [Fact]
    public async Task AddClientAsync_AddsClient()
    {
        // Arrange
        var client = new Client { FirstName = "John", LastName = "Doe" };

        // Act
        await _clientService.AddClientAsync(client);

        // Assert
        _mockClientRepository.Verify(repo => repo.AddClientAsync(client), Times.Once);
    }

    [Fact]
    public async Task UpdateClientAsync_UpdatesClient()
    {
        // Arrange
        var client = new Client { Id = 1, FirstName = "John", LastName = "Doe" };

        // Act
        await _clientService.UpdateClientAsync(client);

        // Assert
        _mockClientRepository.Verify(repo => repo.UpdateClientAsync(client), Times.Once);
    }

    [Fact]
    public async Task DeleteClientAsync_DeletesClient()
    {
        // Act
        await _clientService.DeleteClientAsync(1);

        // Assert
        _mockClientRepository.Verify(repo => repo.DeleteClientAsync(1), Times.Once);
    }
}
