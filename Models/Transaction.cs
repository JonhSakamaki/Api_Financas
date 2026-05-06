using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceApi.Models;

public enum TransactionType
{
    Income,
    Expense
}

public class Transaction
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; } 
}