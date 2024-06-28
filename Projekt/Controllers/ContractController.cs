using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt.Models;
using Projekt.Services;

[ApiController]
[Route("api/[controller]")]
public class ContractController : ControllerBase
{
    private readonly IContractService _contractService;

    public ContractController(IContractService contractService)
    {
        _contractService = contractService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contract>>> GetAllContracts()
    {
        var contracts = await _contractService.GetAllContractsAsync();
        return Ok(contracts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Contract>> GetContractById(int id)
    {
        var contract = await _contractService.GetContractByIdAsync(id);
        if (contract == null)
        {
            return NotFound();
        }
        return Ok(contract);
    }

    [HttpPost]
    public async Task<ActionResult> AddContract(Contract contract)
    {
        await _contractService.AddContractAsync(contract);
        return CreatedAtAction(nameof(GetContractById), new { id = contract.Id }, contract);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateContract(int id, Contract contract)
    {
        if (id != contract.Id)
        {
            return BadRequest();
        }

        await _contractService.UpdateContractAsync(contract);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteContract(int id)
    {
        await _contractService.DeleteContractAsync(id);
        return NoContent();
    }
}