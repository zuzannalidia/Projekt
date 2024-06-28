using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;

public class ContractRepository : IContractRepository
{
    private readonly ApplicationDbContext _context;

    public ContractRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contract>> GetAllContractsAsync()
    {
        return await _context.Contracts.ToListAsync();
    }

    public async Task<Contract> GetContractByIdAsync(int contractId)
    {
        return await _context.Contracts.FindAsync(contractId);
    }

    public async Task AddContractAsync(Contract contract)
    {
        await _context.Contracts.AddAsync(contract);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateContractAsync(Contract contract)
    {
        _context.Contracts.Update(contract);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteContractAsync(int contractId)
    {
        var contract = await _context.Contracts.FindAsync(contractId);
        if (contract != null)
        {
            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();
        }
    }
}