using System;
namespace BankAccountSimualtion.Models
{
  public class SavingsAccount : Account
  {
    public double InterestRate { get; set; }
    public SavingsAccount(string accountNumber, string ownerName, decimal initBalanace = 0m, double interestRate = 0.03)
      : base(accountNumber, ownerName, initBalanace)
    {
      if (interestRate < 0) throw new ArgumentException("Interest rate cannot be negative");
      InterestRate = interestRate;
    }

    public decimal ApplyMonthlyIntrest()
    {
      var monthlyRate = (decimal)InterestRate / 12m;
      var interest = Decimal.Round(Balance * monthlyRate, 2, MidpointRounding.AwayFromZero);
      if (interestRate > 0) Balance += interest;
      return interest;
    }
  }
}