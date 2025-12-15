// using System;
// namespace Linq
// {
//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       int[] arr = { 12, 45, 67, 39, 8, 61, 74, 82, 27, 54, 98, 65, 44 };
//       int Count = 0;
//       for (int i = 0; i < arr.Length; i++)
//       {
//         if (arr[i] > 40) Count++;
//       }

//       int[] brr = new int[Count];
//       int index = 0;
//       for (int i = 0; i < arr.Length; i++)
//       {
//         if (arr[i] > 40)
//         {
//           brr[index] = arr[i];
//           index++;
//         }
//       }

//       Array.Sort(brr);
//       Array.Reverse(brr);

//       foreach (int i in brr)
//         Console.Write(i + " ");
//       Console.ReadLine();
//     }
//   }
// }


//Sql 
/* 
  select <collist> from <table> [as <alias>] [<clauses>]
*/

//linq
/*
  from <alias> in <coll | arr> [<clauses>] select <alias>

  var brr = from i in arr select i;
  var brr = from i in arr where i > 40 select i;
  var brr = from i in arr where i > 40 orderby i select i;
  var brr = from i in arr where i > 40 orderby i descending select i;
*/

// using System;
// using System.Linq;
// namespace Linq
// {
//   class Program
//   {
//     public static void Main(String[] args)
//     {
//       int[] arr = { 12, 45, 67, 39, 8, 61, 74, 82, 27, 54, 98, 65, 44 };
//       var brr = from i in arr where i > 40 orderby i descending select i;
//       foreach (int x in brr)
//         Console.Write(x + " ");
//     }
//   }
// }


// Aggregate Functions


using System;
using System.Linq;
namespace LinqDemo
{
  class Linq
  {
    public static void Main(string[] args)
    {
      // int[] Numbers = { 1, 2, 3, 4, 5, 6, 7 };
      // int? res = null;
      // foreach (int i in Numbers)
      // {
      //   if (!res.HasValue || i < res)
      //   {
      //     res = i;
      //   }
      // }

      // //minimum number in array
      // int res1 = Numbers.Min();
      // Console.WriteLine("Minimum number is : " + res1);

      // //minimum even number in array
      // int res2 = Numbers.Where(x => x % 2 == 0).Min();
      // Console.WriteLine("Minimum even number : " + res2);

      // //max number 
      // int max = Numbers.Max();
      // Console.WriteLine("Max number is : " + max);

      // //sum of all elements 
      // int sum = Numbers.Where(x => x % 2 == 0).Sum();
      // Console.WriteLine("Sum of all even number : " + sum);

      // double avg = Numbers.Average();
      // Console.WriteLine("Numbers avg : " + avg);

      // string[] countries = { "India", "UK" };
      // int minCount = countries.Min(x => x.Length);
      // int maxCount = countries.Max(x => x.Length);

      // Console.WriteLine("Min count : " + minCount + " Max count : " + maxCount); 

      // string[] countries = { "India", "US", "UK", "Canada", "Australia" };

      // string res = string.Empty;
      // res = countries.Aggregate((a, b) => a + ", " + b);
      // Console.WriteLine(res);

      // int[] Numbers = { 2, 3, 4, 5 };
      // int res2 = Numbers.Aggregate((a, b) => a * b);
      // Console.WriteLine(res2);


      // restriction operator
     
    }
  }
}
