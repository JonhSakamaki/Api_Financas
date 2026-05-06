using Microsoft.EntityFrameworkCore;
using FinanceApi.Models;

namespace FinanceApi.Data;

public class FinanceContext : DbContext
{
    public FinanceContext(DbContextOptions<FinanceContext> options) : base(options) { }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }
}