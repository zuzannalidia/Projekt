using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt.Models;
using Projekt.Repositories;

public class ContractService : IContractService
{
    private readonly IContractRepository _contractRepository;

    public ContractService(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task<IEnumerable<Contract>> GetAllContractsAsync()
    {
        return await _contractRepository.GetAllContractsAsync();
    }

    public async Task<Contract> GetContractByIdAsync(int contractId)
    {
        return await _contractRepository.GetContractByIdAsync(contractId);
    }

    public async Task AddContractAsync(Contract contract)
    {
        await _contractRepository.AddContractAsync(contract);
    }

    public async Task UpdateContractAsync(Contract contract)
    {
        await _contractRepository.UpdateContractAsync(contract);
    }

    public async Task DeleteContractAsync(int contractId)
    {
        await _contractRepository.DeleteContractAsync(contractId);
    }
}