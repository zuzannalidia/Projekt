using Projekt.Models;

namespace Projekt.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAllClientsAsync();
    Task<Client> GetClientByIdAsync(int clientId);
    Task AddClientAsync(Client client);
    Task UpdateClientAsync(Client client);
    Task DeleteClientAsync(int clientId);
}
