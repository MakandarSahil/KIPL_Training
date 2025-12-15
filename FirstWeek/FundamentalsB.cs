//15/12/2025

//structure 
// user defined types , contains most of the member what a class can contain - feilds , methods , constructor, properties , indexers, operator methods etc,
// class is a refrence(managed heap memory) type whereas structure(stack memory) is a value type
// we cannot define default constructor in structure we can only define parameterised constructor in struct, need to use "new keyword to call default constructor to initia value"
// can not be inherited by other structure , can implement interface 

// using System;
// namespace StructureExample
// {
//   public struct MyStruct
//   {
//     public int i;
//     public void Display()
//     {
//       Console.WriteLine("Method is a structure : " + i);
//     }
//   }
//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       MyStruct m1;
//       m1.i = 10; // can not be intialised without constructor or like this 
//       m1.Display();
//     }
//   }
// }

//Enumeration or Enum types - user defined type 
// value type - default is int , available - byte, short , int , long , uint, ushort , and sbyte
// using System;
// namespace EnumExample
// {
//   public enum Days
//   {
//     Monday, Tuesday, Wednesday, Thursday, Friday
//   }
//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       // Console.BackgroundColor = ConsoleColor.Blue;
//       // Console.WriteLine("Hello World");
//       // Console.ReadLine();
//       Days d0 = 0;
//       Days d1 = (Days)2;
//       Days d2 = (Days)5; // this will print 5 becuase nothing to access is there
//       Console.WriteLine(d0);
//       Console.WriteLine(d1);
//       Console.WriteLine(d2);
//       foreach (int i in Enum.GetValues(typeof(Days)))
//         Console.WriteLine(i);

//       foreach (string s in Enum.GetNames(typeof(Days)))
//         Console.WriteLine(s);
//     }
//   }
// }


//Properties
// member of class using which we can expose values associated with a class to the outside enviroment
// using System;
// namespace PropertiesExample
// {
//   public class Customer
//   {
//     string _CustID;
//     string _CustomerName;
//     double _Balance;
//     bool _Status;

//     public string CustId
//     {
//       set
//       {
//         if (_Status == true)
//           _CustID = value;
//       }
//       get
//       {
//         return _CustID;
//       }
//     }

//     public string CustomerName
//     {
//       set
//       {
//         if (_Status == true)
//         {
//           _CustomerName = value;
//         }
//       }
//       get
//       {
//         return _CustomerName;
//       }
//     }

//     public double Balance
//     {
//       set
//       {
//         if (_Status == true && value >= 0)
//         {
//           _Balance = value;
//         }
//       }
//       get
//       {
//         return _Balance;
//       }
//     }

//     public bool Status
//     {
//       set
//       {
//         _Status = value;
//       }
//       get
//       {
//         return _Status;
//       }
//     }

//   }

//   public class Program
//   {
//     public static void Main(string[] args)
//     {
//       Customer cust1 = new Customer();
//       cust1.Status = true;
//       cust1.CustId = "101";
//       cust1.CustomerName = "Jhon";
//       cust1.Balance = 10000;

//       Console.WriteLine("Customer ID : " + cust1.CustId);
//       Console.WriteLine("Customer Name : " + cust1.CustomerName);
//       Console.WriteLine("Customer Balance : " + cust1.Balance);
//       Console.WriteLine("Customer Status : " + cust1.Status);

//     }
//   }

// }

// Indexers
// using System;
// namespace IndexerExample
// {
//   public class Employee
//   {
//     int Eno;
//     double Salary;
//     string Ename, Job, Dname, Location;

//     public Employee(int Eno, double Salary, string Ename, string Job, string Dname, string Location)
//     {
//       this.Eno = Eno;
//       this.Salary = Salary;
//       this.Ename = Ename;
//       this.Job = Job;
//       this.Dname = Dname;
//       this.Location = Location;
//     }

//     public object this[int index]
//     {
//       get
//       {
//         if (index == 0) return Eno;
//         else if (index == 1) return Salary;
//         else if (index == 2) return Ename;
//         else if (index == 3) return Job;
//         else if (index == 4) return Dname;
//         else if (index == 5) return Location;
//         else return null;
//       }
//       set
//       {
//         if (index == 0) Eno = (int)value;
//         else if (index == 1) Salary = (double)value;
//         else if (index == 2) Ename = (string)value;
//         else if (index == 3) Job = (string)value;
//         else if (index == 4) Dname = (string)value;
//         else if (index == 5) Location = (string)value;
//       }
//     }
//   }

//   public class TestEmployee
//   {
//     static void Main(string[] args)
//     {
//       Employee emp = new Employee(1, 12000.00, "Sahil", "Trainee", "IT", "Pune");
//       Console.WriteLine("Eno: " + emp[0]);
//       emp[1] = 13000.00;
//       Console.WriteLine("Emp Salary: " + emp[1]);
//     }
//   }
// }


// Delegates - type safe function pointer
// it holds the reference of a method and then calls the method for execution
// why delegates - its a type safe function pointer enables method refrence , soupport callback , enables event handling, Power LINQ, lamabdas and async patterns

// using System;
// namespace DelegateExample
// {
//   //declaring
//   public delegate void AddDelegate(int a, int b);
//   public delegate void SayDelegate(string s);
//   public class DelegateDemo
//   {
//     public void AddNums(int a, int b)
//     {
//       Console.WriteLine(a + b);
//     }
//     public void SayHello(string name)
//     {
//       Console.WriteLine("hello " + name);
//     }
//   }
//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       // Console.WriteLine("Hello");
//       DelegateDemo d = new DelegateDemo();

//       //instantiating
//       AddDelegate add = new AddDelegate(d.AddNums);

//       SayDelegate say = new SayDelegate(d.SayHello);

//       //calling 
//       // add(10, 20); 
//       add.Invoke(10, 20);
//       // say("sahil");
//       say.Invoke("Sahil");
//     }
//   }
// }

// Multicast delegates
// while using multidelgates methods should be non returning other vise they will override the result
// using System;
// namespace MulticastDelegates
// {

//   public delegate void RectDelegate(double Width, double Height);
//   class Reactangle
//   {
//     public void GetArea(double Width, double Height)
//     {
//       Console.WriteLine(Width * Height);
//     }

//     public void GetPerimeter(double Width, double Height)
//     {
//       Console.WriteLine(2 * (Width + Height));
//     }
//   }
//   public class Program
//   {
//     public static void Main(string[] args)
//     {
//       Reactangle rect = new Reactangle();
//       RectDelegate obj = new RectDelegate(rect.GetArea);
//       obj += rect.GetPerimeter;
//       obj.Invoke(12.34, 45.58);
//     }
//   }
// }

// Anonymous method - a method without a method body which can be bound to a delagate and can be directly called 
// using System;
// namespace Anonymous
// {
//   public delegate string GreetDelegate(string name);
//   class AnonymousMethod
//   {

//     // public string Greetings(string name)
//     // {
//     //   return "Hello " + name + " !!!";
//     // }
//     static void Main(string[] args)
//     {
//       // AnonymousMethod obj = new AnonymousMethod();
//       // GreetDelegate del = new GreetDelegate(obj.Greetings);
//       // string str = del.Invoke("Sahil");
//       // Console.WriteLine(str);

//       GreetDelegate obj = delegate (string name)
//       {
//         return "Hello " + name + " !!!";
//       };

//       string str = obj.Invoke("Sahil");
//       Console.WriteLine(str);
//     }
//   }
// }

// Lamda expression 
// using System;
// namespace LambdaExpression
// {

//   public delegate string GreetDelegate(string name);
//   // class Lambda
//   // {
//   //   public string Greetings(string name)
//   //   {
//   //     return "Hello " + name;
//   //   }
//   // }

//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       // Lambda lam = new Lambda();
//       // GreetDelegate obj = delegate (string name)
//       // {
//       //   return "Hello " + name;
//       // };

//       GreetDelegate obj = (name) =>
//       {
//         return "hello " + name;
//       };
//       string str = obj.Invoke("Sahil");
//       Console.WriteLine(str);
//     }
//   }
// }

// pre defined delegates 
// - func - if method returns any value 
// - action - if method is void / non retrun 
// - predicate - if method has return type as bool
// using System;
// namespace Delegates
// {
//   public delegate double Delegate1(int a, float b, double c);
//   public delegate void Delegate2(int a, float b, double c);
//   public delegate bool Delegate3(string str);
//   class GenaricDelegates
//   {
//     public double AddNums1(int a, float b, double c)
//     {
//       return a + b + c;
//     }

//     public void AddNums2(int a, float b, double c)
//     {
//       Console.WriteLine(a + b + c);
//     }

//     public bool CheckLen(string str)
//     {
//       if (str.Length > 5) return true;
//       return false;
//     }
//   }

//   public class Program
//   {
//     public static void Main(string[] args)
//     {
//       GenaricDelegates obj = new GenaricDelegates();
//       // Delegate1 del1 = obj.AddNums1;
//       // Func<int, float, double, double> del1 = obj.AddNums1;
//       Func<int, float, double, double> del1 = (a, b, c) =>
//       {
//         return a + b + c;
//       };
//       double res = del1.Invoke(100, 34.5f, 193.898);
//       Console.WriteLine(res);

//       // Delegate2 del2 = obj.AddNums2;
//       Action<int, float, double> del2 = obj.AddNums2;
//       del2.Invoke(100, 34.5f, 193.898);

//       // Delegate3 del3 = obj.CheckLen;
//       Predicate<string> del3 = obj.CheckLen;
//       // bool b = del3.Invoke("sahilMakandar"); 
//       // c# treats this b local variable as child scope so it give error - A local variable named 'b' cannot be declared in this scope because 
//       // it would give a different meaning to 'b', which is already used in a 'parent or current' scope to denote something else

//       bool res2 = del3.Invoke("SahilMakandar");
//       Console.WriteLine(res2);
//     }
//   }
// }