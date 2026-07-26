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

    [HttpGet("{id}")]
    public async Task<ActionResult<Transaction>> GetTransaction(int id)
    {
        var transaction = await _context.Transactions.Include(t => t.Category).FirstOrDefaultAsync(t => t.Id == id);

    if (transaction == null)
        {
            return NotFound("Transação não encontrada.");
        }

        return transaction;
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

    [HttpGet("Resumo")]
    public async Task<ActionResult<object>> GetResumo()
    {
        var totalReceitas = await _context.Transactions.Where(t => t.Type == TransactionType.Income).SumAsync(t => t.Amount);

        var totalDespesas = await _context.Transactions.Where(t => t.Type == TransactionType.Expense).SumAsync(t => t.Amount);

        var saldo = totalReceitas - totalDespesas;

        return Ok(new
        {
            TotalReceitas = totalReceitas,
            TotalDespesas = totalDespesas,
            SaldoAtual = saldo
        });

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTransaction (int id, Transaction transaction)
    {
        if (id != transaction.Id)
        {
            return BadRequest("O ID informado na URL nao coincide com o ID do corpo da requisicao.");
        }

        var categoryExists = await _context.Categories.AnyAsync(c => c.Id == transaction.CategoryId);
        if (!categoryExists)
        {
            return BadRequest("A categoria informada nao existe.");
        }

        _context.Entry(transaction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TransactionExists(id))
            {
                return NotFound("Transacao nao encontrada.");
            }
            else
            {
                throw;
            }
        }

        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction == null)
        {
            return NotFound("Transacao nao encontrada");
        }

        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync();

        return NoContent();

    }

    private bool TransactionExists(int id)
    {
        return _context.Transactions.Any(e => e.Id == id);
    }

}