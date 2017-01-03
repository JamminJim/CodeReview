using System;
namespace CodeReview
{
	/// <summary>
	/// Youtube URL: https://www.youtube.com/watch?v=qmdziLz51w4
	/// </summary>
	public static class AnonymousMethods
	{
		delegate void Operation(int num);

		public static void Run() {
			Console.WriteLine("AnonymousMethod running...");
			Example1();
			Example2();
		}

		// lots of work to get to this point, declare delegate, write method, instanciate the delegate and execute it
		private static void Example1() {
			Operation op = Double;
			op(2);
		}

		// anonymous method - inline expressions instead of using the above steps
		private static void Example2() {
			Operation op = delegate (int num) {
				Console.WriteLine("{0} x 2 = {1}", num, num * 2);
			};
			op(2);
		}

		/// <summary>
		/// Helper Methods for Examples above
		/// </summary>
		/// <param name="num">Number.</param>

		// Example 1 
		static void Double(int num) {
			Console.WriteLine("{0} x 2 = {1}", num, num * 2);
		}

	}
}
