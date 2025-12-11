using System;
//support overdraft
namespace BankAccountSimulation.Models
{
  public decimal OverdraftLimit { get; set; }
  public class CurrentAccount : Account
  {
    public CurrentAccount(string accountNumber, string ownerName, decimal initBalanace = 0m, decimal overdraftLimit = 0m)
      : base(accountNumber, ownerName, initBalanace)
    {
      if (overdraftLimit < 0) throw new ArgumentException("Overdraft limit can not be negative");
      OverdraftLimit = overdraftLimit;

    }

    public override void Withdraw(decimal amount)
    {
      if (amount <= 0) throw new ArgumentException("Withdraw amount must be greater than 0");
      var resulting = Balance - amount;
      if (amount < -OverdraftLimit) throw new InvalidOperationException("Insufficient funds (overdraft limtit exceeded)");

      Balance = resulting;
    }
  }
}