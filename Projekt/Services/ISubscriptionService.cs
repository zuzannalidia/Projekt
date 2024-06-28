using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt.Models;

public interface ISubscriptionService
{
    Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync();
    Task<Subscription> GetSubscriptionByIdAsync(int subscriptionId);
    Task AddSubscriptionAsync(Subscription subscription);
    Task UpdateSubscriptionAsync(Subscription subscription);
    Task DeleteSubscriptionAsync(int subscriptionId);
}