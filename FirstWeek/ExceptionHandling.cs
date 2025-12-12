//Exceptions 
// using System;
// namespace ExceptionHandling
// {
//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       int a = 10;
//       int b = 0;
//       Console.WriteLine(a / b);
//     }
//   }
// }

// using System;
// namespace ExceptionHandling
// {
//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       try
//       {
//         Console.WriteLine("Enter first number : ");
//         int a = int.Parse(Console.ReadLine());
//         Console.WriteLine("Enter second number : ");
//         int b = int.Parse(Console.ReadLine());
//         Console.WriteLine("Result : " + a / b);
//       }
//       catch (DivideByZeroException ex1)
//       {
//         Console.WriteLine(ex1.Message);
//       }
//       catch (FormatException ex2)
//       {
//         Console.WriteLine(ex2.Message);
//       }
//       finally
//       {
//         Console.WriteLine("Final block executed");
//       }

//       Console.WriteLine("End of the program");
//     }
//   }
// }


// Defining own Exception 

// public class DivideByZeroException : ApplicationException
// {
//   public override string Message
//   {
//     get
//     {
//       return "Attempted to divide by zero";
//     }
//   }
// }