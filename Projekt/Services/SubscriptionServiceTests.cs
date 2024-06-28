using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Projekt.Models;
using Projekt.Repositories;
using Projekt.Services;
using Xunit;

public class SubscriptionServiceTests
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly Mock<ISubscriptionRepository> _mockSubscriptionRepository;

    public SubscriptionServiceTests()
    {
        _mockSubscriptionRepository = new Mock<ISubscriptionRepository>();
        _subscriptionService = new SubscriptionService(_mockSubscriptionRepository.Object);
    }

    [Fact]
    public async Task GetAllSubscriptionsAsync_ReturnsAllSubscriptions()
    {
        // Arrange
        var subscriptions = new List<Subscription>
        {
            new Subscription { Id = 1, ServiceName = "Service1" },
            new Subscription { Id = 2, ServiceName = "Service2" }
        };

        _mockSubscriptionRepository.Setup(repo => repo.GetAllSubscriptionsAsync()).ReturnsAsync(subscriptions);

        // Act
        var result = await _subscriptionService.GetAllSubscriptionsAsync();

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetSubscriptionByIdAsync_ReturnsSubscription()
    {
        // Arrange
        var subscription = new Subscription { Id = 1, ServiceName = "Service1" };
        _mockSubscriptionRepository.Setup(repo => repo.GetSubscriptionByIdAsync(1)).ReturnsAsync(subscription);

        // Act
        var result = await _subscriptionService.GetSubscriptionByIdAsync(1);

        // Assert
        Assert.Equal("Service1", result.ServiceName);
    }

    [Fact]
    public async Task AddSubscriptionAsync_AddsSubscription()
    {
        // Arrange
        var subscription = new Subscription { ServiceName = "Service1" };

        // Act
        await _subscriptionService.AddSubscriptionAsync(subscription);

        // Assert
        _mockSubscriptionRepository.Verify(repo => repo.AddSubscriptionAsync(subscription), Times.Once);
    }

    [Fact]
    public async Task UpdateSubscriptionAsync_UpdatesSubscription()
    {
        // Arrange
        var subscription = new Subscription { Id = 1, ServiceName = "Service1" };

        // Act
        await _subscriptionService.UpdateSubscriptionAsync(subscription);

        // Assert
        _mockSubscriptionRepository.Verify(repo => repo.UpdateSubscriptionAsync(subscription), Times.Once);
    }

    [Fact]
    public async Task DeleteSubscriptionAsync_DeletesSubscription()
    {
        // Act
        await _subscriptionService.DeleteSubscriptionAsync(1);

        // Assert
        _mockSubscriptionRepository.Verify(repo => repo.DeleteSubscriptionAsync(1), Times.Once);
    }
}
