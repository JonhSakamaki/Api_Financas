using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace FinanceApi.Models;

public class Category
{
    public int Id { get;  set; }

    [Required(ErrorMessage = "O nome da categoria e obrigatorio.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome da categoria deve ter entre 3 a 50 caracteres ")]
    public string Name { get; set; } = string.Empty;

    public List<Transaction> Transactions{ get; set; } = new();
}