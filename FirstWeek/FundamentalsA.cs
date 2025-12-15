// date - 11/12/2025
// using System;
// namespace HelloWorld
// {
//     class Car
//     {
//         string model;
//         string color;
//         int year;

//         public void FullThrottle()
//         {
//             Console.WriteLine("The car is going as fast as it can!");
//         }

//         static void Main(string[] args)
//         {
//             Car Ford = new Car();
//             Ford.model = "Mustang";
//             Ford.color = "Red";
//             Ford.year = 1969;

//             Car BMW = new Car();
//             BMW.model = "X5";
//             BMW.color = "Black";
//             BMW.year = 2020;

//             Console.WriteLine(Ford.model);
//             Console.WriteLine(BMW.model);

//             Ford.FullThrottle();
//         }
//     }
// }

// using System;
// namespace HelloWorld
// {
// 	class Car
// 	{
// 		public string model;
// 		public Car(string ModelName)
// 		{
// 			model = ModelName;
// 		}
// 		static void Main(string[] args)
// 		{
// 			Car myObj = new Car("BMW");
// 			Console.WriteLine(myObj.model);
// 		}
// 	}
// }


//Encapsulation Example
// using System;
// namespace HelloWorld
// {
// 	class Person
// 	{
// 		private string name;
// 		public string Name
// 		{
// 			get { return name; }
// 			set { name = value; }
// 		}
// 	}

// 	class Program
// 	{
// 		public static void Main(string[] args)
// 		{
// 			Person prn = new Person();
// 			prn.Name = "John";
// 			Console.WriteLine(prn.Name);
// 		}
// 	}
// }

//Inheritance Example
// using System;
// namespace HelloWorld
// {
// 	class Vehicle
// 	{
// 		public string brand = "Ford";
// 		public void honk()
// 		{
// 			Console.WriteLine("Tuut, tuut!");
// 		}
// 	}

// 	class Car : Vehicle
// 	{
// 		public string modelname = "Mustang";
// 	}

// 	class Program
// 	{
// 		public static void Main(string[] args)
// 		{
// 			Vehicle myVehicle = new Vehicle();
// 			myVehicle.honk();
// 			Console.WriteLine(myVehicle.brand);

// 			Car myCar = new Car();
// 			myCar.honk();
// 			Console.WriteLine(myCar.brand + " " + myCar.modelname);
// 		}
// 	}
// }

//Polymorphism Example
// using System;
// namespace HelloWorld
// {
// 	class Animal
// 	{
// 		public virtual void AnimalSound()
// 		{
// 			Console.WriteLine("The animal makes a sound");
// 		}
// 	}

// 	class Dog : Animal
// 	{
// 		public override void AnimalSound()
// 		{
// 			Console.WriteLine("The dog barks");
// 		}
// 	}

// 	class Program
// 	{
// 		public static void Main(string[] args)
// 		{
// 			Animal animal = new Animal();
// 			animal.AnimalSound();

// 			Animal dog = new Dog();
// 			dog.AnimalSound();
// 		}
// 	}
// }

//example Abstraction
// using System;
// namespace HelloWorld
// {
//   abstract class Animal
//   {
//     public abstract void animalSound();
//     public void sleep()
//     {
//       Console.WriteLine("Zzz");
//     }
//   }

//   class Dog : Animal
//   {
//     public override void animalSound()
//     {
//       Console.WriteLine("The dog barks");
//     }
//   }
//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       // Animal animal = new Animal();
//       // animal.sleep();

//       Dog dog = new Dog();
//       dog.animalSound();
//       dog.sleep();
//     }
//   }
// }

// Interface Example
// using System;
// namespace HelloWorld
// {
//   interface IAnimal
//   {
//     void animalSound();
//   }

//   class Dog : IAnimal
//   {
//     public void animalSound()
//     {
//       Console.WriteLine("The dog barks");
//     }
//   }

//   class Program
//   {
//     public static void Main(string[] args)
//     {

//       // IAnimal animal = new IAnimal();
//       // Dog dog = new Dog();
//       // dog.animalSound();
//     }
//   }
// }

// Multiple Inheritance
// using System;
// using System.Text;
// namespace HelloWorld
// {
//   interface IFirst
//   {
//     void FirstMethod();
//   }

//   interface ISecond
//   {
//     void SecondMethod();
//   }

//   class DemoClass : IFirst, ISecond
//   {
//     public void FirstMethod()
//     {
//       Console.WriteLine("This is first Method");
//     }

//     public void SecondMethod()
//     {
//       Console.WriteLine("This is second Method");
//     }
//   }

//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       DemoClass demo = new DemoClass();
//       demo.FirstMethod();
//       demo.SecondMethod();
//     }
//   }
// }

//Exception handling
// using System;
// namespace HelloWorld
// {
//   class Program
//   {
//     static void checkAge(int age)
//     {
//       if (age < 18)
//       {
//         throw new ArithmeticException("Access Denied - You must be above 18!!");
//       }
//       else
//       {
//         Console.WriteLine("Access granted - You are old enough!!");
//       }
//     }
//     public static void Main(string[] args)
//     {
//       checkAge(15);
//     }
//   }
// }

// namespace HelloWorld
// {
//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       try
//       {
//         int[] myNumbers = { 1, 2, 3 };
//         Console.WriteLine(myNumbers[10]);
//       }
//       catch
//       {
//         Console.WriteLine("Out of Index!! (from catch block)");
//       }
//       finally
//       {
//         Console.WriteLine("final block executed!!");
//       }
//     }
//   }
// }


//12/12/2025
// using System; 
// namespace HelloWorld
// {
//   class CopyConsDemo
//   {
//     int x;
//     public CopyConsDemo(int i)
//     {
//       x = i;
//     }

//     public CopyConsDemo(CopyConsDemo obj)
//     {
//       x = obj.x;
//     }

//     public void Display()
//     {
//       Console.WriteLine("The value of X is " + x);
//     }
//   }

//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       CopyConsDemo copy1 = new CopyConsDemo(10);
//       copy1.Display();
//       CopyConsDemo copy2 = new CopyConsDemo(copy1);
//       copy2.Display();
//     }
//   }
// }

//inheritance
// By default each class is inherited from a Object class that is Object class is parent of each class by default
// Object obj = new Object();
// if class is not inherited from any other class its get inherited from Object class that is if it is inherited from some class then it has parent which is 
// inherited from Object class 

// using System;
// namespace Inheritance
// {
//   public class Class1
//   {

//     // parent class constructor must be accesible to child class to achive inheritance
//     public Class1()
//     {
//       Console.WriteLine("Parent class called");
//     }
//     public void test1()
//     {
//       Console.WriteLine("This is parent class");
//     }
//   }
//   public class Class2 : Class1
//   {
//     public Class2()
//     {
//       Console.WriteLine("Child class called");
//     }
//     public void test2()
//     {
//       Console.WriteLine("This is child class");
//     }
//   }

//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       // Class1 parent = new Class1();
//       // Class2 child = new Class2();
//       // parent.test1();
//       // child.test1();
//       // child.test2();


//       //we can not call child class members even with refrencing that is child can access parents property but 
//       //but parent can not access child class property
//       // Class1 p;
//       // Class2 c = new Class2();
//       // p = c;
//       // p.test1();
//       // p.test2();
//     }
//   }
// }

// using System;
// namespace Inheritance
// {
//   public class Class1
//   {
//     public Class1(int x)
//     {
//       Console.WriteLine("This is class 1 and parameters value : " + x);
//     }
//   }

//   public class Class2 : Class1
//   {
//     // this will give an error beacause it will call parents construct but it requires value to be provided cuase its parameterised
//     // public Class2()
//     // {
//     //   Console.WriteLine("This is class 2");
//     // }

//     //base class need to call parent class with base keyword if parent class constructor is parameterised
//     public Class2() : base(10)
//     {
//       Console.WriteLine("this is class 2");
//     }
//   }

//   class Program
//   {
//     public static void Main(string[] str)
//     {
//       Class2 c = new Class2();
//     }
//   }
// }

// Method overloading - changing the parameters , can be performed within the class and between parent child, child doesnt need permission
// can be overloaded with number of parameters , types of parameters, sequence of parameters 
// - having multiple behaviours
// using System;
// namespace Overloading
// {
//   public class Demo
//   {
//     public void Test()
//     {
//       Console.WriteLine("This is first method");
//     }
//     public void Test(int i)
//     {
//       Console.WriteLine("This is second method :" + i);
//     }

//     public void Test(string s)
//     {
//       Console.WriteLine("This is third Method");
//     }

//     public void Test(int i, string s)
//     {
//       Console.WriteLine("This is fourth Method" + s + i);
//     }

//     public void Test(string s, int i)
//     {
//       Console.WriteLine("This is fifth method" + s + i);
//     }
//   }

//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       Demo demo = new Demo();
//       demo.Test();
//       demo.Test(5);
//       demo.Test("sahil");
//       demo.Test(10, "sahil");
//       demo.Test("Sahil", 20);
//     }
//   }
// }


// using System;
// namespace Overloading
// {
//   public class Class1
//   {
//     public void Test()
//     {
//       Console.WriteLine("This is parent class method 1");
//     }
//   }

//   public class Class2 : Class1
//   {
//     public void Test(int i)
//     {
//       Console.WriteLine("This is child class mehtod 2 which we are trying to overload " + i);
//     }
//   }

//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       Class2 child = new Class2();
//       child.Test();
//       child.Test(10);
//     }
//   }
// }

// Polymorphism
// Method overriding - same name and same parameters , can be only perfromed between parent child classes, child need permission
// - changing the behaviour in child 

// using System;
// namespace Overriding
// {
//   public class Class1
//   {
//     public virtual void Test()
//     {
//       Console.WriteLine("This is parent class");
//     }
//   }

//   public class Class2 : Class1
//   {

//     public override void Test()
//     {
//       //if you want to call parent test method you need to call base call in child 
//       base.Test();
//       Console.WriteLine("This is overloaded method in child class");
//     }
//   }

//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       Class2 child = new Class2();
//       child.Test();
//     }
//   }
// }

// Method hiding
// same as method overriding but can re implement methods from parent which are not declared as virtual

// using System;
// namespace Methodhiding
// {
//   public class Class1
//   {
//     public virtual void Overloading()
//     {
//       Console.WriteLine("This is parent class for method overloading");
//     }
//     public void Hiding()
//     {
//       Console.WriteLine("This is parent class fpr method Hiding");
//     }
//   }

//   public class Class2 : Class1
//   {
//     public override void Overloading()
//     {
//       Console.WriteLine("This is child class for method overloading");
//     }

//     public new void Hiding()
//     {
//       Console.WriteLine("THis is child class for method hiding");
//     }
//   }

//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       Class2 child = new Class2();
//       child.Overloading();
//       child.Hiding();
//     }
//   }
// }


// Abstract class and methods - to make child implement a method like compulsion
// that is every abstact method should be implemented by child class

// using System;
// namespace AbstractClass
// {
//   public abstract class Shape
//   {
//     public double Height, Width, Radius;
//     public const float Pi = 3.14f;

//     public abstract double GetArea();
//   }

//   public class Reactangle : Shape
//   {
//     public Reactangle(double Height, double Width)
//     {
//       this.Height = Height;
//       this.Width = Width;
//     }
//     public override double GetArea()
//     {
//       return Height * Width;
//     }
//   }

//   public class Circle : Shape
//   {
//     public Circle(double Radius)
//     {
//       this.Radius = Radius;
//     }

//     public override double GetArea()
//     {
//       return Radius * Pi;
//     }
//   }

//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       Reactangle rectangle = new Reactangle(10, 20);
//       Circle circle = new Circle(10);

//       Console.WriteLine("Area of Reactangle is :" + rectangle.GetArea());
//       Console.WriteLine("Area of circle is :" + circle.GetArea());
//     }
//   }
// }

// Interfaces - this is also a user defined data type like class
// class  - non-abstact methods (Methods with method body)
// Abstract class - non-abstact methods (Methods with method body) and also abstract methods (without body)

// interface only contains abstact methods (without body)
// child must implement all abstact methods from parent interface
// interface can not contain any feilds or variable 
// can inherit from another interface 

// using System;
// namespace Interface
// {
//   public interface ITestInterface1
//   {
//     void add(int a, int b);
//   }
//   public interface ITestInterface2 : ITestInterface1
//   {
//     void sub(int a, int b);
//   }

//   class ImplementationClass : ITestInterface2
//   {
//     public void add(int a, int b)
//     {
//       Console.WriteLine(a + b);
//     }
//     public void sub(int a, int b)
//     {
//       Console.WriteLine(a - b);
//     }
//   }

//   class Program
//   {
//     public static void Main(string[] args)
//     {
//       ImplementationClass c = new ImplementationClass();
//       c.add(1, 2);
//       c.sub(1, 2);
//     }
//   }
// }

// mutiple and hybrid inheritance using interfaces
// using System;
// namespace MultipleInheritance
// {
//   public interface IFirst
//   {
//     void Test();
//     void Show();
//   }
//   public interface ISecond
//   {
//     void Test();
//     void Show();
//   }

//   public class MultipleInheritanceDemo : IFirst, ISecond
//   {
//     public void Test()
//     {
//       Console.WriteLine("Test called from child");
//     }

//     void IFirst.Show()
//     {
//       Console.WriteLine("Show from IFirst");
//     }

//     void ISecond.Show()
//     {
//       Console.WriteLine("Show from ISeconf");
//     }

//     public static void Main(string[] args)
//     {
//       MultipleInheritanceDemo demo = new MultipleInheritanceDemo();
//       demo.Test();

//       IFirst i1 = demo; i1.Show();
//       ISecond i2 = demo; i2.Show();
//     }
//   }
// }



