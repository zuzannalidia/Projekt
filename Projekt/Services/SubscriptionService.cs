using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt.Models;
using Projekt.Repositories;

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionService(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync()
    {
        return await _subscriptionRepository.GetAllSubscriptionsAsync();
    }

    public async Task<Subscription> GetSubscriptionByIdAsync(int subscriptionId)
    {
        return await _subscriptionRepository.GetSubscriptionByIdAsync(subscriptionId);
    }

    public async Task AddSubscriptionAsync(Subscription subscription)
    {
        await _subscriptionRepository.AddSubscriptionAsync(subscription);
    }

    public async Task UpdateSubscriptionAsync(Subscription subscription)
    {
        await _subscriptionRepository.UpdateSubscriptionAsync(subscription);
    }

    public async Task DeleteSubscriptionAsync(int subscriptionId)
    {
        await _subscriptionRepository.DeleteSubscriptionAsync(subscriptionId);
    }
}