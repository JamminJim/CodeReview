using System;
namespace CodeReview.Subjects.TutsPlus
{
	/// <summary>
	/// Youtube URL: https://www.youtube.com/watch?v=qmdziLz51w4
	/// </summary>
	public class LambdaExpressions
	{
		delegate void Operation(int num);

		public static void Run() {
			Console.WriteLine("LambdaExpressions running...");
			Example1();
			Example2();
			Example3();
		}

		// anonymous method - inline expressions instead of using the above steps
		private static void Example1() {
			Operation op = delegate (int num) { Console.WriteLine("{0} x 2 = {1}", num, num * 2); };
			op(2);
		}

		// lambda allows us to clean up Example1
		private static void Example2() {

			Operation op = num => { Console.WriteLine("{0} x 2 = {1}", num, num * 2); };
			op(2);
			// add the => after the input parameters
			// drop the delegate name
			// can drop the input parameters (int num) if there is only one param
			// can drop the input type if it can be infered (int num) becomes num =>
		}

		// create the delegation inline instead at the top of the file
		private static void Example3() {
			// Action<>	 is a delegate; does not have a return value
			// Func<> 	has a return value
			// notice that Operation is not used.
			Action<int> op = num => { Console.WriteLine("{0} x 2 = {1}", num, num * 2); };
			op(2);

			// last param is always output type
			Func<int, int> Double = x => { return x * 2; };
			Console.WriteLine(Double(2));
		}

	}
}
