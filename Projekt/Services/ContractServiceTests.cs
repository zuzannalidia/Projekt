using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Projekt.Models;
using Projekt.Repositories;
using Projekt.Services;
using Xunit;

public class ContractServiceTests
{
    private readonly IContractService _contractService;
    private readonly Mock<IContractRepository> _mockContractRepository;

    public ContractServiceTests()
    {
        _mockContractRepository = new Mock<IContractRepository>();
        _contractService = new ContractService(_mockContractRepository.Object);
    }

    [Fact]
    public async Task GetAllContractsAsync_ReturnsAllContracts()
    {
        // Arrange
        var contracts = new List<Contract>
        {
            new Contract { Id = 1, SoftwareName = "Software1" },
            new Contract { Id = 2, SoftwareName = "Software2" }
        };

        _mockContractRepository.Setup(repo => repo.GetAllContractsAsync()).ReturnsAsync(contracts);

        // Act
        var result = await _contractService.GetAllContractsAsync();

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetContractByIdAsync_ReturnsContract()
    {
        // Arrange
        var contract = new Contract { Id = 1, SoftwareName = "Software1" };
        _mockContractRepository.Setup(repo => repo.GetContractByIdAsync(1)).ReturnsAsync(contract);

        // Act
        var result = await _contractService.GetContractByIdAsync(1);

        // Assert
        Assert.Equal("Software1", result.SoftwareName);
    }

    [Fact]
    public async Task AddContractAsync_AddsContract()
    {
        // Arrange
        var contract = new Contract { SoftwareName = "Software1" };

        // Act
        await _contractService.AddContractAsync(contract);

        // Assert
        _mockContractRepository.Verify(repo => repo.AddContractAsync(contract), Times.Once);
    }

    [Fact]
    public async Task UpdateContractAsync_UpdatesContract()
    {
        // Arrange
        var contract = new Contract { Id = 1, SoftwareName = "Software1" };

        // Act
        await _contractService.UpdateContractAsync(contract);

        // Assert
        _mockContractRepository.Verify(repo => repo.UpdateContractAsync(contract), Times.Once);
    }

    [Fact]
    public async Task DeleteContractAsync_DeletesContract()
    {
        // Act
        await _contractService.DeleteContractAsync(1);

        // Assert
        _mockContractRepository.Verify(repo => repo.DeleteContractAsync(1), Times.Once);
    }
}
