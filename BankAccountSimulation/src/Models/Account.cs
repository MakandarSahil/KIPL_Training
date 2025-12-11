using System;

namespace BankAccountSimulation.Models
{

  public abstract class Account
  {
    public Guid Id { get; private set; }
    public string AccountNumber { get; private set; }
    public decimal Balance { get; protected set; }
    public string OwnerName { get; set; }

    public string PinHash { get; private set; }
    public string PinSalt { get; private set; }

    protected Account(string accountNumber, string ownerName, decimal initBalanace = 0m)
    {
      Id = Guid.NewGuid();
      AccountNumber = accountNumber ?? throw new ArgumentNullException(nameof(accountNumber));
      OwenerName = ownerName ?? throw new ArgumentNullException(nameof(ownerName));
      Balance = initBalanace >= 0 ? initBalanace : throw new ArgumentException("Enter amount greater than 0");
    }

    public void SetPinHash(string hash, string salt)
    {
      if (string.IsNullOrWhiteSpace(hash)) throw new ArgumentException("Hash cannot be empty");
      if (string.IsNullOrWhiteSpace(salt)) throw new ArgumentException("Salt cannot be empty");

      PinHash = hash;
      PinSalt = salt;
    }

    public virtual void Deposit(decimal amount)
    {
      if (amount <= 0) throw new ArgumentException("Deposit amount must be greater than 0");
      Balance += amount;
    }

    public virtual void Withdraw(decimal amount)
    {
      if (amount <= 0) throw new ArgumentException("Withdraw amount should be greater than 0");
      if (Balance - amount < 0) throw new ArgumentException("Insufficient Balance");
      Balance -= amount;
    }
  }
}