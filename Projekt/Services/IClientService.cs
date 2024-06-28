namespace Projekt.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt.Models;

public interface IClientService
{
    Task<IEnumerable<Client>> GetAllClientsAsync();
    Task<Client> GetClientByIdAsync(int clientId);
    Task AddClientAsync(Client client);
    Task UpdateClientAsync(Client client);
    Task DeleteClientAsync(int clientId);
}
