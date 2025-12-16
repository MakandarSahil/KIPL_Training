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


// using System;
// using System.Linq;
// namespace LinqDemo
// {
//   class Linq
//   {
//     public static void Main(string[] args)
//     {
//       // int[] Numbers = { 1, 2, 3, 4, 5, 6, 7 };
//       // int? res = null;
//       // foreach (int i in Numbers)
//       // {
//       //   if (!res.HasValue || i < res)
//       //   {
//       //     res = i;
//       //   }
//       // }

//       // //minimum number in array
//       // int res1 = Numbers.Min();
//       // Console.WriteLine("Minimum number is : " + res1);

//       // //minimum even number in array
//       // int res2 = Numbers.Where(x => x % 2 == 0).Min();
//       // Console.WriteLine("Minimum even number : " + res2);

//       // //max number 
//       // int max = Numbers.Max();
//       // Console.WriteLine("Max number is : " + max);

//       // //sum of all elements 
//       // int sum = Numbers.Where(x => x % 2 == 0).Sum();
//       // Console.WriteLine("Sum of all even number : " + sum);

//       // double avg = Numbers.Average();
//       // Console.WriteLine("Numbers avg : " + avg);

//       // string[] countries = { "India", "UK" };
//       // int minCount = countries.Min(x => x.Length);
//       // int maxCount = countries.Max(x => x.Length);

//       // Console.WriteLine("Min count : " + minCount + " Max count : " + maxCount); 

//       // string[] countries = { "India", "US", "UK", "Canada", "Australia" };

//       // string res = string.Empty;
//       // res = countries.Aggregate((a, b) => a + ", " + b);
//       // Console.WriteLine(res);

//       // int[] Numbers = { 2, 3, 4, 5 };
//       // int res2 = Numbers.Aggregate((a, b) => a * b);
//       // Console.WriteLine(res2);


//       // restriction operator

//     }
//   }
// }


// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// namespace LinqDemo
// {

//   public class Employee
//   {
//     public int EmployeeID { get; set; }
//     public string FirstName { get; set; }
//     public string LastName { get; set; }
//     public string Gender { get; set; }
//     public int AnnualSalary { get; set; }

//     public static List<Employee> GetAllEmployees()
//     {
//       List<Employee> listEmployees = new List<Employee>
//         {
//             new Employee
//             {
//                 EmployeeID = 101,
//                 FirstName = "Tom",
//                 LastName = "Daely",
//                 Gender = "Male",
//                 AnnualSalary = 60000
//             },
//             new Employee
//             {
//                 EmployeeID = 102,
//                 FirstName = "Mike",
//                 LastName = "Mist",
//                 Gender = "Male",
//                 AnnualSalary = 72000
//             },
//             new Employee
//             {
//                 EmployeeID = 103,
//                 FirstName = "Mary",
//                 LastName = "Lambeth",
//                 Gender = "Female",
//                 AnnualSalary = 48000
//             },
//             new Employee
//             {
//                 EmployeeID = 104,
//                 FirstName = "Pam",
//                 LastName = "Penny",
//                 Gender = "Female",
//                 AnnualSalary = 84000
//             },
//         };

//       return listEmployees;
//     }
//   }

//   // public class Student
//   // {
//   //   public string Name { get; set; }
//   //   public string Gender { get; set; }
//   //   public List<string> Subjects { get; set; }

//   //   public static List<Student> GetAllStudetns()
//   //   {
//   //     List<Student> listStudents = new List<Student>
//   //       {
//   //           new Student
//   //           {
//   //               Name = "Tom",
//   //               Gender = "Male",
//   //               Subjects = new List<string> { "ASP.NET", "C#" }
//   //           },
//   //           new Student
//   //           {
//   //               Name = "Mike",
//   //               Gender = "Male",
//   //               Subjects = new List<string> { "ADO.NET", "C#", "AJAX" }
//   //           },
//   //           new Student
//   //           {
//   //               Name = "Pam",
//   //               Gender = "Female",
//   //               Subjects = new List<string> { "WCF", "SQL Server", "C#" }
//   //           },
//   //           new Student
//   //           {
//   //               Name = "Mary",
//   //               Gender = "Female",
//   //               Subjects = new List<string> { "WPF", "LINQ", "ASP.NET" }
//   //           },
//   //       };

//   //     return listStudents;
//   //   }
//   // }

//   public class Student
//   {
//     public int StudentID { get; set; }
//     public string Name { get; set; }
//     public int TotalMarks { get; set; }

//     public static List<Student> GetAllStudents()
//     {
//       List<Student> listStudents = new List<Student>
//         {
//             new Student
//             {
//                 StudentID= 101,
//                 Name = "Tom",
//                 TotalMarks = 800
//             },
//             new Student
//             {
//                 StudentID= 102,
//                 Name = "Mary",
//                 TotalMarks = 900
//             },
//             new Student
//             {
//                 StudentID= 103,
//                 Name = "Valarie",
//                 TotalMarks = 800
//             },
//             new Student
//             {
//                 StudentID= 104,
//                 Name = "John",
//                 TotalMarks = 800
//             },
//         };

//       return listStudents;
//     }
//   }
//   class Linq
//   {

//     public static void Main(string[] args)
//     {
//       // Restriction Operators
//       // Where()
//       // int[] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//       // var evenNumbers = Numbers.Where(n => n % 2 == 0);
//       // foreach (var i in evenNumbers)
//       // {
//       //   Console.WriteLine(i);
//       // }

//       // Projection Operators 
//       // Select
//       // IEnumerable<int> res = Employee.GetAllEmployees().Select(emp => emp.EmployeeID);
//       // foreach (int id in res)
//       // {
//       //   Console.WriteLine(id);
//       // }

//       // var res = Employee.GetAllEmployees().Select(emp => new { FirstName = emp.FirstName, Gender = emp.Gender });
//       // foreach (var i in res)
//       // {
//       //   Console.WriteLine(i.FirstName + " - " + i.Gender);
//       // }

//       // 10% bonous if salary is more than 50000
//       // var res = Employee.GetAllEmployees().Where(emp => emp.AnnualSalary > 50000)
//       //   .Select(emp => new
//       //   {
//       //     Name = emp.FirstName,
//       //     Salary = emp.AnnualSalary,
//       //     Bonous = emp.AnnualSalary * 0.1
//       //   });

//       // foreach (var i in res)
//       // {
//       //   Console.WriteLine(i.Name + " " + "Salary : " + i.Salary + " " + "Bonous : " + i.Bonous);
//       // }


//       //SelectMany Operator - flatterns query result into singal list
//       // IEnumerable<string> sub = Student.GetAllStudetns().SelectMany(s => s.Subjects).Distinct();
//       // IEnumerable<string> sub = from student in Student.GetAllStudetns()
//       //                           from subject in student.Subjects
//       //                           select subject;
//       // foreach (string subject in sub)
//       // {
//       //   Console.WriteLine(subject);
//       // }

//       // var res = Student.GetAllStudetns().SelectMany(std => std.Subjects, (student, subject) =>
//       //                   new { StudentName = student.Name, SubjectName = subject });

//       // var res = from student in Student.GetAllStudetns()
//       //           from subject in student.Subjects
//       //           select new { StudentName = student.Name, SubjectName = subject };

//       // foreach (var v in res)
//       // {
//       //   Console.WriteLine(v.StudentName + " - " + v.SubjectName);
//       // }

//       //ordering operators

//       // sort students by name in ascending 
//       // IEnumerable<string> res = Student.GetAllStudetns().Select(std => std.Name);
//       // IOrderedEnumerable<Student> res = Student.GetAllStudetns().OrderBy(s => s.Name);
//       // IOrderedEnumerable<Student> res = from student in Student.GetAllStudetns()
//       //                                   orderby student.Name ascending
//       //                                   select student;
//       // foreach (Student s in res)
//       // {
//       //   Console.WriteLine(s.Name);
//       // }

//       // IOrderedEnumerable<Student> res = Student.GetAllStudents().OrderBy(s => s.TotalMarks).ThenBy(s => s.Name).ThenByDescending(s => s.StudentID);
//       // IOrderedEnumerable<Student> res = from student in Student.GetAllStudents()
//       //                                   orderby student.TotalMarks, student.Name, student.StudentID descending
//       //                                   select student;
//       // foreach (Student s in res)
//       // {
//       //   Console.WriteLine(s.TotalMarks + "\t" + s.Name + "\t" + s.StudentID);
//       // }

//       // IEnumerable<Student> res = Student.GetAllStudents();
//       // IEnumerable<Student> res2 = res.Reverse();
//       // foreach (Student s in res2)
//       // {
//       //   Console.WriteLine(s.Name);
//       // }

//       //partitioning operators

//       string[] countries = { "Australia", "Canada", "Germany", "US", "India", "UK", "Italy" };

//       // IEnumerable<string> res = countries.Take(3);
//       // IEnumerable<string> res = countries.Skip(3);
//       // IEnumerable<string> res = (from country in countries
//       //                            select countries).Take(3); 
//       // IEnumerable<string> res = countries.TakeWhile(s => s.Length > 5);
//       // IEnumerable<string> res = countries.SkipWhile(s => s.Length > 5);

//       // foreach (string str in res)
//       // {
//       //   Console.WriteLine(str);
//       // }



//     }

//   }
// }


using System;
using System.Collections.Generic;
using System.Linq;
namespace LinqDemo
{

  public class Student
  {
    public int StudentID { get; set; }
    public string Name { get; set; }
    public int TotalMarks { get; set; }

    public static List<Student> GetAllStudents()
    {
      List<Student> listStudents = new List<Student>
        {
            new Student
            {
                StudentID= 101,
                Name = "Tom",
                TotalMarks = 800
            },
            new Student
            {
                StudentID= 102,
                Name = "Mary",
                TotalMarks = 900
            },
            new Student
            {
                StudentID= 103,
                Name = "Valarie",
                TotalMarks = 800
            },
            new Student
            {
                StudentID= 104,
                Name = "John",
                TotalMarks = 800
            },
        };

      return listStudents;
    }
  }
  class Linq
  {
    public static void Main(string[] args)
    {

      //conversion operators - ToList , ToArray , ToDictionary , ToLookup
      // int[] numbers = { 1, 2, 3, 4, 5 };
      // List<int> res = numbers.ToList();
      // foreach (int i in res)
      // {
      //   Console.WriteLine(i);
      // }

      Dictionary<int, string> result = Student.GetAllStudents().ToDictionary(x => x.StudentID, x => x.Name);

      foreach (KeyValuePair<int, string> kvp in result)
      {
        Console.WriteLine(kvp.Key + " " + kvp.Value);
      }

    }
  }
}