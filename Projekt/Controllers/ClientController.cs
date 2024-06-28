using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt.Models;
using Projekt.Services;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
    {
        var clients = await _clientService.GetAllClientsAsync();
        return Ok(clients);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<Client>> GetClientById(int id)
    {
        var client = await _clientService.GetClientByIdAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        return Ok(client);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult> AddClient(Client client)
    {
        await _clientService.AddClientAsync(client);
        return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult> UpdateClient(int id, Client client)
    {
        if (id != client.Id)
        {
            return BadRequest();
        }

        await _clientService.UpdateClientAsync(client);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult> DeleteClient(int id)
    {
        await _clientService.DeleteClientAsync(id);
        return NoContent();
    }
}