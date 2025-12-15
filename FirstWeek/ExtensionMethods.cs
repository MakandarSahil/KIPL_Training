//Extension Methods 
// its a mechanism of adding new methods into existing class or structure also without modifying the source code of the original type
// we can also use inheritance but it fails when the class is sealed and also main type is not class and its a struct 
// also if we use inheritance then we need to call from child 

// extension methods are defined as static but once there are bound with class they bcome non static

// using System;
// namespace ExtenstionMethods
// {

//   public static class StatClass
//   {
//     public static void Test3(this Program p)
//     {
//       Console.WriteLine("This is Test 3");
//     }
//   }
//   public class Program
//   {
//     public void Test1()
//     {
//       Console.WriteLine("This is Test 1");
//     }

//     public void Test2()
//     {
//       Console.WriteLine("This is Test 2");
//     }
//     public static void Main(string[] args)
//     {
//       Program p = new Program();
//       p.Test1(); p.Test2();
//       p.Test3();
//     }
//   }
// }

