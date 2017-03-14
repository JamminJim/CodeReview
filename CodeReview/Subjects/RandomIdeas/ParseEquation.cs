using System;
namespace CodeReview
{
	public class ParseEquation
	{

		public static void Run() {
			Console.WriteLine("Running Parse Equation");

			var input = "45+16*3-2*6+1";
			var output = solution(input);
			Console.WriteLine("Output {0}", output);
		}

		/// <summary>
		/// Takes a string and parses the equation
		/// </summary>
		/// <returns>The solution.</returns>
		/// <param name="input">Input.</param>
		private static int solution(string input) {
			return 0;
		}

	}
}
