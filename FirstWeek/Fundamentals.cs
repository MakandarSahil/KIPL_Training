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
using System;
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