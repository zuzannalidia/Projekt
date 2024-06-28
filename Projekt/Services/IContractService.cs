using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt.Models;

public interface IContractService
{
    Task<IEnumerable<Contract>> GetAllContractsAsync();
    Task<Contract> GetContractByIdAsync(int contractId);
    Task AddContractAsync(Contract contract);
    Task UpdateContractAsync(Contract contract);
    Task DeleteContractAsync(int contractId);
}