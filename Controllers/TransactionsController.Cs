using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanceApi.Data;
using FinanceApi.Models;

namespace FinanceApi.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly FinanceContext _context;
    public TransactionsController(FinanceContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
    {
        return await _context.Transactions
        .Include(t => t.Category)
        .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
    {
        var categoryExists = await _context.Categories.AnyAsync(c => c.Id == transaction.CategoryId);

        if (!categoryExists)
        {
            return BadRequest("Erro: A categoria informada nao existe no banco de dados.");
        }

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTransactions), new { id = transaction.Id }, transaction);
    }
}