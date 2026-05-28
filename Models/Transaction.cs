using System.ComponentModel.DataAnnotations;
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

    [Required(ErrorMessage = "A descricao e obrigatoria.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage ="A descricao deve ter entre 3 a 100 caracteres.")]
    public string Description { get; set; } = string.Empty;
    
    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "a data e obrigatoria.")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "O tipo de Transacao e obrigatorio.")]
    public TransactionType Type { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "A categoria informada e invalida.")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; } 
}