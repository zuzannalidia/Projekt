using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt.Models;
using Projekt.Services;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Subscription>>> GetAllSubscriptions()
    {
        var subscriptions = await _subscriptionService.GetAllSubscriptionsAsync();
        return Ok(subscriptions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Subscription>> GetSubscriptionById(int id)
    {
        var subscription = await _subscriptionService.GetSubscriptionByIdAsync(id);
        if (subscription == null)
        {
            return NotFound();
        }
        return Ok(subscription);
    }

    [HttpPost]
    public async Task<ActionResult> AddSubscription(Subscription subscription)
    {
        await _subscriptionService.AddSubscriptionAsync(subscription);
        return CreatedAtAction(nameof(GetSubscriptionById), new { id = subscription.Id }, subscription);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateSubscription(int id, Subscription subscription)
    {
        if (id != subscription.Id)
        {
            return BadRequest();
        }

        await _subscriptionService.UpdateSubscriptionAsync(subscription);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSubscription(int id)
    {
        await _subscriptionService.DeleteSubscriptionAsync(id);
        return NoContent();
    }
}