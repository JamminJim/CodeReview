using System;
namespace CodeReview.Subjects.TutsPlus
{

	// example 1 note, define delegate outside of class
	delegate void MyDelegate();

	// example 4 example
	delegate void Operation(int number);

	/// <summary>
	/// Youtube URL: https://www.youtube.com/watch?v=9K9Aq7die7Q
	/// </summary>
	public static class Delegates
	{
		public static void Run() {
			Console.WriteLine("Delegates running...");

			Example1();
			Example2();
			Example3();
			Example4();
			Example5();
		}


		public static void Example1() {
			// invoking a method normally
			SayHello();

			// using a delegate - delegate will create a class behind the scene with the name of MyDelegate
			MyDelegate del = new MyDelegate(SayHello);      // note SayHello matches the return type and signature, so it can be used
			del.Invoke();   // runs the method say hello
		}

		public static void Example2() {

			// abbrivated version 
			MyDelegate del = SayHello;  // ommiting the new MyDelegate(...) part
			del();  // ommiting the .Invoke() part
		}

		public static void Example3() {
			MyDelegate del = GiveMeMyDelegate();        // return a delegate type
			Test(del);                  // pass instance of the delegate to a method
		}

		// use delegate to expose for plugus, extensibility, ... pass in functionality
		public static void Example4() {
			Double(2);

			Operation op = Double;  // assign double to the delegate
			ExecuteOperation(2, op);

			op = Triple;            // here we can easily assign a new method to our delegate and it changes the programs execution at runtime
			ExecuteOperation(2, op);
		}

		public static void Example5() {
			Operation op = Double;
			op += Triple;           // chaining delegates
									// op-=Triple;			// removes

			ExecuteOperation(2, op);
		}



		/// <summary>
		///  Helper Methods for above Examples
		/// </summary>


		private static void SayHello() {
			Console.WriteLine("Hey There");
		}

		// example 3 - pass and return delegates as parameters and execute them
		private static void Test(MyDelegate del) {
			del();
		}

		// example 3 - return type using delegate
		private static MyDelegate GiveMeMyDelegate() {
			return new MyDelegate(SayHello);
		}

		// example 4 
		static void Double(int num) {
			Console.WriteLine("{0} x 2 = {1}", num, num * 2);
		}

		static void Triple(int num) {
			Console.WriteLine("{0} x 3 = {1}", num, num * 3);
		}

		// example 4 - sample method that takes a delegate - this shows off how delegates can be used to alter the program at runtime
		static void ExecuteOperation(int num, Operation operation) {
			operation(num);
		}


	}
}
