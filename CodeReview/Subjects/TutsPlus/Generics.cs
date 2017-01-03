using System;
using System.Collections.Generic;

namespace CodeReview.Subjects.TutsPlus
{
	/// <summary>
	/// Youtube URL: https://www.youtube.com/watch?v=Xgs0ZD8wglg
	/// </summary>
	public static class Generics
	{

		public static void Run() {
			Console.WriteLine("Generics running...");

			/// <summary>
			///  Note: Must incldue the 'using System.Collections.Generic;' include
			///  PROS: Removes duplication in code. (See Example Below)
			/// 	   Dont have to touch implementation code to add more types
			/// </summary>

			// Example 1 - illustrates redunant code
			var result1 = new ResultInt { Success = true, Data = 5 };
			var result2 = new ResultString { Success = false, Data = "John" };
			var result3 = new ResultBool { Success = true, Data = false };

			Console.WriteLine("Result1: {0},{1}", result1.Success, result1.Data);
			Console.WriteLine("Result2: {0},{1}", result2.Success, result2.Data);
			Console.WriteLine("Result3: {0},{1}", result3.Success, result3.Data);


			// Example 2 - use generics to solve the problem in example 1
			// "Parameterize" the unique feature in the 3 methods used above
			// Generics allows you to take the 'types' and paramaterize 

			// here we use the generic class defined below and create of Type 'int'
			var result4 = new Result<int> { Success = true, Data = 5 };
			Console.WriteLine("Result4: {0},{1}", result4.Success, result4.Data);

			// Pro: dont have to touch implementation type of result class to create class of new type
			var result5 = new Result<string> { Success = false, Data = "John" };
			Console.WriteLine("Result5: {0},{1}", result5.Success, result5.Data);

			// Example 3 - how to use generics - passing generic classes to methods
			ResultPrinter.Print(result4);
			ResultPrinter.Print(result5);
		}
	}


	/// <summary>
	///  Example 1: Shows when we have a Result class and we have to refactor and modify it to accept multiple data types.
	///  Note - this illustrates that we have to continuously modify the Data type, and shows us that we need to use Generics.
	/// </summary>

	// first we created a class where data is type int
	public class ResultInt
	{
		public bool Success { get; set; }
		public int Data { get; set; }
	}

	// next we needed to add a second class because data may be a string
	public class ResultString
	{
		public bool Success { get; set; }
		public string Data { get; set; }
	}

	// next we needed to add another class when the data is a bool
	public class ResultBool
	{
		public bool Success { get; set; }
		public bool Data { get; set; }
	}

	/// Example 2 - "Parameterize" the unique feature in the 3 methods used above (Data)
	public class Result<T>
	{
		public bool Success { get; set; }
		public T Data { get; set; }
	}

	/// Example 3 - illustrate how to use Generics
	public static class ResultPrinter
	{
		// note, must add the <T> to the method name to help the compiler understand what T is.
		public static void Print<T>(Result<T> result) {
			Console.WriteLine("Result Printer : Print: {0},{1}", result.Success, result.Data);
		}
	}


}
