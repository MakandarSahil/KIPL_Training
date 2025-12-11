using System;
using System.Globalization;

namespace BankAccountSimulation
{
  internal static class Program
  {
    static void Main(string[] args)
    {
      Console.Title = "Bank Account Simulation - CLI";

      //TODO - create real services amd assign to feilds above here

      ShowWelcomeBanner();

      RunMainMenu();
    }

    static void ShowWelcomeBanner()
    {
      Console.Clear();
      Console.WriteLine("========================================");
      Console.WriteLine("Welcome to Bank Account Simulation!! ");
      Console.WriteLine("========================================");
      Console.WriteLine();
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey(intercept: true);
    }

    static void RunMainMenu()
    {
      while (true)
      {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine("           Bank Account System           ");
        Console.WriteLine("1. Create Account");
        Console.WriteLine("2. Login in Account");
        Console.WriteLine("3. List All Accounts (Admin)");
        Console.WriteLine("4. Apply Monthly Intrest (Admin)");
        Console.WriteLine("5. Exit");
        Console.WriteLine("==============================================");
        Console.WriteLine("Enter Choice: ");

        var choice = Console.ReadLine()?.Trim();

        try
        {
          switch (choice)
          {
            case "1":
              CreateAccountUI();
              break;
            case "2":
              LoginUI();
              break;
            case "3":
              ListAccountsUI();
              break;
            case "4":
              ApplyMonthlyIntrestUI();
              break;
            case "5":
              Console.WriteLine("BYE BYE !!");
              return;
            default:
              Console.WriteLine("Invalid choice. Please try again...");
              Console.ReadKey();
              break;
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Unhandled error: {ex.Message}");
          Console.WriteLine("Press any key to return to the menu...");
          Console.ReadKey();
        }
      }
    }

    static void CreateAccountUI()
    {
      Console.Clear();
      Console.WriteLine("=== Create New Account ===");
      Console.WriteLine("Press any key to return to main menu...");
      Console.ReadKey(true);
    }

    static void LoginUI()
    {
      Console.Clear();
      Console.WriteLine("=== Login Into Your Account ===");
      Console.WriteLine("Press any key to return to main menu...");
      Console.ReadKey(true);
    }

    static void ApplyMonthlyIntrestUI()
    {
      Console.Clear();
      Console.WriteLine("=== Apply Monthly Intrest ===");
      Console.WriteLine("Press any key to return to main menu...");
      Console.ReadKey(true);
    }

    static void ListAccountsUI()
    {
      Console.Clear();
      Console.WriteLine("=== List All Account UI ===");
      Console.WriteLine("Press any key to return to main menu...");
      Console.ReadKey(true);
    }
  }
}