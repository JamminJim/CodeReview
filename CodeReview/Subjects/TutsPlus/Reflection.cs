using System;
using System.Reflection;
using System.Linq;

namespace CodeReview.Subjects.TutsPlus
{
	/// <summary>
	/// Youtube URL: https://www.youtube.com/watch?v=3FvT6uNMT7M
	/// </summary>
	public static class Reflection
	{
		/// <summary>
		/// Reflection allows the code to look at itself and see what makes up itself
		/// 
		/// </summary>
		public static void Run() {
			Console.WriteLine("Reflection running...");
			Reflection.Example3();

		}

		// Example 1 - Show how reflection works. We need an assembly to reflect against, which is this running executable
		private static void Example1() {
			// prints out a unique identifier for this executing assembly
			var assembly = Assembly.GetExecutingAssembly();
			Console.WriteLine(assembly.FullName);       // output: CodeReview, Version=1.0.6206.25140, Culture=neutral, PublicKeyToken=null

			// prints out all the classes in the project
			var types = assembly.GetTypes();
			foreach (var type in types) {
				Console.WriteLine("Type: {0}", type.Name);

				// print out each property for each class found
				var props = type.GetProperties();
				foreach (var prop in props) {
					Console.WriteLine("\tProperty: Name:{0} Type:{1}", prop.Name, prop.PropertyType);      // prints out all the class properties in the project
				}

				// print out each field for each class found
				var fields = type.GetFields();
				foreach (var field in fields) {
					Console.WriteLine("\tFields: Name:{0} Type:{1}", field.Name, field.FieldType);      // prints out all the class fields in the project
				}

				var methods = type.GetMethods();
				foreach (var method in methods) {
					Console.WriteLine("\tMethod: Name:{0} Type: " + method.Name);      // prints out all the class methods in the project
				}
			}
		}

		private static void Example2() {
			// Example 2 - executing using reflection
			var sample = new ReflectionSample { Name = "John", Age = 25 };

			// need to get a type
			var sampleType = typeof(ReflectionSample);    // first way off accomplishing getting type; compile time way of doing it
														  //var sampleType2 = sample.GetType(); // second way; runtime 

			var nameProperty = sampleType.GetProperty("Name");  // retrieves the name property within the Sample class
			Console.WriteLine("Property " + nameProperty.GetValue(sample));       // pass sample as the object we want the property from
																				  // returns "John"

			// execute method
			var myMethod = sampleType.GetMethod("MyMethod");
			myMethod.Invoke(sample, null);          // use the 'invoke' command 

		}

		private static void Example3() {
			// Example 3 - Using Attributes with Reflection
			// Added the MyClassAttribute and MyMethodAttribute classes below and added them to the ReflectionSample

			var assembly = Assembly.GetExecutingAssembly();

			// get the types associated with the MyClass. Get all the type within the assembly where there are custom
			// attributes assigned to that type, and specifically only the ones marked with the MyClassAttribute
			var types = assembly.GetTypes().Where(t => t.GetCustomAttributes<MyClassAttribute>().Count() > 0);
			foreach (var type in types) {
				Console.WriteLine(type.Name);

				var methods = type.GetMethods().Where(m => m.GetCustomAttributes<MyMethodAttribute>().Count() > 0);
				foreach (var method in methods) {
					Console.WriteLine(method.Name);

				}
			}
		}
	}

	[MyClass]
	public class ReflectionSample
	{
		public string Name { get; set; }
		public int Age;

		[MyMethod]
		public void MyMethod() {
			Console.WriteLine("Hello from MyMehtod");
		}

		public void NoAttributeMethod() {

		}
	}

	[AttributeUsage(AttributeTargets.Class)]
	public class MyClassAttribute : Attribute
	{

	}

	[AttributeUsage(AttributeTargets.Method)]
	public class MyMethodAttribute : Attribute
	{

	}





}
