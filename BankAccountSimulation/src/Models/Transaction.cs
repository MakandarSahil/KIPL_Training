using System;
namespace BankAccountSimulation.Models
{
  public class Transaction
  {
    public Guid Id { get; private set; }
    public DateTime Timestamp { get; private set; }

    public string? FromAccountNumber { get; private set; }
    public string? ToAccountNumber { get; private set; }
    public string Type { get; private set; }
    public string? Note { get; private set; }

    public Transaction(string type, decimal amount, string? from = null, string? to = null, string? note = null)
    {
      if (string.IsNullOrWhiteSpace(type)) throw new ArgumentException("Type Required");
      if (amount <= 0) throw new ArgumentException("Amount must be greater than 0");

      Id = Guid.NewGuid();
      Timestamp = DateTime.UtcNow;
      Type = type;
      Amount = amount;
      FromAccountNumber = from;
      ToAccountNumber = to;
      Note = note;
    }
  }
}