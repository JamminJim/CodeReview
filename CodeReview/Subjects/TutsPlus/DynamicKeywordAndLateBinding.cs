using System;
//using IronPython.Hosting;
using System.Dynamic;

namespace CodeReview.Subjects.TutsPlus
{

	/// <summary>
	/// Youtube Url : https://www.youtube.com/watch?v=PD3sIo_GbRU
	/// </summary>
	public static class DynamicKeywordAndLateBinding
	{
		public static void Run() {
			Console.WriteLine("DynamicKeywordAndLateBinding running...");
			Example3();
		}

		// dynamic statement allows us to "change" the type. It uses type of dyanmic and not string intially.
		private static void Example1() {

			//	dynamic type = "string";
			//	type = 5;
		}


		//import iron python into project to run python code - note we created helper Test.py file for this example
		private static void Example2() {

			// creates a python runtime environment 
			//var pythonRuntime = Python.CreateRuntime();

			// load file 
			//dynamic pythonFile = pythonRuntime.UseFile("Subjects/TutsPlus/Test.py");

			// using dynamic we can call methods within python
			//pythonFile.SayHelloToPython();
		}


		// ExpandoObject - uses the 'dynamic' keyword to create dynamic objectss. Note, using System.Dynamic required
		private static void Example3() {

			// 'dyanmic' keyword allows us to add properties at runtime (ala actionscript 2)
			dynamic test = new ExpandoObject();
			test.Name = "John";
			test.Age = 35;

			Console.WriteLine(test.Name);
			Console.WriteLine(test.Age);

			// note similar to C.NET MVC "View Bag"
		}

	}
}
